using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Encodings {
	/// <summary>
	/// Helper functions for working with UTF-32 data.
	/// </summary>
	public static class UTF32 {
		/// <summary>
		/// Big-Endian.
		/// </summary>
		[SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Nesting actually creates the proper structure, especially as endian variants unnested lose all context.")]
		public static class BE {
			/// <summary>
			/// The Byte-Order-Mark of this encoding.
			/// </summary>
			public static IReadOnlyList<Byte> BOM { get; } = new Byte[] { 0x00, 0x00, 0xFE, 0xFF };
		}

		/// <summary>
		/// Little-Endian.
		/// </summary>
		[SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Nesting actually creates the proper structure, especially as endian variants unnested lose all context.")]
		public static class LE {
			/// <summary>
			/// The Byte-Order-Mark of this encoding.
			/// </summary>
			public static IReadOnlyList<Byte> BOM { get; } = new Byte[] { 0xFF, 0xFE, 0x00, 0x00 };
		}
	}
}
