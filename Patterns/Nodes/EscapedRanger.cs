using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Errors;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Ranger"/> which supports escape sequences.
	/// </summary>
	/// <remarks>
	/// The escape sequence is intended to allow the <see cref="Ranger.To"/> node to exist inside of the range, it should be considered exactly like a string quote escape inside of a string.
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class EscapedRanger : Ranger, IEquatable<EscapedRanger> {
		/// <summary>
		/// The <see cref="Node"/> representing the escape sequence.
		/// </summary>
		internal readonly Node Escape;

		/// <summary>
		/// Initialize a new <see cref="EscapedRanger"/> with the given <paramref name="from"/>, <paramref name="to"/>, and <paramref name="escape"/> nodes.
		/// </summary>
		/// <param name="from">The <see cref="Node"/> to start from.</param>
		/// <param name="to">The <see cref="Node"/> to read to.</param>
		/// <param name="escape">The <see cref="Node"/> representing the escape sequence.</param>
		internal EscapedRanger(Node from, Node to, Node escape) : base(from, to) => Escape = escape;

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</
		internal override void Consume(ref Source source, ref Result result) {
			From.Consume(ref source, ref result);
			if (!result) {
				result.Error.Set(ErrorType.ConsumeFailed, From);
				return;
			}
			To.Consume(ref source, ref result);
			while (!result) {
				if (source.EOF) {
					break;
				}
				source.Position++;
				result.Length++;
				//Check for the escape before checking for the end of the range
				if (Escape.CheckHeader(ref source)) {
					Escape.Consume(ref source, ref result);
					result.Error.Set(ErrorType.ConsumeFailed, To); //We need an error to continue the loop, and this is the current error
				}
				if (To.CheckHeader(ref source)) {
					To.Consume(ref source, ref result);
				}
			}
			if (!result) {
				result.Error.Set(ErrorType.EndOfSource, To);
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Node"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns
		public override Boolean Equals(Node node) {
			switch (node) {
			case EscapedRanger other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="EscapedRanger"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.
		public Boolean Equals(EscapedRanger other) => From.Equals(other.From) && To.Equals(other.To) && Escape.Equals(other.Escape);

		/// <summary>
		/// Returns the hash code for this <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns
		public override Int32 GetHashCode() => base.GetHashCode() ^ Escape.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Node"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Node"/>.</
		public override String ToString() => $"from=({From}) to=({To}) escape=({Escape})";
	}
}
