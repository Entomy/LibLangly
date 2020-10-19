using System;

namespace Philosoft {
	/// <summary>
	/// Indicates the collection can be shifted in position.
	/// </summary>
	public interface IShiftable {
		/// <summary>
		/// Shifts the collection left one position.
		/// </summary>
		void ShiftLeft();

		/// <summary>
		/// Shifts the collection left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftLeft(nint amount);

		/// <summary>
		/// Shifts the collection right one position.
		/// </summary>
		void ShiftRight();

		/// <summary>
		/// Shifts the collection right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftRight(nint amount);
	}
}
