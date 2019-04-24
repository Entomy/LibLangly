using System.Diagnostics.CodeAnalysis;

namespace System.Text.Patterns {
	/// <summary>	
	/// Represents a literal pattern
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern
	/// </remarks>
	[SuppressMessage("Microsoft.Analyzers", "CA2225", Justification = "While operators are being overridden, they aren't strictly what they were. Semantics are kept the same, but you wouldn't call repetition 'multiplication'")]
	public sealed class Literal : Pattern, IEquatable<Literal> {
		private readonly String String = "";

		internal Literal(String String) => this.String = String;

		public static implicit operator Literal(String String) => new Literal(String);

		public static Literal operator &(Literal Left, Literal Right) => new Literal(Left.String + Right.String);

		public override Result Consume(Result Candidate) => Consume(Candidate, out _);

		public override Result Consume(Result Candidate, out String Capture) => String.Consume(Candidate, out Capture);

		public override Boolean Equals(String other) => String.Equals(String, other, StringComparison.InvariantCulture);

		public Boolean Equals(Literal other) => String.Equals(other.String, StringComparison.InvariantCulture);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Literal Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Int32 GetHashCode() => String.GetHashCode();

		public override String ToString() => String;
	}
}
