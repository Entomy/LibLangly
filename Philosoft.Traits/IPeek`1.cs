using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have its first element peeked at.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPeek<TElement> {
		/// <summary>
		/// Peeks at thefirst element.
		/// </summary>
		/// <returns>The <typeparamref name="TElement"/> value that was peeked.</returns>
		[return: MaybeNull]
		public TElement Peek();

		/// <summary>
		/// Peeks at the first element.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was peeked.</param>
		void Peek([MaybeNull] out TElement element);
	}
}
