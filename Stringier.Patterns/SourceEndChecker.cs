using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a check for the end of the source.
	/// </summary>
	internal sealed class SourceEndChecker : Checker {

		/// <summary>
		/// Initializes a new <see cref="SourceEndChecker"/>.
		/// </summary>
		internal SourceEndChecker() { }

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (source.Length != location) {
				exception = NoMatch;
				trace?.Add(exception, location);
			} else {
				trace?.Add('␄', location);
				exception = null;
			}
		}

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) => location == source.Length;

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) => location != source.Length;

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (source.Length == location) {
				exception = NoMatch;
				trace?.Add(exception, location);
			} else {
				trace?.Add('␄', location);
				exception = null;
			}
		}
	}
}
