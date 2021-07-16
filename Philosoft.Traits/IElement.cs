namespace System.Traits {
	/// <summary>
	/// Indicates the type contains an element.
	/// </summary>
	public interface IElement<out TElement> {
		/// <summary>
		/// The element contained in this instance.
		/// </summary>
		TElement Element { get; }
	}
}
