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

		public override Boolean Equals(Node node) {
			switch (node) {
			case StringChecker other:
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
				Result.Error.Set(ErrorType.EndOfSource, this);
				return;
			}
			//Now do the appropriate parse
			switch (Bias) {
			case Bias.Tail:
				ConsumeTailBiased(ref Source, ref Result);
				break;
			case Bias.Head:
			default:
				ConsumeHeadBiased(ref Source, ref Result);
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
				Result.Error.Set(ErrorType.ConsumeFailed, this);
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
							Result.Error.Set(ErrorType.ConsumeFailed, this);
						}
					}
					return;
				} else {
					//If it's not, have we found the bias?
					if (!FoundBias) {
						//We haven't so set the error
						Result.Error.Set(ErrorType.ConsumeFailed, this);
					}
					return;
				}
			}
		}

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
					Result.Error.Set(ErrorType.ConsumeFailed, this);
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
				if (FoundBody & !BacktrackedForTail) {
					Source.Position--;
					Result.Length--;
					BacktrackedForTail = true;
					goto TailCheck;
				} else {
					//The tail wasn't found so set the error
					Result.Error.Set(ErrorType.ConsumeFailed, this);
					return;
				}
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) => throw new NotImplementedException();
	}
}
