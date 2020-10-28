using System;
using System.Diagnostics.CodeAnalysis;

namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements popped off.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPoppable<out TElement> {
		/// <summary>
		/// Removes and returns the element at from top of the collection.
		/// </summary>
		/// <returns>The element removed from the top of the collection.</returns>
		TElement Pop();

		/// <summary>
		/// Removes and returns the elements at the top of the collection.
		/// </summary>
		/// <param name="amount">The amount of elements to pop.</param>
		/// <returns>An <see cref="IEnumerable{TElement, TEnumerator}"/> of the elements.</returns>
		System.Collections.Generic.IEnumerable<TElement> Pop(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Pop();
			}
		}
	}

	public static partial class Extensions {
		/// <summary>
		/// Removes and returns the element at from top of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <returns>The element removed from the top of the collection.</returns>
		/// <exception cref="NullReferenceException">Thrown if <paramref name="collection"/> is <see langword="null"/>.</exception>
		[SuppressMessage("Design", "MA0012:Do not raise reserved exception type", Justification = "This is exactly what would be thrown were this pattern not being used, and since we can't handle this, throwing the expected pattern seems far more consistent with normal, expected, behavior.")]
		[SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "This is exactly what would be thrown were this pattern not being used, and since we can't handle this, throwing the expected pattern seems far more consistent with normal, expected, behavior.")]
		public static TElement Pop<TElement>(this IPoppable<TElement> collection) {
			if (collection is null) {
				throw new NullReferenceException();
			}
			return collection.Pop();
		}

		/// <summary>
		/// Removes and returns the elements at the top of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of elements to pop.</param>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <returns>An <see cref="IEnumerable{TElement, TEnumerator}"/> of the elements.</returns>
		/// <exception cref="NullReferenceException">Thrown if <paramref name="collection"/> is <see langword="null"/>.</exception>
		[SuppressMessage("Design", "MA0012:Do not raise reserved exception type", Justification = "This is exactly what would be thrown were this pattern not being used, and since we can't handle this, throwing the expected pattern seems far more consistent with normal, expected, behavior.")]
		[SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "This is exactly what would be thrown were this pattern not being used, and since we can't handle this, throwing the expected pattern seems far more consistent with normal, expected, behavior.")]
		public static System.Collections.Generic.IEnumerable<TElement> Pop<TElement>(this IPoppable<TElement> collection, nint amount) {
			if (collection is null) {
				throw new NullReferenceException();
			}
			return collection.Pop(amount);
		}
	}
}
