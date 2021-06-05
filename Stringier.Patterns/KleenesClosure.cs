using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents the Kleene's Closure (Kleene Star), who's content is optional and may repeat.
	/// </summary>
	internal class KleenesClosure : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Pattern Pattern;

		/// <summary>
		/// Initialize a new <see cref="KleenesClosure"/> from the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed.</param>
		internal KleenesClosure([DisallowNull] Pattern pattern) => Pattern = pattern;

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			// Store the source position and result length, because backtracking has to be done on the entire span unit
			Int32 start = location;
			// Consume as much as possible
			while (exception is null) {
				// Update the positions so we can backtrack this unit
				start = location;
				// Try consuming
				Pattern.Consume(source, ref location, out exception, trace);
				if (exception is not null) {
					// Before we break out, backtrack
					location = start;
				}
			}
			exception = null; // If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) => Pattern.IsConsumeHeader(source, location);

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) => Pattern.IsConsumeHeader(source, location);

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			// Consume as much as possible
			while (exception is null) {
				Pattern.Neglect(source, ref location, out exception, trace);
			}
			exception = null; // As long as the first pattern matched, this consume is successful; we just stop on the eventual fail
		}
	}
}
