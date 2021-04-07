using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can have its elements replaced.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IReplace<in TElement, out TResult> : IReplace<TElement, TElement, TResult> where TResult : IReplace<TElement, TResult> { }
}

namespace Langly {
	public static partial class TraitExtensions {
		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
		[return: MaybeNull]
		public static TElement[] Replace<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement search, [AllowNull] TElement replace) {
			if (collection is null || collection.Length == 0) {
				return collection;
			}
			TElement[] Array = new TElement[collection.Length];
			for (nint i = 0; i < collection.Length; i++) {
				Array[i] = Equals(collection[i], search) ? replace : collection[i];
			}
			return Array;
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
			TElement[] Array = new TElement[collection.Length];
			for (Int32 i = 0; i < collection.Length; i++) {
				Array[i] = Equals(collection.Span[i], search) ? replace : collection.Span[i];
			}
			return Array;
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
			TElement[] Array = new TElement[collection.Length];
			for (Int32 i = 0; i < collection.Length; i++) {
				Array[i] = Equals(collection.Span[i], search) ? replace : collection.Span[i];
			}
			return Array;
		}
	}
}
