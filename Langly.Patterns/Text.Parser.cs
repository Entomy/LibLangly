using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Stringier.Patterns;

namespace Langly.Patterns {
	public sealed partial class Text {
		/// <summary>
		/// Represents a parser object for a <see cref="Text"/>.
		/// </summary>
		private sealed class Parser : Literal.Parser {
			[DisallowNull, NotNull]
			private static readonly Pattern Pattern = Pattern.StringLiteral("\"", "\"");

			/// <inheritdoc/>
			[return: MaybeNull]
			public override Text Parse(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull] IAdd<Capture> trace) {
				Int32 loc = location;
				_ = Pattern.Parse(source, ref location, trace);
				return new Text(loc + 1, location - 1);
			}

			static Parser() => Register(new Parser());
		}
	}
}
