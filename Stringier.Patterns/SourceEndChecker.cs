using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a check for the end of the source.
	/// </summary>
	internal sealed class SourceEndChecker : Checker {

		/// <summary>
		/// Initializes a new <see cref="SourceEndChecker"/>.
		/// </summary>
		internal SourceEndChecker() { }

		/// <inheritdoc/>
		protected override void Consume(ReadOnlyMemory<Char> source, ref Int32 length) => throw new NotImplementedException();

		/// <inheritdoc/>
		protected override void Neglect(ReadOnlyMemory<Char> source, ref Int32 length) => throw new NotImplementedException();
	}
}
