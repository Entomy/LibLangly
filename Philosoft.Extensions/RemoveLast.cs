using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		#region RemoveLast(Collection, TElement)
		/// <summary>
		/// Removes the last instance of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(element) : (TResult)collection;

		/// <summary>
		/// Removes the last instance of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] RemoveLast<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) {
			TElement[] Array = new TElement[collection.Length];
			Int32 i = collection.Length - 1;
			// Loop through, looking for the first match
			for (; i > 0; i--) {
				if (Equals(collection[i], element)) {
					break;
				}
				Array[i] = collection[i];
			}
			// Finish copying elements
			for (; i > 0; i--) {
				Array[i] = collection[i];
			}
			return Array[i..];
		}
		#endregion

		#region RemoveLast(Collection, TElement[])
		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, [AllowNull] params TElement[] elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;
		#endregion

		#region RemoveLast(Collection, Memory<TElement>)
		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: NotNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, Memory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;
		#endregion

		#region RemoveLast(Collection, ReadOnlyMemory<TElement>)
		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;
		#endregion

		#region RemoveLast(Collection, Span<TElement>)
		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, Span<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;
		#endregion

		#region RemoveLast(Collection, ReadOnlySpan<TElement>)
		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveLast<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;
		#endregion

		#region RemoveLast(Collection, Sequence)
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
		public static TResult RemoveLast<TElement, TResult, TEnumerator>([AllowNull] this IRemove<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TResult : IRemove<TElement, TResult> where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.RemoveLast(elements) : (TResult)collection;
		#endregion
	}
}
