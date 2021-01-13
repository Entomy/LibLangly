using System;
using System.Runtime.CompilerServices;

namespace Langly {
	internal static partial class Unsafe {
		/// <summary>
		/// Is the <paramref name="codePoint"/> in the Supplimentary Multilingual Plane?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if in the Supplimentary Multilingual Plane; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsSmp(UInt32 codePoint) => Plane(codePoint) == 1;
	}
}
