using System;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can be equal to another.
	/// </summary>
	/// <typeparam name="TElement">The type this can be equal to.</typeparam>
	public interface IEquals<TElement> : IEquatable<TElement> { }
}
