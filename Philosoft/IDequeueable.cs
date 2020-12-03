using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the collection can have elements dequeued.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IDequeueable<out TElement> {
		/// <summary>
		/// Removes and returns the element from the beginning of the collection.
		/// </summary>
		/// <returns>The element that is removed from the beginning of the collection.</returns>
		TElement Dequeue();

		/// <summary>
		/// Removes and returns the elements from the beginning of the collection.
		/// </summary>
		/// <param name="amount">The amount of elements to dequeue.</param>
		/// <returns>An <see cref="IEnumerable{TElement, TEnumerator}"/> of the elements.</returns>
		System.Collections.Generic.IEnumerable<TElement> Dequeue(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Dequeue();
			}
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Removes and returns the element from the beginning of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <returns>The element that is removed from the beginning of the collection.</returns>
		/// <exception cref="NullReferenceException">Thrown if <paramref name="collection"/> is <see langword="null"/>.</exception>
		[SuppressMessage("Design", "MA0012:Do not raise reserved exception type", Justification = "This is exactly what would be thrown were this pattern not being used, and since we can't handle this, throwing the expected pattern seems far more consistent with normal, expected, behavior.")]
		[SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "This is exactly what would be thrown were this pattern not being used, and since we can't handle this, throwing the expected pattern seems far more consistent with normal, expected, behavior.")]
		public static TElement Dequeue<TElement>(this IDequeueable<TElement> collection) {
			if (collection is null) {
				throw new NullReferenceException();
			}
			return collection.Dequeue();
		}

		/// <summary>
		/// Removes and returns the elements from the beginning of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of elements to dequeue.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <returns>An <see cref="IEnumerable{TElement, TEnumerator}"/> of the elements.</returns>
		/// <exception cref="NullReferenceException">Thrown if <paramref name="collection"/> is <see langword="null"/>.</exception>
		[SuppressMessage("Design", "MA0012:Do not raise reserved exception type", Justification = "This is exactly what would be thrown were this pattern not being used, and since we can't handle this, throwing the expected pattern seems far more consistent with normal, expected, behavior.")]
		[SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "This is exactly what would be thrown were this pattern not being used, and since we can't handle this, throwing the expected pattern seems far more consistent with normal, expected, behavior.")]
		public static System.Collections.Generic.IEnumerable<TElement> Dequeue<TElement>(this IDequeueable<TElement> collection, nint amount) {
			if (collection is null) {
				throw new ArgumentNullException();
			}
			return collection.Dequeue(amount);
		}
	}
}
