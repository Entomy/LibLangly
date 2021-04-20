using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <typeparam name="TSearch">The type of the elements to replace.</typeparam>
		/// <typeparam name="TReplace">The type of the elements to use instead.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
		[return: MaybeNull]
		public static TResult Replace<TSearch, TReplace, TResult>([AllowNull] this IReplace<TSearch, TReplace, TResult> collection, [AllowNull] TSearch search, [AllowNull] TReplace replace) where TResult : IReplace<TSearch, TReplace, TResult> => collection is not null ? collection.Replace(search, replace) : (TResult)collection;

		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
		public static ReadOnlyMemory<Char> Replace([AllowNull] this String collection, Char search, Char replace) {
			if (collection is null || collection.Length == 0) {
				return collection.AsMemory();
			}
			return ReplaceKernel<Char>(collection, search, replace);
		}

		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
		public static Memory<TElement> Replace<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement search, [AllowNull] TElement replace) {
			if (collection is null || collection.Length == 0) {
				return collection;
			}
			return ReplaceKernel<TElement>(collection, search, replace);
		}

		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
		public static Memory<TElement> Replace<TElement>([AllowNull] this Memory<TElement> collection, [AllowNull] TElement search, [AllowNull] TElement replace) {
			if (collection.Length == 0) {
				return collection;
			}
			return ReplaceKernel<TElement>(collection.Span, search, replace);
		}

		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
		public static ReadOnlyMemory<TElement> Replace<TElement>([AllowNull] this ReadOnlyMemory<TElement> collection, [AllowNull] TElement search, [AllowNull] TElement replace) {
			if (collection.Length == 0) {
				return collection;
			}
			return ReplaceKernel<TElement>(collection.Span, search, replace);
		}

		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
		public static Span<TElement> Replace<TElement>([AllowNull] this Span<TElement> collection, [AllowNull] TElement search, [AllowNull] TElement replace) {
			if (collection.Length == 0) {
				return collection;
			}
			return ReplaceKernel<TElement>(collection, search, replace);
		}

		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
		public static ReadOnlySpan<TElement> Replace<TElement>([AllowNull] this ReadOnlySpan<TElement> collection, [AllowNull] TElement search, [AllowNull] TElement replace) {
			if (collection.Length == 0) {
				return collection;
			}
			return ReplaceKernel<TElement>(collection, search, replace);
		}

		[return: NotNull]
		private static TElement[] ReplaceKernel<TElement>(ReadOnlySpan<TElement> collection, [AllowNull] TElement search, [AllowNull] TElement replace) {
			TElement[] array = new TElement[collection.Length];
			for (Int32 i = 0; i < collection.Length; i++) {
				array[i] = Equals(collection[i], search) ? replace : collection[i];
			}
			return array;
		}
	}
}
