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
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Int32 start = location;
			From.Consume(source, ref location, out exception, trace);
			if (exception is not null) return;
			To.Consume(source, ref location, out exception, trace);
			while (exception is not null) {
				if (location == source.Length) break;
				// Check for the escape before checking for the end of the range
				if (Escape.IsConsumeHeader(source, location)) {
					Escape.Consume(source, ref location, out exception, trace);
					exception = NoMatch; // We need an error to continue the loop, and this is the current error
				}
				if (location == source.Length) break;
				if (To.IsConsumeHeader(source, location)) {
					To.Consume(source, ref location, out exception, trace);
				} else {
					location++;
				}
			}
			if (exception is not null) {
				location = start;
			}
		}

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Int32 start = location;
			From.Consume(source, length, ref location, out exception, trace);
			if (exception is not null) return;
			To.Consume(source, length, ref location, out exception, trace);
			while (exception is not null) {
				if (location == length) break;
				// Check for the escape before checking for the end of the range
				if (Escape.IsConsumeHeader(source, location)) {
					Escape.Consume(source, length, ref location, out exception, trace);
					exception = NoMatch; // We need an error to continue the loop, and this is the current error
				}
				if (location == length) break;
				if (To.IsConsumeHeader(source, location)) {
					To.Consume(source, length, ref location, out exception, trace);
				} else {
					location++;
				}
			}
			if (exception is not null) {
				location = start;
			}
		}
	}
}
