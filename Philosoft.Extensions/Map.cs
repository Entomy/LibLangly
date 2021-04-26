using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates <paramref name="collection"/> rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IIndexRef{TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="System"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		public static void Map<TElement>([AllowNull] this IIndex<TElement> collection, [AllowNull] Func<TElement, TElement> func) {
			if (collection is null || func is null) {
				return;
			}
			collection.Map(func);
		}

		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates <paramref name="collection"/> rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IIndexRef{TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="System"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		public static void Map<TElement>([AllowNull] this IIndexRef<TElement> collection, [AllowNull] Func<TElement, TElement> func) {
			if (collection is null || func is null) {
				return;
			}
			collection.Map(func);
		}

		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the <paramref name="collection"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates <paramref name="collection"/> rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IIndexRef{TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="System"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		public static ReadOnlyMemory<Char> Map([AllowNull] this String collection, [AllowNull] Func<Char, Char> func) {
			if (func is null) {
				return collection.AsMemory();
			}
			return collection is not null ? MapKernel(collection.AsSpan(), func) : ReadOnlyMemory<Char>.Empty;
		}

		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the <paramref name="collection"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates <paramref name="collection"/> rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IIndexRef{TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="System"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		public static Memory<TElement> Map<TElement>([AllowNull] this TElement[] collection, [AllowNull] Func<TElement, TElement> func) {
			if (func is null) {
				return collection.AsMemory();
			}
			return collection is not null ? MapKernel(collection.AsSpan(), func) : Memory<TElement>.Empty;
		}

		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates <paramref name="collection"/> rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IIndexRef{TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="System"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		public static Memory<TElement> Map<TElement>(this Memory<TElement> collection, [AllowNull] Func<TElement, TElement> func) {
			if (func is null) {
				return collection;
			}
			return MapKernel(collection.Span, func);
		}

		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates <paramref name="collection"/> rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IIndexRef{TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="System"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		public static ReadOnlyMemory<TElement> Map<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] Func<TElement, TElement> func) {
			if (func is null) {
				return collection;
			}
			return MapKernel(collection.Span, func);
		}

		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates <paramref name="collection"/> rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IIndexRef{TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="System"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		public static Span<TElement> Map<TElement>(this Span<TElement> collection, [AllowNull] Func<TElement, TElement> func) {
			if (func is null) {
				return collection;
			}
			return MapKernel(collection, func);
		}

		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates <paramref name="collection"/> rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IIndexRef{TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="System"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		public static ReadOnlySpan<TElement> Map<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] Func<TElement, TElement> func) {
			if (func is null) {
				return collection;
			}
			return MapKernel(collection, func);
		}

		[return: NotNull]
		private static TElement[] MapKernel<TElement>(ReadOnlySpan<TElement> collection, [DisallowNull] Func<TElement, TElement> func) {
			TElement[] array = new TElement[collection.Length];
			for (Int32 i = 0; i < collection.Length; i++) {
				array[i] = func(collection[i]);
			}
			return array;
		}
	}
}
