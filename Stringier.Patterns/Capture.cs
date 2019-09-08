namespace System.Text.Patterns {
	/// <summary>
	/// Represents a named capture component
	/// </summary>
	/// <remarks>
	/// This is used primarily in the implementation of backreferences (which are like in [Regex](https://www.regular-expressions.info/backref.html)).
	/// </remarks>
	public sealed class Capture : IEquatable<Capture> {
		//! No matter how good of an idea it might seem like, do not add an implicit conversion to String inside this class. Resolution of conversions causes String to be favored over Pattern, in which case StringLiteral's will be formed over CaptureLiteral's, which causes lazy resolution to no longer be done, breaking a bunch of shit

		internal String Value;

		internal Capture() => Value = "";

		public static implicit operator Pattern(Capture Capture) => new CaptureLiteral(Capture);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Capture other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(Capture other) => Stringier.Equals(Value, other);

		public Boolean Equals(String other) => Stringier.Equals(Value, other);

		public override Int32 GetHashCode() => base.GetHashCode();

		public override String ToString() => $"{Value}";
	}
}
