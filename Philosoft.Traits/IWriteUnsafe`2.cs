using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can be written to, with additional unsafe operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to write.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	[CLSCompliant(false)]
	public interface IWriteUnsafe<TElement, out TResult> : IAddUnsafe<TElement, TResult>, IWrite<TElement, TResult> where TElement : unmanaged where TResult : IWriteUnsafe<TElement, TResult> {
		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">A pointer to the <typeparamref name="TElement"/> values to write.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		unsafe TResult Write([AllowNull] TElement* elements, Int32 length) => Add(elements, length);
	}
}
