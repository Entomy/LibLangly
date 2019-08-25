using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal static class IParserExtensions {
		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		internal static Result Consume(this IParser Parser, String Source) {
			Source source = new Source(Source);
			return Parser.Consume(ref source);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		internal static Result Consume(this IParser Parser, ReadOnlySpan<Char> Source) {
			Source source = new Source(Source);
			return Parser.Consume(ref source);
		}
	}
}
