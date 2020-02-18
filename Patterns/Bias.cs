using Stringier.Patterns.Nodes;

namespace Stringier.Patterns {
	/// <summary>
	/// Word letter bias, used by <see cref="WordChecker"/>.
	/// </summary>
	public enum Bias {
		/// <summary>
		/// Bias towards the head
		/// </summary>
		Head,

		/// <summary>
		/// Bias towards the tail
		/// </summary>
		Tail,
	}
}
