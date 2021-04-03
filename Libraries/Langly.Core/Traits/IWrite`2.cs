using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can be written to.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to write.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IWrite<TElement, out TResult> : IAdd<TElement, TResult> where TResult : IWrite<TElement, TResult> {
		/// <summary>
		/// Can this be written to?
		/// </summary>
		/// <remarks>
		/// This is a state indicator. Of course an <see cref="IWrite{TElement, TResult}"/> can be written to, but that doesn't mean it can always be written to. Rather, this being <see langword="true"/> indicates the type can currently be written to.
		/// </remarks>
		Boolean Writable { get; }

		/// <summary>
		/// Writes a <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Write([AllowNull] TElement element) => Add(element);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Write([AllowNull] params TElement[] elements) => Add(elements);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Write(Memory<TElement> elements) => Add(elements);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Write(ReadOnlyMemory<TElement> elements) => Add(elements);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Write<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => Add(elements);

		/// <summary>
		/// Ensures <paramref name="amount"/> bytes are loaded into this object.
		/// </summary>
		/// <typeparam name="TSource">The type of the data source.</typeparam>
		/// <param name="amount">The amount of <typeparamref name="TElement"/> to have loaded.</param>
		/// <param name="source">The source to load data from.</param>
		/// <returns>If the load occurred successfully, returns a <typeparamref name="TResult"/> containing the original and loaded elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult EnsureLoaded<TSource>(nint amount, [AllowNull] IRead<TElement, TSource> source) where TSource : IRead<TElement, TSource> {
			TResult? result = (TResult)this;
			if (source is not null) {
				for (nint i = 0; i < amount; i++) {
					if ((result = result!.Load(source)) is null) { return default; }
				}
			}
			return result;
		}

		/// <summary>
		/// Loads a byte into this object.
		/// </summary>
		/// <typeparam name="TSource">The type of the data source.</typeparam>
		/// <param name="source">The source to load data from.</param>
		/// <returns>If the load occurred successfully, returns a <typeparamref name="TResult"/> containing the original and loaded elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Load<TSource>([AllowNull] IRead<TElement, TSource> source) where TSource : IRead<TElement, TSource> {
			TResult result = (TResult)this;
			if (source is not null) {
				if (source.Read(out TElement element) is null) {
					return default;
				}
				result = result.Write(element);
			}
			return result;
		}

		/// <summary>
		/// Loads <paramref name="amount"/> bytes into this object.
		/// </summary>
		/// <typeparam name="TSource">The type of the data source.</typeparam>
		/// <param name="amount">The amount of elements to load.</param>
		/// <param name="source">The source to load data from.</param>
		/// <returns>If the load occurred successfully, returns a <typeparamref name="TResult"/> containing the original and loaded elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Load<TSource>(nint amount, [AllowNull] IRead<TElement, TSource> source) where TSource : IRead<TElement, TSource> {
			TResult result = (TResult)this;
			for (nint i = 0; i < amount; i++) {
				result = result.Load(source);
				if (result is null) {
					goto Result;
				}
			}
		Result:
			return result;
		}
	}
}

namespace Langly {
	public static partial class TraitExtensions {
		/// <summary>
		/// Writes the <paramref name="element"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="element">The <typeparamref name="TElement"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> stream, [AllowNull] TElement element) where TResult : IWrite<TElement, TResult> => stream is not null ? stream.Write(element) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> stream, [AllowNull] params TElement[] elements) where TResult : IWrite<TElement, TResult> => stream is not null ? stream.Write(elements) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> stream, Memory<TElement> elements) where TResult : IWrite<TElement, TResult> => stream is not null ? stream.Write(elements) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> stream, ReadOnlyMemory<TElement> elements) where TResult : IWrite<TElement, TResult> => stream is not null ? stream.Write(elements) : (TResult)stream;

		/// <summary>
		/// Ensures <paramref name="amount"/> elements are loaded into this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TSource">The type of the data source.</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="amount">The amount of <typeparamref name="TElement"/> to have loaded.</param>
		/// <param name="source">The source to load data from.</param>
		/// <returns>If the load occurred successfully, returns a <typeparamref name="TResult"/> containing the original and loaded elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult EnsureLoaded<TElement, TResult, TSource>([AllowNull] this IWrite<TElement, TResult> stream, nint amount, [AllowNull] IRead<TElement, TSource> source) where TResult : IWrite<TElement, TResult> where TSource : IRead<TElement, TSource> => stream is not null ? stream.EnsureLoaded(amount, source) : (TResult)stream;

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
