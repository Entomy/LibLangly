namespace System.Traits {
	/// <summary>
	/// Indicates the type can have elements popped off of it.
	/// </summary>
	/// <typeparam name="TElement"></typeparam>
	public interface IPop<out TElement> {
		/// <summary>
		/// Pops the top element off this object..
		/// </summary>
		/// <returns>The top element.</returns>
		TElement Pop();
	}
}
