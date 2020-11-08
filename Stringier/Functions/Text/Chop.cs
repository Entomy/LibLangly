using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	public static partial class Text {
		/// <summary>
		/// Chop the <paramref name="text"/> into chunks of <paramref name="size"/>.
		/// </summary>
		/// <param name="text">Text to chop.</param>
		/// <param name="size">Length of the chunks to chop into; their size.</param>
		/// <returns>A <see cref="ChoppedString"/> representing the chunks.</returns>
		public static ChoppedString Chop([AllowNull] this String text, Int32 size) {
			if (text is not null) {
				return new ChoppedString(text, size);
			} else {
				return new ChoppedString();
			}
		}

		/// <summary>
		/// Chop the <paramref name="text"/> into chunks of <paramref name="size"/>.
		/// </summary>
		/// <param name="text">Text to chop.</param>
		/// <param name="size">Length of the chunks to chop into; their size.</param>
		/// <returns>A <see cref="ChoppedString"/> representing the chunks.</returns>
		public static ChoppedString Chop([AllowNull] this Char[] text, Int32 size) {
			if (text is not null) {
				return new ChoppedString(text, size);
			} else {
				return new ChoppedString();
			}
		}

		/// <summary>
		/// Chop the <paramref name="text"/> into chunks of <paramref name="size"/>.
		/// </summary>
		/// <param name="text">Text to chop.</param>
		/// <param name="size">Length of the chunks to chop into; their size.</param>
		/// <returns>A <see cref="ChoppedString"/> representing the chunks.</returns>
		public static ChoppedString Chop(this Memory<Char> text, Int32 size) => new ChoppedString(text.Span, size);

		/// <summary>
		/// Chop the <paramref name="text"/> into chunks of <paramref name="size"/>.
		/// </summary>
		/// <param name="text">Text to chop.</param>
		/// <param name="size">Length of the chunks to chop into; their size.</param>
		/// <returns>A <see cref="ChoppedString"/> representing the chunks.</returns>
		public static ChoppedString Chop(this ReadOnlyMemory<Char> text, Int32 size) => new ChoppedString(text.Span, size);

		/// <summary>
		/// Chop the <paramref name="text"/> into chunks of <paramref name="size"/>.
		/// </summary>
		/// <param name="text">Text to chop.</param>
		/// <param name="size">Length of the chunks to chop into; their size.</param>
		/// <returns>A <see cref="ChoppedString"/> representing the chunks.</returns>
		public static ChoppedString Chop(this Span<Char> text, Int32 size) => new ChoppedString(text, size);

		/// <summary>
		/// Chop the <paramref name="text"/> into chunks of <paramref name="size"/>.
		/// </summary>
		/// <param name="text">Text to chop.</param>
		/// <param name="size">Length of the chunks to chop into; their size.</param>
		/// <returns>A <see cref="ChoppedString"/> representing the chunks.</returns>
		public static ChoppedString Chop(this ReadOnlySpan<Char> text, Int32 size) => new ChoppedString(text, size);

		/// <summary>
		/// Chop the <paramref name="text"/> into chunks of <paramref name="size"/>.
		/// </summary>
		/// <param name="text">Text to chop.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="size">Length of the chunks to chop into; their size.</param>
		/// <returns>A <see cref="ChoppedString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe ChoppedString Chop([AllowNull] Char* text, Int32 length, Int32 size) {
			if (text is not null) {
				return new ChoppedString(new ReadOnlySpan<Char>(text, length), size);
			} else {
				return new ChoppedString();
			}
		}
	}
}
