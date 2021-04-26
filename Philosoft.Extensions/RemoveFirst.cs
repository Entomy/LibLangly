using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		#region RemoveFirst(Collection, TElement)
		/// <summary>
		/// Removes the first instance of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(element) : (TResult)collection;

		/// <summary>
		/// Removes the first instance of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] RemoveFirst<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) {
			if (collection is null || collection.Length == 0) {
				return collection;
			}
			TElement[] Array = new TElement[collection.Length];
			Int32 i = 0;
			// Loop through, looking for the first match
			for (; i < collection.Length; i++) {
				if (Equals(collection[i], element)) {
					break;
				}
				Array[i] = collection[i];
			}
			// Finish copying elements
			for (; i < collection.Length; i++) {
				Array[i] = collection[i];
			}
			return Array[0..i];
		}
		#endregion

		#region RemoveFirst(Collection, TElement[])
		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, [AllowNull] params TElement[] elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;
		#endregion

		#region RemoveFirst(Collection, Memory<TElement>)
		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, Memory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;
		#endregion

		#region RemoveFirst(Collection, ReadOnlyMemory<TElement>)
		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;
		#endregion

		#region RemoveFirst(Collection, Span<TElement>)
		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, Span<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;
		#endregion

		#region RemoveFirst(Collection, ReadOnlySpan<TElement>)
		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		[return: MaybeNull]
		public static TResult RemoveFirst<TElement, TResult>([AllowNull] this IRemove<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IRemove<TElement, TResult> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;
		#endregion

		#region RemoveFirst(Collection, Sequence)
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
		public static TResult RemoveFirst<TElement, TResult, TEnumerator>([AllowNull] this IRemove<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TResult : IRemove<TElement, TResult> where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.RemoveFirst(elements) : (TResult)collection;
		#endregion
	}
}
