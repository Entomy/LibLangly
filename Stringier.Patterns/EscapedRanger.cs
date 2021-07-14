using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Ranger"/> which supports escape sequences.
	/// </summary>
	/// <remarks>
	/// The escape sequence is intended to allow the <see cref="Ranger.To"/> node to exist inside of the range, it should be considered exactly like a string quote escape inside of a string.
	/// </remarks>
	internal sealed class EscapedRanger : Ranger {
		/// <summary>
		/// The <see cref="Pattern"/> representing the escape sequence.
		/// </summary>
		[DisallowNull, NotNull]
		internal readonly Pattern Escape;

		/// <summary>
		/// Initialize a new <see cref="EscapedRanger"/> with the given <paramref name="from"/>, <paramref name="to"/>, and <paramref name="escape"/> nodes.
		/// </summary>
		/// <param name="from">The <see cref="Pattern"/> to start from.</param>
		/// <param name="to">The <see cref="Pattern"/> to read to.</param>
		/// <param name="escape">The <see cref="Pattern"/> representing the escape sequence.</param>
		internal EscapedRanger([DisallowNull] Pattern from, [DisallowNull] Pattern to, [DisallowNull] Pattern escape) : base(from, to) => Escape = escape;

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			// Save the starting position for backtracking
			Int32 start = location;
			// Consume the start of the range
			From.Consume(source, ref location, out exception, trace);
			// If that failed, the range can't be present here, so abort
			if (exception is not null) return;
			// Try parsing the end of the range
			To.Consume(source, ref location, out exception, trace);
			// While we don't have the end, continue trying to find it
			while (exception is not null) {
				// If we're at the end of the source, break out
				if (location == source.Length) break;
				// Check for the escape before checking for the end of the range
				if (Escape.IsConsumeHeader(source, location)) {
					// It might be here, so try actually consuming the escape
					Escape.Consume(source, ref location, out exception, trace);
					exception = NoMatch; // We need an error to continue the loop, and this is the current error
				}
				// If we're at the end of the source, break out
				if (location == source.Length) break;
				// Check for the end
				if (To.IsConsumeHeader(source, location)) {
					// It might be here, so try actually consuming the end
					To.Consume(source, ref location, out exception, trace);
				} else {
					// Nothing matched, so advance to the next position
					location++;
				}
			}
			// A partial error occured, so backtrack
			if (exception is not null) {
				location = start;
			}
		}
	}
}
