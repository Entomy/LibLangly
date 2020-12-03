namespace Langly {
	/// <summary>
	/// Indicates the type can be excluded from another.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public interface IExcludable<TSelf> where TSelf : IExcludable<TSelf> {
		/// <summary>
		/// Exclusion; disjunction; either-or.
		/// </summary>
		TSelf XOr(TSelf other);
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Exclusion; disjunction; either-or.
		/// </summary>
		/// <typeparam name="T">The type of the element.</typeparam>
		/// <param name="element">This element.</param>
		/// <param name="other">The other element.</param>
		/// <returns>The disjunction of the two elements.</returns>
		public static T XOr<T>(this T element, T other) where T : IExcludable<T> => element.XOr(other);
	}
}
