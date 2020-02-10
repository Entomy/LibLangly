using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Ranger"/> which supports escape sequences.
	/// </summary>
	/// <remarks>
	/// The escape sequence is intended to allow the <see cref="Ranger.To"/> node to exist inside of the range, it should be considered exactly like a string quote escape inside of a string.
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class EscapedRanger : Ranger {
		/// <summary>
		/// The <see cref="Pattern"/> representing the escape sequence.
		/// </summary>
		internal readonly Pattern Escape;

		/// <summary>
		/// Initialize a new <see cref="EscapedRanger"/> with the given <paramref name="from"/>, <paramref name="to"/>, and <paramref name="escape"/> nodes.
		/// </summary>
		/// <param name="from">The <see cref="Pattern"/> to start from.</param>
		/// <param name="to">The <see cref="Pattern"/> to read to.</param>
		/// <param name="escape">The <see cref="Pattern"/> representing the escape sequence.</param>
		internal EscapedRanger(Pattern from, Pattern to, Pattern escape) : base(from, to) => Escape = escape;

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			From.Consume(ref source, ref result, trace);
			if (!result) {
				result.Error = Error.ConsumeFailed;
				return;
			}
			To.Consume(ref source, ref result, trace);
			while (!result) {
				if (source.EOF) {
					break;
				}
				source.Position++;
				result.Length++;
				//Check for the escape before checking for the end of the range
				if (Escape.CheckHeader(ref source)) {
					Escape.Consume(ref source, ref result, trace);
					result.Error = Error.ConsumeFailed; //We need an error to continue the loop, and this is the current error
				}
				if (To.CheckHeader(ref source)) {
					To.Consume(ref source, ref result, trace);
				}
			}
			if (!result) {
				result.Error = Error.EndOfSource;
			}
		}
	}
}
