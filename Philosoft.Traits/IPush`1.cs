namespace System.Traits {
	/// <summary>
	/// Indicates the type can elements pushed to it.
	/// </summary>
	/// <typeparam name="TElement"></typeparam>
	public interface IPush<in TElement> {
		/// <summary>
		/// Pushes the <paramref name="element"/> onto this object.
		/// </summary>
		/// <param name="element">The element to push.</param>
		public void Push(TElement element);
	}
}
