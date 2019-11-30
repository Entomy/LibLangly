using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a capturer <see cref="Patterns.Pattern"/>. That is, a <see cref="Patterns.Pattern"/> which captures its match into a <see cref="Patterns.Capture"/>.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class Capturer : Modifier, IEquatable<Capturer> {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed and captured.
		/// </summary>
		private readonly Pattern Pattern;

		/// <summary>
		/// The <see cref="Patterns.Capture"/> object to capture into.
		/// </summary>
		private readonly Capture CapStore = new Capture();

		/// <summary>
		/// Initialize a new <see cref="Capturer"/> of the given <paramref name="pattern"/>, to be captured into <paramref name="capture"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed and captured.</param>
		/// <param name="capture">The <see cref="Patterns.Capture"/> object to capture into.</param>
		internal Capturer(Pattern pattern, out Capture capture) {
			Pattern = pattern;
			capture = CapStore;
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Patterns.Pattern"/> may be present, <c>false</c> if definately not.</returns
		internal override Boolean CheckHeader(ref Source source) => Pattern.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		internal override void Consume(ref Source source, ref Result result) {
			Int32 originalPosition = source.Position;
			Pattern.Consume(ref source, ref result);
			CapStore.Value = source.Substring(originalPosition, source.Position - originalPosition).ToString();
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		internal override void Neglect(ref Source source, ref Result result) {
			Int32 originalPosition = source.Position;
			Pattern.Neglect(ref source, ref result);
			CapStore.Value = source.Substring(originalPosition, source.Position - originalPosition).ToString();
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Patterns.Pattern"/> to compare with the current <see cref="Patterns.Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Patterns.Pattern"/> is equal to the current <see cref="Patterns.Pattern"/>; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(Pattern? other) {
			switch (other) {
			case Capturer capturer:
				return Equals(capturer);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Patterns.Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Patterns.Pattern"/>.</param>.
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(ReadOnlySpan<Char> other) {
			CapStore.Value = other.ToString();
			return Pattern.Equals(other);
		}

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Patterns.Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Patterns.Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(String other) {
			CapStore.Value = other;
			return Pattern.Equals(other);
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Concatenator"/> to compare with the current <see cref="Patterns.Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Patterns.Pattern"/> is equal to the current <see cref="Patterns.Pattern"/>; otherwise, <c>false</c>.</returns>
		public Boolean Equals(Capturer other) => Pattern.Equals(other);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Pattern.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Patterns.Pattern"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Patterns.Pattern"/>.</returns>
		public override String ToString() => $"{Pattern}";
	}
}
