using System;

namespace Langly.Streams.Bases {
	/// <summary>
	/// Represents the base of a <see cref="Stream"/> whos backing data is stored in memory.
	/// </summary>
	internal sealed class StringStreamBase : MemoryStreamBase {
		/// <inheritdoc/>
		internal StringStreamBase(String @string) : base(System.Text.Encoding.Unicode.GetBytes(@string)) { }

		/// <inheritdoc/>
		public sealed override String ToString() => System.Text.Encoding.Unicode.GetString(Buffer);
	}
}
