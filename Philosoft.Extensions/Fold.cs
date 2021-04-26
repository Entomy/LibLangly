using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Folds the collection into a single element as described by the <paramref name="func"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The function describing the folding operation. This is a magma.</param>
		/// <param name="identity">The identity value for <paramref name="func"/>.</param>
		/// <returns>A single element after folding the entire <paramref name="collection"/>. If <paramref name="collection"/> or <paramref name="func"/> are <see langword="null"/> this function returns <paramref name="identity"/>.</returns>
		/// <remarks>
		/// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
		/// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
		/// </remarks>
		[return: MaybeNull]
		public static TElement Fold<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> collection, [DisallowNull] Func<TElement, TElement, TElement> func, [AllowNull] TElement identity) where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.Fold(func, identity) : identity;

		/// <summary>
		/// Folds the collection into a single element as described by the <paramref name="func"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The function describing the folding operation. This is a magma.</param>
		/// <param name="identity">The identity value for <paramref name="func"/>.</param>
		/// <returns>A single element after folding the entire <paramref name="collection"/>. If <paramref name="collection"/> or <paramref name="func"/> are <see langword="null"/> this function returns <paramref name="identity"/>.</returns>
		/// <remarks>
		/// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
		/// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
		/// </remarks>
		[return: MaybeNull]
		public static Char Fold([AllowNull] this String collection, [DisallowNull] Func<Char, Char, Char> func, Char identity) => collection is not null ? Fold(collection.AsSpan(), func, identity) : identity;

		/// <summary>
		/// Folds the collection into a single element as described by the <paramref name="func"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The function describing the folding operation. This is a magma.</param>
		/// <param name="identity">The identity value for <paramref name="func"/>.</param>
		/// <returns>A single element after folding the entire <paramref name="collection"/>. If <paramref name="collection"/> or <paramref name="func"/> are <see langword="null"/> this function returns <paramref name="identity"/>.</returns>
		/// <remarks>
		/// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
		/// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
		/// </remarks>
		[return: MaybeNull]
		public static TElement Fold<TElement>([AllowNull] this TElement[] collection, [DisallowNull] Func<TElement, TElement, TElement> func, [AllowNull] TElement identity) => collection is not null ? Fold(collection.AsSpan(), func, identity) : identity;

		/// <summary>
		/// Folds the collection into a single element as described by the <paramref name="func"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The function describing the folding operation. This is a magma.</param>
		/// <param name="identity">The identity value for <paramref name="func"/>.</param>
		/// <returns>A single element after folding the entire <paramref name="collection"/>. If <paramref name="collection"/> or <paramref name="func"/> are <see langword="null"/> this function returns <paramref name="identity"/>.</returns>
		/// <remarks>
		/// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
		/// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
		/// </remarks>
		[return: MaybeNull]
		public static TElement Fold<TElement>(this Memory<TElement> collection, [DisallowNull] Func<TElement, TElement, TElement> func, [AllowNull] TElement identity) => Fold(collection.Span, func, identity);

		/// <summary>
		/// Folds the collection into a single element as described by the <paramref name="func"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The function describing the folding operation. This is a magma.</param>
		/// <param name="identity">The identity value for <paramref name="func"/>.</param>
		/// <returns>A single element after folding the entire <paramref name="collection"/>. If <paramref name="collection"/> or <paramref name="func"/> are <see langword="null"/> this function returns <paramref name="identity"/>.</returns>
		/// <remarks>
		/// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
		/// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
		/// </remarks>
		[return: MaybeNull]
		public static TElement Fold<TElement>(this ReadOnlyMemory<TElement> collection, [DisallowNull] Func<TElement, TElement, TElement> func, [AllowNull] TElement identity) => Fold(collection.Span, func, identity);

		/// <summary>
		/// Folds the collection into a single element as described by the <paramref name="func"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The function describing the folding operation. This is a magma.</param>
		/// <param name="identity">The identity value for <paramref name="func"/>.</param>
		/// <returns>A single element after folding the entire <paramref name="collection"/>. If <paramref name="collection"/> or <paramref name="func"/> are <see langword="null"/> this function returns <paramref name="identity"/>.</returns>
		/// <remarks>
		/// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
		/// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
		/// </remarks>
		[return: MaybeNull]
		public static TElement Fold<TElement>(this Span<TElement> collection, [DisallowNull] Func<TElement, TElement, TElement> func, [AllowNull] TElement identity) => Fold((ReadOnlySpan<TElement>)collection, func, identity);

		/// <summary>
		/// Folds the collection into a single element as described by the <paramref name="func"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The function describing the folding operation. This is a magma.</param>
		/// <param name="identity">The identity value for <paramref name="func"/>.</param>
		/// <returns>A single element after folding the entire <paramref name="collection"/>. If <paramref name="collection"/> or <paramref name="func"/> are <see langword="null"/> this function returns <paramref name="identity"/>.</returns>
		/// <remarks>
		/// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
		/// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
		/// </remarks>
		[return: MaybeNull]
		public static TElement Fold<TElement>(this ReadOnlySpan<TElement> collection, [DisallowNull] Func<TElement, TElement, TElement> func, [AllowNull] TElement identity) {
			TElement result = identity;
			if (func is not null) {
				if (func is null) {
					goto Result;
				}
				foreach (TElement item in collection) {
					result = func(result, item);
				}
			}
		Result:
			return result;
		}
	}
}
