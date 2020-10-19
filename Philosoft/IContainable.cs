using System;

namespace Philosoft {
	/// <summary>
	/// Indicates the collection can contain elements.
	/// </summary>
	public interface IContainable<in TElement> {
		/// <summary>
		/// Determines whether this collection contains a specific <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The object to locate in the collection.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is found in the collection; otherwise, <see langword="false"/>.</returns>
		Boolean Contains(TElement element);
	}
}
