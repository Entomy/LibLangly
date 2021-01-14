using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Represents the base of all <see cref="Langly"/> objects.
	/// </summary>
	/// <remarks>
	/// This type helps enforce reference semantics when appropriate, by defining certain operations to only work through reference equality and preventing them from being overridden.
	/// </remarks>
	/// <seealso cref="Record{TSelf}"/>
	public abstract class Object : IEquals<Object> {
		/// <summary>
		/// Determines if the two object references are the same.
		/// </summary>
		/// <param name="first">The first object.</param>
		/// <param name="second">The second object.</param>
		/// <returns><see langword="true"/> if the two object references are the same; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] Object first, [AllowNull] Object second) => ReferenceEquals(first, second);

		/// <summary>
		/// Determines if the two object references are the same.
		/// </summary>
		/// <param name="left">The lefthand object.</param>
		/// <param name="right">The righthand object.</param>
		/// <returns><see langword="true"/> if the two object references aren't the same; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] Object left, [AllowNull] Object right) => !ReferenceEquals(left, right);

		/// <summary>
		/// Determines if the two object references are the same.
		/// </summary>
		/// <param name="left">The lefthand object.</param>
		/// <param name="right">The righthand object.</param>
		/// <returns><see langword="true"/> if the two object references are the same; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] Object left, [AllowNull] Object right) => ReferenceEquals(left, right);

		/// <summary>
		/// Determines whether this object reference is the same as the other <paramref name="obj"/> reference.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns><see langword="true"/> if the two object references are the same; otherwise, <see langword="false"/>.</returns>
		public sealed override Boolean Equals([AllowNull] System.Object obj) => ReferenceEquals(this, obj);

		/// <summary>
		/// Determines whether this object reference is the same as the <paramref name="other"/> object reference.
		/// </summary>
		/// <param name="other">The object to compare.</param>
		/// <returns><see langword="true"/> if the two object references are the same; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals([AllowNull] Object other) => ReferenceEquals(this, other);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public sealed override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		public sealed override System.String ToString() => base.ToString();
	}
}
