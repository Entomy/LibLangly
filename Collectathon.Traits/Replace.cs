using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits {
	public static partial class Collection {
		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Replace<TNode, TElement>([DisallowNull] TNode head, [AllowNull] TElement search, [AllowNull] TElement replace) where TNode : class, INext<TNode>, IReplace<TElement> {
			TNode? N = head;
			while (N is not null) {
				N.Replace(search, replace);
				N = N.Next;
			}
		}
	}
}
