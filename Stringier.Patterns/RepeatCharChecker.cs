using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents the repetition of <see cref="CharChecker"/>.
	/// </summary>
	/// <remarks>
	/// This is an optimization, and doesn't do anything that normal repeater wouldn't be able to do.
	/// </remarks>
	internal sealed class RepeatCharChecker : Checker {
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		[NotNull, DisallowNull]
		internal readonly Func<Char, Boolean> Check;

		/// <summary>
		/// The amount of times to repeat.
		/// </summary>
		internal readonly Int32 Count;

		/// <summary>
		/// Initialize a new <see cref="RepeatCharChecker"/> from the specified <paramref name="check"/> and <paramref name="count"/>.
		/// </summary>
		/// <param name="check">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </param>
		/// <param name="count">The amount of times to repeat.</param>
		internal RepeatCharChecker([DisallowNull] Func<Char, Boolean> check, Int32 count) {
			Check = check;
			Count = count;
		}
	}
}
