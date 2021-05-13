using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	public static partial class UTF32 {
		/// <summary>
		/// Little-Endian.
		/// </summary>
		public static class LE {
			/// <summary>
			/// The Byte-Order-Mark of this encoding.
			/// </summary>
			[SuppressMessage("Performance", "HAA0501:Explicit new array type allocation", Justification = "This has to allocate.")]
			public static ReadOnlyMemory<Byte> BOM { get; } = new Byte[] { 0xFF, 0xFE, 0x00, 0x00 };
		}
	}
}
