using System;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Ranger"/> which supports nesting of the range.
	/// </summary>
	internal sealed class NestedRanger : Ranger {
		/// <summary>
		/// The current nesting level.
		/// </summary>
		private Int32 Level;

		/// <summary>
		/// Initialize a new <see cref="NestedRanger"/> with the given <paramref name="from"/> and <paramref name="to"/>
		/// </summary>
		/// <param name="from">The <see cref="Pattern"/> to start from.</param>
		/// <param name="to">The <see cref="Pattern"/> to read to.</param>
		internal NestedRanger(Pattern from, Pattern to) : base(from, to) => Level = 0;

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			From.Consume(ref source, ref result, trace);
			if (result) {
				Level++;
			}
			while (Level > 0) {
				if (source.EOF) {
					break;
				}
				source.Position++;
				result.Length++;
				if (From.CheckHeader(ref source)) {
					From.Consume(ref source, ref result, trace);
					if (result) {
						Level++;
					}
				}
				if (To.CheckHeader(ref source)) {
					To.Consume(ref source, ref result, trace);
					if (result) {
						Level--;
					}
				}
			}
			if (Level != 0) {
				result.Error = Error.ConsumeFailed;
			}
		}
	}
}
