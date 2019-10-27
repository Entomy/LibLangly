namespace System.Text.Patterns {
	internal sealed class RepeatCharChecker : Checker, IEquatable<RepeatCharChecker> {
		internal readonly Func<Char, Boolean> Check;

		internal readonly Int32 Length;

		internal RepeatCharChecker(String Name, Func<Char, Boolean> Check, Int32 Length) : base(Name) {
			this.Check = Check;
			this.Length = Length;
		}

		internal override Boolean CheckHeader(ref Source Source) => !Source.EOF && Check(Source.Peek());

		internal override void Consume(ref Source Source, ref Result Result) {
			if (Source.EOF) {
				Result.Error.Set(ErrorType.EndOfSource, this);
			} else {
				for (Int32 i = 0; i < Length; i++) {
					if (Source.EOF) {
						Result.Error.Set(ErrorType.ConsumeFailed, this);
					}
					if (Check(Source.Peek())) {
						Source.Position++;
						Result.Length++;
						Result.Error.Clear();
					} else {
						Result.Error.Set(ErrorType.ConsumeFailed, this);
						break;
					}
				}
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			if (Source.EOF) {
				Result.Error.Set(ErrorType.EndOfSource, this);
			} else {
				for (Int32 i = 0; i < Length; i++) {
					if (Source.EOF) {
						Result.Error.Set(ErrorType.NeglectFailed, this);
					}
					if (!Check(Source.Peek())) {
						Source.Position++;
						Result.Length++;
						Result.Error.Clear();
					} else {
						Result.Error.Set(ErrorType.NeglectFailed, this);
						break;
					}
				}
			}
		}

		public override Boolean Equals(Node node) {
			switch (node) {
			case RepeatCharChecker other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) {
			if (other.Length != Length) {
				return false;
			}
			for (Int32 i = 0; i < Length; i++) {
				if (!Check(other[i])) { return false; }
			}
			return true;
		}

		public override Boolean Equals(String other) {
			if (other.Length != Length) {
				return false;
			}
			for (Int32 i = 0; i < Length; i++) {
				if (!Check(other[i])) { return false; }
			}
			return true;
		}

		public Boolean Equals(RepeatCharChecker other) => Check.Equals(other.Check) && Length.Equals(other.Length);

		public override Int32 GetHashCode() => Check.GetHashCode();

		public override String ToString() => $"┋{Length}┆{Name}┋";
	}
}
