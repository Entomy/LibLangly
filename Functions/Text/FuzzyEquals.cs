using System;
using Defender;

namespace Stringier {
	public static partial class Text {
		#region FuzzyEquals(Text, Text)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this String text, String other) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan());
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this String text, Char[] other) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan());
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this String text, ReadOnlySpan<Char> other) {
			Guard.NotNull(text, nameof(text));
			return FuzzyEquals(text.AsSpan(), other);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this String text, Char* other, Int32 length) {
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length));
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Char[] text, String other) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan());
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Char[] text, Char[] other) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan());
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Char[] text, ReadOnlySpan<Char> other) {
			Guard.NotNull(text, nameof(text));
			return FuzzyEquals(text.AsSpan(), other);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this Char[] text, Char* other, Int32 length) {
			Guard.NotNull(text, nameof(text));
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length));
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, String other) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan());
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, Char[] other) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan());
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, ReadOnlySpan<Char> other) => FuzzyEquals((ReadOnlySpan<Char>)text, other);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this Span<Char> text, Char* other, Int32 length) {
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals((ReadOnlySpan<Char>)text, new ReadOnlySpan<Char>(other, length));
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, String other) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text, other.AsSpan());
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Char[] other) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text, other.AsSpan());
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) => FuzzyEquals(text, other, 0.95);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Char* other, Int32 length) {
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals(text, new ReadOnlySpan<Char>(other, length));
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, String other) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan());
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, Char[] other) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan());
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, ReadOnlySpan<Char> other) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="otherLength">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, Char* other, Int32 otherLength) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			Guard.Pointer(other, nameof(other), otherLength, nameof(otherLength));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(other, length));
		}
		#endregion

		#region FuzzyEquals(Text, Text, Int32)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this String text, String other, Int32 maxEdits) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan(), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this String text, Char[] other, Int32 maxEdits) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan(), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this String text, ReadOnlySpan<Char> other, Int32 maxEdits) {
			Guard.NotNull(text, nameof(text));
			return FuzzyEquals(text.AsSpan(), other, maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this String text, Char* other, Int32 length, Int32 maxEdits) {
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Char[] text, String other, Int32 maxEdits) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan(), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Char[] text, Char[] other, Int32 maxEdits) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan(), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Char[] text, ReadOnlySpan<Char> other, Int32 maxEdits) {
			Guard.NotNull(text, nameof(text));
			return FuzzyEquals(text.AsSpan(), other, maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this Char[] text, Char* other, Int32 length, Int32 maxEdits) {
			Guard.NotNull(text, nameof(text));
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, String other, Int32 maxEdits) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan(), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, Char[] other, Int32 maxEdits) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan(), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, ReadOnlySpan<Char> other, Int32 maxEdits) => FuzzyEquals((ReadOnlySpan<Char>)text, other, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this Span<Char> text, Char* other, Int32 length, Int32 maxEdits) {
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals((ReadOnlySpan<Char>)text, new ReadOnlySpan<Char>(other, length), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, String other, Int32 maxEdits) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text, other.AsSpan(), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Char[] other, Int32 maxEdits) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text, other.AsSpan(), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> other, Int32 maxEdits) {
			Guard.GreaterThanOrEqual(maxEdits, nameof(maxEdits), 0);
			return EditDistance.Levenshtein(text, other, Level.Char) <= maxEdits;
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Char* other, Int32 length, Int32 maxEdits) {
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals(text, new ReadOnlySpan<Char>(other, length), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, String other, Int32 maxEdits) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan(), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, Char[] other, Int32 maxEdits) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan(), maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, ReadOnlySpan<Char> other, Int32 maxEdits) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other, maxEdits);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="otherLength">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, Char* other, Int32 otherLength, Int32 maxEdits) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			Guard.Pointer(other, nameof(other), otherLength, nameof(otherLength));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(other, length), maxEdits);
		}
		#endregion

		#region FuzzyEquals(Text, Text, Double)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this String text, String other, Double minSimilarity) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan(), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this String text, Char[] other, Double minSimilarity) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan(), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this String text, ReadOnlySpan<Char> other, Double minSimilarity) {
			Guard.NotNull(text, nameof(text));
			return FuzzyEquals(text.AsSpan(), other, minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this String text, Char* other, Int32 length, Double minSimilarity) {
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Char[] text, String other, Double minSimilarity) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan(), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Char[] text, Char[] other, Double minSimilarity) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text.AsSpan(), other.AsSpan(), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Char[] text, ReadOnlySpan<Char> other, Double minSimilarity) {
			Guard.NotNull(text, nameof(text));
			return FuzzyEquals(text.AsSpan(), other, minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this Char[] text, Char* other, Int32 length, Double minSimilarity) {
			Guard.NotNull(text, nameof(text));
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, String other, Double minSimilarity) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan(), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, Char[] other, Double minSimilarity) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan(), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, ReadOnlySpan<Char> other, Double minSimilarity) => FuzzyEquals((ReadOnlySpan<Char>)text, other, minSimilarity);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this Span<Char> text, Char* other, Int32 length, Double minSimilarity) {
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals((ReadOnlySpan<Char>)text, new ReadOnlySpan<Char>(other, length), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, String other, Double minSimilarity) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text, other.AsSpan(), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Char[] other, Double minSimilarity) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(text, other.AsSpan(), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> other, Double minSimilarity) {
			Guard.Within(minSimilarity, nameof(minSimilarity), 0.0, 1.0);
			Int32 edits = EditDistance.Levenshtein(text, other, Level.Char);
			Double similarity = 1.0 - ((Double)edits / (Double)text.Length);
			return similarity >= minSimilarity;
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Char* other, Int32 length, Double minSimilarity) {
			Guard.Pointer(other, nameof(other), length, nameof(length));
			return FuzzyEquals(text, new ReadOnlySpan<Char>(other, length), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, String other, Double minSimilarity) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan(), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, Char[] other, Double minSimilarity) {
			Guard.NotNull(other, nameof(other));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan(), minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, ReadOnlySpan<Char> other, Double minSimilarity) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other, minSimilarity);
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first string to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second string to compare.</param>
		/// <param name="otherLength">The length of the <paramref name="other"/>.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, Char* other, Int32 otherLength, Double minSimilarity) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			Guard.Pointer(other, nameof(other), otherLength, nameof(otherLength));
			return FuzzyEquals(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(other, length), minSimilarity);
		}
		#endregion
	}
}
