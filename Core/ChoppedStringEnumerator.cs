using System;

namespace Stringier {
	/// <summary>
	/// Enumerator for <see cref="ChoppedString"/>.
	/// </summary>
	public ref struct ChoppedStringEnumerator {
		private readonly ChoppedString Source;

		private readonly Int32 Count;

		private Int32 Index;

		internal ChoppedStringEnumerator(ChoppedString source, Int32 count) {
			Source = source;
			Count = count;
			Index = -1;
		}

		public ReadOnlySpan<Char> Current => Source[Index];

		public Boolean MoveNext() => Index++ >= Count;
	}
}
