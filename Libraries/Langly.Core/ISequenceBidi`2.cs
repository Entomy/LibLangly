using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures.Views;

namespace Langly {
	/// <summary>
	/// Indicates the type is a bidirectional sequence of <typeparamref name="TMember"/>.
	/// </summary>
	/// <typeparam name="TMember">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
	/// <remarks>
	/// This interface devirtualizes the enumerator, and simplifies numerous parts of the interface through well defined defaults.
	/// </remarks>
	public interface ISequenceBidi<TMember, TEnumerator> : ISequence<TMember, TEnumerator> where TEnumerator : IEnumeratorBidi<TMember> {
		/// <summary>
		/// Gets a view of the members of this collection in reverse order.
		/// </summary>
		[return: NotNull]
		[SuppressMessage("Member Design", "AV1130:Return type in method signature should be a collection interface instead of a concrete type", Justification = "ReverseView is basically an interface.")]
		ReverseView<TMember, ISequenceBidi<TMember, TEnumerator>, TEnumerator> Reverse();
	}
}
