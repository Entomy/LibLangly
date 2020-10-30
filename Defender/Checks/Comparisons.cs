using System;
using System.Runtime.CompilerServices;

namespace Defender {
	public static partial class Check {
		/// <summary>
		/// Check if the <paramref name="value"/> is greater than the <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <returns><see langword="true"/> if the value is greater than the lower bound; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean GreaterThan<T>(T value, T lower) where T : IComparable<T> => value.CompareTo(lower) > 0;

		/// <summary>
		/// Check if the <paramref name="value"/> is greater than or equal to the <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to check.</param>
		/// <param name="lower">The lower bound.</param>
		/// <returns><see langword="true"/> if the value is greater than or equal to the lower bound; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean GreaterThanOrEqual<T>(T value, T lower) where T : IComparable<T> => value.CompareTo(lower) >= 0;

		/// <summary>
		/// Check if the <paramref name="value"/> is lesser than the <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to check.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is lesser than the upper bound; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean LesserThan<T>(T value, T upper) where T : IComparable<T> => value.CompareTo(upper) < 0;

		/// <summary>
		/// Check if the <paramref name="value"/> is lesser than or equal to the <paramref name="upper"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to check.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns><see langword="true"/> if the value is lesser than or equal to the upper bound; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean LesserThanOrEqual<T>(T value, T upper) where T : IComparable<T> => value.CompareTo(upper) <= 0;
	}
}
