using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public static partial class UTF16 {
		/// <summary>
		/// Big-Endian.
		/// </summary>
		[SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Nesting actually creates the proper structure, especially as endian variants unnested lose all context.")]
		public static class BE {
			/// <summary>
			/// The Byte-Order-Mark of this encoding.
			/// </summary>
			[SuppressMessage("Performance", "HAA0501:Explicit new array type allocation", Justification = "This has to allocate.")]
			public static ReadOnlyMemory<Byte> BOM { get; } = new Byte[] { 0xFE, 0xFF };
		}
	}
}
