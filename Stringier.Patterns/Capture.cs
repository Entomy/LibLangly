using System;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents a named capture component
	/// </summary>
	public sealed class Capture : IEquatable<Capture>, IEquatable<String> {
		internal String Value;

		internal Capture() => Value = "";

		public Int32 Length => Value.Length;

		public static implicit operator Pattern(Capture Capture) => new Pattern(new CaptureLiteral(Capture));

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

		public override String ToString() => Value;
	}
}
