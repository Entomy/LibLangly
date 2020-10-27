using Philosoft;
using System;

namespace Collectathon.Arrays {
	public partial class Array<TIndex, TElement, TSelf> : IEnumerable<Association<TIndex, TElement>, Array<TIndex, TElement, TSelf>.Enumerator> {
		/// <inheritdoc/>
		public sealed override Enumerator GetEnumerator() => new Enumerator(Members, Length);

		public struct Enumerator : IEnumerator<Association<TIndex, TElement>> {
			private readonly Memory<Association<TIndex, TElement>> Members;

			private readonly nint Length;

			private Int32 i;

			public Enumerator(Memory<Association<TIndex, TElement>> members, nint length) {
				Members = members;
				Length = length;
				i = -1;
			}

			/// <inheritdoc/>
			public Association<TIndex, TElement> Current => Members.Span[i];

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Length;

			/// <inheritdoc/>
			public void Reset() => i = -1;
		}
	}
}
