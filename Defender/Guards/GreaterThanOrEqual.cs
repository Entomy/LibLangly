using System;
using System.Runtime.CompilerServices;
using Defender.Exceptions;

namespace Defender {
	public static partial class Guard {
		/// <summary>
		/// 	Guard against the argument being lesser than <paramref name="lower"/> bound.
		/// 	</summary>
		/// 	<param name="value">The value.</param>
		/// 	<param name="name">The name of the argument.</param>
		/// 	<param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentLesserThanException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GreaterThanOrEqual(nint value, String name, nint lower) {
			if (value < lower) {
				throw ArgumentLesserThanException.With(value, name, lower);
			}
		}

		/// <summary>
		/// 	Guard against the argument being lesser than <paramref name="lower"/> bound.
		/// 	</summary>
		/// 	<typeparam name="T">The type of the argument; must be <see cref="IComparable{T}"/>.</typeparam>
		/// 	<param name="value">The value.</param>
		/// 	<param name="name">The name of the argument.</param>
		/// 	<param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentLesserThanException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GreaterThanOrEqual<T>(T value, String name, T lower) where T : IComparable<T> {
			if (Check.LesserThan(value, lower)) {
				throw ArgumentLesserThanException.With(value, name, lower);
			}
		}
	}
}