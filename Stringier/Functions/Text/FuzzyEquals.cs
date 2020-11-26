using System;
using System.Diagnostics.CodeAnalysis;
using Langly;

namespace Stringier {
	public static partial class Text {
		#region FuzzyEquals(Text, String)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, [AllowNull] String other) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, [AllowNull] String other) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, [AllowNull] String other) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, [AllowNull] String other) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, [AllowNull] String other) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, [AllowNull] String other) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text, other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, [AllowNull] String other) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan());
			}
		}
		#endregion

		#region FuzzyEquals(Text, Char[])
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, [AllowNull] Char[] other) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, [AllowNull] Char[] other) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, [AllowNull] Char[] other) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, [AllowNull] Char[] other) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, [AllowNull] Char[] other) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, [AllowNull] Char[] other) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text, other.AsSpan());
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, [AllowNull] Char[] other) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan());
			}
		}
		#endregion

		#region FuzzyEquals(Text, Memory<Char>)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, Memory<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, Memory<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, Memory<Char> other) => FuzzyEquals(text.Span, other.Span);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, Memory<Char> other) => FuzzyEquals(text.Span, other.Span);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, Memory<Char> other) => FuzzyEquals((ReadOnlySpan<Char>)text, other.Span);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Memory<Char> other) => FuzzyEquals(text, other.Span);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, Memory<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.Span);
			}
		}
		#endregion

		#region FuzzyEquals(Text, ReadOnlyMemory<Char>)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, ReadOnlyMemory<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, ReadOnlyMemory<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, ReadOnlyMemory<Char> other) => FuzzyEquals(text.Span, other.Span);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, ReadOnlyMemory<Char> other) => FuzzyEquals(text.Span, other.Span);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, ReadOnlyMemory<Char> other) => FuzzyEquals((ReadOnlySpan<Char>)text, other.Span);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, ReadOnlyMemory<Char> other) => FuzzyEquals(text, other.Span);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, ReadOnlyMemory<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.Span);
			}
		}
		#endregion

		#region FuzzyEquals(Text, Span<Char>)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, Span<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), (ReadOnlySpan<Char>)other);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, Span<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), (ReadOnlySpan<Char>)other);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, Span<Char> other) => FuzzyEquals(text.Span, (ReadOnlySpan<Char>)other);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, Span<Char> other) => FuzzyEquals(text.Span, (ReadOnlySpan<Char>)other);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, Span<Char> other) => FuzzyEquals((ReadOnlySpan<Char>)text, (ReadOnlySpan<Char>)other);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Span<Char> other) => FuzzyEquals(text, (ReadOnlySpan<Char>)other);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, Span<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), (ReadOnlySpan<Char>)other);
			}
		}
		#endregion

		#region FuzzyEquals(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, ReadOnlySpan<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, ReadOnlySpan<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, ReadOnlySpan<Char> other) => FuzzyEquals(text.Span, other);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, ReadOnlySpan<Char> other) => FuzzyEquals(text.Span, other);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, ReadOnlySpan<Char> other) => FuzzyEquals((ReadOnlySpan<Char>)text, other);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) {
			// We need to determine based on the lengths of the texts what type of comparison is most appropriate: edit-distance or string-similarity.
			if (text.Length <= 20) {
				return FuzzyEquals(text, other, maxEdits: 1);
			} else {
				return FuzzyEquals(text, other, minSimilarity: 0.95);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, ReadOnlySpan<Char> other) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other);
			}
		}
		#endregion

		#region FuzzyEquals(Text, Char*)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] this String text, [AllowNull] Char* other, Int32 length) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length));
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] this Char[] text, [AllowNull] Char* other, Int32 length) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length));
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this Memory<Char> text, [AllowNull] Char* other, Int32 length) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, new ReadOnlySpan<Char>(other, length));
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, [AllowNull] Char* other, Int32 length) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, new ReadOnlySpan<Char>(other, length));
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this Span<Char> text, [AllowNull] Char* other, Int32 length) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals((ReadOnlySpan<Char>)text, new ReadOnlySpan<Char>(other, length));
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this ReadOnlySpan<Char> text, [AllowNull] Char* other, Int32 length) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text, new ReadOnlySpan<Char>(other, length));
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="otherLength">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, [AllowNull] Char* other, Int32 otherLength) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(other, otherLength));
			}
		}
		#endregion

		#region FuzzyEquals(Text, String, Int32)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, [AllowNull] String other, Int32 maxEdits) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, [AllowNull] String other, Int32 maxEdits) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, [AllowNull] String other, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, [AllowNull] String other, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, [AllowNull] String other, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, [AllowNull] String other, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text, other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, [AllowNull] String other, Int32 maxEdits) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan(), maxEdits);
			}
		}
		#endregion

		#region FuzzyEquals(Text, Char[], Int32)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, [AllowNull] Char[] other, Int32 maxEdits) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, [AllowNull] Char[] other, Int32 maxEdits) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, [AllowNull] Char[] other, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, [AllowNull] Char[] other, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, [AllowNull] Char[] other, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, [AllowNull] Char[] other, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text, other.AsSpan(), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, [AllowNull] Char[] other, Int32 maxEdits) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan(), maxEdits);
			}
		}
		#endregion

		#region FuzzyEquals(Text, Memory<Char>, Int32)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, Memory<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span, maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, Memory<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span, maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, Memory<Char> other, Int32 maxEdits) => FuzzyEquals(text.Span, other.Span, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, Memory<Char> other, Int32 maxEdits) => FuzzyEquals(text.Span, other.Span, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, Memory<Char> other, Int32 maxEdits) => FuzzyEquals((ReadOnlySpan<Char>)text, other.Span, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Memory<Char> other, Int32 maxEdits) => FuzzyEquals(text, other.Span, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, Memory<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.Span, maxEdits);
			}
		}
		#endregion

		#region FuzzyEquals(Text, ReadOnlyMemory<Char>, Int32)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, ReadOnlyMemory<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span, maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, ReadOnlyMemory<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span, maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, ReadOnlyMemory<Char> other, Int32 maxEdits) => FuzzyEquals(text.Span, other.Span, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, ReadOnlyMemory<Char> other, Int32 maxEdits) => FuzzyEquals(text.Span, other.Span, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, ReadOnlyMemory<Char> other, Int32 maxEdits) => FuzzyEquals((ReadOnlySpan<Char>)text, other.Span, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, ReadOnlyMemory<Char> other, Int32 maxEdits) => FuzzyEquals(text, other.Span, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, ReadOnlyMemory<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.Span, maxEdits);
			}
		}
		#endregion

		#region FuzzyEquals(Text, Span<Char>, Int32)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, Span<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), (ReadOnlySpan<Char>)other, maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, Span<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), (ReadOnlySpan<Char>)other, maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, Span<Char> other, Int32 maxEdits) => FuzzyEquals(text.Span, (ReadOnlySpan<Char>)other, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, Span<Char> other, Int32 maxEdits) => FuzzyEquals(text.Span, (ReadOnlySpan<Char>)other, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, Span<Char> other, Int32 maxEdits) => FuzzyEquals((ReadOnlySpan<Char>)text, (ReadOnlySpan<Char>)other, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Span<Char> other, Int32 maxEdits) => FuzzyEquals(text, (ReadOnlySpan<Char>)other, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, Span<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), (ReadOnlySpan<Char>)other, maxEdits);
			}
		}
		#endregion

		#region FuzzyEquals(Text, ReadOnlySpan<Char>, Int32)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, ReadOnlySpan<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other, maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, ReadOnlySpan<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other, maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, ReadOnlySpan<Char> other, Int32 maxEdits) => FuzzyEquals(text.Span, other, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, ReadOnlySpan<Char> other, Int32 maxEdits) => FuzzyEquals(text.Span, other, maxEdits);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
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
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
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
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(Char* text, Int32 length, ReadOnlySpan<Char> other, Int32 maxEdits) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other, maxEdits);
			}
		}
		#endregion

		#region FuzzyEquals(Text, Char*, Int32)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] this String text, [AllowNull] Char* other, Int32 length, Int32 maxEdits) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] this Char[] text, [AllowNull] Char* other, Int32 length, Int32 maxEdits) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this Memory<Char> text, [AllowNull] Char* other, Int32 length, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, new ReadOnlySpan<Char>(other, length), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, [AllowNull] Char* other, Int32 length, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, new ReadOnlySpan<Char>(other, length), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this Span<Char> text, [AllowNull] Char* other, Int32 length, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals((ReadOnlySpan<Char>)text, new ReadOnlySpan<Char>(other, length), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals(this ReadOnlySpan<Char> text, [AllowNull] Char* other, Int32 length, Int32 maxEdits) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text, new ReadOnlySpan<Char>(other, length), maxEdits);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="otherLength">The length of the <paramref name="other"/>.</param>
		/// <param name="maxEdits">The maximum amount of allowed edits to still be considered roughly equal.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, [AllowNull] Char* other, Int32 otherLength, Int32 maxEdits) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(other, otherLength), maxEdits);
			}
		}
		#endregion

		#region FuzzyEquals(Text, String, Double)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, [AllowNull] String other, Double minSimilarity) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan(), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, [AllowNull] String other, Double minSimilarity) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan(), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, [AllowNull] String other, Double minSimilarity) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, other.AsSpan(), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlyMemory<Char> text, [AllowNull] String other, Double minSimilarity) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, other.AsSpan(), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, [AllowNull] String other, Double minSimilarity) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan(), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, [AllowNull] String other, Double minSimilarity) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text, other.AsSpan(), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
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
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, [AllowNull] String other, Double minSimilarity) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan(), minSimilarity);
			}
		}
		#endregion

		#region FuzzyEquals(Text, Char[], Double)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, [AllowNull] Char[] other, Double minSimilarity) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan(), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, [AllowNull] Char[] other, Double minSimilarity) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.AsSpan(), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Memory<Char> text, [AllowNull] Char[] other, Double minSimilarity) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text.Span, other.AsSpan(), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, [AllowNull] Char[] other, Double minSimilarity) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals((ReadOnlySpan<Char>)text, other.AsSpan(), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, [AllowNull] Char[] other, Double minSimilarity) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text, other.AsSpan(), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
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
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, [AllowNull] Char[] other, Double minSimilarity) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.AsSpan(), minSimilarity);
			}
		}
		#endregion

		#region FuzzyEquals(Text, Memory<Char>, Double)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, Memory<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span, minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, Memory<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span, minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, Memory<Char> other, Double minSimilarity) => FuzzyEquals((ReadOnlySpan<Char>)text, other.Span, minSimilarity);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Memory<Char> other, Double minSimilarity) => FuzzyEquals(text, other.Span, minSimilarity);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
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
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, Memory<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.Span, minSimilarity);
			}
		}
		#endregion

		#region FuzzyEquals(Text, ReadOnlyMemory<Char>, Double)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, ReadOnlyMemory<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span, minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, ReadOnlyMemory<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other.Span, minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, ReadOnlyMemory<Char> other, Double minSimilarity) => FuzzyEquals((ReadOnlySpan<Char>)text, other.Span, minSimilarity);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, ReadOnlyMemory<Char> other, Double minSimilarity) => FuzzyEquals(text, other.Span, minSimilarity);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
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
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, ReadOnlyMemory<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other.Span, minSimilarity);
			}
		}
		#endregion

		#region FuzzyEquals(Text, Span<Char>, Double)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, Span<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), (ReadOnlySpan<Char>)other, minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, Span<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), (ReadOnlySpan<Char>)other, minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this Span<Char> text, Span<Char> other, Double minSimilarity) => FuzzyEquals((ReadOnlySpan<Char>)text, (ReadOnlySpan<Char>)other, minSimilarity);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals(this ReadOnlySpan<Char> text, Span<Char> other, Double minSimilarity) => FuzzyEquals(text, (ReadOnlySpan<Char>)other, minSimilarity);

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
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
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, Span<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), (ReadOnlySpan<Char>)other, minSimilarity);
			}
		}
		#endregion

		#region FuzzyEquals(Text, ReadOnlySpan<Char>, Double)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this String text, ReadOnlySpan<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other, minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
		/// <param name="minSimilarity">
		/// <para>The minimum similarity allowed to still be considered approximately equal.</para>
		/// <para>Range [0, 1], with higher values indicating higher similarity.</para>
		/// </param>
		/// <returns><see langword="true"/> if the value of <paramref name="text"/> is roughly the same as the value of <paramref name="other"/>; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>This determines whether the two texts are similar enough that any differences are likely due to a typo or regional variation.</para>
		/// <para>Avoid using this for attempts at plagiarism detection, as this isn't the way to do it, even though it might seem like it at first.</para>
		/// </remarks>
		public static Boolean FuzzyEquals([AllowNull] this Char[] text, ReadOnlySpan<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), other, minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
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
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
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
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
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
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, ReadOnlySpan<Char> other, Double minSimilarity) {
			if (text is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), other, minSimilarity);
			}
		}
		#endregion

		#region FuzzyEquals(Text, Char*, Double)
		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
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
		public static unsafe Boolean FuzzyEquals([AllowNull] this String text, [AllowNull] Char* other, Int32 length, Double minSimilarity) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
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
		public static unsafe Boolean FuzzyEquals([AllowNull] this Char[] text, [AllowNull] Char* other, Int32 length, Double minSimilarity) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
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
		public static unsafe Boolean FuzzyEquals(this Span<Char> text, [AllowNull] Char* other, Int32 length, Double minSimilarity) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals((ReadOnlySpan<Char>)text, new ReadOnlySpan<Char>(other, length), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="other">The second text to compare.</param>
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
		public static unsafe Boolean FuzzyEquals(this ReadOnlySpan<Char> text, [AllowNull] Char* other, Int32 length, Double minSimilarity) {
			if (other is null) {
				return false;
			} else {
				return FuzzyEquals(text, new ReadOnlySpan<Char>(other, length), minSimilarity);
			}
		}

		/// <summary>
		/// Determines whether two specified texts have roughly the same value.
		/// </summary>
		/// <param name="text">The first text to compare.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The second text to compare.</param>
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
		public static unsafe Boolean FuzzyEquals([AllowNull] Char* text, Int32 length, [AllowNull] Char* other, Int32 otherLength, Double minSimilarity) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return FuzzyEquals(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(other, length), minSimilarity);
			}
		}
		#endregion
	}
}
