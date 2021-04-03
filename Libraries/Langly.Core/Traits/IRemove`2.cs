using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can have elements removed from it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IRemove<TElement, out TResult> where TResult : IRemove<TElement, TResult> {
		/// <summary>
		/// Removes all instances of the element from this object.
		/// </summary>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: NotNull]
		TResult Remove([AllowNull] TElement element);

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult Remove([AllowNull] params TElement[] elements) => elements is not null ? Remove(elements.AsMemory()) : (TResult)this;

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult Remove(Memory<TElement> elements) => Remove((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult Remove(ReadOnlyMemory<TElement> elements) => Remove(elements.Span);

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult Remove(Span<TElement> elements) => Remove((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult Remove(ReadOnlySpan<TElement> elements) {
			TResult? result = (TResult)this;
			foreach (TElement element in elements) {
				result = result.Remove(element);
			}
			return result;
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult Remove<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			TResult result = (TResult)this;
			if (elements is not null) {
				foreach (TElement element in elements) {
					result = result.Remove(element);
				}
			}
			return result;
		}

		/// <summary>
		/// Removes the first instance of the element from this object.
		/// </summary>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: NotNull]
		TResult RemoveFirst([AllowNull] TElement element);

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveFirst([AllowNull] params TElement[] elements) => elements is not null ? RemoveFirst(elements.AsMemory()) : (TResult)this;

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveFirst(Memory<TElement> elements) => RemoveFirst((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveFirst(ReadOnlyMemory<TElement> elements) => RemoveFirst(elements.Span);

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveFirst(Span<TElement> elements) => RemoveFirst((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveFirst(ReadOnlySpan<TElement> elements) {
			TResult result = (TResult)this;
			foreach (TElement element in elements) {
				result = result.RemoveFirst(element);
			}
			return result;
		}

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveFirst<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			TResult result = (TResult)this;
			if (elements is not null) {
				foreach (TElement element in elements) {
					result = result.RemoveFirst(element);
				}
			}
			return result;
		}

		/// <summary>
		/// Removes the last instance of the element from this object.
		/// </summary>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: NotNull]
		TResult RemoveLast([AllowNull] TElement element);

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveLast([AllowNull] params TElement[] elements) => elements is not null ? RemoveLast(elements.AsMemory()) : (TResult)this;

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveLast(Memory<TElement> elements) => RemoveLast((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveLast(ReadOnlyMemory<TElement> elements) => RemoveLast(elements.Span);

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveLast(Span<TElement> elements) => RemoveLast((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveLast(ReadOnlySpan<TElement> elements) {
			TResult result = (TResult)this;
			foreach (TElement element in elements) {
				result = result.RemoveLast(element);
			}
			return result;
		}

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		TResult RemoveLast<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			TResult result = (TResult)this;
			if (elements is not null) {
				foreach (TElement element in elements) {
					result = result.RemoveLast(element);
				}
			}
			return result;
		}
	}
}

namespace Langly {
	public static partial class TraitExtensions {
		/// <summary>
		/// Removes all instances of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(element) : (TResult)collection;

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection,  [AllowNull] params TElement[] elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(elements) : (TResult)collection;

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, Memory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(elements) : (TResult)collection;

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(elements) : (TResult)collection;

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, Span<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(elements) : (TResult)collection;

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(elements) : (TResult)collection;

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult, TEnumerator>([AllowNull] IRemove<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TResult : IRemove<TElement, TResult> where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.Remove(elements) : (TResult)collection;

		/// <summary>
		/// Removes the first instance of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(element) : (TResult)collection;

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, [AllowNull] params TElement[] elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, Memory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, Span<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult, TEnumerator>([AllowNull] IRemove<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TResult : IRemove<TElement, TResult> where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;

		/// <summary>
		/// Removes the last instance of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(element) : (TResult)collection;

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, [AllowNull] params TElement[] elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, Memory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, Span<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] IRemove<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveLast<TElement, TResult, TEnumerator>([AllowNull] IRemove<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TResult : IRemove<TElement, TResult> where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;
	}
}
