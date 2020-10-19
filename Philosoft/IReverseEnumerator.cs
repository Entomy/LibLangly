using System;

namespace Philosoft {
	/// <summary>
	/// Incidates the collection can be enumerated over in reverse.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements to enumerate.</typeparam>
	public interface IReverseEnumerator<TElement> : IReverseEnumerable<TElement, IReverseEnumerator<TElement>> {
		/// <summary>
		/// Gets the element at the current position.
		/// </summary>
		TElement Current { get; }

		/// <summary>
		/// Advances the enumerator to the previous item of the collection.
		/// </summary>
		/// <returns><see langword="true"/> if the enumerator successfully advanced to the next item; <see langword="false"/> if the begining of the collection has been passed.</returns>
		Boolean MoveNext();

		/// <summary>
		/// Resets the enumerator to its initial position.
		/// </summary>
		void Reset();
	}
}
