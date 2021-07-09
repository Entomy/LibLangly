using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class StatisticsExtensions {
		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<nint, TEnumerator> values) where TEnumerator : IEnumerator<nint> => values.Sum() / (values?.Count ?? 0);

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<nuint, TEnumerator> values) where TEnumerator : IEnumerator<nuint> => values.Sum() / (values?.Count ?? 0);

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<Byte, TEnumerator> values) where TEnumerator : IEnumerator<Byte> => values.Sum() / (values?.Count ?? 0);

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<SByte, TEnumerator> values) where TEnumerator : IEnumerator<SByte> => values.Sum() / (values?.Count ?? 0);

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<Int16, TEnumerator> values) where TEnumerator : IEnumerator<Int16> => values.Sum() / (values?.Count ?? 0);

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<UInt16, TEnumerator> values) where TEnumerator : IEnumerator<UInt16> => values.Sum() / (values?.Count ?? 0);

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<Int32, TEnumerator> values) where TEnumerator : IEnumerator<Int32> => values.Sum() / (values?.Count ?? 0);

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<UInt32, TEnumerator> values) where TEnumerator : IEnumerator<UInt32> => values.Sum() / (values?.Count ?? 0);

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<Int64, TEnumerator> values) where TEnumerator : IEnumerator<Int64> => values.Sum() / (values?.Count ?? 0);

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<UInt64, TEnumerator> values) where TEnumerator : IEnumerator<UInt64> => values.Sum() / (values?.Count ?? 0);

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<Single, TEnumerator> values) where TEnumerator : IEnumerator<Single> => values.Sum() / (values?.Count ?? 0);

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double ArithmeticMean<TEnumerator>([AllowNull] this ISequence<Double, TEnumerator> values) where TEnumerator : IEnumerator<Double> => values.Sum() / (values?.Count ?? 0);
	}
}
