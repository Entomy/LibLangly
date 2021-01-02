namespace Langly {
	/// <summary>
	/// Indicates the type is an enumerator for sequences of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
	public interface IEnumerator<out TElement> : System.Collections.Generic.IEnumerator<TElement>, ISequence<TElement, IEnumerator<TElement>> {
		/// <inheritdoc/>
		System.Object System.Collections.IEnumerator.Current => Current;

		/// <inheritdoc/>
		void System.IDisposable.Dispose() => System.GC.SuppressFinalize(this);
	}
}
