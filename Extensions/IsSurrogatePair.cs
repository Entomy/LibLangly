namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <paramref name="High"/> and the specified <paramref name="Low"/> <see cref="Char"/> form a surrogate pair.
		/// </summary>
		/// <param name="High">The high surrogate.</param>
		/// <param name="Low">THe low surrogate.</param>
		/// <returns>true if the numeric value of the high and low parameters are their respective surrogate parts; otherwise false</returns>
		public static Boolean IsSurrogatePair(this Char High, Char Low) => Char.IsSurrogatePair(High, Low);
	}
}
