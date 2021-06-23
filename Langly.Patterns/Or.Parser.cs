using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Stringier;
using Stringier.Patterns;

namespace Langly.Patterns {
	public sealed partial class Or {
		/// <summary>
		/// Represents a parser object for a <see cref="Or"/>.
		/// </summary>
		private sealed class Parser : Operator.Parser {
			[DisallowNull, NotNull]
			private static readonly Pattern Pattern = ("or", Case.Insensitive);

			/// <inheritdoc/>
			[return: MaybeNull]
			public override Or Parse(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull] IAdd<Capture> trace) {
				Int32 loc = location;
				_ = Pattern.Parse(source, ref location, trace);
				return new Or(loc);
			}
		}
	}
}
