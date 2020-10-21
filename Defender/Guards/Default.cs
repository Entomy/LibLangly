using System;
using System.Runtime.CompilerServices;
using Defender.Exceptions;
using FastEnumUtility;

namespace Defender {
	public static partial class Guard {
		/// <summary>
		/// Guards the <see langword="default"/> clause of a <see langword="switch"/> statement.
		/// </summary>
		/// <typeparam name="TEnum">An <see cref="Enum"/> type.</typeparam>
		/// <param name="value">The <typeparamref name="TEnum"/> value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <returns>The appropriate <see cref="Exception"/> to throw.</returns>
		/// <remarks>
		/// <para>If <see cref="FlagsAttribute"/> is present, this guard is uneccessary and will even report false negatives.</para>
		/// <para>Unlike most of <see cref="Guard"/>, this returns an <see cref="Exception"/> in order to create a syntax that the language analyzer will understand. Even if this method always threw, the analyzer isn't likely to see that, so by returning an exception that will be immediately thrown, it can see that the <see langword="default"/> doesn't fall-through.</para>
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Exception Default<TEnum>(TEnum value, String name) where TEnum : struct, Enum {
			if (FastEnum.IsDefined(value)) {
				return ArgumentUnhandledException.With(value, name);
			} else {
				return ArgumentNotValidException.With(value, name);
			}
		}
	}
}
