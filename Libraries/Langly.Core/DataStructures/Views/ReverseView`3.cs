using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Langly.DataStructures.Views {
	/// <summary>
	/// Provides a view of the collection in reverse order.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
	/// <typeparam name="TCollection">The type of the collection.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator of the collection.</typeparam>
	public readonly struct ReverseView<TElement, TCollection, TEnumerator> :
		ISequence<TElement, ReverseView<TElement, TCollection, TEnumerator>.Enumerator>
		where TCollection : ISequenceBidi<TElement, TEnumerator>
		where TEnumerator : IEnumeratorBidi<TElement> {
		/// <summary>
		/// The collection being reversed.
		/// </summary>
		private readonly TCollection Collection;

		/// <summary>
		/// Initializes a new <see cref="ReverseView{TElement, TCollection, TEnumerator}"/>.
		/// </summary>
		/// <param name="collection">The collection to reverse.</param>
		public ReverseView(TCollection collection) => Collection = collection;

		/// <inheritdoc/>
		public nint Count => Collection.Count;

		/// <inheritdoc/>
		[return: NotNull]
		public ReverseView<TElement, TCollection, TEnumerator>.Enumerator GetEnumerator() => new Enumerator(Collection);

		/// <summary>
		/// Provides enumeration over <see cref="ReverseView{TElement, TCollection, TEnumerator}"/>.
		/// </summary>
		/// <remarks>
		/// This effectively allows any bidirectional sequence to be enumerated in reverse, without unique implementations for each.
		/// </remarks>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public readonly struct Enumerator : IEnumerator<TElement> {
			/// <summary>
			/// The bidirectional enumerator of the collection.
			/// </summary>
			private readonly TEnumerator Enum;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="collection">The <typeparamref name="TCollection"/> to enumerate in reverse.</param>
			public Enumerator(TCollection collection) => Enum = collection.GetEnumerator();

			/// <inheritdoc/>
			public TElement Current => Enum.Current;

			/// <inheritdoc/>
			public nint Count => Enum.Count;

			/// <inheritdoc/>
			public Boolean MoveNext() => Enum.MovePrevious();

			/// <inheritdoc/>
			public void Reset() => Enum.ResetEnding();
		}
	}
}
