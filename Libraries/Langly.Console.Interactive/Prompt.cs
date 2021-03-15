using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public static partial class InteractiveConsoleExtensions {
		/// <summary>
		/// Prompts for input with the <paramref name="message"/>, then reads everything up to a line terminator from the standard input stream.
		/// </summary>
		/// <param name="buffer">This screen buffer instance.</param>
		/// <param name="message">The message to prompt with.</param>
		/// <returns>The line that was read, excluding the line terminator.</returns>
		[return: NotNull]
		public static String Prompt(this ScreenBuffer buffer, [AllowNull] String message) {
			buffer.Write(message);
			buffer.Write(": ");
			return buffer.ReadLine();
		}

		/// <summary>
		/// Prompts for input with the <paramref name="message"/>, then reads everything up to a line terminator from the standard input stream.
		/// </summary>
		/// <param name="buffer">This screen buffer instance.</param>
		/// <param name="message">The message to prompt with.</param>
		/// <returns>The line that was read, excluding the line terminator.</returns>
		[return: NotNull]
		public static String Prompt(this ScreenBuffer buffer, [AllowNull] Char[] message) {
			buffer.Write(message);
			buffer.Write(": "); 
			return buffer.ReadLine();
		}

		/// <summary>
		/// Prompts for input with the <paramref name="message"/>, then reads everything up to a line terminator from the standard input stream.
		/// </summary>
		/// <param name="buffer">This screen buffer instance.</param>
		/// <param name="message">The message to prompt with.</param>
		/// <returns>The line that was read, excluding the line terminator.</returns>
		[return: NotNull]
		public static String Prompt(this ScreenBuffer buffer, Memory<Char> message) {
			buffer.Write(message);
			buffer.Write(": ");
			return buffer.ReadLine();
		}

		/// <summary>
		/// Prompts for input with the <paramref name="message"/>, then reads everything up to a line terminator from the standard input stream.
		/// </summary>
		/// <param name="buffer">This screen buffer instance.</param>
		/// <param name="message">The message to prompt with.</param>
		/// <returns>The line that was read, excluding the line terminator.</returns>
		[return: NotNull]
		public static String Prompt(this ScreenBuffer buffer, ReadOnlyMemory<Char> message) {
			buffer.Write(message);
			buffer.Write(": ");
			return buffer.ReadLine();
		}

		/// <summary>
		/// Prompts for input with the <paramref name="message"/>, then reads everything up to a line terminator from the standard input stream.
		/// </summary>
		/// <param name="buffer">This screen buffer instance.</param>
		/// <param name="message">The message to prompt with.</param>
		/// <returns>The line that was read, excluding the line terminator.</returns>
		[return: NotNull]
		public static String Prompt(this ScreenBuffer buffer, Span<Char> message) {
			buffer.Write(message);
			buffer.Write(": ");
			return buffer.ReadLine();
		}

		/// <summary>
		/// Prompts for input with the <paramref name="message"/>, then reads everything up to a line terminator from the standard input stream.
		/// </summary>
		/// <param name="buffer">This screen buffer instance.</param>
		/// <param name="message">The message to prompt with.</param>
		/// <returns>The line that was read, excluding the line terminator.</returns>
		[return: NotNull]
		public static String Prompt(this ScreenBuffer buffer, ReadOnlySpan<Char> message) {
			buffer.Write(message);
			buffer.Write(": ");
			return buffer.ReadLine();
		}

		/// <summary>
		/// Prompts for input with the <paramref name="message"/>, then reads everything up to a line terminator from the standard input stream.
		/// </summary>
		/// <param name="buffer">This screen buffer instance.</param>
		/// <param name="message">The message to prompt with.</param>
		/// <param name="length">The length of the <paramref name="message"/>.</param>
		/// <returns>The line that was read, excluding the line terminator.</returns>
		[return: NotNull]
		public static unsafe String Prompt(this ScreenBuffer buffer, [AllowNull] Char* message, Int32 length) {
			buffer.Write(message, length);
			buffer.Write(": ");
			return buffer.ReadLine();
		}
	}
}
