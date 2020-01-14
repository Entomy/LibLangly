using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Checker"/> specialized for the way words are typically represented and read.
	/// </summary>
	/// <remarks>
	/// This can be thought of as a specialization of <see cref="StringChecker"/>, in that they both match arrays of characters, but the way they match is fundamentally different.
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It is overriden, Sonar is just too stupid to figure out this pattern")]
	internal sealed class WordChecker : Checker {
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		internal readonly Func<Char, Boolean> BodyCheck;
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		internal readonly Func<Char, Boolean> HeadCheck;
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		internal readonly Func<Char, Boolean> TailCheck;

		/// <summary>
		/// Whether the word is head or tail biased.
		/// </summary>
		/// <remarks>
		/// Bias refers to whether the head or tail character is the most important in recognizing a valid match. In instances where there are a very limited amount of possible matching characters, this determines how an exact match is determined.
		/// </remarks>
		private readonly Bias Bias;

		/// <summary>
		/// Initialize a new <see cref="WordChecker"/> with the specified <paramref name="bias"/>, <paramref name="headCheck"/>, <paramref name="bodyCheck"/>, and <paramref name="tailCheck"/>.
		/// </summary>
		/// <param name="bias">Whether the word is head or tail biased.</param>
		/// <param name="headCheck">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		/// <param name="bodyCheck">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		/// <param name="tailCheck">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		internal WordChecker(Bias bias, Func<Char, Boolean> headCheck, Func<Char, Boolean> bodyCheck, Func<Char, Boolean> tailCheck) {
			Bias = bias;
			HeadCheck = headCheck;
			BodyCheck = bodyCheck;
			TailCheck = tailCheck;
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => !source.EOF && HeadCheck(source.Peek());

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			//If we reached the end of the source we have an error
			if (source.EOF) {
				result.Error = Error.EndOfSource;
				return;
			}
			//Now do the appropriate parse
			switch (Bias) {
			case Bias.Tail:
				ConsumeTailBiased(ref source, ref result);
				break;
			default:
				ConsumeHeadBiased(ref source, ref result);
				break;
			}
		}

		private void ConsumeHeadBiased(ref Source Source, ref Result Result) {
			//We'll need to make sure we find the bias
			Boolean FoundBias = false;
			//Check for the head
			if (HeadCheck(Source.Peek())) {
				//If it's found, advance, and mark that we found the bias
				Source.Position++;
				Result.Length++;
				FoundBias = true;
			} else {
				//The head wasn't found so set the error
				Result.Error = Error.ConsumeFailed;
				return;
			}
			//Now deal with the entire body
			while (true) {
				//If we reached the end of the source
				if (Source.EOF) {
					//Backtrack so we can check for the tail
					Source.Position--;
					Result.Length--;
					//And also claim the bias was never found, so we can do a special check later
					FoundBias = false;
					break;
				}
				//Check for the body
				if (BodyCheck(Source.Peek())) {
					//If it's found, advance
					Source.Position++;
					Result.Length++;
				} else {
					//If it's not, break out so we can check for the tail
					break;
				}
			}
			//Check for the tail
			if (TailCheck(Source.Peek())) {
				//If it's found, advance and return
				Source.Position++;
				Result.Length++;
				return;
			} else {
				//The tail wasn't found so we need to do some trickery
				//Check for the head again, but only if the head was not found earlier
				if (!FoundBias && HeadCheck(Source.Peek())) {
					//If it's found, advance and return
					Source.Position++;
					Result.Length++;
					//And then check for the tail again, but only if we're not at the end already
					if (!Source.EOF) {
						if (TailCheck(Source.Peek())) {
							//If it's found, advance and return
							Source.Position++;
							Result.Length++;
						} else {
							//If it's not, set the error
							Result.Error = Error.ConsumeFailed;
						}
					}
					return;
				} else {
					//If it's not, have we found the bias?
					if (!FoundBias) {
						//We haven't so set the error
						Result.Error = Error.ConsumeFailed;
					}
					return;
				}
			}
		}

		[SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "Good luck doing efficient text parsing without ever using a goto")]
		private void ConsumeTailBiased(ref Source Source, ref Result Result) {
			//Check for the head
			if (HeadCheck(Source.Peek())) {
				//If it's found, advance
				Source.Position++;
				Result.Length++;
			} else {
				//The head wasn't found, so check for the tail
				if (TailCheck(Source.Peek())) {
					//If it's found, advance, and return
					Source.Position++;
					Result.Length++;
					return;
				} else {
					//If it's not, set the error
					Result.Error = Error.ConsumeFailed;
					return;
				}
			}
			//Now deal with the entire body
			Boolean FoundBody = false;
			while (true) {
				//If we reached the end of the source
				if (Source.EOF) {
					//Backtrack so we can check for the tail
					Source.Position--;
					Result.Length--;
					break;
				}
				//Check for the body
				if (BodyCheck(Source.Peek())) {
					//If it's found, advance
					Source.Position++;
					Result.Length++;
					FoundBody = true;
				} else {
					//If it's not, break out so we can check for the tail
					break;
				}
			}
			//Check for the tail
			Boolean BacktrackedForTail = false;
		//If we're at the end of the source, backtrack, and check for the tail
		TailCheck:
			if (TailCheck(Source.Peek())) {
				//If it's found, advance and return
				Source.Position++;
				Result.Length++;
				return;
			} else {
				//The tail wasn't found so we need to do some trickery
				//If we found the body but haven't found the tail, backtrack in case the last character was a valid tail
				if (FoundBody && !BacktrackedForTail) {
					Source.Position--;
					Result.Length--;
					BacktrackedForTail = true;
					goto TailCheck;
				} else {
					//The tail wasn't found so set the error
					Result.Error = Error.ConsumeFailed;
					return;
				}
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) => throw new NotImplementedException();
	}
}
