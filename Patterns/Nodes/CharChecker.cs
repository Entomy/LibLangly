using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a programatic check of a <see cref="Char"/> for existance within a set, defined by the <see cref="Check"/> function.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It is overriden, Sonar is just too stupid to figure out this pattern")]
	internal sealed class CharChecker : Checker {
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		internal readonly new Func<Char, Boolean> Check;

		/// <summary>
		/// Construct a new <see cref="CharChecker"/> from the specified <paramref name="check"/>.
		/// </summary>
		/// <param name="check">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.</param>
		internal CharChecker(Func<Char, Boolean> check) => Check = check;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><see langword="true"/> if this <see cref="Pattern"/> may be present, <see langword="false"/> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => !source.EOF && Check(source.Peek());

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			if (source.Length == 0) {
				result.Error = Error.EndOfSource;
				trace?.Collect(result.Error, source.Position);
			} else {
				Char Peek = source.Peek();
				if (Check(Peek)) {
					trace?.Collect(Peek, source.Position);
					source.Position++;
					result.Length++;
					result.Error = Error.None;
				} else {
					result.Error = Error.ConsumeFailed;
					trace?.Collect(result.Error, source.Position);
				}
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) {
			if (source.Length == 0) {
				result.Error = Error.EndOfSource;
				trace?.Collect(result.Error, source.Position);
			} else {
				Char Peek = source.Peek();
				if (!Check(Peek)) {
					trace?.Collect(Peek, source.Position);
					source.Position++;
					result.Length++;
					result.Error = Error.None;
				} else {
					result.Error = Error.NeglectFailed;
					trace?.Collect(result.Error, source.Position);
				}
			}
		}

		#region Alternator

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Alternate(Pattern right) {
			switch (right) {
			case CharChecker checker:
				return new AlternateCharChecker(Check, checker.Check);
			default:
				return base.Alternate(right);
			}
		}

		#endregion

		#region Repeater

		/// <summary>
		/// Repeats this <see cref="Pattern"/> <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public override Pattern Repeat(Int32 count) => new RepeatCharChecker(Check, count);

		#endregion
	}
}
