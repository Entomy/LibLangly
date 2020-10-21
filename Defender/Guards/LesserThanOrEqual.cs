using System;
using System.Runtime.CompilerServices;
using Defender.Exceptions;

namespace Defender {
	public static partial class Guard {
		/// <summary>
		/// 	Guard against the argument being greater than <paramref name="upper"/> bound.
		/// 	</summary>
		/// 	<param name="value">The value.</param>
		/// 	<param name="name">The name of the argument.</param>
		/// 	<param name="upper">The upper bound.</param>
		/// 	<exception cref="ArgumentGreaterThanException">Thrown if the guard clause fails because the value was greater than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LesserThanOrEqual(nint value, String name, nint upper) {
			if (value > upper) {
				throw ArgumentGreaterThanException.With(value, name, upper);
			}
		}

		/// <summary>
		/// 	Guard against the argument being greater than <paramref name="upper"/> bound.
		/// 	</summary>
		/// 	<typeparam name="T">The type of the argument; must be <see cref="IComparable{T}"/>.</typeparam>
		/// 	<param name="value">The value.</param>
		/// 	<param name="name">The name of the argument.</param>
		/// 	<param name="upper">The upper bound.</param>
		/// 	<exception cref="ArgumentGreaterThanException">Thrown if the guard clause fails because the value was greater than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void LesserThanOrEqual<T>(T value, String name, T upper) where T : IComparable<T> {
			if (Check.GreaterThan(value, upper)) {
				throw ArgumentGreaterThanException.With(value, name, upper);
			}
		}
	}
}