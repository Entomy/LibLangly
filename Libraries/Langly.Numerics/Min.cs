using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public static partial class NumericExtensions {
		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		public static nint Min<TEnumerator>([AllowNull] this ISequence<nint, TEnumerator> values) where TEnumerator : IEnumerator<nint> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			nint i =
#if NET5_0
				nint.MaxValue;
#else
				IntPtr.Size switch {
					64 => unchecked((nint)Int64.MaxValue),
					_ => Int32.MaxValue,
				};
#endif
			if (values is not null) {
				foreach (nint value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static nuint Min<TEnumerator>([AllowNull] this ISequence<nuint, TEnumerator> values) where TEnumerator : IEnumerator<nuint> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			nuint i =
#if NET5_0
				nuint.MaxValue;
#else
				IntPtr.Size switch {
					64 => unchecked((nuint)UInt64.MaxValue),
					_ => UInt32.MaxValue,
				};
#endif
			if (values is not null) {
				foreach (nuint value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Int32 Min<TEnumerator>([AllowNull] this ISequence<SByte, TEnumerator> values) where TEnumerator : IEnumerator<SByte> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			Int32 i = Int32.MaxValue;
			if (values is not null) {
				foreach (SByte value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		public static UInt32 Min<TEnumerator>([AllowNull] this ISequence<Byte, TEnumerator> values) where TEnumerator : IEnumerator<Byte> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			UInt32 i = UInt32.MaxValue;
			if (values is not null) {
				foreach (Byte value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		public static Int32 Min<TEnumerator>([AllowNull] this ISequence<Int16, TEnumerator> values) where TEnumerator : IEnumerator<Int16> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			Int32 i = Int32.MaxValue;
			if (values is not null) {
				foreach (Int16 value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static UInt32 Min<TEnumerator>([AllowNull] this ISequence<UInt16, TEnumerator> values) where TEnumerator : IEnumerator<UInt16> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			UInt32 i = UInt32.MaxValue;
			if (values is not null) {
				foreach (UInt16 value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		public static Int32 Min<TEnumerator>([AllowNull] this ISequence<Int32, TEnumerator> values) where TEnumerator : IEnumerator<Int32> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			Int32 i = Int32.MaxValue;
			if (values is not null) {
				foreach (Int32 value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static UInt32 Min<TEnumerator>([AllowNull] this ISequence<UInt32, TEnumerator> values) where TEnumerator : IEnumerator<UInt32> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			UInt32 i = UInt32.MaxValue;
			if (values is not null) {
				foreach (UInt32 value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		public static Int64 Min<TEnumerator>([AllowNull] this ISequence<Int64, TEnumerator> values) where TEnumerator : IEnumerator<Int64> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			Int64 i = Int64.MaxValue;
			if (values is not null) {
				foreach (Int64 value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static UInt64 Min<TEnumerator>([AllowNull] this ISequence<UInt64, TEnumerator> values) where TEnumerator : IEnumerator<UInt64> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			UInt64 i = UInt64.MaxValue;
			if (values is not null) {
				foreach (UInt64 value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		public static Single Min<TEnumerator>([AllowNull] this ISequence<Single, TEnumerator> values) where TEnumerator : IEnumerator<Single> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			Single i = Single.MaxValue;
			if (values is not null) {
				foreach (Single value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		public static Double Min<TEnumerator>([AllowNull] this ISequence<Double, TEnumerator> values) where TEnumerator : IEnumerator<Double> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			Double i = Double.MaxValue;
			if (values is not null) {
				foreach (Double value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the minimum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the minimum of.</param>
		/// <returns>The minimum of the <paramref name="values"/>.</returns>
		public static Decimal Min<TEnumerator>([AllowNull] this ISequence<Decimal, TEnumerator> values) where TEnumerator : IEnumerator<Decimal> {
			if (values is null || values.Count == 0) {
				return 0;
			}
			Decimal i = Decimal.MaxValue;
			if (values is not null) {
				foreach (Decimal value in values) {
					i = value < i ? value : i;
				}
			}
			return i;
		}
	}
}
