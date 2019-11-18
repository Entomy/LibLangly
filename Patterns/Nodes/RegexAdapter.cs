using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Stringier.Patterns.Errors;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Adapts <see cref="System.Text.RegularExpressions.Regex"/> to work with <see cref="Pattern"/>.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class RegexAdapter : Node, IEquatable<RegexAdapter> {
		/// <summary>
		/// The actual <see cref="System.Text.RegularExpressions.Regex"/>.
		/// </summary>
		private readonly Regex Regex;

		/// <summary>
		/// Initializes a new <see cref="RegexAdapter"/> from the given <paramref name="regex"/>.
		/// </summary>
		/// <param name="regex">The actual <see cref="System.Text.RegularExpressions.Regex"/>.</param>
		internal RegexAdapter(Regex regex) => Regex = regex;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => true; //This is true because it represents "the pattern may possibly be here", and we have no way of extracting the header from a Regex, so just don't use this optimization.

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		internal override void Consume(ref Source source, ref Result result) {
			Match Match = Regex.Match(source.ToString());
			if (Match.Success) {
				source.Position += Match.Length;
				result.Length += Match.Length;
			} else {
				result.Error.Set(ErrorType.ConsumeFailed, this);
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		internal override void Neglect(ref Source source, ref Result result) => throw new InvalidOperationException("Regex can not be negated");

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Node"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns
		public override Boolean Equals(Node node) {
			switch (node) {
			case RegexAdapter other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="RegexAdapter"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns
		public Boolean Equals(RegexAdapter other) => Regex.Equals(other.Regex);

		/// <summary>
		/// Returns the hash code for this <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns
		public override Int32 GetHashCode() => Regex.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Node"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Node"/>.</returns
		public override String ToString() => $"╱{Regex}╱";

		#region Negator

		/// <summary>
		/// Negates this <see cref="Node"/>.
		/// </summary>
		/// <returns>A new <see cref="Node"/> which has been negated.</returns>
		internal override Node Negate() => throw new PatternConstructionException("Regex can not be negated");

		#endregion
	}
}
