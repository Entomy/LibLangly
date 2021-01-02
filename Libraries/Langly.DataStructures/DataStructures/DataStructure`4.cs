using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents any possible associative data structure.
	/// </summary>
	/// <typeparam name="TIndex">The type of the index of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the data structure.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for this data structure.</typeparam>
	/// <remarks>
	/// This is extremely anemic in order to avoid the false assumption and leaky abstraction problems most collection libraries get themselves into. This class only sets up things that are truly common for all data structures.
	/// </remarks>
	public abstract class DataStructure<TIndex, TElement, TSelf, TEnumerator> : Record<TSelf>, ISequence<Association<TIndex, TElement>, TEnumerator> where TSelf : DataStructure<TIndex, TElement, TSelf, TEnumerator> where TEnumerator : IEnumerator<Association<TIndex, TElement>> {
		/// <inheritdoc/>
		[return: NotNull]
		public abstract TEnumerator GetEnumerator();
	}
}
