using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can load other values into it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the buffer.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public interface ILoad<TElement, out TSelf> : IAdd<TElement, TSelf>, ICapacity, ICount where TSelf : ILoad<TElement, TSelf> {
		/// <summary>
		/// Ensures <paramref name="amount"/> bytes are loaded into the buffer.
		/// </summary>
		/// <param name="amount">The amount of <typeparamref name="TElement"/> to have loaded.</param>
		/// <param name="source">The source to load data from.</param>
		/// <returns>If the load occurred successfully, returns a <typeparamref name="TResult"/> containing the original and loaded elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TSelf EnsureLoaded<TResult>(nint amount, [AllowNull] IRead<TElement, TResult> source) where TResult : IRead<TElement, TResult> {
			if (source is not null) {
				
			}
			return (TSelf)this;
		}

		/// <summary>
		/// Loads a byte into the buffer.
		/// </summary>
		/// <param name="source">The source to load data from.</param>
		/// <returns>If the load occurred successfully, returns a <typeparamref name="TResult"/> containing the original and loaded elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TSelf Load<TResult>([AllowNull] IRead<TElement, TResult> source) where TResult : IRead<TElement, TResult> {
			if (source is not null) {
				source.Read(out TElement element);
				Add(element);
			}
			return (TSelf)this;
		}
	}
}
