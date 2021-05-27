using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a capturer <see cref="Patterns.Pattern"/>. That is, a <see cref="Patterns.Pattern"/> which captures its match into a <see cref="Capture"/>.
	/// </summary>
	internal sealed class Capturer : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed and captured.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Pattern Pattern;

		/// <summary>
		/// The <see cref="Capture"/> object to capture into.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Capture CapStore;

		/// <summary>
		/// Initialize a new <see cref="Capturer"/> of the given <paramref name="pattern"/>, to be captured into <paramref name="capture"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed and captured.</param>
		/// <param name="capture">The <see cref="Capture"/> object to capture into.</param>
		internal Capturer([DisallowNull] Pattern pattern, [DisallowNull, NotNull] out Capture capture) {
			Pattern = pattern;
			capture = CapStore;
		}

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) => throw new NotImplementedException();

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) => throw new NotImplementedException();

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		private void Consume(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new NotImplementedException();

		private void Neglect(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new NotImplementedException();
	}
}
