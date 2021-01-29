using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Langly.DataStructures.Views {
	public readonly partial struct IndexView<TIndex, TElement, TCollection, TEnumerator> : ISequence<TIndex, IndexView<TIndex, TElement, TCollection, TEnumerator>.Enumerator> {
		/// <inheritdoc/>
		[return: NotNull]
		public Enumerator GetEnumerator() => new Enumerator(Collection);

		/// <summary>
		/// Provides enumeration over a <see cref="IndexView{TIndex, TElement, TCollection, TEnumerator}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<TIndex> {
			/// <summary>
			/// The enumerator of the collection being viewed.
			/// </summary>
			[DisallowNull, NotNull]
			private readonly TEnumerator Enum;

			/// <summary>
			/// Initializes a new <see cref="IndexView{TIndex, TElement, TCollection, TEnumerator}"/>.
			/// </summary>
			/// <param name="collection">The collection to enumerate.</param>
			public Enumerator([DisallowNull] TCollection collection) => Enum = collection.GetEnumerator();

			/// <inheritdoc/>
			public TIndex Current => Enum.Current.Index;

			/// <inheritdoc/>
			public nint Count => Enum.Count;

			/// <inheritdoc/>
			public Boolean MoveNext() => Enum.MoveNext();

			/// <inheritdoc/>
			public void Reset() => Enum.Reset();
		}
	}
}
