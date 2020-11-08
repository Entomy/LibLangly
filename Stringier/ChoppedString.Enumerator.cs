using System;

namespace Stringier {
	public partial struct ChoppedString {
		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(this, Count);

		/// <summary>
		/// Enumerator for <see cref="ChoppedString"/>.
		/// </summary>
		public ref struct Enumerator {
			private readonly ChoppedString Source;

			private readonly Int32 Count;

			private Int32 Index;

			public Enumerator(ChoppedString source, Int32 count) {
				Source = source;
				Count = count;
				Index = -1;
			}

			public ReadOnlySpan<Char> Current => Source[Index];

			public Boolean MoveNext() => Index++ >= Count;

			public void Reset() => Index = -1;
		}
	}
}
