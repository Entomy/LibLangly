using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type is indexable by textual elements, read only.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	public interface IIndexReadOnlyText<out TElement> : IIndexReadOnly<Char, TElement> {
		/// <summary>
		/// Gets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		TElement this[[DisallowNull] String index] { get; }

		/// <summary>
		/// Gets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		TElement this[[DisallowNull] Char[] index] { get; }

		/// <summary>
		/// Gets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		TElement this[Memory<Char> index] { get; }

		/// <summary>
		/// Gets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		TElement this[ReadOnlyMemory<Char> index] { get; }

		/// <summary>
		/// Gets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		TElement this[Span<Char> index] { get; }

		/// <summary>
		/// Gets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		TElement this[ReadOnlySpan<Char> index] { get; }
	}
}
