using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can be read from, with additional unsafe operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to read.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	[CLSCompliant(false)]
	public interface IReadUnsafe<TElement, out TResult> : IRead<TElement, TResult> where TElement : unmanaged where TResult : IReadUnsafe<TElement, TResult> {
		/// <inheritdoc/>
		[return: MaybeNull]
		unsafe TResult IRead<TElement, TResult>.Read(Span<TElement> elements) {
			TResult result = (TResult)this;
			fixed (TElement* elmts = elements) {
				result = result.Read(elmts, elements.Length);
			}
			return result;
		}

		/// <summary>
		/// Reads until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> to fill.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		unsafe TResult Read([DisallowNull] TElement* elements, Int32 length) {
			TResult result = (TResult)this;
			for (Int32 i = 0; i < length; i++) {
				result = result.Read(out elements[i]);
				if (result is null) {
					goto Result;
				}
			}
		Result:
			return result;
		}
	}
}
