using Defender;
using System;

namespace Stringier {
	public static partial class Text {
		#region Slice(Text, Int32)
		/// <summary>
		/// Forms a slice out of this text that begins at a specified index.
		/// </summary>
		/// <param name="text">The text to slice.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <returns>A span that consists of all elements of the current span from <paramref name="start"/> to the end of the text.</returns>
		public static ReadOnlySpan<Char> Slice(this String text, Int32 start) {
			Guard.NotNull(text, nameof(text));
			return Slice(text.AsSpan(), start);
		}

		/// <summary>
		/// Forms a slice out of this text that begins at a specified index.
		/// </summary>
		/// <param name="text">The text to slice.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <returns>A span that consists of all elements of the current span from <paramref name="start"/> to the end of the text.</returns>
		public static ReadOnlySpan<Char> Slice(this Char[] text, Int32 start) {
			Guard.NotNull(text, nameof(text));
			return Slice(text.AsSpan(), start);
		}

		/// <summary>
		/// Forms a slice out of this text that begins at a specified index.
		/// </summary>
		/// <param name="text">The text to slice.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <returns>A span that consists of all elements of the current span from <paramref name="start"/> to the end of the text.</returns>
		public static ReadOnlySpan<Char> Slice(this ReadOnlySpan<Char> text, Int32 start) => text.Slice(start);

		/// <summary>
		/// Forms a slice out of this text that begins at a specified index.
		/// </summary>
		/// <param name="text">The text to slice.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <returns>A span that consists of all elements of the current span from <paramref name="start"/> to the end of the text.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Slice(Char* text, Int32 length, Int32 start) {
			Guard.NotNull(text, nameof(text));
			return Slice(new ReadOnlySpan<Char>(text, length), start);
		}
		#endregion

		#region Slice(Text, Int32, Int32)
		/// <summary>
		/// Forms a slice out of this text starting at a specified index for a specified length.
		/// </summary>
		/// <param name="text">The text to slice.</param>
		/// <param name="start">The index at which to begin this slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <returns>A span that consists of <paramref name="length"/> elements from the current text starting at <paramref name="start"/>.</returns>
		public static ReadOnlySpan<Char> Slice(this String text, Int32 start, Int32 length) {
			Guard.NotNull(text, nameof(text));
			return Slice(text.AsSpan(), start, length);
		}

		/// <summary>
		/// Forms a slice out of this text starting at a specified index for a specified length.
		/// </summary>
		/// <param name="text">The text to slice.</param>
		/// <param name="start">The index at which to begin this slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <returns>A span that consists of <paramref name="length"/> elements from the current text starting at <paramref name="start"/>.</returns>
		public static ReadOnlySpan<Char> Slice(this Char[] text, Int32 start, Int32 length) {
			Guard.NotNull(text, nameof(text));
			return Slice(text.AsSpan(), start, length);
		}

		/// <summary>
		/// Forms a slice out of this text starting at a specified index for a specified length.
		/// </summary>
		/// <param name="text">The text to slice.</param>
		/// <param name="start">The index at which to begin this slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <returns>A span that consists of <paramref name="length"/> elements from the current text starting at <paramref name="start"/>.</returns>
		public static ReadOnlySpan<Char> Slice(this ReadOnlySpan<Char> text, Int32 start, Int32 length) => text.Slice(start, length);

		/// <summary>
		/// Forms a slice out of this text starting at a specified index for a specified length.
		/// </summary>
		/// <param name="text">The text to slice.</param>
		/// <param name="textLength">The length of the <paramref name="text"/>.</param>
		/// <param name="start">The index at which to begin this slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <returns>A span that consists of <paramref name="length"/> elements from the current text starting at <paramref name="start"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Slice(Char* text, Int32 textLength, Int32 start, Int32 length) {
			Guard.NotNull(text, nameof(text));
			return Slice(new ReadOnlySpan<Char>(text, textLength), start, length);
		}
		#endregion
	}
}
