using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Langly.Patterns.Debugging;
using Langly.Streams;

namespace Langly.Patterns {
	/// <summary>
	/// Represents a textual pattern.
	/// </summary>
	public abstract class Pattern : IConsumer {
		/// <summary>
		/// Initializes a new <see cref="Pattern"/>.
		/// </summary>
		protected Pattern() { }

		/// <inheritdoc/>
		ReadOnlyMemory<Char> IConsumer.Consume(ReadOnlyMemory<Char> source, ref nint position, out Patterns.Errors parserErrors, [AllowNull] Trace trace) => throw new NotImplementedException();

		/// <inheritdoc/>
		ReadOnlySpan<Char> IConsumer.Consume(ReadOnlySpan<Char> source, ref nint position, out Patterns.Errors parserErrors, [AllowNull] Trace trace) => throw new NotImplementedException();

		/// <inheritdoc/>
		IEnumerable<String> IConsumer.Consume(Stream source, out Patterns.Errors parserErrors, out Streams.Errors streamErrors, [AllowNull] Trace trace) => throw new NotImplementedException();
	}
}
