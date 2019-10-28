namespace System.Text.Patterns {
	public sealed class Target : IEquatable<Target>, IEquatable<Pattern> {
		private readonly Pattern Pattern;

		internal Target(Pattern Pattern) => this.Pattern = Pattern;

		public static implicit operator Pattern(Target Target) => new Pattern(new Jumper(Target));

		public static Boolean operator !=(Target Left, Pattern Right) => !Left.Equals(Right);

		public static Boolean operator !=(Pattern Left, Target Right) => !Right.Equals(Left);

		public static Boolean operator ==(Target Left, Pattern Right) => Left.Equals(Right);

		public static Boolean operator ==(Pattern Left, Target Right) => Right.Equals(Left);

		public Boolean Equals(Target other) => ReferenceEquals(this, other);

		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Pattern pattern:
				return Equals(pattern);
			default:
				return ReferenceEquals(this, obj);
			}
		}

		public Boolean Equals(Pattern pattern) => Pattern == pattern;

		public override Int32 GetHashCode() => base.GetHashCode();

		internal Boolean CheckHeader(ref Source Source) => Pattern.Head.CheckHeader(ref Source);

		internal void Consume(ref Source Source, ref Result Result) => Pattern.Head.Consume(ref Source, ref Result);

		internal void Neglect(ref Source Source, ref Result Result) => Pattern.Head.Neglect(ref Source, ref Result);
	}
}
