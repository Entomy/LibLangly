using Collectathon.Views;

namespace Langly {
	/// <summary>
	/// Indicates the type is an enumerator, which supports a simple iteration over a collection of a specified type, forward or reverse.
	/// </summary>
	/// <typeparam name="TMember">The type of the elements to enumerate.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
	public interface IReversibleEnumerable<TMember, TSelf, TEnumerator> : IEnumerable<TMember, TEnumerator> where TSelf : IReversibleEnumerable<TMember, TSelf, TEnumerator> where TEnumerator : IReversibleEnumerator<TMember> {
		/// <summary>
		/// Gets a view of the members of this collection in reverse order.
		/// </summary>
		ReverseView<TMember, TSelf, TEnumerator> Reverse { get; }
	}
}
