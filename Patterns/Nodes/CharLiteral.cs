using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns.Nodes {
	/// <summary>	
	/// Represents a character literal, a pattern matching this exact character.
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.Char"/> into something that we can treat as a part of a pattern.
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class CharLiteral : Literal, IEquatable<CharLiteral> {
		/// <summary>
		/// The actual <see cref="System.Char"/> being matched.
		/// </summary>
		internal readonly Char Char;

		/// <summary>
		/// Initialize a new <see cref="CharLiteral"/> with the given <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="System.Char"/> to parse.</param>
		internal CharLiteral(Char @char) : base(Compare.NoPreference) => Char = @char;

		/// <summary>
		/// Initialize a new <see cref="CharLiteral"/> with the given <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="System.Char"/> to parse.</param>
		/// <param name="comparisonType">The <see cref="Compare"/> to use when parsing.</param>
		internal CharLiteral(Char @char, Compare comparisonType) : base(comparisonType) => Char = @char;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => Char.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		internal override void Consume(ref Source source, ref Result result) => Char.Consume(ref source, ref result, ComparisonType);

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		internal override void Neglect(ref Source source, ref Result result) => Char.Neglect(ref source, ref result, ComparisonType);

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to compare with the current <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Pattern"/> is equal to the current <see cref="Pattern"/>; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(Pattern? other) {
			switch (other) {
			case CharLiteral @char:
				return Equals(@char);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="System.Char"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="System.Char"/> to check against this <see cref="Pattern"/>.</param>.
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(ReadOnlySpan<Char> other) => Char.ToString().Equals(other, ComparisonType);

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(String other) => Char.ToString().Equals(other, ComparisonType);

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="CharLiteral"/> to compare with the current <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Pattern"/> is equal to the current <see cref="Pattern"/>; otherwise, <c>false</c>.</returns>
		public Boolean Equals(CharLiteral other) => ComparisonType.Equals(other.ComparisonType) && this.Char.Equals(other.Char, ComparisonType);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Char.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Pattern"/>.</returns>
		public override String ToString() => $"{Char}";

		#region Concatenator

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Concatenate(Pattern right) {
			switch (right) {
			case StringLiteral @string:
				if (ComparisonType.Equals(@string.ComparisonType)) {
					return new StringLiteral(Char + @string.String, ComparisonType);
				} else {
					goto default;
				}
			case CharLiteral @char:
				if (ComparisonType.Equals(@char.ComparisonType)) {
					return new StringLiteral(Char.ToString() + @char.Char.ToString(), ComparisonType);
				} else {
					goto default;
				}
			default:
				return base.Concatenate(right);
			}
		}

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="System.Char"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="System.Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Concatenate(Char right) {
			switch (ComparisonType) {
			case Compare.NoPreference:
				return new StringLiteral(Char.ToString() + right.ToString());
			default:
				return new Concatenator(this, new CharLiteral(right));
			}
		}

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="String"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Concatenate(String right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			switch (ComparisonType) {
			case Compare.NoPreference:
				return new StringLiteral(Char + right);
			default:
				return new Concatenator(this, new StringLiteral(right));
			}
		}

		#endregion

		#region Repeater

		/// <summary>
		/// Repeats this <see cref="Pattern"/> <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public override Pattern Repeat(Int32 count) => new StringLiteral(StringierExtensions.Repeat(Char, count), ComparisonType);

		#endregion
	}
}
