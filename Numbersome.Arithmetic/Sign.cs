using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	/// <summary>
	/// Returns an integer that indicates the sign of a single-precision floating-point number.
	/// </summary>
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns an integer that indicates the sign of a single-precision floating-point number.
		/// </summary>
		/// <param name="value">A signed number.</param>
		/// <returns>A number that indicates the sign of <paramref name="value"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 Sign(this Single value) => Math.Sign(value);

		/// <summary>
		/// Returns an integer that indicates the sign of an 8-bit integer.
		/// </summary>
		/// <param name="value">A signed number.</param>
		/// <returns>A number that indicates the sign of <paramref name="value"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign"/>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 Sign(this SByte value) => Math.Sign(value);

		/// <summary>
		/// Returns an integer that indicates the sign of a 64-bit signed integer.
		/// </summary>
		/// <param name="value">A signed number.</param>
		/// <returns>A number that indicates the sign of <paramref name="value"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 Sign(this Int64 value) => Math.Sign(value);

		/// <summary>
		/// Returns an integer that indicates the sign of a decimal number.
		/// </summary>
		/// <param name="value">A signed decimal number.</param>
		/// <returns>A number that indicates the sign of <paramref name="value"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 Sign(this Decimal value) => Math.Sign(value);

		/// <summary>
		/// Returns an integer that indicates the sign of a 16-bit signed integer.
		/// </summary>
		/// <param name="value">A signed number.</param>
		/// <returns>A number that indicates the sign of <paramref name="value"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 Sign(this Int16 value) => Math.Sign(value);

		/// <summary>
		/// Returns an integer that indicates the sign of a double-precision floating-point number.
		/// </summary>
		/// <param name="value">A signed number.</param>
		/// <returns>A number that indicates the sign of <paramref name="value"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 Sign(this Double value) => Math.Sign(value);

		/// <summary>
		/// Returns an integer that indicates the sign of a 32-bit signed integer.
		/// </summary>
		/// <param name="value">A signed number.</param>
		/// <returns>A number that indicates the sign of <paramref name="value"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 Sign(this Int32 value) => Math.Sign(value);
	}
}
