﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>	
	/// Represents a character literal, a pattern matching this exact character.
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.Char"/> into something that we can treat as a part of a pattern.
	/// </remarks>
	internal sealed class CharLiteral : Literal {
		/// <summary>
		/// The actual <see cref="System.Char"/> being matched.
		/// </summary>
		internal readonly Char Char;

		/// <summary>
		/// Initialize a new <see cref="CharLiteral"/> with the given <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="System.Char"/> to parse.</param>
		internal CharLiteral(Char @char) : this(@char, default) { }

		/// <summary>
		/// Initialize a new <see cref="CharLiteral"/> with the given <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="System.Char"/> to parse.</param>
		/// <param name="casing">The <see cref="Case"/> to use when parsing.</param>
		internal CharLiteral(Char @char, Case casing) : base(casing) => Char = @char;

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Repeat(Int32 count) => new StringLiteral(new String(Char, count), Casing);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Char.ToString();

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (Text.Equals(Char, source[length], Casing)) {
				trace?.Add(source[length], length);
				length++;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, length);
			}
		}

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (!Text.Equals(Char, source[length], Casing)) {
				trace?.Add(source[length], length);
				length++;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, length);
			}
		}
	}
}