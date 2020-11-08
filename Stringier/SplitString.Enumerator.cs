using System;

namespace Stringier {
	public partial struct SplitString {
		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(this, Count);

		/// <summary>
		/// Enumerator for <see cref="SplitString"/>.
		/// </summary>
		public ref struct Enumerator {
			private readonly Int32 Count;
			private readonly SplitString Source;
			private Int32 Index;

			public Enumerator(SplitString source, Int32 count) {
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
