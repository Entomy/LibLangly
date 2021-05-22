using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Stringier.Patterns.Pattern"/> whos content is optional.
	/// </summary>
	internal sealed class Optor : Modifier {
		/// <summary>
		/// The <see cref="Stringier.Patterns.Pattern"/> to be parsed.
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
		public override Pattern Maybe() => this;

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Many() => throw new InvalidOperationException("Options can not span, as it creates an infinite loop. You probably want to make a span optional instead.");
	}
}
