using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns.Nodes {
	/// <summary>	
	/// Represents a string literal pattern, a pattern matching this exact string.
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern.
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class StringLiteral : Literal, IEquatable<StringLiteral> {
		/// <summary>
		/// The actual <see cref="System.String"/> being matched.
		/// </summary>
		internal readonly String String = "";

		/// <summary>
		/// Initialize a new <see cref="StringLiteral"/> with the given <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="System.String"/> to parse.</param>
		internal StringLiteral(String @string) : base(Compare.NoPreference) => String = @string;

		/// <summary>
		/// Intialize a new <see cref="StringLiteral"/> with the given <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="System.String"/> to parse.</param>
		/// <param name="comparisonType">The <see cref="Compare"/> to use when parsing.</param>
		internal StringLiteral(String @string, Compare comparisonType) : base(comparisonType) => String = @string;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => String.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="System.String"/>.</param>
		internal override void Consume(ref Source source, ref Result result) => String.Consume(ref source, ref result, ComparisonType);

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="System.String"/>.</param>
		internal override void Neglect(ref Source source, ref Result result) => String.Neglect(ref source, ref result, ComparisonType);

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to compare with the current <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Pattern"/> is equal to the current <see cref="Pattern"/>; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(Pattern? other) {
			switch (other) {
			case StringLiteral @string:
				return Equals(@string);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Pattern"/>.</param>.
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(ReadOnlySpan<Char> other) => String.Equals(other, ComparisonType);

		/// <summary>
		/// Determines whether the specified <see cref="System.String"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="System.String"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(String other) => !(other is null) && String.Equals(other, ComparisonType);

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="StringLiteral"/> to compare with the current <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Pattern"/> is equal to the current <see cref="Pattern"/>; otherwise, <c>false</c>.</returns>
		public Boolean Equals(StringLiteral other) => ComparisonType.Equals(other.ComparisonType) && this.String.Equals(other.String, ComparisonType);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => String.GetHashCode();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => $"{String}";

		#region Concatenator

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Concatenate(Pattern right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			switch (right) {
			case StringLiteral @string:
				if (ComparisonType.Equals(@string.ComparisonType)) {
					return new StringLiteral(String + @string.String, ComparisonType);
				} else {
					goto default;
				}
			case CharLiteral @char:
				if (ComparisonType.Equals(@char.ComparisonType)) {
					return new StringLiteral(String + @char.Char, ComparisonType);
				} else {
					goto default;
				}
			default:
				return base.Concatenate(right);
			}
		}

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="Char"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Concatenate(Char right) {
			switch (ComparisonType) {
			case Compare.NoPreference:
				return new StringLiteral(String + right.ToString());
			default:
				return new Concatenator(this, new CharLiteral(right));
			}
		}

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="System.String"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="System.String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns
		internal override Pattern Concatenate(String right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			switch (ComparisonType) {
			case Compare.NoPreference:
				return new StringLiteral(String + right);
			default:
				return new Concatenator(this, new StringLiteral(right));
			}
		}

		#endregion

		#region Repeater

		public override Pattern Repeat(Int32 count) => new StringLiteral(StringierExtensions.Repeat(String, count), ComparisonType);

		#endregion
	}
}