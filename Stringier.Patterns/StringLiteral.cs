using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>	
	/// Represents a string literal pattern, a pattern matching this exact string.
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern.
	/// </remarks>
	internal sealed class StringLiteral : Literal {
		/// <summary>
		/// The actual text being matched.
		/// </summary>
		internal readonly ReadOnlyMemory<Char> String;

		/// <summary>
		/// Initialize a new <see cref="StringLiteral"/> with the given <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The text to parse.</param>
		internal StringLiteral([DisallowNull] String @string) : this(@string, default) { }

		/// <summary>
		/// Intialize a new <see cref="StringLiteral"/> with the given <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The text to parse.</param>
		/// <param name="casing">The <see cref="Case"/> to use when parsing.</param>
		internal StringLiteral([DisallowNull] String @string, Case casing) : this(@string.AsMemory(), casing) { }

		/// <summary>
		/// Initialize a new <see cref="StringLiteral"/> with the given <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The text to parse.</param>
		internal StringLiteral(ReadOnlyMemory<Char> @string) : this(@string, default) { }

		/// <summary>
		/// Intialize a new <see cref="StringLiteral"/> with the given <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The text to parse.</param>
		/// <param name="casing">The <see cref="Case"/> to use when parsing.</param>
		internal StringLiteral(ReadOnlyMemory<Char> @string, Case casing) : base(casing) => String = @string;

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Repeat(Int32 count) {
			Memory<Char> buffer = new Char[String.Length * count];
			for (Int32 i = 0; i < count; i++) {
				String.CopyTo(buffer.Slice(String.Length * count));
			}
			return new StringLiteral(buffer, Casing);
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => String.ToString();

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		private void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (location + String.Length > source.Length) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else if (Text.Equals(String, source.Slice(location, String.Length), Casing)) {
				trace?.Add(source.Slice(location, String.Length), location);
				location += String.Length;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, location);
			}
		}

		private void Neglect(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (location + String.Length > source.Length) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else if (!Text.Equals(String, source.Slice(location, String.Length), Casing)) {
				trace?.Add(source.Slice(location, String.Length), location);
				location += String.Length;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, location);
			}
		}
	}
}
