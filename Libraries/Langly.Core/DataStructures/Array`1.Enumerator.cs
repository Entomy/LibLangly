using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Langly.Traits;

namespace Langly.DataStructures {
	public partial struct Array<TElement> : ISequence<TElement, Array<TElement>.Enumerator> {
		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(this);

		/// <summary>
		/// Provides enumeration over a <see cref="Array{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<TElement> {
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
			public void Reset() => i = -1;
		}
	}
}
