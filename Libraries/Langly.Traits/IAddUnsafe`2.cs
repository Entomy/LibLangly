using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have other elements added to it, with additional unsafe operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	[CLSCompliant(false)]
	public interface IAddUnsafe<TElement, out TResult> : IAdd<TElement, TResult> where TElement : unmanaged where TResult : IAddUnsafe<TElement, TResult> {
		/// <inheritdoc/>
		[return: MaybeNull]
		unsafe TResult IAdd<TElement, TResult>.Add(ReadOnlySpan<TElement> elements) {
			TResult? result = (TResult)this;
			fixed (TElement* elmts = elements) {
				if ((result = result!.Add(elmts, elements.Length)) is null) { return default; }
			}
			return result;
		}

		/// <summary>
		/// Adds the <paramref name="elements"/> to this object.
		/// </summary>
		/// <param name="elements">The pointer to the <typeparamref name="TElement"/> values to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		unsafe TResult Add([AllowNull] TElement* elements, Int32 length) {
			TResult? result = (TResult)this;
			if (elements != null) {
				for (Int32 i = 0; i < length; i++) {
					if ((result = result!.Add(elements[i])) is null) { return default; }
				}
			}
			return result;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TResult Add<TElement, TResult>([AllowNull] this IAddUnsafe<TElement, TResult> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged where TResult : IAddUnsafe<TElement, TResult> => collection is not null ? collection.Add(elements, length) : (TResult)collection;
	}
}
