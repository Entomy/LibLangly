namespace Langly {
	/// <summary>
	/// Indicates the type can be conjoined with another.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public interface IConjoinable<TSelf> where TSelf : IConjoinable<TSelf> {
		/// <summary>
		/// Conjunction; intersection; and.
		/// </summary>
		TSelf And(TSelf other);
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Conjunction; intersection; and.
		/// </summary>
		/// <typeparam name="T">The type of the element.</typeparam>
		/// <param name="element">This element.</param>
		/// <param name="other">The other element.</param>
		/// <returns>The conjunction of the two elements.</returns>
		public static T And<T>(this T element, T other) where T : IConjoinable<T> => element.And(other);
	}
}
