using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the collection can have elements inserted into it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IInsert<TElement, out TResult> : IInsert<nint, TElement, TResult> {
		/// <inheritdoc/>
		[return: NotNull]
		TResult IInsert<nint, TElement, TResult>.Insert([DisallowNull] nint index, ReadOnlySpan<TElement> elements) {
			foreach (TElement element in elements) {
				_ = Insert(index++, elements);
			}
			return (TResult)this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		TResult IInsert<nint, TElement, TResult>.Insert<TEnumerator>([DisallowNull] nint index, [AllowNull] ISequence<TElement, TEnumerator> elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					_ = Insert(index++, elements);
				}
			}
			return (TResult)this;
		}
	}
}
