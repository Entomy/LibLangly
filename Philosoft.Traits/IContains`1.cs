using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can contain elements, and test against those.
	/// </summary>
	/// <typeparam name="TElement">The type of element contained in the collection.</typeparam>
	public interface IContains<TElement> {
		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		Boolean Contains([AllowNull] TElement element);

		/// <summary>
		/// Determines whether this collection contains an element described by the specified <paramref name="predicate"/>.
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns><see langword="true"/> if an element described the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		Boolean Contains([AllowNull] Predicate<TElement?> predicate);
	}
}
