namespace System.Traits {
	/// <summary>
	/// Indicates the type can be shifted in position.
	/// </summary>
	public interface IShift {
		/// <summary>
		/// Shifts the collection left one position.
		/// </summary>
		void ShiftLeft()
#if !NETSTANDARD1_3
			=> ShiftLeft(1)
#endif
			;

		/// <summary>
		/// Shifts the collection left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftLeft(nint amount);

		/// <summary>
		/// Shifts the collection right one position.
		/// </summary>
		void ShiftRight()
#if !NETSTANDARD1_3
			=> ShiftRight(1)
#endif
			;

		/// <summary>
		/// Shifts the collection right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftRight(nint amount);
	}
}
