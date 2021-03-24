using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Langly {
	public partial struct Array<TElement> : ISequenceBidi<TElement, Array<TElement>.Enumerator> {
		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(this);

		[return: NotNull]
		public IEnumerator<TElement> Reverse() => throw new NotImplementedException();

		/// <summary>
		/// Provides enumeration over a <see cref="Array{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumeratorBidi<TElement> {
			/// <summary>
			/// The <see cref="Array{TElement}"/> being enumerated.
			/// </summary>
			private readonly Array<TElement> Array;

			private nint i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="array">The <see cref="Array{TElement}"/> to enumerate.</param>
			public Enumerator(Array<TElement> array) {
				Array = array;
				i = -1;
			}

			///<inheritdoc/>
			public TElement Current => Array[i];

			/// <inheritdoc/>
			public nint Count => Array.Count;

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Count;

			/// <inheritdoc/>
			public Boolean MovePrevious() => i-- > 0;

			/// <inheritdoc/>
			public void ResetBeginning() => i = -1;

			/// <inheritdoc/>
			public void ResetEnding() => i = Count;
		}
	}
}
