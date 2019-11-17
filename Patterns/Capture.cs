using System;
using Stringier.Patterns.Nodes;

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
		/// Converts the value of this instance to a <see cref="String"/>.
		/// </summary>
		/// <returns>Returns the captured <see cref="String"/></returns>
		public override String ToString() => $"{Value}";
	}
}
