using System.Text;
using System.Collections.Generic;

namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Joins the <paramref name="Chars"/> into a string.
		/// </summary>
		/// <param name="Chars">The <see cref="Char[]"/> to join.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this Char[] Chars) {
			if (Chars is null) {
				throw new ArgumentNullException(nameof(Chars));
			}
			return new String(Chars);
		}

		/// <summary>
		/// Joins the <paramref name="Chars"/> into a string.
		/// </summary>
		/// <param name="Chars">The <see cref="IEnumerable{T}"/> of <see cref="Char"/> to join.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this IEnumerable<Char> Chars) {
			if (Chars is null) {
				throw new ArgumentNullException(nameof(Chars));
			}
			StringBuilder Result = new StringBuilder();
			foreach (Char Char in Chars) {
				_ = Result.Append(Char);
			}
			return Result.ToString();
		}

		/// <summary>
		/// Joins the <paramref name="Chars"/> with <paramref name="Separator"/> into a string.
		/// </summary>
		/// <param name="Chars">The <see cref="Char[]"/> to join.</param>
		/// <param name="Separator">The <see cref="Char"/> to interleave.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this Char[] Chars, Char Separator) {
			if (Chars is null) {
				throw new ArgumentNullException(nameof(Chars));
			}
			Char[] Result = new Char[(Chars.Length * 2) - 1];
			for (Int32 i = 0; i < (Chars.Length * 2) - 1; i++) {
				Result[i] = i % 2 == 0 ? Chars[i / 2] : Separator;
			}
			return Result.Join();
		}


		/// <summary>
		/// Joins the <paramref name="Chars"/> with <paramref name="Separator"/> into a string.
		/// </summary>
		/// <param name="Chars">The <see cref="IEnumerable{T}"/> of <see cref="Char"/> to join.</param>
		/// <param name="Separator">The <see cref="Char"/> to interleave.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this IEnumerable<Char> Chars, Char Separator) {
			if (Chars is null) {
				throw new ArgumentNullException(nameof(Chars));
			}
			StringBuilder Result = new StringBuilder();
			foreach (Char Char in Chars) {
				_ = Result.Append(Char);
				_ = Result.Append(Separator);
			}
			return Result.ToString().TrimEnd(Separator);
		}
	}
}
