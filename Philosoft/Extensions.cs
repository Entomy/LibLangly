using System;
using System.Diagnostics.CodeAnalysis;

namespace Philosoft {
	/// <summary>
	/// Provides extension methods for the traits in <see cref="Philosoft"/>.
	/// </summary>
	[SuppressMessage("Maintainability", "AV1551:Method overload should call another overload", Justification = "This entire thing essentially already does. Each extension method calls an instance method that does the same thing, but with additional protections in the event the caller is null.")]
	public static class Extensions {
		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		public static void Add<TElement>(this IAddable<TElement> collection, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Add(element);
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		public static void Add<TElement>(this IAddable<TElement> collection, params TElement[] elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for this collection.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		public static void Add<TElement, TEnumerator>(this IAddable<TElement> collection, IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Clears all items from the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void Clear(this IClearable collection) {
			if (collection is null) {
				return;
			}
			collection.Clear();
		}

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <typeparam name="TSelf">The type of this collection; itself.</typeparam>
		/// <returns>A new object that is a copy of this instance.</returns>
		/// <remarks>
		/// <para>The resulting clone must be of the same type as, or compatible with, the original instance.</para>
		/// <para>An implementation of <see cref="Clone"/> can perform either a deep copy or a shallow copy. In a deep copy, all objects are duplicated; in a shallow copy, only the top-level objects are duplicated and the lower levels contain references. Because callers of <see cref="Clone"/> cannot depend on the method performing a predictable cloning operation, we recommend that <see cref="ICloneable{TSelf}"/> not be implemented in public APIs.</para>
		/// <para>See <see cref="Object.MemberwiseClone"/> for more information on cloning, deep versus shallow copies, and examples.</para>
		/// </remarks>
		public static TSelf Clone<TSelf>(this ICloneable<TSelf> collection) => collection is null ? default : collection.Clone();

		/// <summary>
		/// Determines whether this collection contains a specific <paramref name="element"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The object to locate in the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <returns><see langword="true"/> if <paramref name="element"/> is found in the collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains<TElement>(this IContainable<TElement> collection, TElement element) => !(collection is null) && collection.Contains(element);

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void Grow(this IResizable collection) {
			if (collection is null) {
				return;
			}
			collection.Grow();
		}

		/// <summary>
		/// Removes all instances of the <paramref name="element"/> from the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove from the collection.</param>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		public static void Remove<TElement>(this IRemovable<TElement> collection, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Remove(element);
		}

		/// <summary>
		/// Removes all instances of the <paramref name="elements"/> from the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove from the collection.</param>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		public static void Remove<TElement>(this IRemovable<TElement> collection, params TElement[] elements) {
			if (collection is null) {
				return;
			}
			collection.Remove(elements);
		}

		/// <summary>
		/// Removes all instances of the <paramref name="elements"/> from the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove from the collection.</param>
		public static void Remove<TElement, TEnumerator>(this IRemovable<TElement> collection, IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return;
			}
			collection.Remove(elements);
		}

		/// <summary>
		/// Removes all instances that match the specified predicate from the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to remove.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		public static void Remove<TElement>(this IRemovable<TElement> collection, Predicate<TElement> match) {
			if (collection is null) {
				return;
			}
			collection.Remove(match);
		}

