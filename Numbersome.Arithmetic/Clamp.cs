#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt64 Clamp(this UInt64 value, UInt64 min, UInt64 max) => Math.Clamp(value, min, max);

		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt32 Clamp(this UInt32 value, UInt32 min, UInt32 max) => Math.Clamp(value, min, max);

		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt16 Clamp(this UInt16 value, UInt16 min, UInt16 max) => Math.Clamp(value, min, max);

		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int64 Clamp(this Int64 value, Int64 min, Int64 max) => Math.Clamp(value, min, max);

		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 Clamp(this Int32 value, Int32 min, Int32 max) => Math.Clamp(value, min, max);

		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int16 Clamp(this Int16 value, Int16 min, Int16 max) => Math.Clamp(value, min, max);

		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Single Clamp(this Single value, Single min, Single max) => Math.Clamp(value, min, max);

		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Clamp(this Double value, Double min, Double max) => Math.Clamp(value, min, max);

		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Decimal Clamp(this Decimal value, Decimal min, Decimal max) => Math.Clamp(value, min, max);

		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Byte Clamp(this Byte value, Byte min, Byte max) => Math.Clamp(value, min, max);

		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SByte Clamp(this SByte value, SByte min, SByte max) => Math.Clamp(value, min, max);
	}
}
#endif
