using System;
using System.Diagnostics.CodeAnalysis;
#if NETCOREAPP3_0_OR_GREATER
using System.Text;
#endif
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a parser result or named capture component.
	/// </summary>
	/// <remarks>
	/// <para>Any parser result is itself a capture or sequence of captures. The most optimal approach is always taken. For instance, if the source is contiguous memory, the capture will be the entire captured region, but if the source is a stream or other non-contiguous data, the capture will be each individual step of the parse.</para>
	/// <para>This is also used in the implementation of backreferences (which are like in <see href="https://www.regular-expressions.info/backref.html">Regex</see>).</para>
	/// </remarks>
	public sealed partial class Capture :
		IIndexReadOnly<nint, Char>,
		ISequence<Char, Capture.Enumerator> {
		/// <summary>
		/// The captured text.
		/// </summary>
		internal ReadOnlyMemory<Char> Text;

		/// <summary>
		/// Initialize a new <see cref="Capture"/> object.
		/// </summary>
		internal Capture() => Text = ReadOnlyMemory<Char>.Empty;

		/// <inheritdoc/>
		public nint Count => Text.Length;

		/// <inheritdoc/>
		public Char this[[DisallowNull] nint index] => Text.Span[(Int32)index];

		/// <inheritdoc/>
		[return: NotNull]
		public Enumerator GetEnumerator() => new Enumerator(Text);

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<Char> System.Collections.Generic.IEnumerable<Char>.GetEnumerator() => GetEnumerator();

		/// <summary>
		/// Marks this <see cref="Pattern"/> as spanning.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which spans, repeating as many times as necessary until it doesn't match anymore.</returns>
		[return: NotNull]
		public Pattern Many() => new CaptureLiteral(this).Many();

		/// <summary>
		/// Marks this <see cref="Pattern"/> as optional.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which may or may not be present in order to match.</returns>
		[return: NotNull]
		public Pattern Maybe() => new CaptureLiteral(this).Maybe();

		/// <summary>
		/// Marks this <see cref="Pattern"/> as negated.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which matches the negation of this <see cref="Pattern"/>.</returns>
		[return: NotNull]
		public Pattern Not() => new CaptureLiteral(this).Not();

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public Pattern Or([AllowNull] Pattern other) => new CaptureLiteral(this).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Char"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public Pattern Or(Char other) => new CaptureLiteral(this).Or(other);

#if NETCOREAPP3_0_OR_GREATER
		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Rune"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public Pattern Or(Rune other) => new CaptureLiteral(this).Or(other);
#endif

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public Pattern Or([AllowNull] String other) => new CaptureLiteral(this).Or(other);

		/// <summary>
		/// Marks this <see cref="Pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		[return: NotNull]
		public Pattern Repeat(Int32 count) => new CaptureLiteral(this).Repeat(count);

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public Pattern Then([AllowNull] Pattern other) => new CaptureLiteral(this).Then(other);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		[return: NotNull]
		public Pattern Then(Char other) => new CaptureLiteral(this).Then(other);

#if NETCOREAPP3_0_OR_GREATER
		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Rune"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		[return: NotNull]
		public Pattern Then(Rune other) => new CaptureLiteral(this).Then(other);
#endif

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="String"/>.
		/// </summary>
		/// <param name="other">The succeeding <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public Pattern Then([AllowNull] String other) => new CaptureLiteral(this).Then(other);

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>.
		/// </summary>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		[return: NotNull]
		public Pattern To([DisallowNull] Pattern to) => new CaptureLiteral(this).To(to);

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>, allowing an <paramref name="escape"/>.
		/// </summary>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		/// <param name="escape">The escape <see cref="Pattern"/>./</param>
		/// <remarks>
		/// If <paramref name="escape"/> is <see langword="null"/> this does the same as <see cref="To(Pattern)"/>.
		/// </remarks>
		[return: NotNull]
		public Pattern To([DisallowNull] Pattern to, [AllowNull] Pattern escape) => new CaptureLiteral(this).To(to, escape);

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>, that allows nesting of this pattern inside of itself.
		/// </summary>
		/// <remarks>
		/// The easiest way to explain this is that is shows up a lot in programming, with things like if-then-else statements which can contain other if-then-else statements.
		/// </remarks>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		[return: NotNull]
		public Pattern ToNested([DisallowNull] Pattern to) => new CaptureLiteral(this).ToNested(to);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Text.ToString();

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => $"{Text.Slice(0, (Int32)amount)}...";
	}
}
