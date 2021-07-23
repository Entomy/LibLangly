using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Providers {
	public static partial class Collection {
		/// <summary>
		/// Pops the top element off this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TNode">The type of the nodes that make up the collection.</typeparam>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="tail">The tail node of this collection.</param>
		/// <param name="element">The element that was popped.</param>
		[MaybeUnlinksNode]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pop<TElement, TNode>(ref TNode? head, ref TNode? tail, out TElement element) where TNode : class, IElement<TElement>, INext<TNode?>, IUnlink {
			if (head is not null) {
				TNode oldHead = head;
				head = head.Next;
				oldHead.Unlink();
				element = oldHead.Element;
			} else {
				throw new InvalidOperationException("Can't pop an element off an empty collection.");
			}
			if (head is null) {
				tail = null;
			}
		}
	}
}
