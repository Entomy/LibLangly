using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Langly {
	internal static partial class Check {
		/// <summary>
		/// Checks if the <paramref name="value"/> is of type <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The type the <paramref name="value"/> should be of.</typeparam>
		/// <param name="value">The value to check.</param>
		/// <returns><see langword="true"/> if the value is of the specified type; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean OfType<T>([DisallowNull] System.Object value) => value is not null && value.GetType() == typeof(T);
	}
}
