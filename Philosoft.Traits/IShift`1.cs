using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can be shifted in position.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IShift<out TResult> where TResult : IShift<TResult> {
		/// <summary>
		/// Shifts the collection left one position.
		/// </summary>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: NotNull]
		TResult ShiftLeft() => ShiftLeft(1);

		/// <summary>
		/// Shifts the collection left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: NotNull]
		TResult ShiftLeft(nint amount);

		/// <summary>
		/// Shifts the collection right one position.
		/// </summary>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: NotNull]
		TResult ShiftRight() => ShiftRight(1);

		/// <summary>
		/// Shifts the collection right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: NotNull]
		TResult ShiftRight(nint amount);
	}
}
