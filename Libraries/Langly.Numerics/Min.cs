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
		public static Double Min<TEnumerator>([AllowNull] this ISequence<nint, TEnumerator> values) where TEnumerator : IEnumerator<nint> {
			if (values is null || values.Count == 0) {
				return Double.NaN;
			}
			Double i = Double.MaxValue;
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
		public static Double Min<TEnumerator>([AllowNull] this ISequence<nuint, TEnumerator> values) where TEnumerator : IEnumerator<nuint> {
			if (values is null || values.Count == 0) {
				return Double.NaN;
			}
			Double i = Double.MaxValue;
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
		public static Single Min<TEnumerator>([AllowNull] this ISequence<SByte, TEnumerator> values) where TEnumerator : IEnumerator<SByte> {
			if (values is null || values.Count == 0) {
				return Single.NaN;
			}
			Single i = Single.MaxValue;
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
		public static Single Min<TEnumerator>([AllowNull] this ISequence<Byte, TEnumerator> values) where TEnumerator : IEnumerator<Byte> {
			if (values is null || values.Count == 0) {
				return Single.NaN;
			}
			Single i = Single.MaxValue;
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
		public static Single Min<TEnumerator>([AllowNull] this ISequence<Int16, TEnumerator> values) where TEnumerator : IEnumerator<Int16> {
			if (values is null || values.Count == 0) {
				return Single.NaN;
			}
			Single i = Single.MaxValue;
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
		public static Single Min<TEnumerator>([AllowNull] this ISequence<UInt16, TEnumerator> values) where TEnumerator : IEnumerator<UInt16> {
			if (values is null || values.Count == 0) {
				return Single.NaN;
			}
			Single i = Single.MaxValue;
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
		public static Double Min<TEnumerator>([AllowNull] this ISequence<Int32, TEnumerator> values) where TEnumerator : IEnumerator<Int32> {
			if (values is null || values.Count == 0) {
				return Double.NaN;
			}
			Double i = Double.MaxValue;
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
		public static Double Min<TEnumerator>([AllowNull] this ISequence<UInt32, TEnumerator> values) where TEnumerator : IEnumerator<UInt32> {
			if (values is null || values.Count == 0) {
				return Double.NaN;
			}
			Double i = Double.MaxValue;
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
		public static Double Min<TEnumerator>([AllowNull] this ISequence<Int64, TEnumerator> values) where TEnumerator : IEnumerator<Int64> {
			if (values is null || values.Count == 0) {
				return Double.NaN;
			}
			Double i = Double.MaxValue;
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
		public static Double Min<TEnumerator>([AllowNull] this ISequence<UInt64, TEnumerator> values) where TEnumerator : IEnumerator<UInt64> {
			if (values is null || values.Count == 0) {
				return Double.NaN;
			}
			Double i = Double.MaxValue;
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
				return Single.NaN;
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
				return Double.NaN;
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
			Guard.NotNull(values, nameof(values));
			Guard.NotEmpty(values, nameof(values));
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
