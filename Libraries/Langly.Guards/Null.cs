using System;
using System.Runtime.CompilerServices;
using Langly.Exceptions;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guard against the argument not being <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the argument.</typeparam>
		/// <param name="value">The <typeparamref name="T"/> value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotNullException">Thrown if the guard condition fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Null<T>(T value, String name) {
			if (value is not null) {
				throw ArgumentNotNullException.With(value, name);
			}
		}

		/// <summary>
		/// Guard against the argument not being <see langword="null"/>/
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <exception cref="ArgumentNotNullException">Thrown if the guard condition fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe void Null(void* value, String name) {
			if (value is not null) {
				throw ArgumentNotNullException.With(value, name);
			}
		}
	}
}
