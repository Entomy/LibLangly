using System.Traits;

namespace System.Linq {
	public static partial class TraitExtensions {
		/// <summary>
		/// Applies an accumulator function over a sequence.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="source"/>.</typeparam>
		/// <param name="source">An <see cref="IGetEnumerator{TElement, TEnumerator}"/> to aggregate over.</param>
		/// <param name="func">An accumulator function to be invoked on each element.</param>
		/// <returns>The final accumulator value.</returns>
		public static TSource Aggregate<TSource, TEnumerator>(this IGetEnumerator<TSource, TEnumerator>? source, Func<TSource, TSource, TSource>? func) where TEnumerator : notnull, ICurrent<TSource>, IMoveNext {
			if (source is null) { throw new ArgumentNullException(nameof(source)); }
			if (func is null) { throw new ArgumentNullException(nameof(func)); }
			TEnumerator e = source.GetEnumerator();
			if (!e.MoveNext()) { throw new ArgumentException("The source can not be empty", nameof(source)); }
			TSource result = e.Current;
			while (e.MoveNext()) {
				result = func(result, e.Current);
			}
			return result;
		}

		/// <summary>
		/// Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="source"/>.</typeparam>
		/// <param name="source">An <see cref="IGetEnumerator{TElement, TEnumerator}"/> to aggregate over.</param>
		/// <param name="seed">The initial accumulator value.</param>
		/// <param name="func">An accumulator function to be invoked on each element.</param>
		/// <returns>The final accumulator value.</returns>
		public static TAccumulate Aggregate<TSource, TAccumulate, TEnumerator>(this IGetEnumerator<TSource, TEnumerator>? source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate>? func) where TEnumerator : notnull, ICurrent<TSource>, IMoveNext {
			if (source is null) { throw new ArgumentNullException(nameof(source)); }
			if (func is null) { throw new ArgumentNullException(nameof(source)); }
			TAccumulate result = seed;
			foreach (TSource element in source) {
				result = func(result, element);
			}
			return result;
		}

		/// <summary>
		/// Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value, and the specified function is used to select the result value.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
		/// <typeparam name="TResult">The type of the resulting value.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="source"/>.</typeparam>
		/// <param name="source">An <see cref="IGetEnumerator{TElement, TEnumerator}"/> to aggregate over.</param>
		/// <param name="seed">The initial accumulator value.</param>
		/// <param name="func">An accumulator function to be invoked on each element.</param>
		/// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
		/// <returns>The transformed final accumulator value.</returns>
		public static TResult Aggregate<TSource, TAccumulate, TResult, TEnumerator>(this IGetEnumerator<TSource, TEnumerator>? source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate>? func, Func<TAccumulate, TResult>? resultSelector) where TEnumerator : notnull, ICurrent<TSource>, IMoveNext {
			if (source is null) { throw new ArgumentNullException(nameof(source)); }
			if (func is null) { throw new ArgumentNullException(nameof(func)); }
			if (resultSelector is null) { throw new ArgumentNullException(nameof(resultSelector)); }
			TAccumulate result = seed;
			foreach (TSource element in source) {
				result = func(result, element);
			}
			return resultSelector(result);
		}
	}
}
