namespace Stringier.Patterns.Debugging {
	/// <summary>
	/// Specifies the type of error that occured.
	/// </summary>
	/// <remarks>
	/// This is used to map to the equivalent <see cref="System.Exception"/> when the <see cref="Error"/> is thrown.
	/// </remarks>
	public enum Error {
		None = 0,
		ConsumeFailed,
		NeglectFailed,
		EndOfSource,
	}
}
