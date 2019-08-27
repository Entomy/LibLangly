namespace System.Text.Patterns {
	/// <summary>
	/// Represents a named capture component
	/// </summary>
	public sealed class Capture : IComplexNode, IPrimativeNode, IEquatable<Capture> {
		internal String Value;

		internal Capture() => Value = "";

		public Int32 Length => Value.Length;

		public Result Consume(ref Source Source) => Value.Consume(ref Source);

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

		public override Int32 GetHashCode() => Value.GetHashCode();

		public Result Neglect(ref Source Source) => Value.Neglect(ref Source);

		public override String ToString() => $"{Value}";
	}
}
