using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

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
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new NotImplementedException();

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new NotImplementedException();
	}
}
