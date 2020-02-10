using System;
using Stringier.Patterns.Debugging;
using Stringier.Patterns.Nodes;
using Defender;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a textual pattern; this pattern mutates during construction.
	/// </summary>
	/// <remarks>
	/// This is a specialization for use with recursion systems. Because a target is created from a <see cref="Pattern"/> and points to it, the reference must not change, yet the underlying pattern must change. That means the object must mutate, which is generally undesired and avoided.
	/// </remarks>
	internal sealed class MutablePattern : Pattern {
		/// <summary>
		/// The <see cref="Pattern"/> at the head of this <see cref="Pattern"/>; the entry point of the graph.
		/// </summary>
		internal Pattern? Head;

		/// <summary>
		/// Whether the pattern is readonly or not.
		/// </summary>
		/// <remarks>
		/// A <see cref="MutablePattern"/> when readonly is treated exactly like a normal <see cref="Pattern"/> and is no longer mutable.
		/// </remarks>
		private Boolean ReadOnly = false;

		/// <summary>
		/// Initialize a new <see cref="MutablePattern"/>.
		/// </summary>
		internal MutablePattern() { }

		/// <summary>
		/// Seals the pattern to prevent further modification. Only does something for mutable patterns.
		/// </summary>
		/// <remarks>
		/// This essentially converts a mutable pattern back into a pattern, so any further combination works like normal, rather than mutating in-place.
		/// </remarks>
		public override void Seal() => ReadOnly = true;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => Head?.CheckHeader(ref source) ?? false;


		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			Head.Consume(ref source, ref result, trace);
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <exception cref="PatternUndefinedException">The pattern was attempted to be used before actually being defined.</exception>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) {
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			Head.Neglect(ref source, ref result, trace);
		}

		#region Alternator

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public sealed override Pattern Or(Pattern other) {
			if (ReadOnly) {
				return base.Or(other);
			}
			Guard.NotNull(other, nameof(other));
			if (Head is null) {
				throw new PatternUndefinedException();
			} else {
				Head = Head.Alternate(other);
				return this;
			}
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public sealed override Pattern Or(String other) {
			if (ReadOnly) {
				return base.Or(other);
			}
			Guard.NotNull(other, nameof(other));
			if (Head is null) {
				throw new PatternUndefinedException();
			} else {
				Head = Head.Alternate(other);
				return this;
			}
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Char"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public sealed override Pattern Or(Char other) {
			if (ReadOnly) {
				return base.Or(other);
			}
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			Head = Head.Alternate(other);
			return this;
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Capture"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public sealed override Pattern Or(Capture other) {
			if (ReadOnly) {
				return base.Or(other);
			}
			Guard.NotNull(other, nameof(other));
			if (Head is null) {
				throw new PatternUndefinedException();
			} else {
				Head = Head.Alternate(new CaptureLiteral(other));
				return this;
			}
		}

		#endregion

		#region Capturer

		/// <summary>
		/// Declares this <see cref="Pattern"/> should be captured into <paramref name="capture"/> for later reference.
		/// </summary>
		/// <param name="capture">A <see cref="Patterns.Capture"/> object to store into.</param>
		/// <returns>A new <see cref="Pattern"/> which will capture its result into <paramref name="capture"/>.</returns>
		public sealed override Pattern Capture(out Capture capture) {
			if (ReadOnly) {
				return base.Capture(out capture);
			}
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			Head = Head.Capture(out capture);
			return this;
		}

		#endregion

		#region Concatenator

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public sealed override Pattern Then(Pattern other) {
			if (ReadOnly) {
				return base.Then(other);
			}
			Guard.NotNull(other, nameof(other));
			Head = Head is null ? other : Head.Concatenate(other);
			return this;
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="String"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public sealed override Pattern Then(String other) {
			if (ReadOnly) {
				return base.Then(other);
			}
			Guard.NotNull(other, nameof(other));
			Head = Head is null ? new StringLiteral(other) : Head.Concatenate(other);
			return this;
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public sealed override Pattern Then(Char other) {
			if (ReadOnly) {
				return base.Then(other);
			}
			Head = Head is null ? new CharLiteral(other) : Head.Concatenate(other);
			return this;
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public sealed override Pattern Then(Capture other) {
			if (ReadOnly) {
				return base.Then(other);
			}
			Guard.NotNull(other, nameof(other));
			Head = Head is null ? new CaptureLiteral(other) : Head.Concatenate(new CaptureLiteral(other));
			return this;
		}

		#endregion Concatenator

		#region Negator

		/// <summary>
		/// Marks this <see cref="Pattern"/> as negated.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which is negated.</returns>
		/// <remarks>
		/// This exists to set up dispatching to the appropriate <see cref="Pattern"/> type. Dispatching happens to be faster than switching on a typeclass.
		/// </remarks>
		internal sealed override Pattern Negate() {
			if (ReadOnly) {
				return base.Negate();
			}
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			Head = Head.Negate();
			return this;
		}

		#endregion

		#region Optor

		/// <summary>
		/// Marks this <see cref="Pattern"/> as optional.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		/// <remarks>
		/// This exists to set up dispatching to the appropriate <see cref="Pattern"/> type. Dispatching happens to be faster than switching on a typeclass.
		/// </remarks>
		internal sealed override Pattern Optional() {
			if (ReadOnly) {
				return base.Optional();
			}
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			Head = Head.Optional();
			return this;
		}

		#endregion

		#region Repeater

		/// <summary>
		/// Marks this <see cref="Pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public sealed override Pattern Repeat(Int32 count) {
			if (ReadOnly) {
				return base.Repeat(count);
			}
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			Head = Head.Repeat(count);
			return this;
		}

		#endregion

		#region Spanner

		/// <summary>
		/// Marks this <see cref="Pattern"/> as spanning.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		/// <remarks>
		/// This exists to set up dispatching to the appropriate <see cref="Pattern"/> type. Dispatching happens to be faster than switching on a typeclass.
		/// </remarks>
		internal sealed override Pattern Span() {
			if (ReadOnly) {
				return base.Span();
			}
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			Head = Head.Span();
			return this;
		}

		#endregion
	}
}
