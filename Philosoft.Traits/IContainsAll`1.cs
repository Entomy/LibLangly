using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can contain elements, and test against those.
	/// </summary>
	/// <typeparam name="TElement">The type of element contained in the collection.</typeparam>
	public interface IContainsAll<TElement> : IContains<TElement> {
		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsAll([AllowNull] params TElement[] elements);
	}
}
