using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;

namespace Collectathon.Stacks {
	public partial class Stack<TElement> {
		/// <summary>
		/// Provides enumeration over a <see cref="Stack{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<TElement> {
			/// <summary>
			/// The stack being enumerated.
			/// </summary>
			[DisallowNull, NotNull]
			private readonly Stack<TElement> Stack;

			/// <summary>
			/// The current node.
			/// </summary>
			[AllowNull, MaybeNull]
			private Node N;

			private nint i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			public Enumerator([DisallowNull] Stack<TElement> stack) {
				Stack = stack;
				N = null;
				i = -1;
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
			public void Reset() {
				N = null;
				i = -1;
			}

			/// <inheritdoc/>
			[return: NotNull]
			public String ToString(nint amount) => throw new NotImplementedException();
		}
	}
}
