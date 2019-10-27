namespace System.Text.Patterns {
	/// <summary>
	/// The saved state of a <see cref="Source"/>.
	/// </summary>
	public ref struct SourceState {
		/// <summary>
		/// The <see cref="Source"/> this came from.
		/// </summary>
		/// <remarks>
		/// This is used in validating the state actually belongs to the <see cref="System.Text.Patterns.Source"/> it's trying to be used on.
		/// </remarks>
		internal readonly Source Source;

		/// <summary>
		/// The position within the source buffer.
		/// </summary>
		internal readonly Int32 Position;

		/// <summary>
		/// Initialize a new <see cref="SourceState"/> with the specified <paramref name="Source"/> and <paramref name="Position"/>.
		/// </summary>
		/// <param name="Source"></param>
		/// <param name="Position"></param>
		public SourceState(Source Source, Int32 Position) {
			this.Source = Source;
			this.Position = Position;
		}

		public override Boolean Equals(Object obj) => false;

		public static Boolean operator ==(SourceState left, SourceState right) => left.Equals(right);

		public static Boolean operator !=(SourceState left, SourceState right) => !left.Equals(right);

		/// <summary>
		/// Determines whether this <see cref="SourceState"/> and the <paramref name="other"/> <see cref="SourceState"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="SourceState"/> to compare to</param>
		/// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
		public Boolean Equals(SourceState other) => Position.Equals(other.Position) && Source.Equals(other.Source);

		public override Int32 GetHashCode() => Source.GetHashCode();
	}
}
