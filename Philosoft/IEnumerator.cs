using System;

namespace Langly {
	/// <summary>
	/// Indicates the collection can be enumerated over.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements to enumerate.</typeparam>
	public interface IEnumerator<TElement> : System.Collections.Generic.IEnumerator<TElement>, IEnumerable<TElement, IEnumerator<TElement>> {
		/// <summary>
		/// Gets the element at the current position.
		/// </summary>
		TElement Current { get; }

		/// <summary>
		/// Advances the enumerator to the next item of the collection.
		/// </summary>
		/// <returns><see langword="true"/> if the enumerator successfully advanced to the next item; <see langword="false"/> if the end of the collection has been passed.</returns>
		Boolean MoveNext();

		/// <summary>
		/// Resets the enumerator to its initial position.
		/// </summary>
		void Reset();

		/// <inheritdoc/>
		IEnumerator<TElement> IEnumerable<TElement, IEnumerator<TElement>>.GetEnumerator() => this;

		/// <inheritdoc/>
		Object System.Collections.IEnumerator.Current => Current;

		/// <inheritdoc/>
		void System.Collections.IEnumerator.Reset() => Reset();

		/// <inheritdoc/>
		void System.IDisposable.Dispose() => GC.SuppressFinalize(this);
	}
}
