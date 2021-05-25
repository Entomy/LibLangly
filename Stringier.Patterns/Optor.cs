using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Patterns.Pattern"/> whos content is optional.
	/// </summary>
	internal sealed class Optor : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Pattern Pattern;

		/// <summary>
		/// Intialize a new <see cref="Optor"/> from the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Stringier.Patterns.Pattern"/> to be parsed.</param>
		internal Optor([DisallowNull] Pattern pattern) => Pattern = pattern;

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Many() => throw new InvalidOperationException("Options can not span, as it creates an infinite loop. You probably want to make a span optional instead.");

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Maybe() => this;

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Pattern.Consume(source, ref location, out _, trace);
			exception = null; // If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Pattern.Consume(source, length, ref location, out _, trace);
			exception = null; // If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Pattern.Neglect(source, ref location, out _, trace);
			exception = null; // If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}

		/// <inheritdoc/>
		protected internal override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Pattern.Neglect(source, length, ref location, out _, trace);
			exception = null; // If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}
	}
}
