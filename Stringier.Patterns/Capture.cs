using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier {
	/// <summary>
	/// Represents a named capture component
	/// </summary>
	/// <remarks>
	/// This is used primarily in the implementation of backreferences (which are like in [Regex](https://www.regular-expressions.info/backref.html)).
	/// </remarks>
	public sealed class Capture {
		//! No matter how good of an idea it might seem like, do not add an implicit conversion to String inside this class. Resolution of conversions causes String to be favored over Pattern, in which case StringLiteral's will be formed over CaptureLiteral's, which causes lazy resolution to no longer be done, breaking a bunch of shit.
		//! Higher performance could probably be acheived by making this a ref struct, however this would severely limit the usability of captures. It's often necessary to make the pattern a static member of a class, and capturing also winds up a static member, which can't be a ref struct.

		/// <summary>
		/// The captured <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/>.
		/// </summary>
		internal ReadOnlyMemory<Char> Value;

		/// <summary>
		/// Initialize a new <see cref="Capture"/> object.
		/// </summary>
		public Capture() => Value = ReadOnlyMemory<Char>.Empty;

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

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Rune"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public Pattern Or(Rune other) => new CaptureLiteral(this).Or(other);

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

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Rune"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		[return: NotNull]
		public Pattern Then(Rune other) => new CaptureLiteral(this).Then(other);

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
		public override String ToString() => $"{Value}";
	}
}
