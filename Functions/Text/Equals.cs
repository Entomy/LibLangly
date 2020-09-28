using Defender;
using System;

#pragma warning disable MA0074 // Avoid implicit culture-sensitive methods

namespace Stringier {
	public static partial class Text {
		//Note: There's one implementation for literally all of these: Equals(ReadOnlySpan<Char>, ReadOnlySpan<Char>, Case), so the actual amount of code to maintain is super low. Furthermore, it uses the implementation of MemoryExtensions.Equals(ReadOnlySpan<Char>, ReadOnlySpanChar, Case), so there's actually nothing to maintain; they all exist here for orthogonality and coverage.

		#region Equals(Text, String)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this String text, String other) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), other.AsSpan());
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char[] text, String other) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), other.AsSpan());
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> text, String other) {
			Guard.NotNull(other, nameof(other));
			return Equals((ReadOnlySpan<Char>)text, other.AsSpan());
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> text, String other) {
			Guard.NotNull(other, nameof(other));
			return Equals(text, other.AsSpan());
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Char* text, Int32 length, String other) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(new ReadOnlySpan<Char>(text, length), other.AsSpan());
		}
		#endregion

		#region Equals(Text, String, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this String text, String other, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), other.AsSpan(), casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char[] text, String other, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), other.AsSpan(), casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> text, String other, Case casing) {
			Guard.NotNull(other, nameof(other));
			return Equals((ReadOnlySpan<Char>)text, other.AsSpan(), casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> text, String other, Case casing) {
			Guard.NotNull(other, nameof(other));
			return Equals(text, other.AsSpan(), casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Char* text, Int32 length, String other, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(new ReadOnlySpan<Char>(text, length), other.AsSpan(), casing);
		}
		#endregion

		#region Equals(Text, Char[])
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this String text, Char[] other) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), other.AsSpan());
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char[] text, Char[] other) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), other.AsSpan());
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> text, Char[] other) {
			Guard.NotNull(other, nameof(other));
			return Equals((ReadOnlySpan<Char>)text, other.AsSpan());
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> text, Char[] other) {
			Guard.NotNull(other, nameof(other));
			return Equals(text, other.AsSpan());
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Char* text, Int32 length, Char[] other) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(new ReadOnlySpan<Char>(text, length), other.AsSpan());
		}
		#endregion

		#region Equals(Text, Char[], Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this String text, Char[] other, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), other.AsSpan(), casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char[] text, Char[] other, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), other.AsSpan(), casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> text, Char[] other, Case casing) {
			Guard.NotNull(other, nameof(other));
			return Equals((ReadOnlySpan<Char>)text, other.AsSpan(), casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> text, Char[] other, Case casing) {
			Guard.NotNull(other, nameof(other));
			return Equals(text, other.AsSpan(), casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Char* text, Int32 length, Char[] other, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(new ReadOnlySpan<Char>(text, length), other, casing);
		}
		#endregion

		#region Equals(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this String text, ReadOnlySpan<Char> other) {
			Guard.NotNull(text, nameof(text));
			return Equals(text.AsSpan(), other);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char[] text, ReadOnlySpan<Char> other) {
			Guard.NotNull(text, nameof(text));
			return Equals(text.AsSpan(), other);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Span<Char> text, ReadOnlySpan<Char> other) => Equals((ReadOnlySpan<Char>)text, other);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) => Equals(text, other, Case.Sensitive);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Char* text, Int32 length, ReadOnlySpan<Char> other) {
			Guard.NotNull(text, nameof(text));
			return Equals(new ReadOnlySpan<Char>(text, length), other);
		}
		#endregion

		#region Equals(Text, ReadOnlySpan<Char>, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this String text, ReadOnlySpan<Char> other, Case casing) {
			Guard.NotNull(text, nameof(text));
			return Equals(text.AsSpan(), other, casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Char[] text, ReadOnlySpan<Char> other, Case casing) {
			Guard.NotNull(text, nameof(text));
			return Equals(text.AsSpan(), other, casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this Span<Char> text, ReadOnlySpan<Char> other, Case casing) => Equals((ReadOnlySpan<Char>)text, other, casing);

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		public static Boolean Equals(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> other, Case casing) {
			switch (casing) {
			case Case.Insensitive:
				return MemoryExtensions.Equals(text, other, StringComparison.OrdinalIgnoreCase);
			default:
				return MemoryExtensions.Equals(text, other, StringComparison.Ordinal);
			}
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Char* text, Int32 length, ReadOnlySpan<Char> other, Case casing) {
			Guard.NotNull(text, nameof(text));
			return Equals(new ReadOnlySpan<Char>(text, length), other, casing);
		}
		#endregion

		#region Equals(Text, Char*)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(String text, Char* other, Int32 length) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), new ReadOnlySpan<Char>(other, length));
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Char[] text, Char* other, Int32 length) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), new ReadOnlySpan<Char>(other, length));
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(ReadOnlySpan<Char> text, Char* other, Int32 length) {
			Guard.NotNull(other, nameof(other));
			return Equals(text, new ReadOnlySpan<Char>(other, length));
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="otherLength">The length of the <paramref name="other"/>.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Char* text, Int32 length, Char* other, Int32 otherLength) {
			if (length != otherLength) {
				return false;
			}
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(other, otherLength));
		}
		#endregion

		#region Equals(Text, Char*, Case)
		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(String text, Char* other, Int32 length, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Char[] text, Char* other, Int32 length, Case casing) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(text.AsSpan(), new ReadOnlySpan<Char>(other, length), casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(ReadOnlySpan<Char> text, Char* other, Int32 length, Case casing) {
			Guard.NotNull(other, nameof(other));
			return Equals(text, new ReadOnlySpan<Char>(other, length), casing);
		}

		/// <summary>
		/// Determines whether two text objects have the same content.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The text to compare to this instance.</param>
		/// <param name="otherLength">The length of the <paramref name="other"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this <paramref name="text"/>; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="casing"/> is not a <see cref="Case"/> value.</exception>
		[CLSCompliant(false)]
		public static unsafe Boolean Equals(Char* text, Int32 length, Char* other, Int32 otherLength, Case casing) {
			if (length != otherLength) {
				return false;
			}
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Equals(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(other, otherLength), casing);
		}
		#endregion
	}
}
