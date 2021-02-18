using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have elements popped off it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPop<TElement, out TResult> : ICount where TResult : IPop<TElement, TResult> {
		/// <summary>
		/// Pops an element off the top of this object.
		/// </summary>
		/// <param name="element">The popped off element.</param>
		/// <returns>The result of popping the <paramref name="element"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Pop([MaybeNull] out TElement element);

		/// <summary>
		/// Pops elements off the top of this object until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Pop([AllowNull] TElement[] elements) => elements is not null ? Pop(elements.AsMemory()) : (TResult)this;

		/// <summary>
		/// Pops elements off the top of this object until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Pop(Memory<TElement> elements) => Pop(elements.Span);

		/// <summary>
		/// Pops <paramref name="amount"/> of elements off the top of this object.
		/// </summary>
		/// <param name="amount">The amount of elements to pop.</param>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// If <paramref name="amount"/> is greater than <see cref="ICount.Count"/>, this pops off all available elements, but not more.
		/// </remarks>
		[return: MaybeNull]
		TResult Pop(nint amount, out ReadOnlyMemory<TElement> elements) {
			TResult result = (TResult)this;
			Memory<TElement> buffer = new TElement[amount];
			Int32 i = 0;
			for (; i < buffer.Length; i++) {
				result = result.Pop(out buffer.Span[i]);
				if (result is null) {
					goto Result;
				}
			}
		Result:
			elements = buffer.Slice(0, i);
			return result;
		}

		/// <summary>
		/// Pops elements off the top of this object until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Pop(Span<TElement> elements) {
			TResult result = (TResult)this;
			for (Int32 i = 0; i < elements.Length; i++) {
				result = result.Pop(out elements[i]);
				if (result is null) {
					goto Result;
				}
			}
		Result:
			return result;
		}

		/// <summary>
		/// Pops <paramref name="amount"/> of elements off the top of this object.
		/// </summary>
		/// <param name="amount">The amount of elements to pop.</param>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// If <paramref name="amount"/> is greater than <see cref="ICount.Count"/>, this pops off all available elements, but not more.
		/// </remarks>
		[return: MaybeNull]
		TResult Pop(nint amount, out ReadOnlySpan<TElement> elements) {
			TResult result = Pop(amount, out ReadOnlyMemory<TElement> elmts);
			elements = elmts.Span;
			return result;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Pops an element off the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The tyoe of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The popped off element.</param>
		/// <returns>The result of popping the <paramref name="element"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Pop<TElement, TResult>([AllowNull] this IPop<TElement, TResult> collection, [MaybeNull] out TElement element) where TResult : IPop<TElement, TResult> {
			if (collection is null) {
				element = default;
				return (TResult)collection;
			}
			return collection.Pop(out element);
		}

		/// <summary>
		/// Pops elements off the top of this object until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <typeparam name="TElement">The tyoe of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Pop<TElement, TResult>([AllowNull] this IPop<TElement, TResult> collection, [AllowNull] TElement[] elements) where TResult : IPop<TElement, TResult> => collection is not null ? collection.Pop(elements) : (TResult)collection;

		/// <summary>
		/// Pops elements off the top of this object until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <typeparam name="TElement">The tyoe of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Pop<TElement, TResult>([AllowNull] this IPop<TElement, TResult> collection, Memory<TElement> elements) where TResult : IPop<TElement, TResult> => collection is not null ? collection.Pop(elements) : (TResult)collection;

		/// <summary>
		/// Pops <paramref name="amount"/> of elements off the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The tyoe of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of elements to pop.</param>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// If <paramref name="amount"/> is greater than <see cref="ICount.Count"/>, this pops off all available elements, but not more.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Pop<TElement, TResult>([AllowNull] this IPop<TElement, TResult> collection, nint amount, out ReadOnlyMemory<TElement> elements) where TResult : IPop<TElement, TResult> {
			if (collection is null) {
				elements = ReadOnlyMemory<TElement>.Empty;
				return (TResult)collection;
			}
			return collection.Pop(amount, out elements);
		}

		/// <summary>
		/// Pops elements off the top of this object until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <typeparam name="TElement">The tyoe of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Pop<TElement, TResult>([AllowNull] this IPop<TElement, TResult> collection, Span<TElement> elements) where TResult : IPop<TElement, TResult> => collection is not null ? collection.Pop(elements) : (TResult)collection;

		/// <summary>
		/// Pops <paramref name="amount"/> of elements off the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The tyoe of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of elements to pop.</param>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object if successful; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// If <paramref name="amount"/> is greater than <see cref="ICount.Count"/>, this pops off all available elements, but not more.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Pop<TElement, TResult>([AllowNull] this IPop<TElement, TResult> collection, nint amount, out ReadOnlySpan<TElement> elements) where TResult : IPop<TElement, TResult> {
			if (collection is null) {
				elements = ReadOnlySpan<TElement>.Empty;
				return (TResult)collection;
			}
			return collection.Pop(amount, out elements);
		}
	}
}
