using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Langly.DataStructures.Views {
	public partial struct ZipView<TIndex, TElement, TIndexCollection, TElementCollection> : ISequence<(TIndex Index, TElement Element), ZipView<TIndex, TElement, TIndexCollection, TElementCollection>.Enumerator> {
		/// <inheritdoc/>
		[return: NotNull]
		public Enumerator GetEnumerator() => new Enumerator(this);

		/// <summary>
		/// Provides enumeration over a <see cref="ZipView{TIndex, TElement, TIndexCollection, TElementCollection}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<(TIndex Index, TElement Element)> {
			private readonly System.Collections.Generic.IEnumerator<TIndex> Indicies;

			private readonly System.Collections.Generic.IEnumerator<TElement> Elements;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="collection">The <see cref="ZipView{TIndex, TElement, TIndexCollection, TElementCollection}"/> to enumerate.</param>
			public Enumerator(ZipView<TIndex, TElement, TIndexCollection, TElementCollection> collection) {
				Indicies = collection.Indicies.GetEnumerator();
				Elements = collection.Elements.GetEnumerator();
				Count = collection.Count;
			}

			/// <inheritdoc/>
			public (TIndex Index, TElement Element) Current => (Indicies.Current, Elements.Current);

			/// <inheritdoc/>
			public nint Count { get; }

			/// <inheritdoc/>
			public Boolean MoveNext() => Indicies.MoveNext() && Elements.MoveNext();

			/// <inheritdoc/>
			public void Reset() {
				Indicies.Reset();
				Elements.Reset();
			}

			/// <inheritdoc/>
			void IDisposable.Dispose() {
				Indicies.Dispose();
				Elements.Dispose();
				GC.SuppressFinalize(this);
			}
		}
	}
}
