using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Patterns.Pattern"/> who's content can span. That is, as long as it is present once, can repeat multiple times past that point.
	/// </summary>
	internal sealed class Spanner : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Pattern Pattern;

		/// <summary>
		/// Initialize a new <see cref="Spanner"/> from the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed.</param>
		internal Spanner([DisallowNull] Pattern pattern) => Pattern = pattern;

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Many() => this;

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Maybe() => new KleenesClosure(Pattern);

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			// Store the source position and result length, because backtracking has to be done on the entire span unit
			Int32 start = location;
			// We need to confirm the pattern exists at least once
			Pattern.Consume(source, ref location, out exception, trace);
			if (exception is not null) {
				// Backtrack
				location = start;
				return;
			}
			// Now continue to consume as much as possible
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
			exception = null; // As long as the first pattern matched, this consume is successful; we just stop on the eventual fail
		}

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			// Store the source position and result length, because backtracking has to be done on the entire span unit
			Int32 start = location;
			// We need to confirm the pattern exists at least once
			Pattern.Consume(source, length, ref location, out exception, trace);
			if (exception is not null) {
				// Backtrack
				location = start;
				return;
			}
			// Now continue to consume as much as possible
			while (exception is null) {
				// Update the positions so we can backtrack this unit
				start = location;
				// Try consuming
				Pattern.Consume(source, length, ref location, out exception, trace);
				if (exception is not null) {
					// Before we break out, backtrack
					location = start;
				}
			}
			exception = null; // As long as the first pattern matched, this consume is successful; we just stop on the eventual fail
		}

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			// We need to confirm the pattern exists at least once
			Pattern.Neglect(source, ref location, out exception, trace);
			if (exception is not null) return;
			// Now continue to consume as much as possible
			while (exception is null) {
				Pattern.Neglect(source, ref location, out exception, trace);
			}
			exception = null; // As long as the first pattern matched, this consume is successful; we just stop on the eventual fail
		}

		/// <inheritdoc/>
		protected internal override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			// We need to confirm the pattern exists at least once
			Pattern.Neglect(source, location, ref location, out exception, trace);
			if (exception is not null) return;
			// Now continue to consume as much as possible
			while (exception is null) {
				Pattern.Neglect(source, location, ref location, out exception, trace);
			}
			exception = null; // As long as the first pattern matched, this consume is successful; we just stop on the eventual fail
		}
	}
}
