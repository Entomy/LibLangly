using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Errors;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents the alternation of two <see cref="Pattern"/>. That is, one <see cref="Pattern"/> or the other.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class Alternator : Combinator, IEquatable<Alternator> {
		/// <summary>
		/// The lefthand <see cref="Pattern"/>; the first.
		/// </summary>
		private readonly Pattern Left;

		/// <summary>
		/// The righthand <see cref="Pattern"/>; the last.
		/// </summary>
		private readonly Pattern Right;

		/// <summary>
		/// Initialize a new <see cref="Concatenator"/> with the <paramref name="left"/> and <paramref name="right"/> <see cref="Pattern"/>.
		/// </summary>
		/// <param name="left">The lefthand <see cref="Pattern"/>; the first.</param>
		/// <param name="right">The righthand <see cref="Pattern"/>; the last.</param
		internal Alternator(Pattern left, Pattern right) {
			Left = left;
			Right = right;
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns
		internal override Boolean CheckHeader(ref Source source) => Left.CheckHeader(ref source) || Right.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</
		internal override void Consume(ref Source source, ref Result result) {
			Left.Consume(ref source, ref result);
			if (!result) {
				Error Error = result.Error; //Store the error
				result.Error.Clear();
				Right.Consume(ref source, ref result);
				if (!result) {
					result.Error = Error; //Resassign the first error, since both failed, but we want to be clear of that
				}
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</
		internal override void Neglect(ref Source source, ref Result result) {
			Int32 OriginalPosition = source.Position;
			Int32 OriginalLength = result.Length;
			Right.Neglect(ref source, ref result);
			if (result) {
				source.Position = OriginalPosition;
				result.Length = OriginalLength;
				Left.Neglect(ref source, ref result);
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to compare with the current <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Pattern"/> is equal to the current <see cref="Pattern"/>; otherwise, <c>false</c>.</returns
		public override Boolean Equals(Pattern? other) {
			switch (other) {
			case Alternator alternator:
				return Equals(alternator);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Concatenator"/> to compare with the current <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Pattern"/> is equal to the current <see cref="Pattern"/>; otherwise, <c>false</c>.</returns
		public Boolean Equals(Alternator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns
		public override Int32 GetHashCode() => Left.GetHashCode() | Right.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Pattern"/>.</returns>
		public override String ToString() => $"┃{Left}│{Right}┃";

		#region Alternator

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Alternate(Pattern right) => new ChainAlternator(Left, Right, right);

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="Char"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</returns
		internal override Pattern Alternate(Char right) => new ChainAlternator(Left, Right, new CharLiteral(right));

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="String"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</
		internal override Pattern Alternate(String right) => new ChainAlternator(Left, Right, new StringLiteral(right));

		#endregion

		#region Spanner

		/// <summary>
		/// Makes this <see cref="Pattern"/> spanning.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which spans.</returns
		internal override Pattern Span() {
			if (Left is Optor || Right is Optor) {
				throw new PatternConstructionException("One or more of the components of this alternator are optional, and the alternator is marked as spanning. Options can not span, as it creates an infinite loop. While this potentially could succeed, this is absolutely an error.");
			} else {
				return base.Span();
			}
		}

		#endregion
	}
}
