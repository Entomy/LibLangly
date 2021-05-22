using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents the alternation of <see cref="CharChecker"/>.
	/// </summary>
	/// <remarks>
	/// This is an optimization, and doesn't do anything that normal alternation wouldn't be able to do.
	/// </remarks>
	internal sealed class AlternateCharChecker : Checker {
		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		[NotNull, DisallowNull]
		internal readonly Func<Char, Boolean> Left;

		/// <summary>
		/// A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.
		/// </summary>
		[NotNull, DisallowNull]
		internal readonly Func<Char, Boolean> Right;

		/// <summary>
		/// Initialize a new <see cref="AlternateCharChecker"/> from the specified <paramref name="left"/> check and <paramref name="right"/> check.
		/// </summary>
		/// <param name="left">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.</param>
		/// <param name="right">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/>.</param>
		internal AlternateCharChecker([DisallowNull] Func<Char, Boolean> left, [DisallowNull] Func<Char, Boolean> right) {
			Left = left;
			Right = right;
		}
	}
}
