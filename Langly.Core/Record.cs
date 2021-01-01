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
	public abstract class Record<TSelf> : IEquals<Record<TSelf>>, IEquals<IEquals<Record<TSelf>>> where TSelf : Record<TSelf> {
		public static Boolean operator !=([AllowNull] Record<TSelf> left, [AllowNull] Record<TSelf> right) {
			if (left is null && right is null) {
				return false;
			} else if (left is null || right is null) {
				return true;
			} else {
				return !left.Equals(right);
			}
		}

		public static Boolean operator !=([AllowNull] Record<TSelf> left, [AllowNull] IEquals<Record<TSelf>> right) {
			if (left is null && right is null) {
				return false;
			} else if (left is null || right is null) {
				return true;
			} else {
				return !right.Equals(left);
			}
		}

		public static Boolean operator !=([AllowNull] IEquals<Record<TSelf>> left, [AllowNull] Record<TSelf> right) {
			if (left is null && right is null) {
				return false;
			} else if (left is null || right is null) {
				return true;
			} else {
				return !left.Equals(right);
			}
		}

		public static Boolean operator ==([AllowNull] Record<TSelf> left, [AllowNull] Record<TSelf> right) {
			if (left is null && right is null) {
				return true;
			} else if (left is null || right is null) {
				return false;
			} else {
				return left.Equals(right);
			}
		}

		public static Boolean operator ==([AllowNull] Record<TSelf> left, [AllowNull] IEquals<Record<TSelf>> right) {
			if (left is null && right is null) {
				return true;
			} else if (left is null || right is null) {
				return false;
			} else {
				return right.Equals(left);
			}
		}

		public static Boolean operator ==([AllowNull] IEquals<Record<TSelf>> left, [AllowNull] Record<TSelf> right) {
			if (left is null && right is null) {
				return true;
			} else if (left is null || right is null) {
				return false;
			} else {
				return left.Equals(right);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Boolean Equals([AllowNull] System.Object obj) {
			switch (obj) {
			case Record<TSelf> other:
				return Equals(other);
			case IEquals<Record<TSelf>> other:
				return Equals(other);
			default:
				return false;
			}
		}

		public abstract Boolean Equals([AllowNull] Record<TSelf> other);

		public Boolean Equals([AllowNull] IEquals<Record<TSelf>> other) => other is not null && other.Equals(this);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public sealed override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		public abstract override String ToString();
	}
}
