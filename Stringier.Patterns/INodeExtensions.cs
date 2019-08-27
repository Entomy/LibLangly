using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal static class INodeExtensions {
		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see name="Pattern"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		internal static Result Neglect(this INode INode, String Source) {
			Source source = new Source(Source);
			return INode.Neglect(ref source);
		}

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see cref="ComplexPattern"/>
		/// </summary>
		/// <param name="Source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		internal static Result Neglect(this INode INode, ReadOnlySpan<Char> Source) {
			Source source = new Source(Source);
			return INode.Neglect(ref source);
		}
	}
}
