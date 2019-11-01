namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Repeat the <paramref name="Char"/> <paramref name="Count"/> times.
		/// </summary>
		/// <param name="Char">The <see cref="Char"/> to repeat.</param>
		/// <param name="Count">The amount of times to repeat the <paramref name="Char"/>.</param>
		/// <returns>A <see cref="String"/> containing the repeated <paramref name="Char"/>.</returns>
		public static String Repeat(this Char Char, Int32 Count) {
			if (Count <= 0) { throw new ArgumentOutOfRangeException(nameof(Count), "Count must be a positive integer"); }
			return new String(Char, Count);
		}
	}
}
