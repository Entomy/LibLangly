using System;
using System.Runtime.CompilerServices;

namespace Defender {
	public static partial class Check {
		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(nint value, nint lower, nint upper) => (value - lower) * (upper - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(nuint value, nuint lower, nuint upper) => (value - lower) <= (upper - lower);

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Byte value, Byte lower, Byte upper) => (value - (UInt32)lower) <= (upper - (UInt32)lower);

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Byte value, Range range) => (value - (UInt32)range.Start.Value) <= (range.End.Value - (UInt32)range.Start.Value);

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(SByte value, SByte lower, SByte upper) => (value - lower) * (upper - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(SByte value, Range range) => (value - range.Start.Value) * (range.End.Value - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Int16 value, Int16 lower, Int16 upper) => (value - lower) * (upper - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Int16 value, Range range) => (value - range.Start.Value) * (range.End.Value - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(UInt16 value, UInt16 lower, UInt16 upper) => (value - (UInt32)lower) <= (upper - (UInt32)lower);

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(UInt16 value, Range range) => (value - (UInt32)range.Start.Value) <= (range.End.Value - (UInt32)range.Start.Value);

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Int32 value, Int32 lower, Int32 upper) => (value - lower) * (upper - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Int32 value, Range range) => (value - range.Start.Value) * (range.End.Value - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(UInt32 value, UInt32 lower, UInt32 upper) => (value - lower) <= (upper - lower);

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(UInt32 value, Range range) => (value - range.Start.Value) <= (range.End.Value - range.Start.Value);

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Int64 value, Int64 lower, Int64 upper) => (value - lower) * (upper - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Int64 value, Range range) => (value - range.Start.Value) * (range.End.Value - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(UInt64 value, UInt64 lower, UInt64 upper) => (value - lower) <= (upper - lower);

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(UInt64 value, Range range) => value <= Int32.MaxValue && Within(unchecked((Int32)value), range);

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Single value, Single lower, Single upper) => (value - lower) * (upper - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Single value, Range range) => (value - range.Start.Value) * (range.End.Value - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Double value, Double lower, Double upper) => (value - lower) * (upper - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Double value, Range range) => (value - range.Start.Value) * (range.End.Value - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Decimal value, Decimal lower, Decimal upper) => (value - lower) * (upper - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Decimal value, Range range) => (value - range.Start.Value) * (range.End.Value - value) >= 0;

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Char value, Char lower, Char upper) => (value - (UInt32)lower) < (upper - (UInt32)lower);

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the <paramref name="range"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="range">The range.</param>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within(Char value, Range range) => (value - (UInt32)range.Start.Value) < (range.End.Value - (UInt32)range.Start.Value);

		/// <summary>
		/// Checks if the <paramref name="value"/> is within the range, <paramref name="lower"/>..<paramref name="upper"/>, inclusive.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <typeparam name="T">The type being checked.</typeparam>
		/// <returns><see langword="true"/> if the value is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Within<T>(T value, T lower, T upper) where T : IComparable<T> => value.CompareTo(lower) <= 0 && value.CompareTo(upper) <= 0;
	}
}
