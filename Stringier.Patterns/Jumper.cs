namespace System.Text.Patterns {
	internal sealed class Jumper : Node, IEquatable<Jumper> {
		private readonly Target Target;

		internal Jumper(Target Target) => this.Target = Target;

		public override Boolean Equals(Node node) {
			switch (node) {
			case Jumper jumper:
				return Equals(jumper);
			default:
				return false;
			}
		}
		public Boolean Equals(Jumper other) => Target.Equals(other.Target);

		public override Int32 GetHashCode() => Target.GetHashCode();

		public override String ToString() => "::Jump::";

		internal override Boolean CheckHeader(ref Source Source) => Target.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) => Target.Consume(ref Source, ref Result);

		internal override void Neglect(ref Source Source, ref Result Result) => Target.Neglect(ref Source, ref Result);
	}
}
