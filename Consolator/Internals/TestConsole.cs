using System;
using System.Text;

namespace Consolator.Internals {
	/// <summary>
	/// Provides testable <see cref="Console"/> behavior.
	/// </summary>
	/// <remarks>
	/// By injecting this into <see cref="Console"/>, those operations will be passed here instead, enabling introspection.
	/// </remarks>
	public sealed class TestConsole : IConsoleReader, IConsoleWriter, IConsoleErrorWriter {
		private readonly StringBuilder ErrorLog = new StringBuilder();
		private readonly StringBuilder WriteLog = new StringBuilder();

		/// <summary>
		/// Gets the written errors text from the buffer and flushes the buffer.
		/// </summary>
		public String Errors {
			get {
				String errors = ErrorLog.ToString();
				ErrorLog.Clear();
				return errors;
			}
		}

		/// <summary>
		/// Gets the written text from the buffer and flushes the buffer.
		/// </summary>
		public String Written {
			get {
				String written = WriteLog.ToString();
				WriteLog.Clear();
				return written;
			}
		}

		/// <inheritdoc/>
		void IConsoleWriter.Write(ReadOnlySpan<Char> text) => WriteLog.Append(text);

		/// <inheritdoc/>
		unsafe void IConsoleWriter.Write(Char* text, Int32 length) => WriteLog.Append(text, length);

		/// <inheritdoc/>
		void IConsoleErrorWriter.Write(ReadOnlySpan<Char> text) => ErrorLog.Append(text);

		/// <inheritdoc/>
		unsafe void IConsoleErrorWriter.Write(Char* text, Int32 length) => ErrorLog.Append(text, length);

		/// <inheritdoc/>
		void IConsoleWriter.WriteLine() => WriteLog.AppendLine();

		/// <inheritdoc/>
		void IConsoleErrorWriter.WriteLine() => ErrorLog.AppendLine();
	}
}
