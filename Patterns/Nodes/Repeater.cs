﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Patterns.Pattern"/> whos content repeats a given number of times.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class Repeater : Modifier, IEquatable<Repeater> {
		/// <summary>
		/// The amount of times to be parsed.
		/// </summary>
		private readonly Int32 Count;

		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed.
		/// </summary>
		private readonly Pattern Pattern;

		/// <summary>
		/// Initialize a new <see cref="Repeater"/> from the given <paramref name="pattern"/> and <paramref name="count"/>
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed.</param>
		/// <param name="count">The amount of times to be parsed.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> must be a positive integer.</exception>
		internal Repeater(Pattern pattern, Int32 count) {
			Pattern = pattern;
			if (count < 1) {
				throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive");
			}
			Count = count;
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
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.
		internal override void Consume(ref Source source, ref Result result) {
			for (Int32 i = 0; i < Count; i++) {
				Pattern.Consume(ref source, ref result);
				if (!result) {
					return;
				}
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.
		internal override void Neglect(ref Source source, ref Result result) {
			for (Int32 i = 0; i < Count; i++) {
				Pattern.Neglect(ref source, ref result);
				if (!result) {
					return;
				}
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to compare with the current <see cref="Patterns.Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Patterns.Pattern"/> is equal to the current <see cref="Patterns.Pattern"/>; otherwise, <c>false</c>.</
		public override Boolean Equals(Pattern pattern) {
			switch (pattern) {
			case Repeater repeater:
				return Equals(repeater);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Concatenator"/> to compare with the current <see cref="Patterns.Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Patterns.Pattern"/> is equal to the current <see cref="Patterns.Pattern"/>; otherwise, <c>false</c>.</returns
		public Boolean Equals(Repeater other) => Pattern.Equals(other.Pattern) && Count.Equals(other.Count);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Pattern.GetHashCode() ^ Count.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Patterns.Pattern"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Patterns.Pattern"/>.</returns>
		public override String ToString() => $"{Count}╣{Pattern}║";
	}
}
