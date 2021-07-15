using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;

namespace Collectathon.Enumerators {
	/// <summary>
	/// Provides enumeration over a standard linked list.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements being enumerated.</typeparam>
	/// <typeparam name="TNode">The type of the nodes being enumerated.</typeparam>
	[StructLayout(LayoutKind.Auto)]
	public struct StandardListEnumerator<TElement, TNode> : ICount, ICurrent<TElement?>, IMoveNext, IReset where TNode : class, IElement<TElement>, INext<TNode> {
		/// <summary>
		/// The head node.
		/// </summary>
		[AllowNull, MaybeNull]
		private readonly TNode Head;

		/// <summary>
		/// The current node.
		/// </summary>
		[AllowNull, MaybeNull]
		private TNode N;

		/// <summary>
		/// Whether enumeration is active or not.
		/// </summary>
		private Boolean Active;

		/// <summary>
		/// Initializes a new <see cref="StandardListEnumerator{TElement, TNode}"/>.
		/// </summary>
		/// <param name="head">The head node of the list.</param>
		/// <param name="length">The length of the sequence.</param>
		public StandardListEnumerator([AllowNull] TNode head, Int32 length) {
			Head = head;
			N = null;
			Active = true;
			Count = length;
		}

		/// <inheritdoc/>
		public TElement? Current => N.Element;

		/// <inheritdoc/>
		public Int32 Count { get; }

		/// <inheritdoc/>
		public Boolean MoveNext() {
			if (Active) {
				N = N is null ? Head : N.Next;
				return Active = N is not null;
			} else {
				return false;
			}
		}

		/// <inheritdoc/>
		public void Reset() => N = null;
	}
}
