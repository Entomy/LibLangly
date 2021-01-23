using System;
using System.Runtime.CompilerServices;
using Langly.Exceptions;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// 	Guard against the argument being lesser than or equal to <paramref name="lower"/> bound.
		/// </summary>
		/// 	<param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// 	<param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentEqualException">Thrown if the guard clause fails because the value was equal to the bound.</exception>
		/// 	<exception cref="ArgumentLesserThanException">Thrown if the guard clause fails because the value was lesser than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GreaterThan(nint value, String name, nint lower) {
			if (value <= lower) {
				if (value == lower) {
					throw ArgumentEqualException.With(value, name, lower);
				} else {
					throw ArgumentLesserThanException.With(value, name, lower);
				}
			}
		}

		/// <summary>
		/// 	Guard against the argument being lesser than or equal to <paramref name="lower"/> bound.
		/// </summary>
		/// <typeparam name="T">The type of the argument; must be <see cref="IComparable{T}"/>.</typeparam>
		/// 	<param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// 	<param name="lower">The lower bound.</param>
		/// 	<exception cref="ArgumentEqualException">Thrown if the guard clause fails because the value was equal to the bound.</exception>
		/// 	<exception cref="ArgumentLesserThanException">Thrown if the guard clause fails because the value was lesser than the bound.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GreaterThan<T>(T value, String name, T lower) where T : IComparable<T> {
			if (value.CompareTo(lower) <= 0) {
				if (value.CompareTo(lower) == 0) {
					throw ArgumentEqualException.With(value, name, lower);
				} else {
					throw ArgumentLesserThanException.With(value, name, lower);
				}
			}
		}
	}
}
