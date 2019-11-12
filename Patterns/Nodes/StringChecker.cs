using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Errors;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Checker"/> specialized for generic "strings" of characters.
	/// </summary>
	/// <remarks>
	/// This is a generalization, but not a universal generalization. It makes some assumptions.
	/// The general approach to how this works is that the "head" is only present zero or one times, the "body" is present zero or many times, and the "tail" is only present zero or one times. Various boolean flags control this behavior.
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It is overriden, Sonar is just too stupid to figure out this pattern")]
	internal sealed class StringChecker : Checker, IEquatable<StringChecker> {
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		internal readonly Func<Char, Boolean> HeadCheck;

		/// <summary>
		/// Whether the <see cref="HeadCheck"/> must be present.
		/// </summary>
		internal readonly Boolean HeadRequired = true;

		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		internal readonly Func<Char, Boolean> BodyCheck;

		/// <summary>
		/// Whether the <see cref="BodyCheck"/> must be present.
		/// </summary>
		internal readonly Boolean BodyRequired = true;

		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		internal readonly Func<Char, Boolean> TailCheck;

		/// <summary>
		/// Whether the <see cref="TailCheck"/> must be present.
		/// </summary>
		internal readonly Boolean TailRequired = true;

		/// <summary>
		/// Initialize a new <see cref="StringChecker"/> with the specified <paramref name="name"/>, <paramref name="headCheck"/>, <paramref name="bodyCheck"/>, and <paramref name="tailCheck"/>. All checks are required.
		/// </summary>
		/// <param name="name">The name to refer to this as</param>
		/// <param name="headCheck">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		/// <param name="bodyCheck">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		/// <param name="tailCheck">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		internal StringChecker(String name, Func<Char, Boolean> headCheck, Func<Char, Boolean> bodyCheck, Func<Char, Boolean> tailCheck) : base(name) {
			HeadCheck = headCheck;
			BodyCheck = bodyCheck;
			TailCheck = tailCheck;
		}

		/// <summary>
		/// Initialize a new <see cref="StringChecker"/> with the specified <paramref name="name"/>, <paramref name="headCheck"/>, <paramref name="bodyCheck"/>, and <paramref name="tailCheck"/>. Whether checks are required are explit through <paramref name="headRequired"/>, <paramref name="bodyRequired"/>, and <paramref name="tailRequired"/>; at least one must be <c>true</c>.
		/// </summary>
		/// <param name="name">The name to refer to this as</param>
		/// <param name="headCheck">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		/// <param name="headRequired"
		/// <param name="bodyCheck">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		/// <param name="bodyRequired"
		/// <param name="tailCheck">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		/// <param name="tailRequired"
		internal StringChecker(String name, Func<Char, Boolean> headCheck, Boolean headRequired, Func<Char, Boolean> bodyCheck, Boolean bodyRequired, Func<Char, Boolean> tailCheck, Boolean tailRequired) : this(name, headCheck, bodyCheck, tailCheck) {
			if (!headRequired && !bodyRequired && !tailRequired) { throw new PatternConstructionException("At least one component must be required"); }
			HeadRequired = headRequired;
			BodyRequired = bodyRequired;
			TailRequired = tailRequired;
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</
		internal override Boolean CheckHeader(ref Source source) => !source.EOF && HeadCheck(source.Peek());

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</
		internal override void Consume(ref Source source, ref Result result) {
			//The constructors should catch this situation first, but it should still be checked here in case someone forgot
			if (!HeadRequired && !BodyRequired && !TailRequired) { throw new PatternConstructionException("At least one component must be required"); }
			//To make this easier to reason about, the implementation has been split, and this function actually just calls the requested one
			//This actually causes a small amount of optimization, beleive it or not. In a unified approach, two of these checks would have to occur inside of the body loop, and multiple times within the same iteration, which means they are repeated several times instead of just once here. This also prevents possible branch misprediction problems.
			Boolean FoundBody;
			if (HeadRequired) {
				ConsumeRequiredHead(ref source, ref result, out FoundBody);
			} else {
				ConsumeOptionalHead(ref source, ref result, out FoundBody);
			}
			if (BodyRequired) {
				ConsumeRequiredBody(ref source, ref result, ref FoundBody);
			} else {
				ConsumeOptionalBody(ref source, ref result, ref FoundBody);
			}
			if (TailRequired) {
				ConsumeRequiredTail(ref source, ref result, in FoundBody);
			} else {
				ConsumeOptionalTail(ref source, ref result, in FoundBody);
			}
			//Because these are generalized, they don't validate length, so we do that now
			if ((HeadRequired && BodyRequired && TailRequired && result.Length < 3) //If all three are required, the length must be at least 3
			|| (!(HeadRequired ^ BodyRequired ^ TailRequired) && result.Length < 2) //If two are required, the length must be at least 2
			|| (HeadRequired ^ BodyRequired ^ TailRequired && result.Length < 1)) { //If only one is required, the length must be at least 1
				result.Error.Set(ErrorType.ConsumeFailed, this);
			}
		}

		private void ConsumeRequiredHead(ref Source source, ref Result result, out Boolean foundBody) {
			//We have to output this
			foundBody = false;
			//If we reached the end of the source we have an error
			if (source.EOF) {
				result.Error.Set(ErrorType.EndOfSource, this);
				return;
			}
			//Check for the head
			if (HeadCheck(source.Peek())) {
				//If it's found, advance
				source.Position++;
				result.Length++;
			} else {
				//If it's not, we have an error
				result.Error.Set(ErrorType.ConsumeFailed, this);
				return;
			}
		}

		private void ConsumeOptionalHead(ref Source source, ref Result result, out Boolean foundBody) {
			//We have to output this, so default to false and we'll set it to true if we find it
			foundBody = false;
			//If we reached the end of the source we have an error
			if (source.EOF) {
				result.Error.Set(ErrorType.EndOfSource, this);
				return;
			}
			//The head isn't required, so we're going to check for the body first
			if (BodyCheck(source.Peek())) {
				//The body was found, so set it to true
				foundBody = true;
			} else if (!HeadCheck(source.Peek())) {
				//The head wasn't found, so we have an error
				result.Error.Set(ErrorType.ConsumeFailed, this);
				return;
			}
			//So regardless of whether the head or body was found, advance like normal. If the body was found, we've already marked that.
			source.Position++;
			result.Length++;
		}

		private void ConsumeRequiredBody(ref Source source, ref Result result, ref Boolean foundBody) {
			//Loop repeatedly, we'll break out internally
			while (true) {
				//If we reached the end of the source, backtrack so we can check for the tail
				if (source.EOF) {
					source.Position--;
					result.Length--;
					return;
				}
				//Check for the body
				if (BodyCheck(source.Peek())) {
					//The body was found, so advance and set it to true, then continue the loop
					source.Position++;
					result.Length++;
					foundBody = true;
					continue;
				} else {
					//Something else was found, so backtrack so we can check for the tail
					source.Position--;
					result.Length--;
					return;
				}
			}
		}

		private void ConsumeOptionalBody(ref Source source, ref Result result, ref Boolean foundBody) {
			// This isn't parsed any differently, so just chain
			ConsumeRequiredBody(ref source, ref result, ref foundBody);
			// It's optional, but Consume__Tail() wants to know if it was found, so just say it was regardless
			foundBody = true;
		}

		private void ConsumeRequiredTail(ref Source source, ref Result result, in Boolean foundBody) {
			//If we reached the end of the source we have an error
			if (source.EOF) {
				result.Error.Set(ErrorType.EndOfSource, this);
				return;
			}
			//Check for the tail
			if (TailCheck(source.Peek())) {
				//Have we found the body earlier?
				if (!foundBody) {
					//If not, set the error
					result.Error.Set(ErrorType.ConsumeFailed, this);
					return;
				}
				//We found the tail, so advance
				source.Position++;
				result.Length++;
			} else {
				//No tail was found, so set the error
				result.Error.Set(ErrorType.ConsumeFailed, this);
			}
		}

		private void ConsumeOptionalTail(ref Source source, ref Result result, in Boolean foundBody) {
			//If we reached the end of the source we have an error
			if (source.EOF) {
				result.Error.Set(ErrorType.EndOfSource, this);
				return;
			}
			//Have we found the body earlier?
			if (!foundBody) {
				//If not, set the error
				result.Error.Set(ErrorType.ConsumeFailed, this);
				return;
			}
			// We never actually check for the tail, because it doesn't matter. When checking the body, it progressed as far as it could, and either is right in front of the tail, or reached the end of source and backtracked. Both situations have us right before the "tail", which is either actually the tail, or the last part of the body which needs to be reconsumed. So optimize out the check and just advance
			source.Position++;
			result.Length++;
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</
		internal override void Neglect(ref Source source, ref Result result) => throw new NotImplementedException();

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Node"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.
		public override Boolean Equals(Node node) {
			switch (node) {
			case StringChecker other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="AlternateCharChecker"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.
		public Boolean Equals(StringChecker other) => HeadCheck.Equals(other.HeadCheck) && BodyCheck.Equals(other.BodyCheck) && TailCheck.Equals(other.TailCheck);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns
		public override Int32 GetHashCode() => HeadCheck.GetHashCode() ^ BodyCheck.GetHashCode() ^ TailCheck.GetHashCode();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns
		public override String ToString() => $"┋{Name}┋";
	}
}
