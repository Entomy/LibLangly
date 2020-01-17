using System;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a check for the end of a line.
	/// </summary>
	internal sealed class LineEndChecker : Checker {
		/// <summary>
		/// Initializes a new <see cref="LineEndChecker"/>.
		/// </summary>
		internal LineEndChecker() { }

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) {
			switch (source.Peek()) {
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

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			if (source.EOF) {
				trace?.Collect(Error.EndOfSource, source.Position);
				result.Error = Error.EndOfSource;
				return;
			}
			switch (source.Peek()) {
			case '\u000A':
				if (source.EOF) {
					goto Done;
				}
				switch (source.Peek()) {
				case '\u000D':
					trace?.Collect("\u000A\u000D", source.Position);
					source.Position++;
					result.Length++;
					goto Done;
				default:
					// The line terminator is just 0x000A
					break;
				}
				trace?.Collect('\u000A', source.Position);
				break;
			case '\u000B':
				trace?.Collect('\u000B', source.Position);
				break;
			case '\u000C':
				trace?.Collect('\u000C', source.Position);
				break;
			case '\u000D':
				if (source.EOF) {
					goto Done;
				}
				switch (source.Peek()) {
				case '\u000A':
					trace?.Collect("\u000D\u000A", source.Position);
					source.Position++;
					result.Length++;
					goto Done;
				default:
					// The line terminator is just 0x000D
					break;
				}
				trace?.Collect('\u000D', source.Position);
				break;
			case '\u0085':
				trace?.Collect('\u0085', source.Position);
				break;
			case '\u2028':
				trace?.Collect('\u2028', source.Position);
				break;
			case '\u2029':
				trace?.Collect('\u2029', source.Position);
				break;
			default:
				result.Error = Error.ConsumeFailed;
				trace?.Collect(result.Error, source.Position);
				return;
			}
		Done:
			source.Position++;
			result.Length++;
		}


		/// <summary>
		/// Call the Neglect parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) {
			if (source.EOF) {
				result.Error = Error.EndOfSource;
				trace?.Collect(result.Error, source.Position);
				return;
			}
			switch (source.Peek()) {
			case '\u000A':
			case '\u000B':
			case '\u000C':
			case '\u000D':
			case '\u0085':
			case '\u2028':
			case '\u2029':
				result.Error = Error.NeglectFailed;
				trace?.Collect(result.Error, source.Position);
				break;
			default:
				trace?.Collect(source.Peek(), source.Position);
				source.Position++;
				result.Length++;
				break;
			}
		}
	}
}
