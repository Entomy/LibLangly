using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public static partial class NumericExtensions {
		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		public static nint Max<TEnumerator>([AllowNull] this ISequence<nint, TEnumerator> values) where TEnumerator : IEnumerator<nint> {
			nint i = 0;
			if (values is not null) {
				foreach (nint value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static nuint Max<TEnumerator>([AllowNull] this ISequence<nuint, TEnumerator> values) where TEnumerator : IEnumerator<nuint> {
			nuint i = 0;
			if (values is not null) {
				foreach (nuint value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Int32 Max<TEnumerator>([AllowNull] this ISequence<SByte, TEnumerator> values) where TEnumerator : IEnumerator<SByte> {
			Int32 i = 0;
			if (values is not null) {
				foreach (SByte value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		public static UInt32 Max<TEnumerator>([AllowNull] this ISequence<Byte, TEnumerator> values) where TEnumerator : IEnumerator<Byte> {
			UInt32 i = 0;
			if (values is not null) {
				foreach (Byte value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		public static Int32 Max<TEnumerator>([AllowNull] this ISequence<Int16, TEnumerator> values) where TEnumerator : IEnumerator<Int16> {
			Int32 i = 0;
			if (values is not null) {
				foreach (Int16 value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static UInt32 Max<TEnumerator>([AllowNull] this ISequence<UInt16, TEnumerator> values) where TEnumerator : IEnumerator<UInt16> {
			UInt32 i = 0;
			if (values is not null) {
				foreach (UInt16 value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		public static Int32 Max<TEnumerator>([AllowNull] this ISequence<Int32, TEnumerator> values) where TEnumerator : IEnumerator<Int32> {
			Int32 i = 0;
			if (values is not null) {
				foreach (Int32 value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static UInt32 Max<TEnumerator>([AllowNull] this ISequence<UInt32, TEnumerator> values) where TEnumerator : IEnumerator<UInt32> {
			UInt32 i = 0;
			if (values is not null) {
				foreach (UInt32 value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		public static Int64 Max<TEnumerator>([AllowNull] this ISequence<Int64, TEnumerator> values) where TEnumerator : IEnumerator<Int64> {
			Int64 i = 0;
			if (values is not null) {
				foreach (Int64 value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static UInt64 Max<TEnumerator>([AllowNull] this ISequence<UInt64, TEnumerator> values) where TEnumerator : IEnumerator<UInt64> {
			UInt64 i = 0;
			if (values is not null) {
				foreach (UInt64 value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		public static Single Max<TEnumerator>([AllowNull] this ISequence<Single, TEnumerator> values) where TEnumerator : IEnumerator<Single> {
			Single i = 0;
			if (values is not null) {
				foreach (Single value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		public static Double Max<TEnumerator>([AllowNull] this ISequence<Double, TEnumerator> values) where TEnumerator : IEnumerator<Double> {
			Double i = 0;
			if (values is not null) {
				foreach (Double value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}

		/// <summary>
		/// Finds the maximum of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the maximum of.</param>
		/// <returns>The maximum of the <paramref name="values"/>.</returns>
		public static Decimal Max<TEnumerator>([AllowNull] this ISequence<Decimal, TEnumerator> values) where TEnumerator : IEnumerator<Decimal> {
			Decimal i = 0;
			if (values is not null) {
				foreach (Decimal value in values) {
					i = value > i ? value : i;
				}
			}
			return i;
		}
	}
}
