using System;
using static Stringier.Metrics;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Determines whether two specified <see cref="String"/> objects have roughly the same value.
		/// </summary>
		/// <param name="string">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="string"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// This determines whether the two <see cref="String"/> objects are similar enough that any differences are likely due to a typo or regional variation.
		/// </remarks>
		public static Boolean FuzzyEquals(this String @string, String other) => FuzzyEquals(@string, other, 1);

		/// <summary>
		/// Determines whether the specified <see cref="String"/> and <see cref="ReadOnlySpan{T}"/> objects have roughly the same value.
		/// </summary>
		/// <param name="string">The string to compare.</param>
		/// <param name="other">The span to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="string"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// This determines whether the specified <see cref="String"/> and <see cref="ReadOnlySpan{T}"/> objects are similar enough that any differences are likely due to a typo or regional variation.
		/// </remarks>
		public static Boolean FuzzyEquals(this String @string, ReadOnlySpan<Char> other) => FuzzyEquals(@string, other, 1);

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> and <see cref="String"/> objects have roughly the same value.
		/// </summary>
		/// <param name="span">The span to compare.</param>
		/// <param name="other">The string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="span"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// This determines whether the specified <see cref="ReadOnlySpan{T}"/> and <see cref="String"/> objects are similar enough that any differences are likely due to a typo or regional variation.
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> span, String other) => FuzzyEquals(span, other, 1);

		/// <summary>
		/// Determines whether two specified <see cref="ReadOnlySpan{T}"/> objects have roughly the same value.
		/// </summary>
		/// <param name="span">The first span to compare.</param>
		/// <param name="other">The second span to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="span"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// This determines whether the two <see cref="ReadOnlySpan{T}"/> objects are similar enough that any differences are likely due to a typo or regional variation.
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> span, ReadOnlySpan<Char> other) => FuzzyEquals(span, other, 1);

		/// <summary>
		/// Determines whether two specified <see cref="String"/> objects have roughly the same value.
		/// </summary>
		/// <param name="string">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of edits between the two objects allowed before being considered unequal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="string"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// This determines whether the two <see cref="String"/> objects are similar enough that any differences are likely due to a typo or regional variation.
		/// </remarks>
		public static Boolean FuzzyEquals(this String @string, String other, Int32 maxEdits) => LevenshteinDistance(@string, other) <= maxEdits;

		/// <summary>
		/// Determines whether the specified <see cref="String"/> and <see cref="ReadOnlySpan{T}"/> objects have roughly the same value.
		/// </summary>
		/// <param name="string">The string to compare.</param>
		/// <param name="other">The span to compare.</param>
		/// <param name="maxEdits">The maximum amount of edits between the two objects allowed before being considered unequal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="string"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// This determines whether the specified <see cref="String"/> and <see cref="ReadOnlySpan{T}"/> objects are similar enough that any differences are likely due to a typo or regional variation.
		/// </remarks>
		public static Boolean FuzzyEquals(this String @string, ReadOnlySpan<Char> other, Int32 maxEdits) => LevenshteinDistance(@string, other) <= maxEdits;

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> and <see cref="String"/> objects have roughly the same value.
		/// </summary>
		/// <param name="span">The span to compare.</param>
		/// <param name="other">The string to compare.</param>
		/// <param name="maxEdits">The maximum amount of edits between the two objects allowed before being considered unequal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="span"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// This determines whether the specified <see cref="ReadOnlySpan{T}"/> and <see cref="String"/> objects are similar enough that any differences are likely due to a typo or regional variation.
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> span, String other, Int32 maxEdits) => LevenshteinDistance(span, other) <= maxEdits;

		/// <summary>
		/// Determines whether two specified <see cref="ReadOnlySpan{T}"/> objects have roughly the same value.
		/// </summary>
		/// <param name="span">The first span to compare.</param>
		/// <param name="other">The second span to compare.</param>
		/// <param name="maxEdits">The maximum amount of edits between the two objects allowed before being considered unequal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="span"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// This determines whether the two <see cref="ReadOnlySpan{T}"/> objects are similar enough that any differences are likely due to a typo or regional variation.
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> span, ReadOnlySpan<Char> other, Int32 maxEdits) => LevenshteinDistance(span, other) <= maxEdits;
	}
}
