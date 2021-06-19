using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Traits;

namespace Stringier {
	/// <summary>
	/// Represent a Rope, a type of dynamic text structure.
	/// </summary>
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed partial class Rope :
		IAddMemory<Char>, IAdd<String>,
		IClear,
		IEquatable<Rope>, IEquatable<Char>,
#if NETCOREAPP3_0_OR_GREATER
		IEquatable<Rune>,
#endif
		IEquatable<String>, IEquatable<Char[]>, IEquatable<Memory<Char>>, IEquatable<ReadOnlyMemory<Char>>,
		IIndex<nint, Char>,
		IInsertMemory<nint, Char>, IInsert<nint, String>,
		IPostpendMemory<Char>, IPostpend<String>,
		IPrependMemory<Char>, IPrepend<String>,
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
		public Rope([DisallowNull] String elements) : this() => Add(elements);

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

		/// <summary>
		/// Gets the number of <see cref="Char"/> contained in this collection.
		/// </summary>
		public nint Count { get; private set; }

#if NETCOREAPP3_0_OR_GREATER
		/// <summary>
		/// Gets the number of <see cref="Rune"/> contained in this collection.
		/// </summary>
		public nint RuneCount => throw new NotImplementedException();
#endif

		/// <summary>
		/// Gets or sets the <see cref="Char"/> at the specified <paramref name="index"/>.
		/// </summary>
		/// <param name="index">The index of the <see cref="Char"/> to get.</param>
		/// <returns>The <see cref="Char"/> at the specified <paramref name="index"/>.</returns>
		public Char this[nint index] {
			get {
				if (0 > index || index >= Count) {
					throw new IndexOutOfRangeException();
				}
				Node? N = Head;
				nint i = 0;
				// Seeks to the node the element is in, and calculate the index offset (i)
				while (N is not null && index >= i + N.Count) {
					i += N.Count;
					N = N.Next;
				}
				return N is not null ? N[index - i] : throw new IndexOutOfRangeException();
			}
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
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] Rope left, [AllowNull] Rope right) => !left?.Equals(right) ?? (right is not null && right.Count > 0);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] Rope left, [AllowNull] String right) => !(left?.Equals(right) ?? String.IsNullOrEmpty(right));

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] String left, [AllowNull] Rope right) => !(right?.Equals(left) ?? String.IsNullOrEmpty(left));

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] Rope left, [AllowNull] Char[] right) => !left?.Equals(right) ?? (right is not null && right.Length > 0);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] Char[] left, [AllowNull] Rope right) => !right?.Equals(left) ?? (left is not null && left.Length > 0);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] Rope left, Memory<Char> right) => !(left?.Equals(right) ?? right.IsEmpty);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=(Memory<Char> left, [AllowNull] Rope right) => !(right?.Equals(left) ?? left.IsEmpty);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] Rope left, ReadOnlyMemory<Char> right) => !(left?.Equals(right) ?? right.IsEmpty);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=(ReadOnlyMemory<Char> left, [AllowNull] Rope right) => !(right?.Equals(left) ?? left.IsEmpty);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] Rope left, Span<Char> right) => !(left?.Equals(right) ?? right.IsEmpty);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=(Span<Char> left, [AllowNull] Rope right) => !(right?.Equals(left) ?? left.IsEmpty);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] Rope left, ReadOnlySpan<Char> right) => !(left?.Equals(right) ?? right.IsEmpty);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are not equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is not equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=(ReadOnlySpan<Char> left, [AllowNull] Rope right) => !(right?.Equals(left) ?? left.IsEmpty);

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

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] Rope left, [AllowNull] Rope right) => left?.Equals(right) ?? (right is null || right.Count <= 0);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] Rope left, [AllowNull] String right) => left?.Equals(right) ?? String.IsNullOrEmpty(right);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] String left, [AllowNull] Rope right) => right?.Equals(left) ?? String.IsNullOrEmpty(left);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] Rope left, [AllowNull] Char[] right) => left?.Equals(right) ?? (right is null || right.Length <= 0);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] Char[] left, [AllowNull] Rope right) => right?.Equals(left) ?? (left is null || left.Length <= 0);

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] Rope left, Memory<Char> right) => left?.Equals(right) ?? right.IsEmpty;

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==(Memory<Char> left, [AllowNull] Rope right) => right?.Equals(left) ?? left.IsEmpty;

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] Rope left, ReadOnlyMemory<Char> right) => left?.Equals(right) ?? right.IsEmpty;

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==(ReadOnlyMemory<Char> left, [AllowNull] Rope right) => right?.Equals(left) ?? left.IsEmpty;

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] Rope left, Span<Char> right) => left?.Equals(right) ?? right.IsEmpty;

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==(Span<Char> left, [AllowNull] Rope right) => right?.Equals(left) ?? left.IsEmpty;

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] Rope left, ReadOnlySpan<Char> right) => left?.Equals(right) ?? right.IsEmpty;

		/// <summary>
		/// Determines whether the <paramref name="left"/> and <paramref name="right"/> texts are equal.
		/// </summary>
		/// <param name="left">The lefthand text.</param>
		/// <param name="right">The righthand text.</param>
		/// <returns><see langword="true"/> if the <paramref name="left"/> text is equal to the <paramref name="right"/> text; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==(ReadOnlySpan<Char> left, [AllowNull] Rope right) => right?.Equals(left) ?? left.IsEmpty;

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
		public void Add([AllowNull] String element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void Clear() {
			Collection.Clear(Head);
			Head = null;
			Tail = null;
			Count = 0;
		}

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] Object obj) {
			switch (obj) {
			case Rope other:
				return Equals(other);
			case String other:
				return Equals(other);
			case Char[] other:
				return Equals(other);
			case Memory<Char> other:
				return Equals(other);
			case ReadOnlyMemory<Char> other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals([AllowNull] Object obj, Case casing) {
			switch (obj) {
			case Rope other:
				return Equals(other, casing);
			case String other:
				return Equals(other, casing);
			case Char[] other:
				return Equals(other, casing);
			case Memory<Char> other:
				return Equals(other, casing);
			case ReadOnlyMemory<Char> other:
				return Equals(other, casing);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] Rope other) => Collection.Equals(this, other);

		/// <summary>
		/// Determines whether the specified object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">The object to compare with this object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals([AllowNull] Rope other, Case casing) => throw new NotImplementedException();

		/// <inheritdoc/>
		public Boolean Equals(Char other) => throw new NotImplementedException();

		/// <summary>
		/// Determines whether the specified object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">The object to compare with this object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals(Char other, Case casing) => throw new NotImplementedException();

#if NETCOREAPP3_0_OR_GREATER
		/// <inheritdoc/>
		public Boolean Equals(Rune other) => throw new NotImplementedException();

		/// <summary>
		/// Determines whether the specified object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">The object to compare with this object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals(Rune other, Case casing) => throw new NotImplementedException();
#endif

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals([AllowNull] String other) => Equals(other.AsSpan());

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals([AllowNull] String other, Case casing) => Equals(other.AsSpan(), casing);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals([AllowNull] Char[] other) => Equals(other.AsSpan());

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals([AllowNull] Char[] other, Case casing) => Equals(other.AsSpan(), casing);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(Memory<Char> other) => Equals(other.Span);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals(Memory<Char> other, Case casing) => Equals(other.Span, casing);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(ReadOnlyMemory<Char> other) => Equals(other.Span);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals(ReadOnlyMemory<Char> other, Case casing) => Equals(other.Span, casing);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(Span<Char> other) => Equals((ReadOnlySpan<Char>)other);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals(Span<Char> other, Case casing) => Equals((ReadOnlySpan<Char>)other, casing);


		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(ReadOnlySpan<Char> other) {
			if (Count != other.Length) return false;
			Int32 i = 0;
			foreach (Char item in this) {
				if (!item.Equals(other[i++])) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a valid <see cref="Case"/> value.</exception>
		public Boolean Equals(ReadOnlySpan<Char> other, Case casing) {
			if (Count != other.Length) return false;
			Int32 i = 0;
			switch (casing) {
			case Case.Insensitive:
				foreach (Char item in this) {
					if (!Char.ToUpper(item).Equals(Char.ToUpper(other[i++]))) {
						return false;
					}
				}
				break;
			case Case.Sensitive:
				foreach (Char item in this) {
					if (!item.Equals(other[i++])) {
						return false;
					}
				}
				break;
			default:
				throw new ArgumentException("Casing is not a valid Case value.", nameof(casing));
			}
			return true;
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">A pointer to the object to compare with the current object.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public unsafe Boolean Equals([AllowNull] Char* other, Int32 length) => Equals(new ReadOnlySpan<Char>(other, length));

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">A pointer to the object to compare with the current object.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public unsafe Boolean Equals([AllowNull] Char* other, Int32 length, Case casing) => Equals(new ReadOnlySpan<Char>(other, length), casing);

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
		public void Insert(nint index, [AllowNull] String element) => throw new NotImplementedException();

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
		public void Postpend([AllowNull] String element) => throw new NotImplementedException();

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
		public void Prepend([AllowNull] String element) => throw new NotImplementedException();

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
		public override String ToString() {
			StringBuilder builder = new StringBuilder();
			if (Head is not null) {
				Node? N = Head;
				nint i = 0;
				while (N is not null) {
					_ = builder.Append(N);
					N = N.Next;
				}
			}
			return $"{builder}";
		}

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) {
			StringBuilder builder = new StringBuilder();
			if (Head is not null) {
				Node? N = Head;
				nint i = 0;
				while (N is not null) {
					if (i + N.Count > amount) {
						_ = builder.Append(N.ToString().Substring(0, (Int32)(amount - i))).Append("...");
						break;
					} else {
						_ = builder.Append(N);
					}
					i += N.Count;
					N = N.Next;
				}
			}
			return $"{builder}";
		}
	}
}
