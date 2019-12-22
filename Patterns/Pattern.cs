namespace Stringier.Patterns {
	/// <summary>
	/// Represents a textual pattern
	/// </summary>
	public abstract partial class Pattern {
		/// <summary>
		/// Initialize a new <see cref="Pattern"/>.
		/// </summary>
		protected Pattern() { }

		/// <summary>
		/// Seals the pattern to prevent further modification. Only does something for mutable patterns.
		/// </summary>
		/// <remarks>
		/// This essentially converts a mutable pattern back into a pattern, so any further combination works like normal, rather than mutating in-place.
		/// </remarks>
		public virtual void Seal() { }

		/// <summary>
		/// Get an empty mutable pattern.
		/// </summary>
		/// <returns>An empty mutable pattern.</returns>
		/// <remarks>
		/// This provides a pattern which mutates in-place, which is dangerous. However, it is required when using the target/jumper system as left-recursion and mutual-recursion are not possible without it. <see cref="Seal"/> should be called when done, to prevent further modification than intended, which can have disasterous consequences.
		/// </remarks>
		public static Pattern Mutable() => new MutablePattern();
	}
}
