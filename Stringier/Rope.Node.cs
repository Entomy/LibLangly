using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public partial class Rope {
		/// <summary>
		/// Represents any node of a <see cref="Rope"/>.
		/// </summary>
		protected abstract class Node : ILengthy, IReadOnlyIndexable<Char> {
			[AllowNull] public Node Next;

			[AllowNull] public Node Previous;

			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="next"></param>
			/// <param name="previous"></param>
			protected Node([AllowNull] Node next, [AllowNull] Node previous) {
				Next = next;
				Previous = previous;
			}

			/// <inheritdoc/>
			public abstract nint Length { get; }

			/// <inheritdoc/>
			public abstract Char this[nint index] { get; }

			internal abstract void Insert(nint index, Char element, out Node head, out Node tail);

			internal abstract void Insert(nint index, [DisallowNull] String element, out Node head, out Node tail);

			internal abstract void Insert(nint index, ReadOnlyMemory<Char> element, out Node head, out Node tail);

			internal abstract unsafe void Insert(nint index, [DisallowNull] Char* element, Int32 length, out Node head, out Node tail);
		}
	}
}
