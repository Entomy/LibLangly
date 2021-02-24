using System;
using System.Runtime.CompilerServices;
using Langly.Exceptions;

namespace Langly {
	public static partial class Guard {
		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(nint value, String name, nint lower, nint upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(nuint value, String name, nuint lower, nuint upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(Byte value, String name, Byte lower, Byte upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(SByte value, String name, SByte lower, SByte upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(Int16 value, String name, Int16 lower, Int16 upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(UInt16 value, String name, UInt16 lower, UInt16 upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(Int32 value, String name, Int32 lower, Int32 upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(UInt32 value, String name, UInt32 lower, UInt32 upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(Int64 value, String name, Int64 lower, Int64 upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(UInt64 value, String name, UInt64 lower, UInt64 upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(Single value, String name, Single lower, Single upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(Double value, String name, Double lower, Double upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within(Decimal value, String name, Decimal lower, Decimal upper) {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}

		/// <summary>
		/// Guards against the <paramref name="value"/> being outside of the range of <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <typeparam name="T">The type of the argument.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <exception cref="ArgumentNotWithinException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Within<T>(T value, String name, T lower, T upper) where T : IComparable<T> {
			if (!Check.Within(value, lower, upper)) {
				throw ArgumentNotWithinException.With(value, name, lower, upper);
			}
		}
	}
}
