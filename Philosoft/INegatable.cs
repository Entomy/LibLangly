namespace Langly {
	/// <summary>
	/// Indicates the type can be negated.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public interface INegatable<TSelf> where TSelf : INegatable<TSelf> {
		/// <summary>
		/// Negation; compliment; not.
		/// </summary>
		TSelf Not();
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Negation; compliment; not.
		/// </summary>
		/// <typeparam name="T">The type of the element.</typeparam>
		/// <param name="element">This element.</param>
		/// <returns>The negation of this element.</returns>
		public static T Not<T>(this T element) where T : INegatable<T> => element.Not();
	}
}
