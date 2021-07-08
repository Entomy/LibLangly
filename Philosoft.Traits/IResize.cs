namespace System.Traits {
	/// <summary>
	/// Indicates the type is resizable.
	/// </summary>
	/// <remarks>
	/// This implementation technically leaks an implementation detail, in that the underlying data structure is of a fixed size, and uses array swapping to appear as a dynamic data structure.
	/// </remarks>
	public interface IResize : ICapacity {
		/// <summary>
		/// The current capacity of the collection before needing to be resized.
		/// </summary>
		new Int32 Capacity { get; set; }

#if !NETSTANDARD1_3
		/// <inheritdoc/>
		Int32 ICapacity.Capacity => Capacity;
#endif

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The new capacity of the collection.</param>
		void Resize(Int32 capacity);
	}
}
