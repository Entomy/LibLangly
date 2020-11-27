using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public static partial class Text {
		#region Equals(Text, String)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String text, [AllowNull] String other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] text, [AllowNull] String other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> text, [AllowNull] String other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, [AllowNull] String other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> text, [AllowNull] String other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> text, [AllowNull] String other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, [AllowNull] String other) => Equals(text, length, other, default);
		#endregion

		#region Equals(Text, String, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String text, [AllowNull] String other, Case casing) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] text, [AllowNull] String other, Case casing) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> text, [AllowNull] String other, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals(text.Span, other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, [AllowNull] String other, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals(text.Span, other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> text, [AllowNull] String other, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals((ReadOnlySpan<Char>)text, other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> text, [AllowNull] String other, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals(text, other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, [AllowNull] String other, Case casing) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return Equals(new ReadOnlySpan<Char>(text, length), other.AsSpan(), casing);
			}
		}
		#endregion

		#region Equals(Text, Char[])
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String text, [AllowNull] Char[] other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] text, [AllowNull] Char[] other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> text, [AllowNull] Char[] other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, [AllowNull] Char[] other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> text, [AllowNull] Char[] other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> text, [AllowNull] Char[] other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, [AllowNull] Char[] other) => Equals(text, length, other, default);
		#endregion

		#region Equals(Text, Char[], Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String text, [AllowNull] Char[] other, Case casing) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] text, [AllowNull] Char[] other, Case casing) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> text, [AllowNull] Char[] other, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals(text.Span, other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, [AllowNull] Char[] other, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals(text.Span, other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> text, [AllowNull] Char[] other, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals((ReadOnlySpan<Char>)text, other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> text, [AllowNull] Char[] other, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals(text, other.AsSpan(), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, [AllowNull] Char[] other, Case casing) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return Equals(new ReadOnlySpan<Char>(text, length), other.AsSpan(), casing);
			}
		}
		#endregion

		#region Equals(Text, Memory<Char>)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String text, Memory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] text, Memory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> text, Memory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, Memory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> text, Memory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> text, Memory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, Memory<Char> other) => Equals(text, length, other, default);
		#endregion

		#region Equals(Text, Memory<Char>, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String text, Memory<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), other.Span, casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] text, Memory<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), other.Span, casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> text, Memory<Char> other, Case casing) => Equals(text.Span, other.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, Memory<Char> other, Case casing) => Equals(text.Span, other.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> text, Memory<Char> other, Case casing) => Equals((ReadOnlySpan<Char>)text, other.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> text, Memory<Char> other, Case casing) => Equals(text, other.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, Memory<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(new ReadOnlySpan<Char>(text, length), other.Span, casing);
			}
		}
		#endregion

		#region Equals(Text, ReadOnlyMemory<Char>)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String text, ReadOnlyMemory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] text, ReadOnlyMemory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> text, ReadOnlyMemory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, ReadOnlyMemory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> text, ReadOnlyMemory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> text, ReadOnlyMemory<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, ReadOnlyMemory<Char> other) => Equals(text, length, other, default);
		#endregion

		#region Equals(Text, ReadOnlyMemory<Char>, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String text, ReadOnlyMemory<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), other.Span, casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] text, ReadOnlyMemory<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), other.Span, casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> text, ReadOnlyMemory<Char> other, Case casing) => Equals(text.Span, other.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, ReadOnlyMemory<Char> other, Case casing) => Equals(text.Span, other.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> text, ReadOnlyMemory<Char> other, Case casing) => Equals((ReadOnlySpan<Char>)text, other.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> text, ReadOnlyMemory<Char> other, Case casing) => Equals(text, other.Span, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, ReadOnlyMemory<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(new ReadOnlySpan<Char>(text, length), other.Span, casing);
			}
		}
		#endregion

		#region Equals(Text, Span<Char>)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String text, Span<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] text, Span<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> text, Span<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, Span<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> text, Span<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> text, Span<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, Span<Char> other) => Equals(text, length, other, default);
		#endregion

		#region Equals(Text, Span<Char>, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String text, Span<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), (ReadOnlySpan<Char>)other, casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] text, Span<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), (ReadOnlySpan<Char>)other, casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> text, Span<Char> other, Case casing) => Equals(text.Span, (ReadOnlySpan<Char>)other, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, Span<Char> other, Case casing) => Equals(text.Span, (ReadOnlySpan<Char>)other, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> text, Span<Char> other, Case casing) => Equals((ReadOnlySpan<Char>)text, (ReadOnlySpan<Char>)other, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> text, Span<Char> other, Case casing) => Equals(text, (ReadOnlySpan<Char>)other, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, Span<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(new ReadOnlySpan<Char>(text, length), (ReadOnlySpan<Char>)other, casing);
			}
		}
		#endregion

		#region Equals(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this String text, ReadOnlySpan<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals([AllowNull] this Char[] text, ReadOnlySpan<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Memory<Char> text, ReadOnlySpan<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, ReadOnlySpan<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> text, ReadOnlySpan<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) => Equals(text, other, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, ReadOnlySpan<Char> other) => Equals(text, length, other, default);
		#endregion

		#region Equals(Text, ReadOnlySpan<Char>, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this String text, ReadOnlySpan<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), other, casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals([AllowNull] this Char[] text, ReadOnlySpan<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), other, casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Memory<Char> text, ReadOnlySpan<Char> other, Case casing) => Equals(text.Span, other, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlyMemory<Char> text, ReadOnlySpan<Char> other, Case casing) => Equals(text.Span, other, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> text, ReadOnlySpan<Char> other, Case casing) => Equals((ReadOnlySpan<Char>)text, other, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> other, Case casing) {
			switch (casing) {
			case Case.Insensitive:
				return EqualsInsensitive(text, other);
			case Case.Sensitive:
				return EqualsSensitive(text, other);
			default:
				throw ArgumentNotValidException.With(casing, nameof(casing));
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, ReadOnlySpan<Char> other, Case casing) {
			if (text is null) {
				return false;
			} else {
				return Equals(new ReadOnlySpan<Char>(text, length), other, casing);
			}
		}
		#endregion

		#region Equals(Text, Char*)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] String text, [AllowNull] Char* other, Int32 length) => Equals(text, other, length, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char[] text, [AllowNull] Char* other, Int32 length) => Equals(text, other, length, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Memory<Char> text, [AllowNull] Char* other, Int32 length) => Equals(text, other, length, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(ReadOnlyMemory<Char> text, [AllowNull] Char* other, Int32 length) => Equals(text, other, length, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Span<Char> text, [AllowNull] Char* other, Int32 length) => Equals(text, other, length, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(ReadOnlySpan<Char> text, [AllowNull] Char* other, Int32 length) => Equals(text, other, length, default);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="otherLength">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, [AllowNull] Char* other, Int32 otherLength) => Equals(text, length, other, otherLength, default);
		#endregion

		#region Equals(Text, Char*, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] String text, [AllowNull] Char* other, Int32 length, Case casing) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char[] text, [AllowNull] Char* other, Int32 length, Case casing) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return Equals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Memory<Char> text, [AllowNull] Char* other, Int32 length, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals(text.Span, new ReadOnlySpan<Char>(other, length), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(ReadOnlyMemory<Char> text, [AllowNull] Char* other, Int32 length, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals(text.Span, new ReadOnlySpan<Char>(other, length), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Span<Char> text, [AllowNull] Char* other, Int32 length, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals((ReadOnlySpan<Char>)text, new ReadOnlySpan<Char>(other, length), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(ReadOnlySpan<Char> text, [AllowNull] Char* other, Int32 length, Case casing) {
			if (other is null) {
				return false;
			} else {
				return Equals(text, new ReadOnlySpan<Char>(other, length), casing);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="otherLength">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNotValidException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals([AllowNull] Char* text, Int32 length, [AllowNull] Char* other, Int32 otherLength, Case casing) {
			if (text is null && other is null) {
				return true;
			} else if (text is null || other is null) {
				return false;
			} else {
				return Equals(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(other, otherLength), casing);
			}
		}
		#endregion

		private static Boolean EqualsInsensitive(ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) {
			if (text.Length != other.Length) {
				return false;
			}
			for (Int32 i = 0; i < text.Length; i++) {
				if (text[i].ToUpper() != other[i].ToUpper()) {
					return false;
				}
			}
			return true;
		}

		private static Boolean EqualsSensitive(ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) {
			if (text.Length != other.Length) {
				return false;
			}
			for (Int32 i = 0; i < text.Length; i++) {
				if (text[i] != other[i]) {
					return false;
				}
			}
			return true;
		}
	}
}
