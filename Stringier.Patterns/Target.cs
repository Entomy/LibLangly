namespace System.Text.Patterns {
	public sealed class Target : IEquatable<Target>, IEquatable<Pattern> {
		private readonly Node Node;

		internal Target(Node Node) => this.Node = Node;

		public Boolean Equals(Target other) => ReferenceEquals(this, other);

		public static Boolean operator ==(Target Left, Pattern Right) => Left.Equals(Right);

		public static Boolean operator ==(Pattern Left, Target Right) => Right.Equals(Left);

		public static Boolean operator !=(Target Left, Pattern Right) => !Left.Equals(Right);

		public static Boolean operator !=(Pattern Left, Target Right) => !Right.Equals(Left);

		public Boolean Equals(Pattern pattern) => Node == pattern.Head;

		internal Boolean CheckHeader(ref Source Source) => Node.CheckHeader(ref Source);

		internal void Consume(ref Source Source, ref Result Result) => Node.Consume(ref Source, ref Result);

		internal void Neglect(ref Source Source, ref Result Result) => Node.Neglect(ref Source, ref Result);
	}
}
