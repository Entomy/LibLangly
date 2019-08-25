/// <summary>	
/// Represents a literal pattern
/// </summary>
/// <remarks>
/// This exists to box <see cref="System.Char"/> into something that we can treat as a part of a pattern
/// </remarks>
namespace System.Text.Patterns {
	internal sealed class CharLiteral : Node, IPrimative, IEquatable<Char>, IEquatable<CharLiteral> {
		private readonly Char Char = '\u0000';

		/// <summary>
		/// The <see cref="StringComparison"/> to use during pattern matching
		/// </summary>
		private readonly StringComparison ComparisonType = StringComparison.CurrentCulture;

		internal CharLiteral(Char Char) : this(Char, StringComparison.CurrentCulture) { }

		internal CharLiteral(Char Char, StringComparison ComparisonType) {
			this.Char = Char;
			this.ComparisonType = ComparisonType;
		}

		public static implicit operator CharLiteral(Char Char) => new CharLiteral(Char);

		public static implicit operator CharLiteral((Char Char, StringComparison ComparisonType) Pattern) => new CharLiteral(Pattern.Char, Pattern.ComparisonType);

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Consume(ref Source Source) => Char.Consume(ref Source, ComparisonType);

		public override Boolean Equals(String other) => Stringier.Equals(Char.ToString(), other, ComparisonType);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case CharLiteral Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public Boolean Equals(Char other) => Stringier.Equals(Char, other, ComparisonType);

		public Boolean Equals(CharLiteral other) => Stringier.Equals(Char, other.Char, ComparisonType);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Char.GetHashCode();

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting this <see cref="Pattern"/>
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public override Result Neglect(ref Source Source) => Char.Neglect(ref Source, ComparisonType);

		public override String ToString() => Char.ToString();
	}
}
