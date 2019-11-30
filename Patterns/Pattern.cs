using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Nodes;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a textual pattern
	/// </summary>
	public partial class Pattern : IEquatable<Pattern>, IEquatable<String> {
		/// <summary>
		/// The <see cref="Node"/> at the head of this <see cref="Pattern"/>; the entry point of the graph.
		/// </summary>
		internal Node? Head;

		/// <summary>
		/// Initialize a new <see cref="Pattern"/>.
		/// </summary>
		internal Pattern() { }

		/// <summary>
		/// Initialize a new <see cref="Pattern"/> with the given head <see cref="Node"/>.
		/// </summary>
		/// <param name="head">The head <see cref="Node"/> of this <see cref="Pattern"/>; the entry point of the graph.</param>
		internal Pattern(Node head) => Head = head;

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="Result"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Consume(Result Source) {
			Source source = new Source(Source);
			return Consume(ref source);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Consume(String Source) {
			if (Source is null) {
				throw new ArgumentNullException(nameof(Source));
			}
			Source source = new Source(Source);
			return Consume(ref source);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Consume(ref Source Source) {
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			Result Result = new Result(ref Source);
			Int32 OriginalPosition = Source.Position;
			Head.Consume(ref Source, ref Result);
			if (!Result) {
				Source.Position = OriginalPosition;
			}
			return Result;
		}

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
		public Boolean Equals(Pattern other) => Head?.Equals(other?.Head) ?? false;

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public Boolean Equals(ReadOnlySpan<Char> other) => Head?.Equals(other) ?? false;

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public Boolean Equals(String other) {
			if (Head is null && other is null) {
				return true;
			} else if (Head is null || other is null) {
				return false;
			} else {
				return Head.Equals(other);
			}
		}

		public static Pattern Mutable() => new MutablePattern();

		/// <summary>
		/// Returns the hash code for this <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "This is actually the behavior we want. I don't know why you'd ever put Patterns in a collection, but this is the best way to appropriately deal with that without hampering performance in what this is intended for.")]
		public override Int32 GetHashCode() => base.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Pattern"/>.</returns>
		public override String ToString() => Head?.ToString() ?? "";
	}
}