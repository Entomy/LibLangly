using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Langly.DataStructures {
	public partial class Stack<TElement> {
		/// <inheritdoc/>
		[return: NotNull]
		public override Enumerator GetEnumerator() => new Enumerator(this);

		/// <summary>
		/// Provides the enumerator for <see cref="Stack{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<TElement> {
			/// <summary>
			/// The stack being enumerated.
			/// </summary>
			[DisallowNull]
			private readonly Stack<TElement> Stack;

			[AllowNull]
			private Node N;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="stack">The stack to enumerate.</param>
			public Enumerator([DisallowNull] Stack<TElement> stack) {
				Stack = stack;
				N = null;
			}

			/// <inheritdoc/>
			public TElement Current => N.Element;

			/// <inheritdoc/>
			public nint Count => Stack.Count;

			/// <inheritdoc/>
			public Boolean MoveNext() {
				N = N is null ? Stack.Head : N.Next;
				return N is not null;
			}

			/// <inheritdoc/>
			public void Reset() => N = null;
		}
	}
}
