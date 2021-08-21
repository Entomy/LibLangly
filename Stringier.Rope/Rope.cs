using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Traits;
using System.Traits.Concepts;
using System.Traits.Providers;

namespace Stringier {
	/// <summary>
	/// Represent a Rope, a type of dynamic text structure.
	/// </summary>
	[DebuggerDisplay("{ToString(),nq}")]
	public sealed partial class Rope :
		IAdd<Char>, IAdd<String?>, IAdd<Char[]?>,
		IClear,
		IEquatable<Rope>, IEquatable<Char>,
#if NETCOREAPP3_0_OR_GREATER
		IEquatable<Rune>,
#endif
		IEquatable<String?>,
		IIndex<Index, Char>,
		IInsert<Index, Char>, IInsert<Index, String?>, IInsert<Index, Char[]?>,
		IPostpend<Char>, IPostpend<String?>, IPostpend<Char[]?>,
		IPrepend<Char>, IPrepend<String?>, IPrepend<Char[]?>,
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
		[LinksNewNode]
		public Rope(Char element) : this() => Add(element);

		/// <summary>
		/// Initializes a new <see cref="Rope"/> with the initial <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the rope.</param>
		[LinksNewNode]
		public Rope([DisallowNull] String elements) : this() => Add(elements);

		/// <summary>
		/// Initializes a new <see cref="Rope"/> with the initial <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the rope.</param>
		[LinksNewNode]
		public Rope([DisallowNull] params Char[] elements) : this() => Add(elements);

		/// <summary>
		/// Gets the number of <see cref="Char"/> contained in this collection.
		/// </summary>
		public Int32 Count { get; private set; }

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
		public Char this[Index index] {
			get {
				Int32 idx = index.GetOffset(Count);
				if (0 > idx || idx >= Count) {
					throw new IndexOutOfRangeException();
				}
				Node? N = Head;
				Int32 i = 0;
				// Seeks to the node the element is in, and calculate the index offset (i)
				while (N is not null && idx >= i + N.Count) {
					i += N.Count;
					N = N.Next;
				}
				return N is not null ? N[idx - i] : throw new IndexOutOfRangeException();
			}
			set => throw new NotImplementedException();
		}

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
		[LinksNewNode]
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
		[LinksNewNode]
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
		[LinksNewNode]
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
		[LinksNewNode]
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
		[LinksNewNode]
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
		[LinksNewNode]
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
		[LinksNewNode]
		public void Add(Char element) => Postpend(element);

		/// <inheritdoc/>
		[LinksNewNode]
		public void Add([AllowNull] params Char[] elements) => Postpend(elements);

		/// <inheritdoc/>
		[LinksNewNode]
		public void Add([AllowNull] String element) => Postpend(element);

		/// <inheritdoc/>
		[UnlinksNode]
		public void Clear() {
			Collection.Clear(ref Head, ref Tail);
			Count = 0;
		}

