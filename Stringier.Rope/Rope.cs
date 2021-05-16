using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Langly;

namespace Stringier {
	/// <summary>
	/// Represent a Rope, a type of dynamic text structure.
	/// </summary>
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed partial class Rope :
		IAddMemory<Char>,
		IClear,
		IEquatable<Rope>,
		IIndex<nint, Char>,
		IInsertMemory<nint, Char>,
		IPostpendMemory<Char>,
		IPrependMemory<Char>,
		IRemove<Char>,
		IReplace<Char>,
		ISequence<Char, Rope.Enumerator> {
		/// <summary>
		/// The head node of the list; the first element.
		/// </summary>
		[AllowNull, MaybeNull]
		private Node Head;

		/// <summary>
		/// The tail node of the list; the last element.
		/// </summary>
		[AllowNull, MaybeNull]
		private Node Tail;

		/// <summary>
		/// Initializes a new <see cref="Rope"/>.
		/// </summary>
		public Rope() { }

		/// <summary>
		/// Initializes a new <see cref="Rope"/> with the initial <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The initial element of the rope.</param>
		public Rope(Char element) : this() => Add(element);

		/// <summary>
		/// Initializes a new <see cref="Rope"/> with the initial <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the rope.</param>
		public Rope([DisallowNull] String elements) : this() => this.Add(elements);

		/// <summary>
		/// Initializes a new <see cref="Rope"/> with the initial <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the rope.</param>
		public Rope([DisallowNull] params Char[] elements) : this() => Add(elements);

		/// <summary>
		/// Initializes a new <see cref="Rope"/> with the initial <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the rope.</param>
		public Rope(Memory<Char> elements) : this() => Add(elements);

		/// <summary>
		/// Initializes a new <see cref="Rope"/> with the initial <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the rope.</param>
		public Rope(ReadOnlyMemory<Char> elements) : this() => Add(elements);

		/// <inheritdoc/>
		public nint Count { get; private set; }

		/// <inheritdoc/>
		public Char this[nint index] {
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		/// <summary>
		/// Converts the <paramref name="char"/> to a <see cref="Rope"/>.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> to convert.</param>
		[return: NotNull]
		public static implicit operator Rope(Char @char) => new(@char);

		/// <summary>
		/// Converts the <paramref name="string"/> to a <see cref="Rope"/>.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to convert.</param>
		[return: MaybeNull, NotNullIfNotNull("string")]
		public static implicit operator Rope([AllowNull] String @string) => @string is not null ? new(@string) : null;

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="Rope"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> of <see cref="Char"/> to convert.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static implicit operator Rope([AllowNull] Char[] array) => array is not null ? new(array) : null;

		/// <summary>
		/// Converts the <paramref name="memory"/> to a <see cref="Rope"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> of <see cref="Char"/> to convert.</param>
		[return: NotNull]
		public static implicit operator Rope(Memory<Char> memory) => new(memory);

		/// <summary>
		/// Converts the <paramref name="memory"/> to a <see cref="Rope"/>.
		/// </summary>
		/// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> to convert.</param>
		[return: NotNull]
		public static implicit operator Rope(ReadOnlyMemory<Char> memory) => new(memory);

		/// <summary>
		/// Concats the two texts.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns>A <see cref="Rope"/> representing the concatenation of both texts.</returns>
		[return: NotNull]
		public static Rope operator +([AllowNull] Rope left, Char right) {
			if (left is not null) {
				left.Postpend(right);
				return left;
			} else {
				return new(right);
			}
		}

		/// <summary>
		/// Concats the two texts.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns>A <see cref="Rope"/> representing the concatenation of both texts.</returns>
		[return: MaybeNull, NotNullIfNotNull("left"), NotNullIfNotNull("right")]
		public static Rope operator +([AllowNull] Rope left, [AllowNull] String right) {
			if (left is not null) {
				left.Postpend(right);
				return left;
			} else if (right is not null) {
				return new(right);
			} else {
				return null;
			}
		}

		/// <summary>
		/// Concats the two texts.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns>A <see cref="Rope"/> representing the concatenation of both texts.</returns>
		[return: MaybeNull, NotNullIfNotNull("left"), NotNullIfNotNull("right")]
		public static Rope operator +([AllowNull] Rope left, [AllowNull] Char[] right) {
			if (left is not null) {
				left.Postpend(right);
				return left;
			} else if (right is not null) {
				return new(right);
			} else {
				return null;
			}
		}

		/// <summary>
		/// Concats the two texts.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns>A <see cref="Rope"/> representing the concatenation of both texts.</returns>
		[return: NotNull]
		public static Rope operator +([AllowNull] Rope left, Memory<Char> right) {
			if (left is not null) {
				left.Postpend(right);
				return left;
			} else {
				return new(right);
			}
		}

		/// <summary>
		/// Concats the two texts.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns>A <see cref="Rope"/> representing the concatenation of both texts.</returns>
		[return: NotNull]
		public static Rope operator +([AllowNull] Rope left, ReadOnlyMemory<Char> right) {
			if (left is not null) {
				left.Postpend(right);
				return left;
			} else {
				return new(right);
			}
		}

		/// <summary>
		/// Concats the two texts.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns>A <see cref="Rope"/> representing the concatenation of both texts.</returns>
		[return: NotNull]
		public static Rope operator +(Char left, [AllowNull] Rope right) {
			if (right is not null) {
				right.Prepend(left);
				return right;
			} else {
				return new(left);
			}
		}

		/// <summary>
		/// Concats the two texts.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns>A <see cref="Rope"/> representing the concatenation of both texts.</returns>
		[return: MaybeNull, NotNullIfNotNull("left"), NotNullIfNotNull("right")]
		public static Rope operator +([AllowNull] String left, [AllowNull] Rope right) {
			if (right is not null) {
				right.Prepend(left);
				return right;
			} else if (left is not null) {
				return new(left);
			} else {
				return null;
			}
		}

		/// <summary>
		/// Concats the two texts.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns>A <see cref="Rope"/> representing the concatenation of both texts.</returns>
		[return: MaybeNull, NotNullIfNotNull("left"), NotNullIfNotNull("right")]
		public static Rope operator +([AllowNull] Char[] left, [AllowNull] Rope right) {
			if (right is not null) {
				right.Prepend(left);
				return right;
			} else if (left is not null) {
				return new(left);
			} else {
				return null;
			}
		}

		/// <summary>
		/// Concats the two texts.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns>A <see cref="Rope"/> representing the concatenation of both texts.</returns>
		[return: NotNull]
		public static Rope operator +(Memory<Char> left, [AllowNull] Rope right) {
			if (right is not null) {
				right.Prepend(left);
				return right;
			} else {
				return new(left);
			}
		}

		/// <summary>
		/// Concats the two texts.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns>A <see cref="Rope"/> representing the concatenation of both texts.</returns>
		[return: NotNull]
		public static Rope operator +(ReadOnlyMemory<Char> left, [AllowNull] Rope right) {
			if (right is not null) {
				right.Prepend(left);
				return right;
			} else {
				return new(left);
			}
		}

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Add(Char element) => Postpend(element);

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Add([AllowNull] params Char[] elements) => Postpend(elements);

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Add(Memory<Char> elements) => Postpend(elements);

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Add(ReadOnlyMemory<Char> elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Clear() {
			Node P = null!;
			Node? N = Head;
			while (N is not null) {
				P = N;
				N = N.Next;
				P.Clear();
			}
			Head = null;
			Tail = null;
			Count = 0;
		}

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] Object obj) {
			switch (obj) {
			case Rope other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] Rope other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(this);

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<Char> System.Collections.Generic.IEnumerable<Char>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Insert(nint index, Char element) {
			if (index == 0) {
				Prepend(element);
			} else if (index == Count) {
				Postpend(element);
			} else {
				Node N = Head;
				nint i = 0;
				// Will the element be inserted into the only node in the chain?
				if (ReferenceEquals(Head, Tail)) {
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, element);
					// Replace this node with the chain section
					Head = head;
					Tail = tail;
				} else
				// Will the element be inserted into the head node?
				if (index <= Head.Count) {
					// Get the surrounding nodes
					Node next = N.Next;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, element);
					// Link the chain section into the chain
					tail.Next = next;
					// Replace this node with the chain section
					Head = head;
					next.Previous = tail;
				} else
				// Will the element be inserted into the tail node?
				if (index > Count - Tail.Count) {
					// Set to the tail node
					N = Tail;
					i = Count - Tail.Count;
					// Get the surrounding nodes
					Node prev = N.Previous;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, element);
					// Link the chain section into the chain
					head.Previous = prev;
					// Replace this node with the chain section
					Tail = tail;
					prev.Next = head;
				} else {
					// Seeks to the node the element will be inserted in, and calculate the index offset (i)
					while (N is not null && index > i + N.Count) {
						i += N.Count;
						N = N.Next;
					}
					// Get the surrounding nodes
					Node prev = N.Previous;
					Node next = N.Next;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, element);
					// Link the chain section into the chain
					head.Previous = prev;
					tail.Next = next;
					// Replace this node with the chain section
					prev.Next = head;
					next.Previous = tail;
				}
				// Increment the counter
				Count++;
			}
		}

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Insert(nint index, [AllowNull] params Char[] elements) => Insert(index, elements.AsMemory());

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Insert(nint index, Memory<Char> elements) => Insert(index, (ReadOnlyMemory<Char>)elements);

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Insert(nint index, ReadOnlyMemory<Char> elements) {
			if (index == 0) {
				Prepend(elements);
			} else if (index == Count) {
				Postpend(elements);
			} else {
				Node N = Head;
				nint i = 0;
				// Will the element be inserted into the only node in the chain?
				if (ReferenceEquals(Head, Tail)) {
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, elements);
					// Replace this node with the chain section
					Head = head;
					Tail = tail;
				} else
				// Will the element be inserted into the head node?
				if (index <= Head.Count) {
					// Get the surrounding nodes
					Node next = N.Next;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, elements);
					// Link the chain section into the chain
					tail.Next = next;
					// Replace this node with the chain section
					Head = head;
					next.Previous = tail;
				} else
				// Will the element be inserted into the tail node?
				if (index > Count - Tail.Count) {
					// Set to the tail node
					N = Tail;
					i = Count - Tail.Count;
					// Get the surrounding nodes
					Node prev = N.Previous;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, elements);
					// Link the chain section into the chain
					head.Previous = prev;
					// Replace this node with the chain section
					Tail = tail;
					prev.Next = head;
				} else {
					// Seeks to the node the element will be inserted in, and calculate the index offset (i)
					while (N is not null && index > i + N.Count) {
						i += N.Count;
						N = N.Next;
					}
					// Get the surrounding nodes
					Node prev = N.Previous;
					Node next = N.Next;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, elements);
					// Link the chain section into the chain
					head.Previous = prev;
					tail.Next = next;
					// Replace this node with the chain section
					prev.Next = head;
					next.Previous = tail;
				}
				// Increment the counter
				Count++;
			}
		}

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Postpend(Char element) {
			if (Count > 0) {
				Tail!.Next = Tail!.Postpend(element);
				Tail = Tail.Next;
			} else {
				Head = new CharNode(element, next: null, previous: null);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Postpend([AllowNull] params Char[] elements) => Postpend(elements.AsMemory());

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Postpend(Memory<Char> elements) => Postpend((ReadOnlyMemory<Char>)elements);

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Postpend(ReadOnlyMemory<Char> elements) {
			if (Count > 0) {
				Tail!.Next = Tail!.Postpend(elements);
				Tail = Tail.Next;
			} else {
				Head = new MemoryNode(elements, next: null, previous: null);
				Tail = Head;
			}
			Count += elements.Length;
		}

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Prepend(Char element) {
			if (Count > 0) {
				Head = Head!.Prepend(element);
			} else {
				Head = new CharNode(element, next: null, previous: null);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Prepend([AllowNull] params Char[] elements) => Prepend(elements.AsMemory());

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Prepend(Memory<Char> elements) => Prepend((ReadOnlyMemory<Char>)elements);

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Prepend(ReadOnlyMemory<Char> elements) {
			if (Count > 0) {
				Head = Head!.Prepend(elements);
			} else {
				Head = new MemoryNode(elements, next: null, previous: null);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		public void Remove(Char element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void RemoveFirst(Char element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void RemoveLast(Char element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void Replace(Char search, Char replace) {
			// If the head node is null
			if (Head is null) {
				// The chain is empty and there's nothing to do
				return;
			}
			Node? N = Head;
			Node head = Head;
			Node tail = Tail!;
			Node? prev = null;
			// Iterate through the entire chain, doing any necessary replacements. Unchanged nodes are reused for efficiency.
			while (N is not null) {
				(head, tail) = N.Replace(search, replace);
				// If the head hasn't been relinked yet. This works because prev is only null on the first iteration. After each iteration prev is always the end of the chain.
				if (prev is null) {
					// Relink it
					Head = head;
					// This entire chain is now the chain section that was just created
				} else {
					// Attach the chain section to the new chain
					prev.Next = head;
					head.Previous = prev;
				}
				// Move to the next node
				prev = tail;
				N = N.Next;
			}
			// Finish linking the last node
			Tail = tail;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(this);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => Collection.ToString(this, amount);
	}
}
