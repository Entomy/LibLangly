using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a check for the end of a line.
	/// </summary>
	internal sealed class LineEndChecker : Checker {
		/// <summary>
		/// Initializes a new <see cref="LineEndChecker"/>.
		/// </summary>
		internal LineEndChecker() { }

		/// <inheritdoc/>
		protected override void Consume(ReadOnlyMemory<Char> source, ref Int32 length) => throw new NotImplementedException();

		/// <inheritdoc/>
		protected override void Neglect(ReadOnlyMemory<Char> source, ref Int32 length) => throw new NotImplementedException();
	}
}
