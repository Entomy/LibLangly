namespace System.Traits {
	/// <summary>
	/// Indicates the type can be seeked.
	/// </summary>
	public interface ISeek {
		/// <summary>
		/// The position within the datastream, counted by an offset from the start.
		/// </summary>
		Int32 Position { get; set; }

		/// <summary>
		/// Seeks to the <paramref name="offset"/>.
		/// </summary>
		/// <param name="offset">The offset from the current position to seek to.</param>
		void Seek(Int32 offset);
	}
}
