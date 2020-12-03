using System;

namespace Langly {
	/// <summary>
	/// Indicates the collection can be enumerated over, forward or reverse.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements to enumerate.</typeparam>
	public interface IReversibleEnumerator<TElement> : IEnumerator<TElement> {
		/// <summary>
		/// Retracts the enumerator to the previous item of the collection.
		/// </summary>
		/// <returns><see langword="true"/> if the enumerator successfully retracted to the next item; <see langword="false"/> if the beginning of the collection has been passed.</returns>
		Boolean MovePrevious();

		/// <summary>
		/// Resets the enumerator to the beginning position for forward enumeration.
		/// </summary>
		void ResetBeginning();

		/// <summary>
		/// Resets the enumerator to the ending position for reverse enumeration.
		/// </summary>
		void ResetEnding();

		/// <inheritdoc/>
		void IEnumerator<TElement>.Reset() => ResetBeginning();
	}
}
