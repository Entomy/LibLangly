using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type has an associated enumerator.
	/// </summary>
	/// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
	public interface IGetEnumerator<out TEnumerator> {
		/// <summary>
		/// Returns an enumerator that iterates through the sequence.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		[return: NotNull]
		TEnumerator GetEnumerator();
	}
}
