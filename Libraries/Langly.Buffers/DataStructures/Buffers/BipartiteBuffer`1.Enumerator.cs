using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Langly.Traits;

namespace Langly.DataStructures.Buffers {
	public partial class BipartiteBuffer<TElement> {
		/// <inheritdoc/>
		[return: NotNull]
		public override BipartiteBuffer<TElement>.Enumerator GetEnumerator() => new Enumerator(this);

		/// <summary>
		/// Provides enumeration over a <see cref="BipartiteBuffer{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<TElement> {
			/// <summary>
			/// The buffer being enumerated.
			/// </summary>
			[DisallowNull, NotNull]
			private readonly BipartiteBuffer<TElement> Buffer;

			/// <summary>
			/// The current index.
			/// </summary>
			private nint i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="buffer">The buffer to enumerate.</param>
			public Enumerator([DisallowNull] BipartiteBuffer<TElement> buffer) {
				Buffer = buffer;
				i = -1;
			}

			/// <inheritdoc/>
			public TElement Current => Buffer[i];

			/// <inheritdoc/>
			public nint Count => Buffer.Count;

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Count;

			/// <inheritdoc/>
			public void Reset() => i = -1;
		}
	}
}
