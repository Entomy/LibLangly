using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can contain elements, and test against those.
	/// </summary>
	/// <typeparam name="TElement">The type of element contained in the collection.</typeparam>
	public interface IContainsAny<TElement> : IContains<TElement> {
		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsAny([AllowNull] params TElement?[] elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsAny(ArraySegment<TElement?> elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsAny(Memory<TElement?> elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsAny(ReadOnlyMemory<TElement?> elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsAny(Span<TElement?> elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsAny(ReadOnlySpan<TElement?> elements);
	}
}
