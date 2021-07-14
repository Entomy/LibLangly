using System;
using System.Runtime.InteropServices;
using System.Traits.Concepts;

namespace Numbersome {
	public sealed partial class Counter<TElement> {
		/// <summary>
		/// Provides enumeration over a <see cref="Counter{TElement}"/>.
		/// </summary>
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<(TElement? Element, Int32 Count)> {
			private readonly ReadOnlyMemory<TElement?> Elements;

			private readonly ReadOnlyMemory<Int32> Counts;

			private Int32 i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="elements">The elements to enumerate over.</param>
			/// <param name="counts">The counts to enumerate over.</param>
			/// <param name="count">The total amount of allocated indicies in <paramref name="elements"/> and <paramref name="counts"/>.</param>
			public Enumerator(ReadOnlyMemory<TElement?> elements, ReadOnlyMemory<Int32> counts, Int32 count) {
				Elements = elements;
				Counts = counts;
				Count = count;
				i = -1;
			}

			/// <inheritdoc/>
			public (TElement? Element, Int32 Count) Current => (Elements.Span[i], Counts.Span[i]);

			/// <inheritdoc/>
			public Int32 Count { get; private set; }

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Count;

			/// <inheritdoc/>
			public void Reset() => i = -1;
		}
	}
}
