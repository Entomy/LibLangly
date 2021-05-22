using System;
using System.Diagnostics.CodeAnalysis;

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
		protected override void Consume(ReadOnlyMemory<Char> source, ref Int32 length) => throw new NotImplementedException();

		/// <inheritdoc/>
		protected override void Neglect(ReadOnlyMemory<Char> source, ref Int32 length) => throw new NotImplementedException();
	}
}
