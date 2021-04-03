using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can have other elements added to it, with additional span operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IAddSpan<TElement, out TResult> : IAdd<TElement, TResult> where TResult : IAddSpan<TElement, TResult> {
		/// <inheritdoc/>
		[return: MaybeNull]
		TResult IAdd<TElement, TResult>.Add(Memory<TElement> elements) => Add(elements.Span);

		/// <inheritdoc/>
		[return: MaybeNull]
		TResult IAdd<TElement, TResult>.Add(ReadOnlyMemory<TElement> elements) => Add(elements.Span);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		TResult Add(Span<TElement> elements) => Add((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		TResult Add(ReadOnlySpan<TElement> elements) {
			TResult? result = (TResult)this;
			foreach (TElement element in elements) {
				if ((result = result!.Add(element)) is null) { return default; }
			}
			return result;
		}
	}
}

namespace Langly {
	public static partial class TraitExtensions {
		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TElement, TResult>([AllowNull] this IAddSpan<TElement, TResult> collection, Span<TElement> elements) where TResult : IAddSpan<TElement, TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TElement, TResult>([AllowNull] this IAddSpan<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IAddSpan<TElement, TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;
	}
}
