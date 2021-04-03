using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Langly.Traits;

namespace Langly.DataStructures {
	public partial class Counter<TElement> : ISequence<TElement, Counter<TElement>.Enumerator> {
		/// <inheritdoc/>
		[return: NotNull]
		public Enumerator GetEnumerator() => new Enumerator(this);

		/// <summary>
		/// Provides enumeration over a <see cref="Counter{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<TElement> {
			/// <summary>
			/// The <see cref="Counter{TElement}"/> being enumerated.
			/// </summary>
			[DisallowNull, NotNull]
			private readonly Counter<TElement> Counter;

			[AllowNull, MaybeNull]
			private Node N;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="counter">The <see cref="Counter{TElement}"/> to enumerate.</param>
			public Enumerator([DisallowNull] Counter<TElement> counter) {
				Counter = counter;
				N = null;
			}

			/// <inheritdoc/>
			[MaybeNull]
			public TElement Current => N.Index;

			/// <inheritdoc/>
			public nint Count => Counter.Count;

			/// <inheritdoc/>
			public Boolean MoveNext() {
				if (N is null) {
					N = Counter.Head;
				} else {
					N = N.Next;
				}
				return N is not null;
			}

			/// <inheritdoc/>
			public void Reset() => N = null;
		}
	}
}
