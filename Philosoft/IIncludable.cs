namespace Langly {
	/// <summary>
	/// Indicates the type can be included with another.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself</typeparam>
	public interface IIncludable<TSelf> where TSelf : IIncludable<TSelf> {
		/// <summary>
		/// Inclusion; union; or.
		/// </summary>
		TSelf Or(TSelf other);
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Inclusion; union; or.
		/// </summary>
		/// <typeparam name="T">The type of the element.</typeparam>
		/// <param name="element">This element.</param>
		/// <param name="other">The other element.</param>
		/// <returns>The union of the two elements.</returns>
		public static T Or<T>(this T element, T other) where T : IIncludable<T> => element.Or(other);
	}
}
