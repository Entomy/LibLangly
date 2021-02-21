using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type of mean to calculate.
	/// </summary>
	public enum Mean {
		/// <summary>
		/// The sum of the members divided by the number of members.
		/// </summary>
		Arithmetic = 0,

		/// <summary>
		/// The square root of the product of the members
		/// </summary>
		Geometric = 1,
	}

	public static partial class NumericExtensions {
		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<nint, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<nint> => mean switch {
			Langly.Mean.Arithmetic => values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<nuint, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<nuint> => mean switch {
			Langly.Mean.Arithmetic => values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<Byte, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<Byte> => mean switch {
			Langly.Mean.Arithmetic => (Double)values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0f / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<SByte, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<SByte> => mean switch {
			Langly.Mean.Arithmetic => (Double)values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0f / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<Int16, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<Int16> => mean switch {
			Langly.Mean.Arithmetic => (Double)values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0f / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<UInt16, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<UInt16> => mean switch {
			Langly.Mean.Arithmetic => (Double)values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0f / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<Int32, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<Int32> => mean switch {
			Langly.Mean.Arithmetic => values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<UInt32, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<UInt32> => mean switch {
			Langly.Mean.Arithmetic => values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<Int64, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<Int64> => mean switch {
			Langly.Mean.Arithmetic => values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<UInt64, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<UInt64> => mean switch {
			Langly.Mean.Arithmetic => values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<Single, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<Single> => mean switch {
			Langly.Mean.Arithmetic => (Double)values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0f / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double Mean<TEnumerator>([AllowNull] this ISequence<Double, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<Double> => mean switch {
			Langly.Mean.Arithmetic => values.Sum() / (values?.Count ?? 0),
			Langly.Mean.Geometric => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0)),
			_ => throw Guard.Default(mean, nameof(mean)),
		};

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <param name="mean">The type of mean to calculate.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Decimal Mean<TEnumerator>([AllowNull] this ISequence<Decimal, TEnumerator> values, Mean mean) where TEnumerator : IEnumerator<Decimal> {
			Guard.NotNull(values, nameof(values));
			Guard.NotEmpty(values, nameof(values));
			return mean switch {
				Langly.Mean.Arithmetic => values.Sum() / (values?.Count ?? 0),
				Langly.Mean.Geometric => throw new NotImplementedException("Microsoft doesn't think there's a valid reason to exponentiate decimals despite this exact function being used to calculate numerous financial indicies, and other financial applications. Someone has to implement a replacement Pow() function"),
				_ => throw Guard.Default(mean, nameof(mean)),
			};
		}
	}
}
