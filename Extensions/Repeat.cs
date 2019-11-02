using System.Text;

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

		/// <summary>
		/// Repeat the <paramref name="String"/> <paramref name="Count"/> times.
		/// </summary>
		/// <param name="String">The <see cref="String"/> to repeat.</param>
		/// <param name="Count">The amount of times to repeat the <paramref name="String"/>.</param>
		/// <returns>A <see cref="String"/> containing the repeated <paramref name="String"/>.</returns>
		public static String Repeat(this String String, Int32 Count) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			if (Count <= 0) {
				throw new ArgumentOutOfRangeException(nameof(Count), "Count must be a positive integer");
			}
			StringBuilder Result = new StringBuilder(String.Length * Count);
			for (Int32 i = 0; i < Count; i++) {
				_ = Result.Append(String);
			}
			return Result.ToString();
		}
	}
}
