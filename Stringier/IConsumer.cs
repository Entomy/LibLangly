using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Patterns.Debugging;
using Langly.Streams;

namespace Langly {
	/// <summary>
	/// Indicates the type can consume a source.
	/// </summary>
	public interface IConsumer {
		protected internal abstract ReadOnlyMemory<Char> Consume(ReadOnlyMemory<Char> source, ref nint position, out Patterns.Errors parserErrors, [AllowNull] Trace trace);

		protected internal abstract ReadOnlySpan<Char> Consume(ReadOnlySpan<Char> source, ref nint position, out Patterns.Errors parserErrors, [AllowNull] Trace trace);

		protected internal abstract System.Collections.Generic.IEnumerable<String> Consume([DisallowNull] Stream source, out Patterns.Errors parserErrors, out Streams.Errors streamErrors, [AllowNull] Trace trace);
	}
}
