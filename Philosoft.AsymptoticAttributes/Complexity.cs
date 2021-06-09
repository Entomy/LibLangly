namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Represents the asymptotic complexity of an operation.
	/// </summary>
	public enum Complexity {
		/// <summary>
		/// The asymptotic complexity is unknown, it hasn't been defined.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// Constant complexity across all parameters and states.
		/// </summary>
		One = 1,

		/// <summary>
		/// <c>n</c> complexity; execution time increases linearly with the number of elements.
		/// </summary>
		n = 3,

		/// <summary>
		/// <c>k</c> complexity; execution time increases linearly by some additional constant.
		/// </summary>
		k = 4,

		/// <summary>
		/// <c>log(n)</c> complexity; execution time increases logarithmically of the number of elements.
		/// </summary>
		log_n = 6,

		/// <summary>
		/// <c>n+k</c> complexity.
		/// </summary>
		n_plus_k = 7,

		/// <summary>
		/// <c>n²</c> complexity; execution time increases exponentially by the square of the elements.
		/// </summary>
		n_squared = 9,

		/// <summary>
		/// <c>log(log(n))</c> complexity; execution time increases logarithmically by the logarithm of the number of elements. 
		/// </summary>
		log_log_n = 12,
		
		/// <summary>
		/// <c>nⁿ</c> complexity; execution time increases exponentially by the cube of the elements.
		/// </summary>
		n_to_n = 27,

		/// <summary>
		/// <c>nᵏ</c> complexity; execution time increases exponentially by the number of elements raised to some additional constant.
		/// </summary>
		n_to_k = 81,
	}
}
