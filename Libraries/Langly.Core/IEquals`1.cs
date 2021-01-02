using System;

namespace Langly {
	/// <summary>
	/// Indicates the type can be equal to another.
	/// </summary>
	/// <typeparam name="TElement"></typeparam>
	public interface IEquals<TElement> : IEquatable<TElement> { }
}
