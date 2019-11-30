using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Patterns.Pattern"/> whos content should be neglected.
	/// </summary>
	/// <remarks>
	/// This is syntactic sugar around the Neglect parser, which parses anything that does not match the pattern, with some special semantics for certain patterns. It is basically saying "anything that isn't this, that is the same length".
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class Negator : Modifier, IEquatable<Negator> {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed.
		/// </summary>
		private readonly Pattern Pattern;

		/// <summary>
		/// Intialize a new <see cref="Negator"/> from the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed.</param>
		internal Negator(Pattern pattern) => Pattern = pattern;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Patterns.Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => !Pattern.CheckHeader(ref source);

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <remarks>
		/// This is not an error, it deliberately calls the other parser.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.
		internal override void Consume(ref Source source, ref Result result) => Pattern.Neglect(ref source, ref result);

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <remarks>
		/// This is not an error, it deliberately calls the other parser.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.
		internal override void Neglect(ref Source source, ref Result result) => Pattern.Consume(ref source, ref result);

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to compare with the current <see cref="Patterns.Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Patterns.Pattern"/> is equal to the current <see cref="Patterns.Pattern"/>; otherwise, <c>false</c>.
		public override Boolean Equals(Pattern pattern) {
			switch (pattern) {
			case Negator negator:
				return Equals(negator);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Concatenator"/> to compare with the current <see cref="Patterns.Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Patterns.Pattern"/> is equal to the current <see cref="Patterns.Pattern"/>; otherwise, <c>false</c>.
		public Boolean Equals(Negator other) => Pattern.Equals(other.Pattern);

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Patterns.Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Patterns.Pattern"/>.</param>.
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(ReadOnlySpan<Char> other) {
			Source Source = new Source(other);
			Result Result = new Result(ref Source);
			Consume(ref Source, ref Result);
			if (Result) {
				return true;
			} else {
				//We have to do some manual work here
				//Normally we would store the source position, but since we create the source in this method, the original position is always 0
				//Call the underlying neglect
				Pattern.Consume(ref Source, ref Result);
				if (Result) {
					//If this was successful, check if it consumed the entire source
					return Source.Length != 0;
				} else {
					//Otherwise it's definately not a match
					return false;
				}
			}
		}

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Patterns.Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Patterns.Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(String other) {
			Source Source = new Source(other);
			Result Result = new Result(ref Source);
			Consume(ref Source, ref Result);
			if (Result) {
				return true;
			} else {
				//We have to do some manual work here
				//Normally we would store the source position, but since we create the source in this method, the original position is always 0
				//Call the underlying neglect
				Pattern.Consume(ref Source, ref Result);
				//If this was successful, check if it consumed the entire source, otherwise it's definately not a match
				return Result && Source.Length != 0;
			}
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => -Pattern.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Pattern"/>.</returns>
		public override String ToString() => $"!╣{Pattern}║";
	}
}
