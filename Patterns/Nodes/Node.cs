using System;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Pattern"/> node.
	/// </summary>
	internal abstract class Node : IEquatable<Node>, IEquatable<String> {
		/// <summary>
		/// Checks the first character in the <paramref name="Source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="Source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal abstract Boolean CheckHeader(ref Source Source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="Source"/> with the <paramref name="Result"/>.
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume.</param>
		/// <param name="Result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		internal abstract void Consume(ref Source Source, ref Result Result);

		/// <summary>
		/// Call the Neglect parser of this <see cref="Node"/> on the <paramref name="Source"/> with the <paramref name="Result"/>.
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume.</param>
		/// <param name="Result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		internal abstract void Neglect(ref Source Source, ref Result Result);

		public static Boolean operator ==(Node Left, Node Right) => Left is null || Right is null ? false : Left.Equals(Right);

		public static Boolean operator !=(Node Left, Node Right) => Left is null || Right is null ? false : !Left.Equals(Right);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public sealed override Boolean Equals(Object? obj) {
			switch (obj) {
			case Node node:
				return Equals(node);
			case String @string:
				return Equals(@string);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Node"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns>
		public abstract Boolean Equals(Node node);

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Node"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Node"/>.</param>.
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public virtual Boolean Equals(ReadOnlySpan<Char> other) {
			Source Source = new Source(other);
			Result Result = new Result(ref Source);
			Consume(ref Source, ref Result);
			return Result && Source.Length == 0;
		}

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Node"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Node"/>.</param>
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
		/// Returns the hash code for this <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public abstract override Int32 GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Node"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Node"/>.</returns>
		public abstract override String ToString();

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Node"/>.
		/// </summary>
		/// <param name="right">The <see cref="Node"/> to check if this <see cref="Node"/> does not match.</param>
		/// <returns>A new <see cref="Node"/> alternating this <see cref="Node"/> and <paramref name="right"/>.</returns>
		internal virtual Node Alternate(Node right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Alternator(this, right);
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Node"/>.
		/// </summary>
		/// <param name="right">The <see cref="Char"/> to check if this <see cref="Node"/> does not match.</param>
		/// <returns>A new <see cref="Node"/> alternating this <see cref="Node"/> and <paramref name="right"/>.</returns>
		internal virtual Node Alternate(Char right) => new Alternator(this, new CharLiteral(right));

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Node"/>.
		/// </summary>
		/// <param name="right">The <see cref="String"/> to check if this <see cref="Node"/> does not match.</param>
		/// <returns>A new <see cref="Node"/> alternating this <see cref="Node"/> and <paramref name="right"/>.</returns
		internal virtual Node Alternate(String right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Alternator(this, new StringLiteral(right));
		}

		/// <summary>
		/// Captures this <see cref="Node"/>'s match into the <paramref name="capture"/>.
		/// </summary>
		/// <param name="capture">The <see cref="Patterns.Capture"/> to capture into.</param>
		/// <returns>A new <see cref="Node"/> which will capture its contents into <paramref name="capture"/>.</returns>
		internal Node Capture(out Capture capture) => new Capturer(this, out capture);

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Node"/> comes before the <paramref name="right"/> <see cref="Node"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="Node"/>.</param>
		/// <returns>A new <see cref="Node"/> concatenating this <see cref="Node"/> and <paramref name="right"/>.</returns>
		internal virtual Node Concatenate(Node right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Concatenator(this, right);
		}

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Node"/> comes before the <paramref name="right"/> <see cref="Char"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Node"/> concatenating this <see cref="Node"/> and <paramref name="right"/>.</returns>
		internal virtual Node Concatenate(Char right) => new Concatenator(this, new CharLiteral(right));

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Node"/> comes before the <paramref name="right"/> <see cref="String"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="String"/>.</param>
		/// <returns>A new <see cref="Node"/> concatenating this <see cref="Node"/> and <paramref name="right"/>.</returns
		internal virtual Node Concatenate(String right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Concatenator(this, new StringLiteral(right));
		}

		//internal virtual Node Negate() => new Negator(this);

		internal virtual Node Optional() => new Optor(this);

		//internal virtual Node Repeat(Int32 Count) => new Repeater(this, Count);

		//internal virtual Node Span() => new Spanner(this);
	}
}