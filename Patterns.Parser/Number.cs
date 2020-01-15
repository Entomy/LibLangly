using System;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents a number.
	/// </summary>
	internal sealed class Number : Token {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		new public static readonly Pattern Pattern = Many(DecimalDigitNumber);

		/// <summary>
		/// Initialize a new <see cref="Number"/> with the given <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The literal text of the token; how it was parsed.</param>
		private Number(String text) : base(text) { }

		/// <summary>
		/// Attempt to consume a <see cref="Number"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="Number"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		new internal static Number? Consume(ref Source source) {
			Result result = Pattern.Consume(ref source);
			return result ? new Number(result) : null;
		}
	}
}
