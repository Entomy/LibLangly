using System;
using System.Runtime.CompilerServices;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guard against the argument being unequal to the specified value.
		/// </summary>
		/// <param name="value">The value to guard.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="other">The value <paramref name="value"/> must be equal to.</param>
		/// <exception cref="ArgumentNotEqualException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Equal(nint value, String name, nint other) {
			if (value != other) {
				throw ArgumentNotEqualException.With(value, name, other);
			}
		}

		/// <summary>
		/// Guard against the argument being unequal to the specified value.
		/// </summary>
		/// <typeparam name="TValue">The type of the argument.</typeparam>
		/// <typeparam name="TOther">The type of the <paramref name="other"/> value.</typeparam>
		/// <param name="value">The value to guard.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="other">The value <paramref name="value"/> must be equal to.</param>
		/// <exception cref="ArgumentNotEqualException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Equal<TValue, TOther>(TValue value, String name, TOther other) where TValue : IEquatable<TOther> {
			if (!(value?.Equals(other) ?? true)) {
				throw ArgumentNotEqualException.With(value, name, other);
			}
		}

		/// <summary>
		/// Guard against the argument being unequal to the specified value.
		/// </summary>
		/// <param name="value">The value to guard.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="other">The value <paramref name="value"/> must be equal to.</param>
		/// <exception cref="ArgumentNotEqualException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Equal(Object value, String name, Object other) {
			if (!Equals(value, other)) {
				throw ArgumentNotEqualException.With(value, name, other);
			}
		}
	}
}
