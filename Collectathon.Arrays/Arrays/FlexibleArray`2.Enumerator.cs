using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;
using Langly;

namespace Collectathon.Arrays {
	public partial class FlexibleArray<TElement, TSelf> {
		/// <summary>
		/// Provides enumeration over <see cref="FlexibleArray{TElement, TSelf}"/>.
		/// </summary>
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<TElement>, IEquatable<Enumerator> {
			private readonly Memory<TElement> Elements;

			private nint i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="collection">The collection to enumerate over.</param>
			public Enumerator(TSelf collection) {
				Elements = collection.Memory;
				Count = collection.Count;
				i = -1;
			}

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
				Count = length;
				i = -1;
			}

			/// <inheritdoc/>
			[MaybeNull]
			public TElement Current => Elements.Span[(Int32)i];

			/// <inheritdoc/>
			[MaybeNull]
			Object System.Collections.IEnumerator.Current => Current;

			/// <inheritdoc/>
			public nint Count { get; }

			public static Boolean operator !=(Enumerator left, Enumerator right) => !left.Equals(right);

			public static Boolean operator ==(Enumerator left, Enumerator right) => left.Equals(right);

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public void Dispose() { /* No-op */ }

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
			public Boolean Equals(Enumerator other) => Count.Equals(other.Count) && Elements.Equals(other.Elements);

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			[return: NotNull]
			public IEnumerator<TElement> GetEnumerator() => this;

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			[return: NotNull]
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this;

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			[return: NotNull]
			System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => this;

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override Int32 GetHashCode() => base.GetHashCode();

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Count;

			/// <inheritdoc/>
			public void Reset() => i = -1;

			/// <inheritdoc/>
			[return: NotNull]
			public override String ToString() => Collection.ToString(this);

			/// <inheritdoc/>
			[return: NotNull]
			public String ToString(nint amount) => Collection.ToString(this, amount);
		}
	}
}
