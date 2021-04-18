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
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		public static ReadOnlyMemory<Char> Remove([AllowNull] this String collection, Char element) {
			if (collection is null || collection.Length == 0) {
				return collection.AsMemory();
			}
			return RemoveKernel(collection, element, out Int32 length).Slice(0, length);
		}

		/// <summary>
		/// Removes all instances of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		public static Memory<TElement> Remove<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) {
			if (collection is null || collection.Length == 0) {
				return collection.AsMemory();
			}
			return RemoveKernel(collection, element, out Int32 length).Slice(0, length);
		}

		/// <summary>
		/// Removes all instances of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		public static Memory<TElement> Remove<TElement>(this Memory<TElement> collection, [AllowNull] TElement element) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel(collection.Span, element, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		public static ReadOnlyMemory<TElement> Remove<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] TElement element) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel(collection.Span, element, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		public static Span<TElement> Remove<TElement>(this Span<TElement> collection, [AllowNull] TElement element) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel(collection, element, out Int32 length).AsSpan(0, length);
		}

		/// <summary>
		/// Removes all instances of the element from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove.</param>
		/// <returns>The original elements after the specified element has been removed.</returns>
		public static ReadOnlySpan<TElement> Remove<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] TElement element) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel(collection, element, out Int32 length).AsSpan(0, length);
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

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlyMemory<Char> Remove([AllowNull] this String collection, [AllowNull] params Char[] elements) {
			if (collection is null || collection.Length == 0 || elements is null || elements.Length == 0) {
				return collection.AsMemory();
			}
			return RemoveKernel<Char>(collection.AsSpan(), elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Memory<TElement> Remove<TElement>([AllowNull] this TElement[] collection, [AllowNull] params TElement[] elements) {
			if (collection is null || collection.Length == 0 || elements is null || elements.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.AsSpan(), elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Memory<TElement> Remove<TElement>(this Memory<TElement> collection, [AllowNull] params TElement[] elements) {
			if (collection.Length == 0 || elements is null || elements.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.Span, elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlyMemory<TElement> Remove<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] params TElement[] elements) {
			if (collection.Length == 0 || elements is null || elements.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.Span, elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Span<TElement> Remove<TElement>(this Span<TElement> collection, [AllowNull] params TElement[] elements) {
			if (collection.Length == 0 || elements is null || elements.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements, out Int32 length).AsSpan(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlySpan<TElement> Remove<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] params TElement[] elements) {
			if (collection.Length == 0 || elements is null || elements.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements, out Int32 length).AsSpan(0, length);
		}
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

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlyMemory<Char> Remove([AllowNull] this String collection, Memory<Char> elements) {
			if (collection.Length == 0) {
				return collection.AsMemory();
			}
			return RemoveKernel<Char>(collection.AsSpan(), elements.Span, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Memory<TElement> Remove<TElement>([AllowNull] this TElement[] collection, Memory<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.AsSpan(), elements.Span, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Memory<TElement> Remove<TElement>(this Memory<TElement> collection, Memory<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.Span, elements.Span, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlyMemory<TElement> Remove<TElement>(this ReadOnlyMemory<TElement> collection, Memory<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.Span, elements.Span, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Span<TElement> Remove<TElement>(this Span<TElement> collection, Memory<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements.Span, out Int32 length).AsSpan(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlySpan<TElement> Remove<TElement>(this ReadOnlySpan<TElement> collection, Memory<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements.Span, out Int32 length).AsSpan(0, length);
		}
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

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlyMemory<Char> Remove([AllowNull] this String collection, ReadOnlyMemory<Char> elements) {
			if (collection.Length == 0) {
				return collection.AsMemory();
			}
			return RemoveKernel<Char>(collection, elements.Span, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Memory<TElement> Remove<TElement>([AllowNull] this TElement[] collection, ReadOnlyMemory<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements.Span, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Memory<TElement> Remove<TElement>(this Memory<TElement> collection, ReadOnlyMemory<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.Span, elements.Span, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlyMemory<TElement> Remove<TElement>(this ReadOnlyMemory<TElement> collection, ReadOnlyMemory<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.Span, elements.Span, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Span<TElement> Remove<TElement>(this Span<TElement> collection, ReadOnlyMemory<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements.Span, out Int32 length).AsSpan(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlySpan<TElement> Remove<TElement>(this ReadOnlySpan<TElement> collection, ReadOnlyMemory<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements.Span, out Int32 length).AsSpan(0, length);
		}
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

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlyMemory<Char> Remove([AllowNull] this String collection, Span<Char> elements) {
			if (collection.Length == 0) {
				return collection.AsMemory();
			}
			return RemoveKernel<Char>(collection, elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Memory<TElement> Remove<TElement>([AllowNull] this TElement[] collection, Span<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Memory<TElement> Remove<TElement>(this Memory<TElement> collection, Span<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.Span, elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlyMemory<TElement> Remove<TElement>(this ReadOnlyMemory<TElement> collection, Span<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.Span, elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Span<TElement> Remove<TElement>(this Span<TElement> collection, Span<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements, out Int32 length).AsSpan(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlySpan<TElement> Remove<TElement>(this ReadOnlySpan<TElement> collection, Span<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements, out Int32 length).AsSpan(0, length);
		}
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

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlyMemory<Char> Remove([AllowNull] this String collection, ReadOnlySpan<Char> elements) {
			if (collection.Length == 0) {
				return collection.AsMemory();
			}
			return RemoveKernel<Char>(collection, elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Memory<TElement> Remove<TElement>([AllowNull] this TElement[] collection, ReadOnlySpan<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Memory<TElement> Remove<TElement>(this Memory<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.Span, elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlyMemory<TElement> Remove<TElement>(this ReadOnlyMemory<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection.Span, elements, out Int32 length).AsMemory(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static Span<TElement> Remove<TElement>(this Span<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements, out Int32 length).AsSpan(0, length);
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <returns>The original elements after the specified elements have been removed.</returns>
		public static ReadOnlySpan<TElement> Remove<TElement>(this ReadOnlySpan<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (collection.Length == 0) {
				return collection;
			}
			return RemoveKernel<TElement>(collection, elements, out Int32 length).AsSpan(0, length);
		}
		#endregion

		#region Remove(Collection, TElement*, Int32)
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

		[return: NotNull]
		private static TElement[] RemoveKernel<TElement>(ReadOnlySpan<TElement> collection, [AllowNull] TElement element, out Int32 length) {
			TElement[] array = new TElement[collection.Length];
			length = 0;
			foreach (TElement item in collection) {
				if (!Equals(item, element)) {
					array[length] = item;
				}
			}
			return array;
		}

		[return: NotNull]
		private static TElement[] RemoveKernel<TElement>(ReadOnlySpan<TElement> collection, ReadOnlySpan<TElement> elements, out Int32 length) {
			TElement[] array = new TElement[collection.Length];
			length = 0;
			foreach (TElement item in collection) {
				foreach (TElement element in elements) {
					if (!Equals(item, element)) {
						array[length] = item;
					}
				}
			}
			return array;
		}
	}
}
