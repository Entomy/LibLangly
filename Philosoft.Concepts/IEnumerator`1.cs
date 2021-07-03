namespace System.Traits.Concepts {
	/// <summary>
	/// Indicates the type is an enumerator for sequences of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
	public interface IEnumerator<out TElement> : ICount, ICurrent<TElement>, IMoveNext, IReset { }
}
