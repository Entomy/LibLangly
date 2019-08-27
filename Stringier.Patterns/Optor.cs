namespace System.Text.Patterns {
	internal sealed class Optor : IComplexNode, IEquatable<Optor> {
		private readonly INode Pattern;

		internal Optor(INode Pattern) => this.Pattern = Pattern;

		public Result Consume(ref Source Source) {
			Result Result = Pattern.Consume(ref Source);
			Result.Success = true; //Consuming an optional pattern is always considered successful, the only thing that changes is what is captured
			return Result;
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Optor other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(String other) => true;

		public Boolean Equals(Optor other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => ~Pattern.GetHashCode();

		public Result Neglect(ref Source Source) {
			Result Result = Pattern.Neglect(ref Source);
			Result.Success = true; //Consuming an optional pattern is always considered successful, the only thing that changes is what is captured
			return Result;
		}

		public override String ToString() => $"~{Pattern}";
	}
}
