using System.Diagnostics.CodeAnalysis;

namespace Philosoft {
	/// <summary>
	/// Indicates the collection is peekable.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	[SuppressMessage("Major Code Smell", "S3246:Generic type parameters should be co/contravariant when possible", Justification = "Agreed, they should. However this isn't even remotely possible in this situation.")]
	public interface IPeekable<TElement> {
		/// <summary>
		/// Returns the object at the beginning of the collection without removing it.
		/// </summary>
		/// <returns>The object that is removed from the beginning of the collection.</returns>
		ref readonly TElement Peek();
	}
}
