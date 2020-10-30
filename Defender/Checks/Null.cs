using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Defender {
	public static partial class Check {
		/// <summary>
		/// Checks if the <paramref name="value"/> is <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the argument.</typeparam>
		/// <param name="value">The <typeparamref name="T"/> value.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Null<T>([NotNullWhen(false)] T value) => value is null;

		/// <summary>
		/// Checks if the <paramref name="value"/> is <see langword="null"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe Boolean Null([NotNullWhen(false)] void* value) => value is null;
	}
}
