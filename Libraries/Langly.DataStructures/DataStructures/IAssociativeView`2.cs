namespace Langly.DataStructures {
	/// <summary>
	/// Indicates the type is a view of an associative collection.
	/// </summary>
	public interface IAssociativeView<TMember, TEnumerator> : ISequence<TMember, TEnumerator> where TEnumerator : IEnumerator<TMember> { }
}
