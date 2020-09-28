using System;
using Defender;

namespace Stringier {
	public static partial class Text {
		#region PadRight(Text, Int32)
		/// <summary>
		/// Returns a new string that left-aligns the characters in this instance by padding them with spaces on the right, for a specified total length.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many spaces as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
		public static String PadRight(this String text, Int32 totalWidth) => PadRight(text, totalWidth, ' ');

		/// <summary>
		/// Returns a new string that left-aligns the characters in this instance by padding them with spaces on the right, for a specified total length.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many spaces as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
		public static String PadRight(this Char[] text, Int32 totalWidth) => PadRight(text, totalWidth, ' ');

		/// <summary>
		/// Returns a new string that left-aligns the characters in this instance by padding them with spaces on the right, for a specified total length.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many spaces as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
		public static String PadRight(this Span<Char> text, Int32 totalWidth) => PadRight(text, totalWidth, ' ');

		/// <summary>
		/// Returns a new string that left-aligns the characters in this instance by padding them with spaces on the right, for a specified total length.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many spaces as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
		public static String PadRight(this ReadOnlySpan<Char> text, Int32 totalWidth) => PadRight(text, totalWidth, ' ');

		/// <summary>
		/// Returns a new string that left-aligns the characters in this instance by padding them with spaces on the right, for a specified total length.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many spaces as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
		[CLSCompliant(false)]
		public static unsafe String PadRight(Char* text, Int32 length, Int32 totalWidth) => PadRight(text, length, totalWidth, ' ');
		#endregion

		#region PadRight(Text, Int32, Char)
		/// <summary>
		/// Returns a new string that left-aligns the characters in this instance by padding them on the right with a specified Unicode character, for a specified total length.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many <paramref name="paddingChar"/> characters as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
		public static String PadRight(this String text, Int32 totalWidth, Char paddingChar) {
			Guard.NotNull(text, nameof(text));
			return PadRight(text.AsSpan(), totalWidth, paddingChar).ToString();
		}

		/// <summary>
		/// Returns a new string that left-aligns the characters in this instance by padding them on the right with a specified Unicode character, for a specified total length.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many <paramref name="paddingChar"/> characters as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
		public static String PadRight(this Char[] text, Int32 totalWidth, Char paddingChar) {
			Guard.NotNull(text, nameof(text));
			return PadRight(text.AsSpan(), totalWidth, paddingChar);
		}

		/// <summary>
		/// Returns a new string that left-aligns the characters in this instance by padding them on the right with a specified Unicode character, for a specified total length.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many <paramref name="paddingChar"/> characters as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
		public static String PadRight(this Span<Char> text, Int32 totalWidth, Char paddingChar) => PadRight((ReadOnlySpan<Char>)text, totalWidth, paddingChar);

		/// <summary>
		/// Returns a new string that left-aligns the characters in this instance by padding them on the right with a specified Unicode character, for a specified total length.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many <paramref name="paddingChar"/> characters as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
		public static String PadRight(this ReadOnlySpan<Char> text, Int32 totalWidth, Char paddingChar) {
			Guard.GreaterThanOrEqual(totalWidth, nameof(totalWidth), 0);
			if (totalWidth <= text.Length) {
				return text.ToString();
			}
			Span<Char> result = new Char[totalWidth];
			Int32 splitPoint = totalWidth - text.Length;
			text.CopyTo(result.Slice(0, splitPoint));
			result.Slice(splitPoint, text.Length).Fill(paddingChar);
			return result.ToString();
		}

		/// <summary>
		/// Returns a new string that left-aligns the characters in this instance by padding them on the right with a specified Unicode character, for a specified total length.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many <paramref name="paddingChar"/> characters as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
		[CLSCompliant(false)]
		public static unsafe String PadRight(Char* text, Int32 length, Int32 totalWidth, Char paddingChar) {
			Guard.NotNull(text, nameof(text));
			return PadRight(new ReadOnlySpan<Char>(text, length), totalWidth, paddingChar);
		}
		#endregion
	}
}
