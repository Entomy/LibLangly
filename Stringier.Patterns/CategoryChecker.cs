#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	internal sealed class CategoryChecker : Checker {
		/// <summary>
		/// The category to match.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Category Category;

		/// <summary>
		/// Initializes a new <see cref="CategoryChecker"/>.
		/// </summary>
		/// <param name="category">The category to match.</param>
		public CategoryChecker([DisallowNull] Category category) => Category = category;

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (location == source.Length) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else if (Category.Contains(source[location])) {
				trace?.Add(source[location], location);
				location++;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, location);
			}
		}

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) => Category.Contains(source[location]);

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) => !Category.Contains(source[location]);

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (location == source.Length) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else if (!Category.Contains(source[location])) {
				trace?.Add(source[location], location);
				location++;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, location);
			}
		}
	}
}
#endif
