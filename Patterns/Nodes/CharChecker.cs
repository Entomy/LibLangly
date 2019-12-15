using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;
using Stringier.Patterns.Errors;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a programatic check of a <see cref="Char"/> for existance within a set, defined by the <see cref="Check"/> function.
	/// </summary>
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It is overriden, Sonar is just too stupid to figure out this pattern")]
	internal sealed class CharChecker : Checker {
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		internal readonly new Func<Char, Boolean> Check;

		/// <summary>
		/// Construct a new <see cref="CharChecker"/> from the specified <paramref name="check"/>
		/// </summary>
		/// <param name="name">The name to refer to this as</param>
		/// <param name="check">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		internal CharChecker(String name, Func<Char, Boolean> check) : base(name) => Check = check;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns
		internal override Boolean CheckHeader(ref Source source) => !source.EOF && Check(source.Peek());

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			if (source.Length == 0) {
				result.Error.Set(ErrorType.EndOfSource, this);
				trace?.Collect(result.Error);
			} else {
				Char Peek = source.Peek();
				if (Check(Peek)) {
					trace?.Collect(Peek, source.Position);
					source.Position++;
					result.Length++;
					result.Error.Clear();
				} else {
					result.Error.Set(ErrorType.ConsumeFailed, this);
					trace?.Collect(result.Error);
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
				result.Error.Set(ErrorType.EndOfSource, this);
				trace?.Collect(result.Error);
			} else {
				Char Peek = source.Peek();
				if (!Check(Peek)) {
					trace?.Collect(Peek, source.Position);
					source.Position++;
					result.Length++;
					result.Error.Clear();
				} else {
					result.Error.Set(ErrorType.NeglectFailed, this);
					trace?.Collect(result.Error);
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
				return new AlternateCharChecker(Name, Check, checker.Check);
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
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns
		public override Pattern Repeat(Int32 count) => new RepeatCharChecker(Name, Check, count);

		#endregion
	}
}
