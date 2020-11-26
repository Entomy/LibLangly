using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the collection is peekable.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	[SuppressMessage("Major Code Smell", "S3246:Generic type parameters should be co/contravariant when possible", Justification = "Agreed, they should. However this isn't even remotely possible in this situation.")]
	public interface IPeekable<TElement> {
		/// <summary>
		/// Returns the element at the beginning of the collection without removing it.
		/// </summary>
		/// <returns>The element from the beginning of the collection.</returns>
		ref readonly TElement Peek();
	}

	public static partial class Extensions {
		/// <summary>
		/// Returns the element at the beginning of the collection without removing it.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <returns>The element from the beginning of the collection.</returns>
		/// <exception cref="NullReferenceException">Thrown if <paramref name="collection"/> is <see langword="null"/>.</exception>
		[SuppressMessage("Design", "MA0012:Do not raise reserved exception type", Justification = "This is exactly what would be thrown were this pattern not being used, and since we can't handle this, throwing the expected pattern seems far more consistent with normal, expected, behavior.")]
		[SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "This is exactly what would be thrown were this pattern not being used, and since we can't handle this, throwing the expected pattern seems far more consistent with normal, expected, behavior.")]
		public static ref readonly TElement Peek<TElement>(this IPeekable<TElement> collection) {
			if (collection is null) {
				throw new NullReferenceException();
			}
			return ref collection.Peek();
		}
	}
}
