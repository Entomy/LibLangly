using System;
using System.Runtime.CompilerServices;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guard against the argument not being of the type <typeparamref name="TType"/>.
		/// </summary>
		/// <typeparam name="TType">The type the <paramref name="value"/> must be.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void OfType<TType>(Object value, String name) {
			if (!Check.OfType<TType>(value)) {
				throw ArgumentNotTypeException.With<TType>(value, name);
			}
		}
	}
}
