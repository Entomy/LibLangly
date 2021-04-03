using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Internals {
	/// <summary>
	/// Indicates the type provides read behavior for the <see cref="Console"/>.
	/// </summary>
	[CLSCompliant(false)]
	public interface IConsoleReader : IPeek<Char, IConsoleReader>, IReadUnsafe<Char, IConsoleReader> {
		/// <summary>
		/// Reads everything up to a line terminator from the standard input stream.
		/// </summary>
		/// <param name="elements">The line that was read, excluding the line terminator.</param>
		[return: NotNull]
		IConsoleReader ReadLine([NotNull] out String elements);
	}
}
