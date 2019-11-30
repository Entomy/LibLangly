using System;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a textual pattern
	/// </summary>
	public abstract partial class Pattern : IEquatable<Pattern>, IEquatable<String> {
		/// <summary>
		/// Initialize a new <see cref="Pattern"/>.
		/// </summary>
		internal Pattern() { }

		/// <summary>
		/// Seals the pattern to prevent further modification. Only does something for mutable patterns.
		/// </summary>
		/// <remarks>
		/// This essentially converts a mutable pattern back into a pattern, so any further combination works like normal, rather than mutating in-place.
		/// </remarks>
		public virtual void Seal() { }
		public static Boolean operator ==(Pattern left, Pattern right) {
			if (left is null && right is null) {
				return true;
			} else if (left is null || right is null) {
				return false;
			} else {
				return left.Equals(right);
			}
		}

		public static Boolean operator !=(Pattern left, Pattern right) {
			if (left is null && right is null) {
				return false;
			} else if (left is null || right is null) {
				return true;
			} else {
				return !left.Equals(right);
			}
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Pattern other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to compare with the current <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Pattern"/> is equal to the current <see cref="Pattern"/>; otherwise, <c>false</c>.</returns>
		public abstract Boolean Equals(Pattern? other);

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public virtual Boolean Equals(ReadOnlySpan<Char> other) {
			Source Source = new Source(other);
			Result Result = new Result(ref Source);
			Consume(ref Source, ref Result);
			return Result && Source.Length == 0;
		}

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public virtual Boolean Equals(String other) {
			if (other is null) {
				return false;
			}
			Source Source = new Source(other);
			Result Result = new Result(ref Source);
			Consume(ref Source, ref Result);
			return Result && Source.Length == 0;
		}

		/// <summary>
		/// Get an empty mutable pattern.
		/// </summary>
		/// <returns>An empty mutable pattern.</returns>
		/// <remarks>
		/// This provides a pattern which mutates in-place, which is dangerous. However, it is required when using the target/jumper system as left-recursion and mutual-recursion are not possible without it. <see cref="Seal"/> should be called when done, to prevent further modification than intended, which can have disasterous consequences.
		/// </remarks>
		public static Pattern Mutable() => new MutablePattern();

		/// <summary>
		/// Returns the hash code for this <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public abstract override Int32 GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Pattern"/>.</returns>
		public abstract override String ToString();

	}
}