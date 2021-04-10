using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can be cleared.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IClear<out TResult> where TResult : IClear<TResult> {
		/// <summary>
		/// Clears this collection.
		/// </summary>
		[return: NotNull]
		TResult Clear();
	}
}
