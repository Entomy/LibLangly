using System;
using System.Runtime.CompilerServices;

namespace Langly {
	public static partial class Check {
		/// <summary>
		/// Check if the <paramref name="value"/> is equal to the <paramref name="other"/>.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to check.</param>
		/// <param name="other">The other value.</param>
		/// <returns><see langword="true"/> if the value is equal to the other value; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// This exists to help with equality situations where for some reason <see cref="IEquatable{T}"/> isn't defined and <see cref="Object.Equals(Object)"/> or <see cref="Object.Equals(Object, Object)"/> hasn't been overridden, but <see cref="IComparable{T}"/> has been implemented.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Equal<T>(T value, T other) where T : IComparable<T> => value.CompareTo(other) == 0;
	}
}
