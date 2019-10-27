namespace System.Text.Patterns {
	internal sealed class StringChecker : Checker, IEquatable<StringChecker> {
		internal readonly Func<Char, Boolean> HeadCheck;
		internal readonly Boolean HeadRequired = true;
		internal readonly Func<Char, Boolean> BodyCheck;
		internal readonly Boolean BodyRequired = true;
		internal readonly Func<Char, Boolean> TailCheck;
		internal readonly Boolean TailRequired = true;

		internal StringChecker(String Name, Func<Char, Boolean> HeadCheck, Func<Char, Boolean> BodyCheck, Func<Char, Boolean> TailCheck) : base(Name) {
			this.HeadCheck = HeadCheck;
			this.BodyCheck = BodyCheck;
			this.TailCheck = TailCheck;
		}

		internal StringChecker(String Name, Func<Char, Boolean> HeadCheck, Boolean HeadRequired, Func<Char, Boolean> BodyCheck, Boolean BodyRequired, Func<Char, Boolean> TailCheck, Boolean TailRequired) : this(Name, HeadCheck, BodyCheck, TailCheck) {
			if (!HeadRequired && !BodyRequired && !TailRequired) { throw new PatternConstructionException("At least one component must be required"); }
			this.HeadRequired = HeadRequired;
			this.BodyRequired = BodyRequired;
			this.TailRequired = TailRequired;
		}

		internal override Boolean CheckHeader(ref Source Source) => Source.EOF ? false : HeadCheck(Source.Peek());

		internal override void Consume(ref Source Source, ref Result Result) {
			//The constructors should catch this situation first, but it should still be checked here in case someone forgot
			if (!HeadRequired && !BodyRequired && !TailRequired) { throw new PatternConstructionException("At least one component must be required"); }
			//To make this easier to reason about, the implementation has been split, and this function actually just calls the requested one
			//This actually causes a small amount of optimization, beleive it or not. In a unified approach, two of these checks would have to occur inside of the body loop, and multiple times within the same iteration, which means they are repeated several times instead of just once here. This also prevents possible branch misprediction problems.
			Boolean FoundBody;
			if (HeadRequired) { ConsumeRequiredHead(ref Source, ref Result, out FoundBody); } else { ConsumeOptionalHead(ref Source, ref Result, out FoundBody); }
			if (BodyRequired) { ConsumeRequiredBody(ref Source, ref Result, ref FoundBody); } else { ConsumeOptionalBody(ref Source, ref Result, ref FoundBody); }
			if (TailRequired) { ConsumeRequiredTail(ref Source, ref Result, in FoundBody); } else { ConsumeOptionalTail(ref Source, ref Result, in FoundBody); }
			//Because these are generalized, they don't validate length, so we do that now
			if ((HeadRequired && BodyRequired && TailRequired && Result.Length < 3) //If all three are required, the length must be at least 3
			|| (!(HeadRequired ^ BodyRequired ^ TailRequired) && Result.Length < 2) //If two are required, the length must be at least 2
			|| (HeadRequired ^ BodyRequired ^ TailRequired && Result.Length < 1)) { //If only one is required, the length must be at least 1
				Result.Error.Set(ErrorType.ConsumeFailed, this);
			}
		}

		private void ConsumeRequiredHead(ref Source Source, ref Result Result, out Boolean FoundBody) {
			//We have to output this
			FoundBody = false;
			//If we reached the end of the source we have an error
			if (Source.EOF) {
				Result.Error.Set(ErrorType.EndOfSource, this);
				return;
			}
			//Check for the head
			if (HeadCheck(Source.Peek())) {
				//If it's found, advance
				Source.Position++;
				Result.Length++;
			} else {
				//If it's not, we have an error
				Result.Error.Set(ErrorType.ConsumeFailed, this);
				return;
			}
		}

		private void ConsumeOptionalHead(ref Source Source, ref Result Result, out Boolean FoundBody) {
			//We have to output this, so default to false and we'll set it to true if we find it
			FoundBody = false;
			//If we reached the end of the source we have an error
			if (Source.EOF) {
				Result.Error.Set(ErrorType.EndOfSource, this);
				return;
			}
			//The head isn't required, so we're going to check for the body first
			if (BodyCheck(Source.Peek())) {
				//The body was found, so set it to true
				FoundBody = true;
			} else if (!HeadCheck(Source.Peek())) {
				//The head wasn't found, so we have an error
				Result.Error.Set(ErrorType.ConsumeFailed, this);
				return;
			}
			//So regardless of whether the head or body was found, advance like normal. If the body was found, we've already marked that.
			Source.Position++;
			Result.Length++;
		}

		private void ConsumeRequiredBody(ref Source Source, ref Result Result, ref Boolean FoundBody) {
			//Loop repeatedly, we'll break out internally
			while (true) {
				//If we reached the end of the source, backtrack so we can check for the tail
				if (Source.EOF) {
					Source.Position--;
					Result.Length--;
					return;
				}
				//Check for the body
				if (BodyCheck(Source.Peek())) {
					//The body was found, so advance and set it to true, then continue the loop
					Source.Position++;
					Result.Length++;
					FoundBody = true;
					continue;
				} else {
					//Something else was found, so backtrack so we can check for the tail
					Source.Position--;
					Result.Length--;
					return;
				}
			}
		}

		private void ConsumeOptionalBody(ref Source Source, ref Result Result, ref Boolean FoundBody) {
			// This isn't parsed any differently, so just chain
			ConsumeRequiredBody(ref Source, ref Result, ref FoundBody);
			// It's optional, but Consume__Tail() wants to know if it was found, so just say it was regardless
			FoundBody = true;
		}

		private void ConsumeRequiredTail(ref Source Source, ref Result Result, in Boolean FoundBody) {
			//If we reached the end of the source we have an error
			if (Source.EOF) {
				Result.Error.Set(ErrorType.EndOfSource, this);
				return;
			}
			//Check for the tail
			if (TailCheck(Source.Peek())) {
				//Have we found the body earlier?
				if (!FoundBody) {
					//If not, set the error
					Result.Error.Set(ErrorType.ConsumeFailed, this);
					return;
				}
				//We found the tail, so advance
				Source.Position++;
				Result.Length++;
			} else {
				//No tail was found, so set the error
				Result.Error.Set(ErrorType.ConsumeFailed, this);
			}
		}

		private void ConsumeOptionalTail(ref Source Source, ref Result Result, in Boolean FoundBody) {
			//If we reached the end of the source we have an error
			if (Source.EOF) {
				Result.Error.Set(ErrorType.EndOfSource, this);
				return;
			}
			//Have we found the body earlier?
			if (!FoundBody) {
				//If not, set the error
				Result.Error.Set(ErrorType.ConsumeFailed, this);
				return;
			}
			// We never actually check for the tail, because it doesn't matter. When checking the body, it progressed as far as it could, and either is right in front of the tail, or reached the end of source and backtracked. Both situations have us right before the "tail", which is either actually the tail, or the last part of the body which needs to be reconsumed. So optimize out the check and just advance
			Source.Position++;
			Result.Length++;
		}

		internal override void Neglect(ref Source Source, ref Result Result) => throw new NotImplementedException();

		public override Boolean Equals(Node node) {
			switch (node) {
			case StringChecker other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(StringChecker other) => HeadCheck.Equals(other.HeadCheck) && BodyCheck.Equals(other.BodyCheck) && TailCheck.Equals(other.TailCheck);

		public override Int32 GetHashCode() => HeadCheck.GetHashCode() ^ BodyCheck.GetHashCode() ^ TailCheck.GetHashCode();

		public override String ToString() => $"┋{Name}┋";
	}
}
