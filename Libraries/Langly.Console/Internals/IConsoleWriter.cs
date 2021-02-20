using System;

namespace Langly.Internals {
	/// <summary>
	/// Indicates the type provides write behavior for the <see cref="Console"/>.
	/// </summary>
	[CLSCompliant(false)]
	public interface IConsoleWriter : IWriteText<IConsoleWriter>, IWriteUnsafe<Char, IConsoleWriter> { }
}