		/// <inheritdoc/>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Rope other:
				return Equals(other);
			case String other:
				return Equals(other);
			case Char[] other:
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
		public Boolean Equals(Object? obj, Case casing) {
			switch (obj) {
			case Rope other:
				return Equals(other, casing);
			case String other:
				return Equals(other, casing);
			case Char[] other:
				return Equals(other, casing);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Rope? other) => Collection.Equals(this, other);

		/// <summary>
		/// Determines whether the specified object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">The object to compare with this object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals(Rope? other, Case casing) => throw new NotImplementedException();

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
		public Boolean Equals(String? other) => Equals(other.AsSpan());

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals(String? other, Case casing) => Equals(other.AsSpan(), casing);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(Char[]? other) => Equals(other.AsSpan());

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals(Char[]? other, Case casing) => Equals(other.AsSpan(), casing);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(ArraySegment<Char> other) => Equals(other.AsSpan());

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public Boolean Equals(ArraySegment<Char> other, Case casing) => Equals(other.AsSpan(), casing);

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
			if (Count != other.Length) { return false; }
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
			if (Count != other.Length) { return false; }
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
		public unsafe Boolean Equals(Char* other, Int32 length) => Equals(new ReadOnlySpan<Char>(other, length));

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">A pointer to the object to compare with the current object.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public unsafe Boolean Equals(Char* other, Int32 length, Case casing) => Equals(new ReadOnlySpan<Char>(other, length), casing);

		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(this);

		/// <inheritdoc/>
		[LinksNewNode]
		public void Insert(Index index, Char element) {
			Int32 idx = index.GetOffset(Count);
			if (idx == 0) {
				Prepend(element);
			} else if (idx == Count) {
				Postpend(element);
			} else if (Head is null || Tail is null) {
				Add(element);
			} else {
				Node? N = Head;
				Int32 i = 0;
				// Will the element be inserted into the only node in the chain?
				if (ReferenceEquals(Head, Tail)) {
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
					// Replace this node with the chain section
					Head = head;
					Tail = tail;
				} else
				// Will the element be inserted into the head node?
				if (idx <= Head.Count) {
					// Get the surrounding nodes
					Node next = N.Next!;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
					// Link the chain section into the chain
					tail.Next = next;
					// Replace this node with the chain section
					Head = head;
					next.Previous = tail;
				} else
				// Will the element be inserted into the tail node?
				if (idx > Count - Tail.Count) {
					// Set to the tail node
					N = Tail;
					i = Count - Tail.Count;
					// Get the surrounding nodes
					Node prev = N.Previous!;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
					// Link the chain section into the chain
					head.Previous = prev;
					// Replace this node with the chain section
					Tail = tail;
					prev.Next = head;
				} else {
					// Seeks to the node the element will be inserted in, and calculate the index offset (i)
					while (N is not null && idx > i + N.Count) {
						i += N.Count;
						N = N.Next;
					}
					// Get the surrounding nodes
					Node prev = N!.Previous!;
					Node next = N.Next!;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
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
		[MaybeLinksNewNode]
		public void Insert(Index index, [AllowNull] params Char[] element) {
			Int32 idx = index.GetOffset(Count);
			if (element is null) {
				return;
			}
			if (idx == 0) {
				Prepend(element);
			} else if (idx == Count) {
				Postpend(element);
			} else if (Head is null || Tail is null) {
				Add(element);
			} else {
				Node? N = Head;
				Int32 i = 0;
				// Will the element be inserted into the only node in the chain?
				if (ReferenceEquals(Head, Tail)) {
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
					// Replace this node with the chain section
					Head = head;
					Tail = tail;
				} else
				// Will the element be inserted into the head node?
				if (idx <= Head.Count) {
					// Get the surrounding nodes
					Node next = N.Next!;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
					// Link the chain section into the chain
					tail.Next = next;
					// Replace this node with the chain section
					Head = head;
					next.Previous = tail;
				} else
				// Will the element be inserted into the tail node?
				if (idx > Count - Tail.Count) {
					// Set to the tail node
					N = Tail;
					i = Count - Tail.Count;
					// Get the surrounding nodes
					Node prev = N.Previous!;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
					// Link the chain section into the chain
					head.Previous = prev;
					// Replace this node with the chain section
					Tail = tail;
					prev.Next = head;
				} else {
					// Seeks to the node the element will be inserted in, and calculate the index offset (i)
					while (N is not null && idx > i + N.Count) {
						i += N.Count;
						N = N.Next;
					}
					// Get the surrounding nodes
					Node prev = N!.Previous!;
					Node next = N.Next!;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
					// Link the chain section into the chain
					head.Previous = prev;
					tail.Next = next;
					// Replace this node with the chain section
					prev.Next = head;
					next.Previous = tail;
				}
				// Increment the counter
				Count += element.Length;
			}
		}

		/// <inheritdoc/>
		[MaybeLinksNewNode]
		public void Insert(Index index, [AllowNull] String element) {
			Int32 idx = index.GetOffset(Count);
			if (element is null) {
				return;
			}
			if (idx == 0) {
				Prepend(element);
			} else if (idx == Count) {
				Postpend(element);
			} else if (Head is null || Tail is null) {
				Add(element);
			} else {
				Node? N = Head;
				Int32 i = 0;
				// Will the element be inserted into the only node in the chain?
				if (ReferenceEquals(Head, Tail)) {
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
					// Replace this node with the chain section
					Head = head;
					Tail = tail;
				} else
				// Will the element be inserted into the head node?
				if (idx <= Head.Count) {
					// Get the surrounding nodes
					Node next = N.Next!;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
					// Link the chain section into the chain
					tail.Next = next;
					// Replace this node with the chain section
					Head = head;
					next.Previous = tail;
				} else
				// Will the element be inserted into the tail node?
				if (idx > Count - Tail.Count) {
					// Set to the tail node
					N = Tail;
					i = Count - Tail.Count;
					// Get the surrounding nodes
					Node prev = N.Previous!;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
					// Link the chain section into the chain
					head.Previous = prev;
					// Replace this node with the chain section
					Tail = tail;
					prev.Next = head;
				} else {
					// Seeks to the node the element will be inserted in, and calculate the index offset (i)
					while (N is not null && idx > i + N.Count) {
						i += N.Count;
						N = N.Next;
					}
					// Get the surrounding nodes
					Node prev = N!.Previous!;
					Node next = N.Next!;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(idx - i, element);
					// Link the chain section into the chain
					head.Previous = prev;
					tail.Next = next;
					// Replace this node with the chain section
					prev.Next = head;
					next.Previous = tail;
				}
				// Increment the counter
				Count += element.Length;
			}
		}

		/// <inheritdoc/>
		[LinksNewNode]
		public void Postpend(Char element) {
			if (Head is not null && Tail is not null) {
				Tail!.Next = Tail!.Postpend(element);
				Tail = Tail.Next;
			} else {
				Head = new CharNode(element, next: null, previous: null);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		[MaybeLinksNewNode]
		public void Postpend([AllowNull] params Char[] element) {
			if (element is null) {
				return;
			}
			if (Head is not null && Tail is not null) {
				Tail!.Next = Tail!.Postpend(element);
				Tail = Tail.Next;
			} else {
				Head = new ArrayNode(element, next: null, previous: null);
				Tail = Head;
			}
			Count += element.Length;
		}

		/// <inheritdoc/>
		[MaybeLinksNewNode]
		public void Postpend([AllowNull] String element) {
			if (element is null) {
				return;
			}
			if (Head is not null && Tail is not null) {
				Tail!.Next = Tail!.Postpend(element);
				Tail = Tail.Next;
			} else {
				Head = new StringNode(element, next: null, previous: null);
				Tail = Head;
			}
			Count += element.Length;
		}

		/// <inheritdoc/>
		[LinksNewNode]
		public void Prepend(Char element) {
			if (Head is not null && Tail is not null) {
				Head = Head!.Prepend(element);
			} else {
				Head = new CharNode(element, next: null, previous: null);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		[MaybeLinksNewNode]
		public void Prepend([AllowNull] params Char[] element) {
			if (element is null) {
				return;
			}
			if (Head is not null && Tail is not null) {
				Head = Head!.Prepend(element);
			} else {
				Head = new ArrayNode(element, next: null, previous: null);
				Tail = Head;
			}
			Count += element.Length;
		}

		/// <inheritdoc/>
		[MaybeLinksNewNode]
		public void Prepend([AllowNull] String element) {
			if (element is null) {
				return;
			}
			if (Head is not null && Tail is not null) {
				Head = Head!.Prepend(element);
			} else {
				Head = new StringNode(element, next: null, previous: null);
				Tail = Head;
			}
			Count += element.Length;
		}

		/// <inheritdoc/>
		[MaybeUnlinksNode]
		public void Remove(Char element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[MaybeUnlinksNode]
		public void RemoveFirst(Char element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[MaybeUnlinksNode]
		public void RemoveLast(Char element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[MaybeLinksNewNode]
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
		public String ToString(Int32 amount) {
			StringBuilder builder = new StringBuilder();
			if (Head is not null) {
				Node? N = Head;
				Int32 i = 0;
				while (N is not null) {
					if (i + N.Count > amount) {
						_ = builder.Append(N?.ToString()?.Substring(0, amount - i) ?? "").Append("...");
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
