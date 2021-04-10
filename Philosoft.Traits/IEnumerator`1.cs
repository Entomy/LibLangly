using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type is an enumerator for sequences of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
	public interface IEnumerator<TElement> : System.Collections.Generic.IEnumerator<TElement>, ISequence<TElement, IEnumerator<TElement>> {
		/// <inheritdoc/>
		[SuppressMessage("Performance", "HAA0601:Value type to reference type conversion causing boxing allocation", Justification = "There's nothing I can do about this.")]
		System.Object System.Collections.IEnumerator.Current => Current;

		/// <inheritdoc/>
		void System.IDisposable.Dispose() => GC.SuppressFinalize(this);

		/// <inheritdoc/>
		IEnumerator<TElement> ISequence<TElement, IEnumerator<TElement>>.GetEnumerator() => this;

		/// <inheritdoc/>
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => this;

		/// <inheritdoc/>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this;
	}
}
