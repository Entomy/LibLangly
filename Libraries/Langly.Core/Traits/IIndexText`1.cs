using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type is indexable by textual elements, read only.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	public interface IIndexText<TElement> : IIndex<Char, TElement>, IIndexReadOnlyText<TElement> {
		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		new TElement this[[DisallowNull] String index] { get; set; }

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		new TElement this[[DisallowNull] Char[] index] { get; set; }

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		new TElement this[Memory<Char> index] { get; set; }

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		new TElement this[ReadOnlyMemory<Char> index] { get; set; }

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		new TElement this[Span<Char> index] { get; set; }

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		new TElement this[ReadOnlySpan<Char> index] { get; set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		TElement IIndexReadOnlyText<TElement>.this[[DisallowNull] String index] => this[index];

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		TElement IIndexReadOnlyText<TElement>.this[[DisallowNull] Char[] index] => this[index];

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		TElement IIndexReadOnlyText<TElement>.this[Memory<Char> index] => this[index];

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		TElement IIndexReadOnlyText<TElement>.this[ReadOnlyMemory<Char> index] => this[index];

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		TElement IIndexReadOnlyText<TElement>.this[Span<Char> index] => this[index];

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		TElement IIndexReadOnlyText<TElement>.this[ReadOnlySpan<Char> index] => this[index];
	}
}
