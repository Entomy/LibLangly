using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Trees;

namespace Collectathon.Enumerators {
	/// <summary>
	/// Provides enumeration over a <see cref="Tree{TElement, TNode, TSelf}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the tree.</typeparam>
	public abstract class TreeEnumerator<TElement> : IEnumerator<TElement> {
		/// <inheritdoc/>
		[MaybeNull]
		public TElement Current { get; }

		/// <inheritdoc/>
		[MaybeNull]
		Object System.Collections.IEnumerator.Current => Current;

		/// <inheritdoc/>
		public abstract Int32 Count { get; }

		/// <inheritdoc/>
		public virtual void Dispose() { /* No-op */ }

		/// <inheritdoc/>
		[return: NotNull]
		public IEnumerator<TElement> GetEnumerator() => this;

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this;

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => this;

		/// <inheritdoc/>
		public abstract Boolean MoveNext();

		/// <inheritdoc/>
		public abstract void Reset();

		/// <inheritdoc/>
		[return: NotNull]
		public sealed override String ToString() => throw new NotImplementedException();

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(Int32 amount) => throw new NotImplementedException();
	}
}
