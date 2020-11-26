using System;
using System.Runtime.CompilerServices;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guards against the argument being an invalid (undeclared) enumeration value.
		/// </summary>
		/// <typeparam name="TEnum">An <see cref="Enum"/> type.</typeparam>
		/// <param name="value">The <typeparamref name="TEnum"/> value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <remarks>If <see cref="FlagsAttribute"/> is present, this guard is uneccessary and will even report false negatives.</remarks>
		/// <exception cref="ArgumentNotValidException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Valid<TEnum>(TEnum value, String name) where TEnum : struct, Enum {
			if (!Check.Valid(value)) { 
				throw ArgumentNotValidException.With(value, name);
			}
		}
	}
}
