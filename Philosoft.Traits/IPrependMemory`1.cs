using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements prepended onto it, with additional array and memory operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPrependMemory<TElement> : IPrepend<TElement> {
		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		void Prepend([AllowNull] params TElement[] elements)
#if !NETSTANDARD1_3
			=> Prepend(elements.AsMemory())
#endif
			;

		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		void Prepend(Memory<TElement> elements)
#if !NETSTANDARD1_3
			=> Prepend((ReadOnlyMemory<TElement>)elements)
#endif
			;

		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		void Prepend(ReadOnlyMemory<TElement> elements);
	}
}
