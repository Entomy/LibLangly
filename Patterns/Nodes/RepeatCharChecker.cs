using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;
using Stringier.Patterns.Errors;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents the repetition of <see cref="CharChecker"/>.
	/// </summary>
	/// <remarks>
	/// This is an optimization, and doesn't do anything that normal repeater wouldn't be able to do.
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It is overriden, Sonar is just too stupid to figure out this pattern")]
	internal sealed class RepeatCharChecker : Checker {
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		internal readonly new Func<Char, Boolean> Check;

		/// <summary>
		/// The amount of times to repeat.
		/// </summary>
		internal readonly Int32 Count;

		/// <summary>
		/// Initialize a new <see cref="RepeatCharChecker"/> from the specified <paramref name="name"/>, <paramref name="check"/>, and <paramref name="count"/>.
		/// </summary>
		/// <param name="name">The name to refer to this as</param>
		/// <param name="check">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </param>
		/// <param name="count">The amount of times to repeat.</param>
		internal RepeatCharChecker(String name, Func<Char, Boolean> check, Int32 count) : base(name) {
			Check = check;
			Count = count;
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => !source.EOF && Check(source.Peek());

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			if (source.EOF) {
				result.Error.Set(ErrorType.EndOfSource, this);
			} else {
				for (Int32 i = 0; i < Count; i++) {
					if (source.EOF) {
						result.Error.Set(ErrorType.ConsumeFailed, this);
					}
					if (Check(source.Peek())) {
						source.Position++;
						result.Length++;
						result.Error.Clear();
					} else {
						result.Error.Set(ErrorType.ConsumeFailed, this);
						break;
					}
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
			if (source.EOF) {
				result.Error.Set(ErrorType.EndOfSource, this);
			} else {
				for (Int32 i = 0; i < Count; i++) {
					if (source.EOF) {
						result.Error.Set(ErrorType.NeglectFailed, this);
					}
					if (!Check(source.Peek())) {
						source.Position++;
						result.Length++;
						result.Error.Clear();
					} else {
						result.Error.Set(ErrorType.NeglectFailed, this);
						break;
					}
				}
			}
		}
	}
}
