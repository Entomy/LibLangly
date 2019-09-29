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

		/// <summary>
		/// Determines whether two <see cref="Object"/> instances are equal.
		/// </summary>
		/// <param name="obj">The <see cref="Object"/> to compare with the current object.</param>
		/// <returns><c>true</c> if the specified <see cref="Object"/> is equal to the current object; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Capture other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether two <see cref="Capture"/> instances are equal.
		/// </summary>
		/// <param name="other">The <see cref="Capture"/> to compare with the current object.</param>
		/// <returns><c>true</c> if the specified <see cref="Capture"/> is equal to the current object; otherwise, <c>false</c>.</returns>
		public Boolean Equals(Capture other) => Stringier.Equals(Value, other.Value);

		/// <summary>
		/// Determines whether the <see cref="String"/> instance is equal to the current object.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to compare with the current object.</param>
		/// <returns><c>true</c> if the specified <see cref="String"/> is equal to the current object; otherwise, <c>false</c>.</returns>
		public Boolean Equals(String other) => Stringier.Equals(Value, other);

		/// <summary>
		/// Returns the hash code for this <see cref="Capture"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Value.GetHashCode();

		/// <summary>
		/// Converts the value of this instance to a <see cref="String"/>.
		/// </summary>
		/// <returns>Returns the captured <see cref="String"/></returns>
		public override String ToString() => $"{Value}";
	}
}
