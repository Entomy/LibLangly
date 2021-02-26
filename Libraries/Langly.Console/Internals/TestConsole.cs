using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Langly.Internals {
	/// <summary>
	/// Provides testable <see cref="Console"/> behavior.
	/// </summary>
	/// <remarks>
	/// By injecting this into <see cref="Console"/>, those operations will be passed here instead, enabling introspection.
	/// </remarks>
	public sealed class TestConsole : IConsoleReader, IConsoleWriter, IConsoleError {
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

		/// <inheritdoc/>
		public Boolean Readable => true;

		/// <inheritdoc/>
		public Boolean Writable => true;

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
		[return: NotNull]
		IConsoleReader IPeek<Char, IConsoleReader>.Peek(out Char element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[return: NotNull]
		IConsoleReader IRead<Char, IConsoleReader>.Read(out Char element) => throw new NotImplementedException();

		[return: NotNull]
		IConsoleReader IConsoleReader.ReadLine(out String elements) => throw new NotImplementedException();

		/// <inheritdoc/>
		[return: NotNull]
		IConsoleWriter IAdd<Char, IConsoleWriter>.Add(Char element) {
			WriteLog.Append(element);
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		IConsoleError IAdd<Char, IConsoleError>.Add(Char element) {
			ErrorLog.Append(element);
			return this;
		}
	}
}
