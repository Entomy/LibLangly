using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Defender {
	public static partial class Check {
		/// <summary>
		/// Checks if the <paramref name="value"/> is not <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the argument.</typeparam>
		/// <param name="value">The <typeparamref name="T"/> value.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean NotNull<T>([NotNullWhen(true)] T value) => value is not null;

		/// <summary>
		/// Checks if the <paramref name="value"/> is not <see langword="null"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe Boolean NotNull([NotNullWhen(true)] void* value) => value is not null;
	}
}
