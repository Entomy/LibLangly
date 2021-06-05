#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a rune literal, a pattern matching this exact rune.
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.Text.Rune"/> into something that we can treat as part of a pattern.
	/// </remarks>
	internal sealed class RuneLiteral : Literal {
		/// <summary>
		/// The <see cref="System.Text.Rune"/> being matched.
		/// </summary>
		internal readonly Rune Rune;

		/// <summary>
		/// Initialize a new <see cref="RuneLiteral"/> with the given <paramref name="rune"/>.
		/// </summary>
		/// <param name="rune"></param>
		internal RuneLiteral(Rune rune) : this(rune, default) { }

		/// <summary>
		/// Initialize a new <see cref="RuneLiteral"/> with the given <paramref name="rune"/>.
		/// </summary>
		/// <param name="rune">The <see cref="System.Text.Rune"/> to parse.</param>
		/// <param name="casing">The <see cref="Case"/> to use when parsing.</param>
		internal RuneLiteral(Rune rune, Case casing) : base(casing) => Rune = rune;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Rune.ToString();

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Int32 length = Rune.Utf16SequenceLength;
			if (location + length > source.Length) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else if (Text.Equals(Rune, source.Slice(location, length), Casing)) {
				trace?.Add(source.Slice(location, length), location);
				location += length;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, location);
			}
		}

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) {
			// We're checking for the entire Rune instead of just the first char. Since most runes won't need to be decoded, this is more efficient.
			Int32 length = Rune.Utf16SequenceLength;
			return Text.Equals(Rune, source.Slice(location, length), Casing);
		}

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) {
			// We're checking for the entire Rune instead of just the first char. Since most runes won't need to be decoded, this is more efficient.
			Int32 length = Rune.Utf16SequenceLength;
			return !Text.Equals(Rune, source.Slice(location, length), Casing);
		}

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace)  {
			Int32 length = Rune.Utf16SequenceLength;
			if (location + length > source.Length) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else if (!Text.Equals(Rune, source.Slice(location, length), Casing)) {
				trace?.Add(source.Slice(location, length), location);
				location += length;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, location);
			}
		}
	}
}
#endif
