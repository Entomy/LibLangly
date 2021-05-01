using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;

namespace Collectathon.Arrays {
	public partial class FlexibleArray<TIndex, TElement, TSelf> {
		/// <summary>
		/// Provides enumeration over <see cref="FlexibleArray{TIndex, TElement, TSelf}"/>.
		/// </summary>
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<(TIndex Index, TElement Element)> {
			private readonly Memory<(TIndex Index, TElement Element)> Memory;

			private nint i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="collection">The collection to enumerate over.</param>
			public Enumerator(TSelf collection) {
				Memory = collection.Memory;
				Count = collection.Count;
				i = -1;
			}

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="memory">The memory to enumerate over.</param>
			/// <param name="length">The length of the <paramref name="memory"/>.</param>
			/// <remarks>
			/// At first it might seem like <paramref name="length"/> is superfluous, as <see cref="Array"/> has a known length. However, many data structures use an array as an allocated chunk of memory, with the actual array as a portion of this, up to the entire chunk. <paramref name="length"/> is the actual used portion.
			/// </remarks>
			public Enumerator(Memory<(TIndex, TElement)> memory, nint length) {
				Memory = memory;
				Count = length;
				i = -1;
			}

			/// <inheritdoc/>
			public (TIndex Index, TElement Element) Current => Memory.Span[(Int32)i];

			/// <inheritdoc/>
			public nint Count { get; }

			public static Boolean operator !=(Enumerator left, Enumerator right) => !left.Equals(right);

			public static Boolean operator ==(Enumerator left, Enumerator right) => left.Equals(right);

			/// <inheritdoc/>
			public override Boolean Equals([AllowNull] Object obj) {
				switch (obj) {
				case Enumerator enumerator:
					return Equals(enumerator);
				default:
					return false;
				}
			}

			/// <inheritdoc/>
			public Boolean Equals(Enumerator other) => Count.Equals(other.Count) && Memory.Equals(other.Memory);

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override Int32 GetHashCode() => base.GetHashCode();

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Count;

			/// <inheritdoc/>
			public void Reset() => i = -1;

			/// <inheritdoc/>
			[return: NotNull]
			public String ToString(nint amount) => throw new NotImplementedException();
		}
	}
}
