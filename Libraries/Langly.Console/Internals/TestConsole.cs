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
		public Boolean Readable => true;

		/// <inheritdoc/>
		public Boolean Writable => true;

		/// <inheritdoc/>
		[return: MaybeNull]
		IConsoleReader IRead<Char, IConsoleReader>.Read(out Char element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[return: MaybeNull]
		IConsoleWriter IWrite<Char, IConsoleWriter>.Write(Char element) {
			WriteLog.Append(element);
			return this;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		IConsoleWriter IWrite<Char, IConsoleWriter>.Write(ReadOnlyMemory<Char> elements) {
			WriteLog.Append(elements);
			return this;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		IConsoleError IWrite<Char, IConsoleError>.Write(Char element) {
			ErrorLog.Append(element);
			return this;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		IConsoleError IWrite<Char, IConsoleError>.Write(ReadOnlyMemory<char> elements) {
			ErrorLog.Append(elements);
			return this;
		}
	}
}
