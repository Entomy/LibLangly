using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Collectathon.Views;
using Langly;

namespace Collectathon.Arrays {
	public partial class Array<TElement, TSelf> : IReversibleEnumerable<TElement, Array<TElement, TSelf>, Array<TElement, TSelf>.Enumerator> {
		/// <inheritdoc/>
		public sealed override Enumerator GetEnumerator() => new Enumerator(Elements, Length);

		/// <inheritdoc/>
		public ReverseView<TElement, Array<TElement, TSelf>, Enumerator> Reverse => new ReverseView<TElement, Array<TElement, TSelf>, Enumerator>(this);

		/// <summary>
		/// Provides enumeration over <see cref="Array{TElement, TSelf}"/>.
		/// </summary>
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IReversibleEnumerator<TElement>, IEquatable<Enumerator> {
			private readonly Memory<TElement> Elements;

			private readonly nint Length;

			private nint i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="elements">The elements to enumerate over.</param>
			/// <param name="length">The length of the <paramref name="elements"/>.</param>
			/// <remarks>
			/// At first it might seem like <paramref name="length"/> is superfluous, as <see cref="Array"/> has a known length. However, many data structures use an array as an allocated chunk of memory, with the actual array as a portion of this, up to the entire chunk. <paramref name="length"/> is the actual used portion.
			/// </remarks>
			public Enumerator(Memory<TElement> elements, nint length) {
				Elements = elements;
				Length = length;
				i = -1;
			}

			/// <inheritdoc/>
			public TElement Current => Elements.Span[(Int32)i];

			public static Boolean operator !=(Enumerator left, Enumerator right) => !left.Equals(right);

			public static Boolean operator ==(Enumerator left, Enumerator right) => left.Equals(right);

			/// <inheritdoc/>
			public override Boolean Equals(Object obj) {
				switch (obj) {
				case Enumerator enumerator:
					return Equals(enumerator);
				default:
					return false;
				}
			}

			/// <inheritdoc/>
			public Boolean Equals(Enumerator other) => Elements.Equals(other.Elements) && Length.Equals(other.Length);

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override Int32 GetHashCode() => base.GetHashCode();

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Length;

			/// <inheritdoc/>
			public Boolean MovePrevious() => i-- > 0;

			/// <inheritdoc/>
			public void ResetBeginning() => i = -1;

			/// <inheritdoc/>
			public void ResetEnding() => i = Length;
		}
	}
}
