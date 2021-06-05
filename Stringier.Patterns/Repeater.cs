using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Patterns.Pattern"/> whos content repeats a given number of times.
	/// </summary>
	internal sealed class Repeater : Modifier {
		/// <summary>
		/// The amount of times to be parsed.
		/// </summary>
		private readonly Int32 Count;

		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Pattern Pattern;

		/// <summary>
		/// Initialize a new <see cref="Repeater"/> from the given <paramref name="pattern"/> and <paramref name="count"/>
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed.</param>
		/// <param name="count">The amount of times to be parsed.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> must be a positive integer.</exception>
		internal Repeater([DisallowNull] Pattern pattern, Int32 count) {
			Pattern = pattern;
			if (count <= 0) {
				throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive");
			}
			Count = count;
		}

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			for (Int32 i = 0; i < Count; i++) {
				Pattern.Consume(source, ref location, out exception, trace);
				if (exception is not null) return;
			}
		}

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) => Pattern.IsConsumeHeader(source, location);

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) => Pattern.IsNeglectHeader(source, location);

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			for (Int32 i = 0; i < Count; i++) {
				Pattern.Neglect(source, ref location, out exception, trace);
				if (exception is not null) return;
			}
		}
	}
}
