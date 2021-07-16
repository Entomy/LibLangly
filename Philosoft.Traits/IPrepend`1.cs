namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements prepended onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPrepend<in TElement> {
		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <param name="element">The element to prepend.</param>
		void Prepend(TElement element);
	}
}
