using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		#region Remove(Collection, TElement)
		/// <summary>
		/// Removes all instances of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(element) : (TResult)collection;

		/// <summary>
		/// Removes all instances of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] Remove<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) {
			if (collection is null || collection.Length == 0) {
				return collection;
			}
			TElement[] Array = new TElement[collection.Length];
			Int32 i = 0;
			foreach (TElement item in collection) {
				if (!Equals(item, element)) {
					Array[i] = item;
				}
			}
			return Array[0..i];
		}
		#endregion

		#region Remove(Collection, TElement[])
		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection,  [AllowNull] params TElement[] elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(elements) : (TResult)collection;
		#endregion

		#region Remove(Collection, Memory<TElement>)
		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, Memory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(elements) : (TResult)collection;
		#endregion

		#region Remove(Collection, ReadOnlyMemory<TElement>)
		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(elements) : (TResult)collection;
		#endregion

		#region Remove(Collection, Span<TElement>)
		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, Span<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(elements) : (TResult)collection;
		#endregion

		#region Remove(Collection, ReadOnlySpan<TElement>)
		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult Remove<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.Remove(elements) : (TResult)collection;
		#endregion

		#region Remove(Collection, Sequence)
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
		public static TResult Remove<TElement, TResult, TEnumerator>([AllowNull] this IRemove<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TResult : IRemove<TElement, TResult> where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.Remove(elements) : (TResult)collection;
		#endregion
	}
}
