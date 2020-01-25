using System;
using Stringier.Patterns.Nodes;
using Defender;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a named capture component
	/// </summary>
	/// <remarks>
	/// This is used primarily in the implementation of backreferences (which are like in [Regex](https://www.regular-expressions.info/backref.html)).
	/// </remarks>
	public sealed class Capture : IEquatable<String> {
		//! No matter how good of an idea it might seem like, do not add an implicit conversion to String inside this class. Resolution of conversions causes String to be favored over Pattern, in which case StringLiteral's will be formed over CaptureLiteral's, which causes lazy resolution to no longer be done, breaking a bunch of shit.
		//! Higher performance could probably be acheived by making this a ref struct, however this would severely limit the usability of captures. It's often necessary to make the pattern a static member of a class, and capturing also winds up a static member, which can't be a ref struct.

		/// <summary>
		/// The captured <see cref="String"/>.
		/// </summary>
		internal String Value;

		/// <summary>
		/// Initialize a new <see cref="Capture"/> object.
		/// </summary>
		public Capture() => Value = "";

		/// <summary>
		/// Get this <see cref="Capture"/> as a <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A <see cref="Pattern"/> representing literally this <see cref="Capture"/>.</returns>
		public Pattern AsPattern() => new CaptureLiteral(this);

		/// <summary>
		/// Determines whether this <see cref="Capture"/> and a specified <see cref="String"/> object have the same value. Comparison is ordinal.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to compare to this instance.</param>
		/// <returns><c>true</c> if the value of the <paramref name="other"/> parameter is the same as this capture; otherwise, <c>false</c>.</returns>
		public Boolean Equals(String other) => !(other is null) && Value.Equals(other, StringComparison.Ordinal);

		/// <summary>
		/// Determines whether this <see cref="Capture"/> and a specified <see cref="String"/> object have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to compare to this instance.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies how the text will be compared.</param>
		/// <returns><c>true</c> if the value of the <paramref name="other"/> parameter is the same as this capture; otherwise, <c>false</c>.</returns>
		public Boolean Equals(String other, StringComparison comparisonType) => !(other is null) && Value.Equals(other, comparisonType);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Capture"/>.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to check if this <see cref="Capture"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Capture"/> and <paramref name="other"/></returns>
		public Pattern Or(Pattern other) {
			Guard.NotNull(other, nameof(other));
			return new CaptureLiteral(this).Alternate(other);
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Capture"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check if this <see cref="Capture"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Capture"/> and <paramref name="other"/></returns>
		public Pattern Or(String other) {
			Guard.NotNull(other, nameof(other));
			return new CaptureLiteral(this).Alternate(other);
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Capture"/>.
		/// </summary>
		/// <param name="other">The <see cref="Char"/> to check if this <see cref="Capture"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Capture"/> and <paramref name="other"/></returns>
		public Pattern Or(Char other) => new CaptureLiteral(this).Alternate(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Capture"/>.
		/// </summary>
		/// <param name="other">The <see cref="Capture"/> to check if this <see cref="Capture"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Capture"/> and <paramref name="other"/></returns>
		public Pattern Or(Capture other) {
			Guard.NotNull(other, nameof(other));
			return new CaptureLiteral(this).Alternate(new CaptureLiteral(other));
		}

		/// <summary>
		/// Marks this <see cref="Capture"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public Pattern Repeat(Int32 count) => new CaptureLiteral(this).Repeat(count);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public Pattern Then(Pattern other) {
			Guard.NotNull(other, nameof(other));
			return new CaptureLiteral(this).Concatenate(other);
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="String"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public Pattern Then(String other) {
			Guard.NotNull(other, nameof(other));
			return new CaptureLiteral(this).Concatenate(other);
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public Pattern Then(Char other) => new CaptureLiteral(this).Concatenate(other);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public Pattern Then(Capture other) {
			Guard.NotNull(other, nameof(other));
			return new CaptureLiteral(this).Concatenate(new CaptureLiteral(other));
		}

		/// <summary>
		/// Converts the value of this instance to a <see cref="String"/>.
		/// </summary>
		/// <returns>Returns the captured <see cref="String"/></returns>
		public override String ToString() => $"{Value}";

		/// <summary>
		/// Compare this <see cref="Capture"/> with the given <paramref name="comparisonType"/>.
		/// </summary>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A new <see cref="Pattern"/> representing this <see cref="Capture"/> compared with <paramref name="comparisonType"/>.</returns>
		public Pattern With(Compare comparisonType) => new CaptureLiteral(this, comparisonType);
	}
}
