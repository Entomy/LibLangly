using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Represents the base of all <see cref="Langly"/> records.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <remarks>
	/// This type helps enforce structural semantics when appropriate, by establishing certain contracts around how equality works.
	/// </remarks>
	/// <seealso cref="Object"/>
	public abstract class Record<TSelf> : IEquals<TSelf>, IEquals<IEquals<TSelf>> where TSelf : Record<TSelf> {
		/// <summary>
		/// Determines if the two values aren't equal.
		/// </summary>
		/// <param name="left">The lefthand value.</param>
		/// <param name="right">The righthand value.</param>
		/// <returns><see langword="true"/> if the two values aren't equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] Record<TSelf> left, [AllowNull] Record<TSelf> right) {
			if (left is null && right is null) {
				return false;
			} else if (left is null || right is null) {
				return true;
			} else {
				return !left.Equals(right);
			}
		}

		/// <summary>
		/// Determines if the two values aren't equal.
		/// </summary>
		/// <param name="left">The lefthand value.</param>
		/// <param name="right">The righthand value.</param>
		/// <returns><see langword="true"/> if the two values aren't equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] Record<TSelf> left, [AllowNull] IEquals<Record<TSelf>> right) {
			if (left is null && right is null) {
				return false;
			} else if (left is null || right is null) {
				return true;
			} else {
				return !right.Equals(left);
			}
		}

		/// <summary>
		/// Determines if the two values aren't equal.
		/// </summary>
		/// <param name="left">The lefthand value.</param>
		/// <param name="right">The righthand value.</param>
		/// <returns><see langword="true"/> if the two values aren't equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] IEquals<Record<TSelf>> left, [AllowNull] Record<TSelf> right) {
			if (left is null && right is null) {
				return false;
			} else if (left is null || right is null) {
				return true;
			} else {
				return !left.Equals(right);
			}
		}

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="left">The lefthand value.</param>
		/// <param name="right">The righthand value.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] Record<TSelf> left, [AllowNull] Record<TSelf> right) {
			if (left is null && right is null) {
				return true;
			} else if (left is null || right is null) {
				return false;
			} else {
				return left.Equals(right);
			}
		}

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="left">The lefthand value.</param>
		/// <param name="right">The righthand value.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] Record<TSelf> left, [AllowNull] IEquals<Record<TSelf>> right) {
			if (left is null && right is null) {
				return true;
			} else if (left is null || right is null) {
				return false;
			} else {
				return right.Equals(left);
			}
		}

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="left">The lefthand value.</param>
		/// <param name="right">The righthand value.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] IEquals<Record<TSelf>> left, [AllowNull] Record<TSelf> right) {
			if (left is null && right is null) {
				return true;
			} else if (left is null || right is null) {
				return false;
			} else {
				return left.Equals(right);
			}
		}

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="obj">The other object.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed override Boolean Equals([AllowNull] System.Object obj) {
			switch (obj) {
			case TSelf other:
				return Equals(other);
			case IEquals<TSelf> other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="other">The other value.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		public abstract Boolean Equals([AllowNull] TSelf other);

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="other">The other value.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals([AllowNull] IEquals<TSelf> other) => other is not null && other.Equals((TSelf)this);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public sealed override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		public abstract override String ToString();
	}
}
