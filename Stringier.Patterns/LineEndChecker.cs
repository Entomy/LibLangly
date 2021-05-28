using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a check for the end of a line.
	/// </summary>
	internal sealed class LineEndChecker : Checker {
		/// <summary>
		/// Initializes a new <see cref="LineEndChecker"/>.
		/// </summary>
		internal LineEndChecker() { }

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) {
			switch (source[location]) {
			case '\u000A':
			case '\u000B':
			case '\u000C':
			case '\u000D':
			case '\u0085':
			case '\u2028':
			case '\u2029':
				return true;
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) {
			switch (source[location]) {
			case '\u000A':
			case '\u000B':
			case '\u000C':
			case '\u000D':
			case '\u0085':
			case '\u2028':
			case '\u2029':
				return false;
			default:
				return true;
			}
		}

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		private static void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (source.Length == location) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else {
				exception = null;
				switch (source[location]) {
				case '\u000A':
					if (location + 1 < source.Length && source[location + 1] == '\u000D') {
						trace?.Add(source.Slice(location, 2), location);
						location++;
					} else {
						trace?.Add('\u000A', location);
					}
					break;
				case '\u000B':
					trace?.Add('\u000B', location);
					break;
				case '\u000C':
					trace?.Add('\u000C', location);
					break;
				case '\u000D':
					if (location + 1 < source.Length && source[location + 1] == '\u000A') {
						trace?.Add(source.Slice(location, 2), location);
						location++;
					} else {
						trace?.Add('\u000D', location);
					}
					break;
				case '\u0085':
					trace?.Add('\u0085', location);
					break;
				case '\u2028':
					trace?.Add('\u2028', location);
					break;
				case '\u2029':
					trace?.Add('\u2029', location);
					break;
				default:
					exception = NoMatch;
					trace?.Add(exception, location);
					return;
				}
				location++;
			}
		}

		private static void Neglect(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (source.Length == location) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else {
				switch (source[location]) {
				case '\u000A':
				case '\u000B':
				case '\u000C':
				case '\u000D':
				case '\u0085':
				case '\u2028':
				case '\u2029':
					exception = NoMatch;
					trace?.Add(exception, location);
					break;
				default:
					exception = null;
					trace?.Add(source[location], location++);
					break;
				}
				location++;
			}
		}
	}
}
