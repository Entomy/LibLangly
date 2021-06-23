using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the remainder resulting from the division of a specified number by another specified number.
		/// </summary>
		/// <param name="x">A dividend.</param>
		/// <param name="y">A divisor.</param>
		/// <returns>
		/// <para>A number equal to <paramref name="x"/> - (<paramref name="y"/> Q), where Q is the equotient of <paramref name="x"/> / <paramref name="y"/> rounded to the nearest integer (if <paramref name="x"/> / <paramref name="y"/> falls halfway between two integers, the even integer is returned).</para>
		/// <para>If <paramref name="x"/> - (<paramref name="y"/> Q) is zero, the value +0 is returned if <paramref name="x"/> is positive, or -0 if <paramref name="x"/> is negative.</para>
		/// <para>IF <paramref name="y"/> = 0, <see cref="Double.NaN"/> is returned.</para>
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.ieeeremainder"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double IEEERemainder(this Double x, Double y) => Math.IEEERemainder(x, y);
	}
}
