using System;
using System.Runtime.CompilerServices;
using FastEnumUtility;

namespace Defender {
	public static partial class Check {
		/// <summary>
		/// Checks if the <paramref name="value"/> is a valid (declared) enumeration value.
		/// </summary>
		/// <typeparam name="T">An <see cref="Enum"/> type.</typeparam>
		/// <param name="value">The <typeparamref name="T"/> value.</param>
		/// <returns><see langword="true"/> if a valid value; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Valid<T>(T value) where T : struct, Enum => FastEnum.IsDefined(value);
	}
}
