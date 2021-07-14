using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class StatisticsExtensions {
		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<nint, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<nint>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<nuint, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<nuint>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Byte, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<Byte>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<SByte, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<SByte>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Int16, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<Int16>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<UInt16, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<UInt16>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Int32, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<Int32>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<UInt32, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<UInt32>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Int64, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<Int64>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<UInt64, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<UInt64>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Single, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<Single>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Double, TEnumerator> values) where TEnumerator : notnull, ICount, ICurrent<Double>, IMoveNext, IReset => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));
	}
}
