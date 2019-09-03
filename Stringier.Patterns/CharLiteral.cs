/// <summary>	
/// Represents a literal pattern
/// </summary>
/// <remarks>
/// This exists to box <see cref="System.Char"/> into something that we can treat as a part of a pattern
/// </remarks>
namespace System.Text.Patterns {
	internal sealed class CharLiteral : PrimativePattern, IEquatable<Char>, IEquatable<CharLiteral> {
		private readonly Char Char = '\u0000';

		/// <summary>
		/// The <see cref="StringComparison"/> to use during pattern matching
		/// </summary>
		private readonly StringComparison ComparisonType = Stringier.DefaultComparisonType;

		internal CharLiteral(Char Char) : this(Char, Stringier.DefaultComparisonType) { }

		internal CharLiteral(Char Char, StringComparison ComparisonType) {
			this.Char = Char;
			this.ComparisonType = ComparisonType;
		}

		protected internal override Int32 Length => 1;

		/// <summary>
		/// Check the first <see cref="Char"/> of the <paramref name="Source"/> against this <see cref="Pattern"/>
		/// </summary>
		/// <param name="Source"></param>
		/// <returns>True if a full parse would possibly match, false if definately not</returns>
		protected internal override Boolean CheckFirstChar(ref Source Source) => Stringier.Equals(Char, Source.Peek());

		/// <summary>
		/// Attempt to consume the <see cref="ComplexPattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public override Result Consume(ref Source Source) => Char.Consume(ref Source, ComparisonType);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case CharLiteral other:
				return Equals(other);
			case Char other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => Stringier.Equals(Char.ToString(), other, ComparisonType);

		public override Boolean Equals(String other) => Stringier.Equals(Char.ToString(), other, ComparisonType);

		public Boolean Equals(Char other) => Stringier.Equals(Char, other, ComparisonType);

		public Boolean Equals(CharLiteral other) => Stringier.Equals(Char, other.Char, ComparisonType);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Char.GetHashCode();

		public override String ToString() => $"{Char}";

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see cref="ComplexPattern"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		protected internal override Result Neglect(ref Source Source) => Char.Neglect(ref Source, ComparisonType);
	}
}
