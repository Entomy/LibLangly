using System;
using Stringier.Patterns.Debugging;
using Defender;

namespace Stringier.Patterns {
	public abstract partial class Pattern {
		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Result"/> to consume.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</returns>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		public Result Consume(Result source) => Consume(source, null);

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Result"/> to consume.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</returns>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		public Result Consume(Result source, ITrace? trace) {
			Source src = new Source(source);
			return Consume(ref src, trace);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to consume.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</returns>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		public Result Consume(String source) {
			Guard.NotNull(source, nameof(source));
			return Consume(source, null);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to consume.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</returns>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		public Result Consume(String source, ITrace? trace) {
			Guard.NotNull(source, nameof(source));
			Source src = new Source(source);
			return Consume(ref src, trace);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</returns>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		public Result Consume(ref Source source) => Consume(ref source, null);

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</returns>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		public Result Consume(ref Source source, ITrace? trace) {
			Result result = new Result(ref source);
			Int32 OriginalPosition = source.Position;
			Consume(ref source, ref result, trace);
			if (!result) {
				source.Position = OriginalPosition;
			}
			return result;
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal abstract Boolean CheckHeader(ref Source source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		internal void Consume(ref Source source, ref Result result) => Consume(ref source, ref result, null);

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/> and <paramref name="trace"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		internal abstract void Consume(ref Source source, ref Result result, ITrace? trace);

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		internal void Neglect(ref Source source, ref Result result) => Neglect(ref source, ref result, null);

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/> and <paramref name="trace"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		internal abstract void Neglect(ref Source source, ref Result result, ITrace? trace);
	}
}
