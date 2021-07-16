namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements added to it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IAdd<in TElement> {
		/// <summary>
		/// Adds an element to this object.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add(TElement element);
	}
}
