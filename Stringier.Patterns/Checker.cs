namespace System.Text.Patterns {
	/// <summary>
	/// This is an internal pattern used to programatically check a <see cref="Char"/> for existance within a set.
	/// </summary>
	/// <remarks>
	/// Specifically, it's used in the construction of predefined patterns. This is because it's considerably easier to define a range of codepoints and check for the existance within that. The code to do this is clunky and awkward however, so not something to expose publicly.
	/// Testing: While it might seem like testing this class is somehow not possible because of the visibility, this isn't the case at all. <see cref="Checker"/> is exposed, non-obviously, through the predefined patterns, and can easily be checked that way; if those fail while the isolated tests pass, the issue is almost certainly with this class.
	/// </remarks>
	internal sealed class Checker : Node, IEquatable<Checker> {
		private readonly Func<Char, Boolean> Check;

		internal Checker(Func<Char, Boolean> Check) => this.Check = Check;

		public static implicit operator Checker(Func<Char, Boolean> Check) => new Checker(Check);

		public override Result Consume(ref Source Source) {
			if (Source.Length == 0) { return new Result(); }
			return Check(Source.Peek()) ? new Result(Source.Read(1)) : new Result();
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case String Other:
				return Equals(Other);
			case Checker Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Boolean Equals(String other) => throw new NotImplementedException();

		public Boolean Equals(Checker other) => Check.Equals(other);

		public override Int32 GetHashCode() => Check.GetHashCode();

		public override Result Neglect(ref Source Source) {
			if (Source.Length == 0) { return new Result(); }
			return Check(Source.Peek()) ? new Result() : new Result(Source.Read(1));
		}

		public override String ToString() => Check.ToString();
	}
}
