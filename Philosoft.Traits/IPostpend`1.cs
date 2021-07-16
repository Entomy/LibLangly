namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements postpended onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPostpend<in TElement> {
		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <param name="element">The element to postpend.</param>
		void Postpend(TElement element);
	}
}
