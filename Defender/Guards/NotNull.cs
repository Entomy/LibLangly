using System;
using System.Runtime.CompilerServices;
using Defender.Exceptions;

namespace Defender {
	public static partial class Guard {
		/// <summary>
		/// Guard against the argument being <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the argument.</typeparam>
		/// <param name="value">The <typeparamref name="T"/> value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotNullException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotNull<T>(T value, String name) {
			if (value is null) {
				throw Defender.Exceptions.ArgumentNullException.With(value, name);
			}
		}

		/// <summary>
		/// Guard against the argument being <see langword="null"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotNullException">Thrown if the guard clause fails.</exception>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe void NotNull(void* value, String name) {
			if (value is null) {
				throw Defender.Exceptions.ArgumentNullException.With(value, name);
			}
		}
	}
}
