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

		public static String Join(this IEnumerable<String> Strings) {
			if (Strings is null) {
				throw new ArgumentNullException(nameof(Strings));
			}
			StringBuilder Result = new StringBuilder();
			foreach (String String in Strings) {
				_ = Result.Append(String);
			}
			return Result.ToString();
		}

		/// <summary>
		/// Concatenates all the elements of a string array, using the specified separator between each element.
		/// </summary>
		/// <param name="Strings">An array that contains the strings to concatenate.</param>
		/// <param name="Separator">The char to use as a separator. Separator is included in the returned string only if value has more than one element.</param>
		/// <returns>A string that consists of the elements in value delimited by the separator char. If value is an empty array, the method returns Empty.</returns>
		public static String Join(this IEnumerable<String> Strings, Char Separator) {
			if (Strings is null) {
				throw new ArgumentNullException(nameof(Strings));
			}
			StringBuilder Result = new StringBuilder();
			foreach (String String in Strings) {
				_ = Result.Append(String);
				_ = Result.Append(Separator);
			}
			return Result.ToString().TrimEnd(Separator);
		}

		/// <summary>
		/// Concatenates all the elements of an object enumerable, using the specified separator between each element.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="Objects"/> to join.</typeparam>
		/// <param name="Objects">An enumerable that contains the objects to concatenate.</param>
		/// <param name="Separator">The char to use as a separator. Separator is included in the returned string only if <paramref name="Objects"/> has more than one element.</param>
		/// <returns>A string that consists of the elements in <paramref name="Objects"/> delimited by the <paramref name="Separator"/> char. If <paramref name="Objects"/> is an empty enumerable, the method returns <see cref="String.Empty"/>.</returns>
		public static String Join<T>(this IEnumerable<T> Objects, Char Separator) {
			if (Objects is null) {
				throw new ArgumentNullException(nameof(Objects));
			}
			StringBuilder Result = new StringBuilder();
			foreach (T Object in Objects) {
				_ = Result.Append(Object);
				_ = Result.Append(Separator);
			}
			return Result.ToString().TrimEnd(Separator);
		}
	}
}
