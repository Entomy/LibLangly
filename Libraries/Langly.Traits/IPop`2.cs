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
		/// <returns>The result of popping the <paramref name="element"/> off this object.</returns>
		[return: MaybeNull]
		TResult Pop([MaybeNull] out TElement element);

		/// <summary>
		/// Pops <paramref name="amount"/> of elements off the top of this object.
		/// </summary>
		/// <param name="amount">The amount of elements to pop.</param>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object.</returns>
		/// <remarks>
		/// If <paramref name="amount"/> is greater than <see cref="ICount.Count"/>, this pops off all available elements, but not more.
		/// </remarks>
		[return: MaybeNull]
		TResult Pop(nint amount, [NotNull] out TElement[] elements) {
			elements = amount > Count ? new TElement[Count] : new TElement[amount];
			for (nint i = 0; i < elements.Length; i++) {
				_ = Pop(out elements[i]);
			}
			return (TResult)this;
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
		/// <returns>The result of popping the <paramref name="element"/> off this object.</returns>
		[return: MaybeNull]
		public static TResult Pop<TElement, TResult>([MaybeNull] this IPop<TElement, TResult> collection, [MaybeNull] out TElement element) where TResult : IPop<TElement, TResult> {
			if (collection is null) {
				element = default;
				return (TResult)collection;
			}
			return collection.Pop(out element);
		}

		/// <summary>
		/// Pops <paramref name="amount"/> of elements off the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The tyoe of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of elements to pop.</param>
		/// <param name="elements">The popped off elements.</param>
		/// <returns>The result of popping the <paramref name="elements"/> off this object.</returns>
		/// <remarks>
		/// If <paramref name="amount"/> is greater than <see cref="ICount.Count"/>, this pops off all available elements, but not more.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Pop<TElement, TResult>([MaybeNull] this IPop<TElement, TResult> collection, nint amount, [NotNull] out TElement[] elements) where TResult : IPop<TElement, TResult> {
			if (collection is null) {
				elements = Array.Empty<TElement>();
				return (TResult)collection;
			}
			return collection.Pop(amount, out elements);
		}
	}
}
