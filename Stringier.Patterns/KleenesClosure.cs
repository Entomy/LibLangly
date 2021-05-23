﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents the Kleene's Closure (Kleene Star), who's content is optional and may repeat.
	/// </summary>
	internal class KleenesClosure : Modifier {
		/// <summary>
		/// The <see cref="Stringier.Patterns.Pattern"/> to be parsed.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Pattern Pattern;

		/// <summary>
		/// Initialize a new <see cref="KleenesClosure"/> from the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Stringier.Patterns.Pattern"/> to be parsed.</param>
		internal KleenesClosure([DisallowNull] Pattern pattern) => Pattern = pattern;

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new NotImplementedException();

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new NotImplementedException();
	}
}