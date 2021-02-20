using System;

namespace Langly.Internals {
	/// <summary>
	/// Indicates the type provides error-write behavior for the <see cref="Console"/>.
	/// </summary>
	[CLSCompliant(false)]
	public interface IConsoleError : IWriteText<IConsoleError>, IWriteUnsafe<Char, IConsoleError> { }
}
