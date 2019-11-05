namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <paramref name="high"/> and the specified <paramref name="low"/> <see cref="Char"/> form a surrogate pair.
		/// </summary>
		/// <param name="high">The high surrogate.</param>
		/// <param name="low">THe low surrogate.</param>
		/// <returns>true if the numeric value of the high and low parameters are their respective surrogate parts; otherwise false</returns>
		public static Boolean IsSurrogatePair(this Char high, Char low) => Char.IsSurrogatePair(high, low);
	}
}
