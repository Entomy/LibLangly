using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Stringier.Patterns;

namespace Langly {
	public abstract partial class Lexeme {
		/// <summary>
		/// Represents a parser object for a <see cref="Lexeme"/>.
		/// </summary>
		protected abstract class Parser : INext<Parser>, IPrevious<Parser>, IUnlink {
			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Parser Next { get; set; }

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Parser Previous { get; set; }

			/// <summary>
			/// Parses the <paramref name="source"/>.
			/// </summary>
			/// <param name="source">The source to parse.</param>
			/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
			/// <param name="trace">The object to trace the steps through the pattern graph in.</param>
			/// <returns>A <see cref="Lexeme"/> if parsing was successful; otherwise, <see langword="null"/>.</returns>
			[return: MaybeNull]
			public abstract Lexeme Parse(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull] IAdd<Capture> trace);

			/// <inheritdoc/>
			public void Unlink() {
				Next = null;
				Previous = null;
			}
		}
	}
}
