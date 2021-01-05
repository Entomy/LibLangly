using System;

namespace Langly.DataStructures {
	/// <summary>
	/// Indicates the type is a bidirectional enumerator for sequences of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
	/// <seealso cref="IEnumerator{TElement}"/>
	public interface IEnumeratorBidi<TElement> : IEnumerator<TElement> {
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
		void System.Collections.IEnumerator.Reset() => ResetBeginning();
	}
}
