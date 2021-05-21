using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	/// <summary>
	/// Represents a programatic check of a <see cref="Char"/> for existance within a set, defined by the <see cref="Check"/> function.
	/// </summary>
	internal sealed class CharChecker : Checker {
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		[NotNull, DisallowNull]
		internal readonly Func<Char, Boolean> Check;

		/// <summary>
		/// Construct a new <see cref="CharChecker"/> from the specified <paramref name="check"/>.
		/// </summary>
		/// <param name="check">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.</param>
		internal CharChecker([DisallowNull] Func<Char, Boolean> check) => Check = check;

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Or([AllowNull] Pattern right) {
			switch (right) {
			case CharChecker checker:
				return new AlternateCharChecker(Check, checker.Check);
			default:
				return base.Or(right);
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Repeat(Int32 count) => new RepeatCharChecker(Check, count);
	}
}
