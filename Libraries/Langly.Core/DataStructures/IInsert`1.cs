namespace Langly.DataStructures {
	/// <summary>
	/// Indicates the collection can have elements inserted into it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IInsert<in TElement> : IInsert<nint, TElement> { }
}
