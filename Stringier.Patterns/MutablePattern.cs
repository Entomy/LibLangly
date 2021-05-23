#if NET5_0_OR_GREATER
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a textual pattern; this pattern mutates during construction.
	/// </summary>
	public sealed class MutablePattern : Pattern {
		/// <summary>
		/// The <see cref="Pattern"/> at the head of this <see cref="MutablePattern"/>; the entry point of the graph.
		/// </summary>
		/// <remarks>
		/// This works because even though <see cref="MutablePattern"/> is derived from <see cref="Pattern"/>, and therefore behaves like one, it holds a <see cref="Pattern"/> in this field, potentially doing things like swapping the pattern, or even holding no pattern at all. All the normal pattern building operations dispatch onto this pattern, if present, providing the same operations, but simultaneously allowing for this pattern to exist before it's really been defined, allowing for circular references like recursive grammars.
		/// </remarks>
		[AllowNull, MaybeNull]
		private Pattern Head;

		/// <summary>
		/// Initialize a new <see cref="MutablePattern"/>.
		/// </summary>
		public MutablePattern() { }

		/// <summary>
		/// Converts to a <see cref="MutablePattern"/> matching exactly the <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> to match.</param>
		[return: NotNull]
		public static implicit operator MutablePattern(Char @char) => new MutablePattern { Head = @char };

		/// <summary>
		/// Converts to a <see cref="MutablePattern"/> matching exactly the <paramref name="char"/>.
		/// </summary>
		/// <param name="char">A <see cref="ValueTuple{T1, T2}"/> of <see cref="Char"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator MutablePattern((Char, Case) @char) => new MutablePattern { Head = @char };

		/// <summary>
		/// Converts to a <see cref="MutablePattern"/> matching exactly the <paramref name="rune"/>.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> to match.</param>
		[return: NotNull]
		public static implicit operator MutablePattern(Rune rune) => new MutablePattern { Head = rune };

		/// <summary>
		/// Converts to a <see cref="MutablePattern"/> matching exactly the <paramref name="rune"/>.
		/// </summary>
		/// <param name="rune">A <see cref="ValueTuple{T1, T2}"/> of <see cref="Rune"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator MutablePattern((Rune, Case) rune) => new MutablePattern { Head = rune };

		/// <summary>
		/// Converts to a <see cref="MutablePattern"/> matching exactly the <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to match.</param>
		[return: NotNull]
		public static implicit operator MutablePattern([AllowNull] String @string) => new MutablePattern { Head = @string };

		/// <summary>
		/// Converts to a <see cref="MutablePattern"/> matching exactly the <paramref name="string"/>.
		/// </summary>
		/// <param name="string">A <see cref="ValueTuple{T1, T2}"/> of <see cref="String"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator MutablePattern((String, Case) @string) => new MutablePattern { Head = @string };

		/// <summary>
		/// Converts to a <see cref="MutablePattern"/> matching exactly the <paramref name="capture"/>.
		/// </summary>
		/// <param name="capture">The <see cref="Patterns.Capture"/> to match.</param>
		[return: NotNull]
		public static implicit operator MutablePattern([AllowNull] Capture capture) => new MutablePattern { Head = capture };

		/// <summary>
		/// Converts to a <see cref="MutablePattern"/> matching exactly the <paramref name="capture"/>.
		/// </summary>
		/// <param name="capture">A <see cref="ValueTuple{T1, T2}"/> of <see cref="Patterns.Capture"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator MutablePattern((Capture, Case) capture) => new MutablePattern { Head = capture };

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The <see cref="MutablePattern"/> to make optional.</param>
		/// <returns>A new <see cref="MutablePattern"/> which may or may not be present in order to match.</returns>
		[return: MaybeNull, NotNullIfNotNull("pattern")]
		public static MutablePattern operator -([AllowNull] MutablePattern pattern) => pattern?.Maybe();

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="MutablePattern"/> to negate.</param>
		/// <returns>A new <see cref="MutablePattern"/> which matches the negation of <paramref name="pattern"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("pattern")]
		public static MutablePattern operator !([AllowNull] MutablePattern pattern) => pattern?.Not();

		/// <summary>
		/// Declares <paramref name="right"/> to come after <paramref name="left"/>.
		/// </summary>
		/// <param name="left">The lefthand <see cref="MutablePattern"/>; placed first.</param>
		/// <param name="right">The righthand <see cref="MutablePattern"/>; placed last.</param>
		/// <returns>A new <see cref="MutablePattern"/> matching <paramref name="left"/> then <paramref name="right"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("left"), NotNullIfNotNull("right")]
		public static MutablePattern operator &([AllowNull] MutablePattern left, [AllowNull] MutablePattern right) => left?.Then(right) ?? right;

		/// <summary>
		/// Marks the <paramref name="pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="pattern">The <see cref="MutablePattern"/> to repeat.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="MutablePattern"/> repeated <paramref name="count"/> times.</returns>
		[return: MaybeNull, NotNullIfNotNull("pattern")]
		public static MutablePattern operator *([AllowNull] MutablePattern pattern, Int32 count) => pattern?.Repeat(count);

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>.
		/// </summary>
		/// <param name="left">The lefthand <see cref="MutablePattern"/>; checked first.</param>
		/// <param name="right">The righthand <see cref="MutablePattern"/>; checked last.</param>
		/// <returns>A new <see cref="MutablePattern"/> matching <paramref name="left"/> or <paramref name="right"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("left"), NotNullIfNotNull("right")]
		public static MutablePattern operator |([AllowNull] MutablePattern left, [AllowNull] MutablePattern right) => left?.Or(right) ?? right;

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The <see cref="MutablePattern"/> to span.</param>
		/// <returns>A new <see cref="MutablePattern"/> which spans, repeating as many times as necessary until it doesn't match anymore.</returns>
		[return: MaybeNull, NotNullIfNotNull("pattern")]
		public static MutablePattern operator +([AllowNull] MutablePattern pattern) => pattern?.Many();

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Capture([DisallowNull, NotNull] out Capture capture) {
			if (Head is not null) {
				Head = Head.Capture(out capture);
			} else {
				capture = new CaptureDummy();
			}
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Many() {
			Head = Head?.Many();
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Maybe() {
			Head = Head?.Maybe();
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Not() {
			Head = Head?.Not();
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Or([AllowNull] Pattern other) {
			Head = Head?.Or(other) ?? other;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Or(Char other) {
			Head = Head?.Or(other) ?? other;
			return this;
		}

		/// <inheritdoc/>
		public override MutablePattern Or(Rune other) {
			Head = Head?.Or(other) ?? other;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Or([AllowNull] String other) {
			Head = Head?.Or(other) ?? other;
			return this;
		}
		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Repeat(Int32 count) {
			Head = Head?.Repeat(count);
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Then([AllowNull] Pattern other) {
			Head = Head?.Then(other) ?? other;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Then(Char other) {
			Head = Head?.Then(other) ?? other;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Then(Rune other) {
			Head = Head?.Then(other) ?? other;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern Then([AllowNull] String other) {
			Head = Head?.Then(other) ?? other;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern To([DisallowNull] Pattern to) {
			Head = Head?.To(to);
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern To([DisallowNull] Pattern to, [AllowNull] Pattern escape) {
			Head = Head?.To(to, escape);
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override MutablePattern ToNested([DisallowNull] Pattern to) {
			Head = Head?.ToNested(to);
			return this;
		}

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			Head?.Consume(source, ref length, out exception, trace);
		}

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			Head?.Neglect(source, ref length, out exception, trace);
		}
	}
}
#endif
