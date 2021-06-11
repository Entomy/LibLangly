namespace System.Traits {
	/// <summary>
	/// Indicates the type can be unlinked from other instances.
	/// </summary>
	public interface IUnlink {
		/// <summary>
		/// Unlinks this instance from any other instances it's associated with.
		/// </summary>
		void Unlink();
	}
}
