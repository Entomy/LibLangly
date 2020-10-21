using System;
using System.Diagnostics.CodeAnalysis;
using Defender.Exceptions;

namespace Defender {
	public static partial class Guard {
		/// <summary>
		/// Guards against the argument not having a required flag set.
		/// </summary>
		/// <typeparam name="TEnum">An <see cref="Enum"/> type.</typeparam>
		/// <param name="value">The value to guard.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="flags">The required flags.</param>
		/// <exception cref="ArgumentNotHasFlagsException">Thrown if the guard clause fails.</exception>
		[SuppressMessage("Performance", "RCS1096:Convert 'HasFlag' call to bitwise operation (or vice versa).", Justification = "We don't have a choice. Operators can not be used on generic types, and Microsoft hasn't followed their own advice and didn't implement method-call analogues of the operators.")]
		public static void HasFlag<TEnum>(TEnum value, String name, TEnum flags) where TEnum : struct, Enum {
			if (!value.HasFlag(flags)) {
				throw ArgumentNotHasFlagsException.With(value, name, flags);
			}
		}
	}
}
