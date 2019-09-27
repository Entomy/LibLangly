using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class WordChecker : Checker, IEquatable<WordChecker> {
		internal readonly Func<Char, Boolean> BodyCheck;
		internal readonly Func<Char, Boolean> HeadCheck;
		internal readonly Func<Char, Boolean> TailCheck;
		private readonly Bias Bias;
		internal WordChecker(String Name, Bias Bias, Func<Char, Boolean> HeadCheck, Func<Char, Boolean> BodyCheck, Func<Char, Boolean> TailCheck) : base(Name) {
			this.Bias = Bias;
			this.HeadCheck = HeadCheck;
			this.BodyCheck = BodyCheck;
			this.TailCheck = TailCheck;
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case StringChecker other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(WordChecker other) => Bias.Equals(other.Bias) && HeadCheck.Equals(other.HeadCheck) && BodyCheck.Equals(other.BodyCheck) && TailCheck.Equals(other.TailCheck);

		public override Int32 GetHashCode() => Bias.GetHashCode() ^ HeadCheck.GetHashCode() ^ BodyCheck.GetHashCode() ^ TailCheck.GetHashCode();

		public override String ToString() => $"┋{Name}┋";

		internal override Boolean CheckHeader(ref Source Source) => Source.EOF ? false : HeadCheck(Source.Peek());

		internal override void Consume(ref Source Source, ref Result Result) {
			//If we reached the end of the source we have an error
			if (Source.EOF) {
				Result.Error = new EndOfSourceError(Expected: ToString());
				return;
			}
			//Check for the head
			if (HeadCheck(Source.Peek())) {
				//If it's found, advance
				Source.Position++;
				Result.Length++;
			} else {
				//The head wasn't found, so if we're tail biased check for the tail
				if (Bias == Bias.Tail && TailCheck(Source.Peek())) {
					//If it's found, advance and return
					Source.Position++;
					Result.Length++;
					return;
				} else {
					//If it's not, set the error
					Result.Error = new ConsumeFailedError(Expected: ToString());
					return;
				}
			}
			//Now deal with the entire body
			Boolean FoundBody = false;
			//Loop repeatedly, we'll break out internally
			while (true) {
				//If we reached the end of the source, backtrack so we can check for the tail
				if (Source.EOF) {
					Source.Position--;
					Result.Length--;
					break;
				}
				//Check for the body
				if (BodyCheck(Source.Peek())) {
					//If it's found, advance, and mark that we found it
					Source.Position++;
					Result.Length++;
					FoundBody = true;
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
				//The tail wasn't found, so if we're head biased check for the head again
				if (Bias == Bias.Head && HeadCheck(Source.Peek())) {
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
							Result.Error = new ConsumeFailedError(Expected: ToString());
						}
					}
					return;
				} else {
					//If it's not, set the error
					Result.Error = new ConsumeFailedError(Expected: ToString());
					return;
				}
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) => throw new NotImplementedException();
	}
}
