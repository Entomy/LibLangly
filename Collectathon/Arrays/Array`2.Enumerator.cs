using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Philosoft;

namespace Collectathon.Arrays {
	public partial class Array<TIndex, TElement, TSelf> : IEnumerable<Association<TIndex, TElement>, Array<TIndex, TElement, TSelf>.Enumerator> {
		/// <inheritdoc/>
		public sealed override Enumerator GetEnumerator() => new Enumerator(Members, Length);

		/// <summary>
		/// Provides enumeration over <see cref="Array{TIndex, TElement, TSelf}"/>.
		/// </summary>
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<Association<TIndex, TElement>>, IEquatable<Enumerator> {
			private Int32 i;

			private readonly nint Length;
			private readonly Memory<Association<TIndex, TElement>> Members;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="members">The members to enumerate over.</param>
			/// <param name="length">The length of the <paramref name="members"/>.</param>
			/// <remarks>
			/// At first it might seem like <paramref name="length"/> is superfluous, as <see cref="Array"/> has a known length. However, many data structures use an array as an allocated chunk of memory, with the actual array as a portion of this, up to the entire chunk. <paramref name="length"/> is the actual used portion.
			/// </remarks>
			public Enumerator(Memory<Association<TIndex, TElement>> members, nint length) {
				Members = members;
				Length = length;
				i = -1;
			}

			/// <inheritdoc/>
			public Association<TIndex, TElement> Current => Members.Span[i];

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
			public Boolean Equals(Enumerator other) => Members.Equals(other.Members) && Length.Equals(other.Length);

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override Int32 GetHashCode() => base.GetHashCode();

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Length;

			/// <inheritdoc/>
			public void Reset() => i = -1;
		}
	}
}
