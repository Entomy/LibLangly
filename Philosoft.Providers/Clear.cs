using System.Runtime.CompilerServices;

namespace System.Traits.Providers {
	public static partial class Collection {
		/// <summary>
		/// Clears this collection.
		/// </summary>
		/// <typeparam name="TNode">The type of the nodes in the collection.</typeparam>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="tail">The tail node of this collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Clear<TNode>(ref TNode? head, ref TNode? tail) where TNode : class, INext<TNode?>, IUnlink {
			TNode? P = null;
			TNode? N = head;
			while (N is not null) {
				P = N;
				N = N.Next;
				P.Unlink();
			}
			head = null;
			tail = null;
		}
	}
}
