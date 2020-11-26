namespace Langly {
	/// <summary>
	/// Indicates the collection can have elements inserted into it.
	/// </summary>
	public interface IInsertable<in TElement> : IInsertable<nint, TElement> {
	}
}