		/// <summary>
		/// Removes the entry at the specified <paramref name="index"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which to remove the entry from the collection.</param>
		/// <typeparam name="TIndex">The type of the indices of the collection.</typeparam>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		public static void RemoveAt<TIndex, TElement>(this IRemovable<TIndex, TElement> collection, TIndex index) {
			if (collection is null) {
				return;
			}
			collection.RemoveAt(index);
		}

		/// <summary>
		/// Removes the entries at the specified <paramref name="indices"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="indices">The indices at which to remove the entry from the collection.</param>
		/// <typeparam name="TIndex">The type of the indices of the collection.</typeparam>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		public static void RemoveAt<TIndex, TElement>(this IRemovable<TIndex, TElement> collection, params TIndex[] indices) {
			if (collection is null) {
				return;
			}
			collection.RemoveAt(indices);
		}

		/// <summary>
		/// Returns a new collection in which all occurrences of the <paramref name="oldElement"/> are replaced with the <paramref name="newElement"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="oldElement">The element to be replaced.</param>
		/// <param name="newElement">The element to replace with.</param>
		/// <typeparam name="TOld">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TNew">The type of the elements to replace with.</typeparam>
		public static void Replace<TOld, TNew>(this IReplaceable<TOld, TNew> collection, TOld oldElement, TNew newElement) {
			if (collection is null) {
				return;
			}
			collection.Replace(oldElement, newElement);
		}

		/// <summary>
		/// Returns a new collection in which all replacements described by the <paramref name="map"/> are performed.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="map">The mapping of elements to be replaced and their replacements.</param>
		/// <typeparam name="TOld">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TNew">The type of the elements to replace with.</typeparam>
		public static void Replace<TOld, TNew>(this IReplaceable<TOld, TNew> collection, params (TOld, TNew)[] map) {
			if (collection is null) {
				return;
			}
			collection.Replace(map);
		}

		/// <summary>
		/// Returns a new collection in which instances that match the specified predicate are replaced with the <paramref name="newElement"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="match">The <see cref="Func{T, TResult}"/> delegate that defines the conditions of the element to replace.</param>
		/// <param name="newElement">The element to be replaced with.</param>
		/// <typeparam name="TOld">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TNew">The type of the elements to replace with.</typeparam>
		public static void Replace<TOld, TNew>(this IReplaceable<TOld, TNew> collection, Func<TOld, Boolean> match, TNew newElement) {
			if (collection is null) {
				return;
			}
			collection.Replace(match, newElement);
		}

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		public static void Resize(this IResizable collection, nint capacity) {
			if (collection is null) {
				return;
			}
			collection.Resize(capacity);
		}

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void Shrink(this IResizable collection) {
			if (collection is null) {
				return;
			}
			collection.Shrink();
		}

		/// <summary>
		/// Forms a slice out of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <typeparam name="TSlice">The type of the slice.</typeparam>
		/// <returns>A slice that consists of all elements of the current collection.</returns>
		public static TSlice Slice<TSlice>(this ISliceable<TSlice> collection) => collection is null ? default : collection.Slice();

		/// <summary>
		/// Forms a slice out of the collection that begins at a specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <typeparam name="TSlice">The type of the slice.</typeparam>
		/// <returns>A slice that consists of all elements of the current collection from <paramref name="start"/> to the end of the collection.</returns>
		public static TSlice Slice<TSlice>(this ISliceable<TSlice> collection, nint start) => collection is null ? default : collection.Slice(start);

		/// <summary>
		/// Forms a slice out of the current span starting at a specified index for a specified length.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <typeparam name="TSlice">The type of the slice.</typeparam>
		/// <returns>A slice that consists of <paramref name="length"/> elements from the current collection starting at <paramref name="start"/>.</returns>
		public static TSlice Slice<TSlice>(this ISliceable<TSlice> collection, nint start, nint length) => collection is null ? default : collection.Slice(start, length);

		/// <summary>
		/// Forms a slice out of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <typeparam name="TSlice">The type of the slice.</typeparam>
		/// <returns>A slice that consists of all elements of the current collection.</returns>
		public static TSlice Slice<TSlice>(this IReadOnlySliceable<TSlice> collection) => collection is null ? default : collection.Slice();

		/// <summary>
		/// Forms a slice out of the collection that begins at a specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <typeparam name="TSlice">The type of the slice.</typeparam>
		/// <returns>A slice that consists of all elements of the current collection from <paramref name="start"/> to the end of the collection.</returns>
		public static TSlice Slice<TSlice>(this IReadOnlySliceable<TSlice> collection, nint start) => collection is null ? default : collection.Slice(start);

		/// <summary>
		/// Forms a slice out of the current span starting at a specified index for a specified length.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <typeparam name="TSlice">The type of the slice.</typeparam>
		/// <returns>A slice that consists of <paramref name="length"/> elements from the current collection starting at <paramref name="start"/>.</returns>
		public static TSlice Slice<TSlice>(this IReadOnlySliceable<TSlice> collection, nint start, nint length) => collection is null ? default : collection.Slice(start, length);
	}
}
