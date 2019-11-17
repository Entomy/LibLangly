﻿using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Errors;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a programatic check of a <see cref="Char"/> for existance within a set, defined by the <see cref="Check"/> function.
	/// </summary>
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It is overriden, Sonar is just too stupid to figure out this pattern")]
	internal sealed class CharChecker : Checker, IEquatable<CharChecker> {
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		internal readonly Func<Char, Boolean> Check;

		/// <summary>
		/// Construct a new <see cref="CharChecker"/> from the specified <paramref name="check"/>
		/// </summary>
		/// <param name="name">The name to refer to this as</param>
		/// <param name="check">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		internal CharChecker(String name, Func<Char, Boolean> check) : base(name) => Check = check;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns
		internal override Boolean CheckHeader(ref Source source) => !source.EOF && Check(source.Peek());

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param
		internal override void Consume(ref Source source, ref Result result) {
			if (source.Length == 0) {
				result.Error.Set(ErrorType.EndOfSource, this);
			} else {
				if (Check(source.Peek())) {
					source.Position++;
					result.Length++;
					result.Error.Clear();
				} else {
					result.Error.Set(ErrorType.ConsumeFailed, this);
				}
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param
		internal override void Neglect(ref Source source, ref Result result) {
			if (source.Length == 0) {
				result.Error.Set(ErrorType.EndOfSource, this);
			} else {
				if (!Check(source.Peek())) {
					source.Position++;
					result.Length++;
					result.Error.Clear();
				} else {
					result.Error.Set(ErrorType.NeglectFailed, this);
				}
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Node"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns
		public override Boolean Equals(Node node) {
			switch (node) {
			case CharChecker other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Node"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Node"/>.</param>.
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(ReadOnlySpan<Char> other) => other.Length == 1 && Check(other[0]);

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Node"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Node"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns
		public override Boolean Equals(String other) => other.Length == 1 && Check(other[0]);

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="CharChecker"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns
		public Boolean Equals(CharChecker other) => Check.Equals(other.Check);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Check.GetHashCode();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => $"┋{Name}┋";

		#region Alternator

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Node"/>.
		/// </summary>
		/// <param name="right">The <see cref="Node"/> to check if this <see cref="Node"/> does not match.</param>
		/// <returns>A new <see cref="Node"/> alternating this <see cref="Node"/> and <paramref name="right"/>.</returns>
		internal override Node Alternate(Node right) {
			switch (right) {
			case CharChecker cc:
				return new AlternateCharChecker(Name, Check, cc.Check);
			default:
				return base.Alternate(right);
			}
		}

		#endregion

		#region Repeater

		/// <summary>
		/// Repeats this <see cref="Node"/> <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Node"/> repeated <paramref name="count"/> times.</returns
		internal override Node Repeat(Int32 count) => new RepeatCharChecker(Name, Check, count);

		#endregion
	}
}