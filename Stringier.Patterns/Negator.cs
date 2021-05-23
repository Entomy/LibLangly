using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Stringier.Patterns.Pattern"/> whos content should be neglected.
	/// </summary>
	/// <remarks>
	/// This is syntactic sugar around the Neglect parser, which parses anything that does not match the pattern, with some special semantics for certain patterns. It is basically saying "anything that isn't this, that is the same length".
	/// </remarks>
	internal sealed class Negator : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Pattern Pattern;

		/// <summary>
		/// Intialize a new <see cref="Negator"/> from the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Stringier.Patterns.Pattern"/> to be parsed.</param>
		internal Negator([DisallowNull] Pattern pattern) => Pattern = pattern;

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Not() => Pattern;

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			Pattern?.Neglect(source, ref length, out exception, trace);
		}

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			Pattern?.Consume(source, ref length, out exception, trace);
		}
	}
}
