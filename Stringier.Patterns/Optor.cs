using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents the optor pattern
	/// </summary>
	public sealed class Optor : Pattern, IEquatable<Optor> {
		private readonly Pattern Pattern;

		internal Optor(Pattern Pattern) => this.Pattern = Pattern;

		public override Result Consume(Result Candidate) => Consume(Candidate, out _);

		public override Result Consume(Result Candidate, out String Capture) {
			return new Result(true, Pattern.Consume(Candidate, out Capture));
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Optor Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Boolean Equals(String other) => Pattern.Equals(other);

		public Boolean Equals(Optor other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => ~Pattern.GetHashCode();

		public override String ToString() => $"~{Pattern}";
	}
}
