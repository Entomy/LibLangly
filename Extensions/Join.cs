using System;
using System.Text;
using System.Collections.Generic;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Joins the <paramref name="chars"/> into a string.
		/// </summary>
		/// <param name="chars">The <see cref="Char[]"/> to join.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this Char[] chars) {
			if (chars is null) {
				throw new ArgumentNullException(nameof(chars));
			}
			return new String(chars);
		}

		/// <summary>
		/// Joins the <paramref name="chars"/> into a string.
		/// </summary>
		/// <param name="chars">The <see cref="IEnumerable{T}"/> of <see cref="Char"/> to join.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this IEnumerable<Char> chars) {
			if (chars is null) {
				throw new ArgumentNullException(nameof(chars));
			}
			StringBuilder Result = new StringBuilder();
			foreach (Char Char in chars) {
				_ = Result.Append(Char);
			}
			return Result.ToString();
		}

		/// <summary>
		/// Joins the <paramref name="chars"/> with <paramref name="separator"/> into a string.
		/// </summary>
		/// <param name="chars">The <see cref="Char[]"/> to join.</param>
		/// <param name="separator">The <see cref="Char"/> to interleave.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this Char[] chars, Char separator) {
			if (chars is null) {
				throw new ArgumentNullException(nameof(chars));
			}
			Char[] Result = new Char[(chars.Length * 2) - 1];
			for (Int32 i = 0; i < (chars.Length * 2) - 1; i++) {
				Result[i] = i % 2 == 0 ? chars[i / 2] : separator;
			}
			return Result.Join();
		}

		/// <summary>
		/// Joins the <paramref name="chars"/> with <paramref name="separator"/> into a string.
		/// </summary>
		/// <param name="chars">The <see cref="IEnumerable{T}"/> of <see cref="Char"/> to join.</param>
		/// <param name="separator">The <see cref="Char"/> to interleave.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this IEnumerable<Char> chars, Char separator) {
			if (chars is null) {
				throw new ArgumentNullException(nameof(chars));
			}
			StringBuilder Result = new StringBuilder();
			foreach (Char Char in chars) {
				_ = Result.Append(Char);
				_ = Result.Append(separator);
			}
			return Result.ToString().TrimEnd(separator);
		}

		/// <summary>
		/// Joins the <paramref name="strings"/> into a string.
		/// </summary>
		/// <param name="strings">The <see cref="IEnumerable{T}"/> of <see cref="String"/> to join.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this IEnumerable<String> strings) {
			if (strings is null) {
				throw new ArgumentNullException(nameof(strings));
			}
			StringBuilder Result = new StringBuilder();
			foreach (String String in strings) {
				_ = Result.Append(String);
			}
			return Result.ToString();
		}

		/// <summary>
		/// Concatenates all the elements of a string array, using the specified separator between each element.
		/// </summary>
		/// <param name="strings">An array that contains the strings to concatenate.</param>
		/// <param name="Separator">The char to use as a separator. Separator is included in the returned string only if value has more than one element.</param>
		/// <returns>A string that consists of the elements in value delimited by the separator char. If value is an empty array, the method returns Empty.</returns>
		public static String Join(this IEnumerable<String> strings, Char Separator) {
			if (strings is null) {
				throw new ArgumentNullException(nameof(strings));
			}
			StringBuilder Result = new StringBuilder();
			foreach (String String in strings) {
				_ = Result.Append(String);
				_ = Result.Append(Separator);
			}
			return Result.ToString().TrimEnd(Separator);
		}

		/// <summary>
		/// Concatenates all the elements of an object enumerable, using the specified separator between each element.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="objects"/> to join.</typeparam>
		/// <param name="objects">An enumerable that contains the objects to concatenate.</param>
		/// <param name="separator">The char to use as a separator. Separator is included in the returned string only if <paramref name="objects"/> has more than one element.</param>
		/// <returns>A string that consists of the elements in <paramref name="objects"/> delimited by the <paramref name="separator"/> char. If <paramref name="objects"/> is an empty enumerable, the method returns <see cref="String.Empty"/>.</returns>
		public static String Join<T>(this IEnumerable<T> objects, Char separator) {
			if (objects is null) {
				throw new ArgumentNullException(nameof(objects));
			}
			StringBuilder Result = new StringBuilder();
			foreach (T Object in objects) {
				_ = Result.Append(Object);
				_ = Result.Append(separator);
			}
			return Result.ToString().TrimEnd(separator);
		}
	}
}
