using System;
using System.Runtime.CompilerServices;
using Defender.Exceptions;

namespace Defender {
	public static partial class Guard {
		/// <summary>
		/// Guards against the strong pointer being invalid.
		/// </summary>
		/// <param name="pointer">The pointer.</param>
		/// <param name="pointerName">The name of the pointer argument.</param>
		/// <param name="length">The length.</param>
		/// <param name="lengthName">The name of the pointer length.</param>
		/// <exception cref="ArgumentNullException">Thrown when the <paramref name="pointer"/> is null.</exception>
		/// <exception cref="ArgumentLesserThanException">Thrown when the <paramref name="length"/> is less than <c>0</c>.</exception>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe void Pointer(void* pointer, String pointerName, nint length, String lengthName) {
			Guard.NotNull(pointer, pointerName);
			Guard.GreaterThanOrEqual(length, lengthName, 0);
		}

		/// <summary>
		/// Guards against the strong pointer being invalid.
		/// </summary>
		/// <param name="pointer">The pointer.</param>
		/// <param name="pointerName">The name of the pointer argument.</param>
		/// <param name="length">The length.</param>
		/// <param name="lengthName">The name of the pointer length.</param>
		/// <exception cref="ArgumentNullException">Thrown when the <paramref name="pointer"/> is null.</exception>
		/// <exception cref="ArgumentLesserThanException">Thrown when the <paramref name="length"/> is less than <c>0</c>.</exception>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe void Pointer(void* pointer, String pointerName, Int32 length, String lengthName) {
			Guard.NotNull(pointer, pointerName);
			Guard.GreaterThanOrEqual(length, lengthName, 0);
		}
	}
}
