using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
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
