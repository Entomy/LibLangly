using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Loads an element into this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TSource">The type of the data source.</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="source">The source to load data from.</param>
		/// <returns>If the load occurred successfully, returns a <typeparamref name="TResult"/> containing the original and loaded elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Load<TElement, TResult, TSource>([AllowNull] this IWrite<TElement, TResult> stream, [AllowNull] IRead<TElement, TSource> source) where TResult : IWrite<TElement, TResult> where TSource : IRead<TElement, TSource> => stream is not null ? stream.Load(source) : (TResult)stream;

		/// <summary>
		/// Loads <paramref name="amount"/> elements into this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TSource">The type of the data source.</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="amount">The amount of elements to load.</param>
		/// <param name="source">The source to load data from.</param>
		/// <returns>If the load occurred successfully, returns a <typeparamref name="TResult"/> containing the original and loaded elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Load<TElement, TResult, TSource>([AllowNull] this IWrite<TElement, TResult> stream, nint amount, [AllowNull] IRead<TElement, TSource> source) where TResult : IWrite<TElement, TResult> where TSource : IRead<TElement, TSource> => stream is not null ? stream.Load(amount, source) : (TResult)stream;
	}
}
