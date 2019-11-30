using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Errors;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents the repetition of <see cref="CharChecker"/>.
	/// </summary>
	/// <remarks>
	/// This is an optimization, and doesn't do anything that normal repeater wouldn't be able to do.
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It is overriden, Sonar is just too stupid to figure out this pattern")]
	internal sealed class RepeatCharChecker : Checker, IEquatable<RepeatCharChecker> {
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		internal readonly new Func<Char, Boolean> Check;

		/// <summary>
		/// The amount of times to repeat.
		/// </summary>
		internal readonly Int32 Count;

		/// <summary>
		/// Initialize a new <see cref="RepeatCharChecker"/> from the specified <paramref name="name"/>, <paramref name="check"/>, and <paramref name="count"/>.
		/// </summary>
		/// <param name="name">The name to refer to this as</param>
		/// <param name="check">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </param>
		/// <param name="count">The amount of times to repeat.</param>
		internal RepeatCharChecker(String name, Func<Char, Boolean> check, Int32 count) : base(name) {
			Check = check;
			Count = count;
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => !source.EOF && Check(source.Peek());

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		internal override void Consume(ref Source source, ref Result result) {
			if (source.EOF) {
				result.Error.Set(ErrorType.EndOfSource, this);
			} else {
				for (Int32 i = 0; i < Count; i++) {
					if (source.EOF) {
						result.Error.Set(ErrorType.ConsumeFailed, this);
					}
					if (Check(source.Peek())) {
						source.Position++;
						result.Length++;
						result.Error.Clear();
					} else {
						result.Error.Set(ErrorType.ConsumeFailed, this);
						break;
					}
				}
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		internal override void Neglect(ref Source source, ref Result result) {
			if (source.EOF) {
				result.Error.Set(ErrorType.EndOfSource, this);
			} else {
				for (Int32 i = 0; i < Count; i++) {
					if (source.EOF) {
						result.Error.Set(ErrorType.NeglectFailed, this);
					}
					if (!Check(source.Peek())) {
						source.Position++;
						result.Length++;
						result.Error.Clear();
					} else {
						result.Error.Set(ErrorType.NeglectFailed, this);
						break;
					}
				}
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Pattern"/> to compare with the current <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Pattern"/> is equal to the current <see cref="Pattern"/>; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(Pattern? node) {
			switch (node) {
			case RepeatCharChecker checker:
				return Equals(checker);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(ReadOnlySpan<Char> other) {
			if (other.Length != Count) {
				return false;
			}
			for (Int32 i = 0; i < Count; i++) {
				if (!Check(other[i])) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(String other) {
			if (other.Length != Count) {
				return false;
			}
			for (Int32 i = 0; i < Count; i++) {
				if (!Check(other[i])) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="RepeatCharChecker"/> to compare with the current <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Pattern"/>; otherwise, <c>false</c>.</returns>
		public Boolean Equals(RepeatCharChecker other) => Check.Equals(other.Check) && Count.Equals(other.Count);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Check.GetHashCode();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => $"┋{Count}┆{Name}┋";
	}
}
