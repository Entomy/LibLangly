using System;
using System.Text;
using System.Collections.Generic;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Joins the <paramref name="chars"/> into a string.
		/// </summary>
		/// <param name="chars">The <see cref="Array"/> of <see cref="Char"/> to join.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this Char[] chars) {
			Guard.NotNull(chars, nameof(chars));
			return new String(chars);
		}

		/// <summary>
		/// Joins the <paramref name="chars"/> into a string.
		/// </summary>
		/// <param name="chars">The <see cref="IEnumerable{T}"/> of <see cref="Char"/> to join.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this IEnumerable<Char> chars) {
			Guard.NotNull(chars, nameof(chars));
			StringBuilder result = new StringBuilder();
			foreach (Char @char in chars) {
				_ = result.Append(@char);
			}
			return result.ToString();
		}

		/// <summary>
		/// Joins the <paramref name="strings"/> into a string.
		/// </summary>
		/// <param name="strings">The <see cref="IEnumerable{T}"/> of <see cref="String"/> to join.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this IEnumerable<String> strings) {
			Guard.NotNull(strings, nameof(strings));
			StringBuilder result = new StringBuilder();
			foreach (String @string in strings) {
				_ = result.Append(@string);
			}
			return result.ToString();
		}

		/// <summary>
		/// Joins the <typeparamref name="T"/> into a string.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="items"/>.</typeparam>
		/// <param name="items">The <see cref="IEnumerable{T}"/> of <typeparamref name="T"/> to join.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join<T>(this IEnumerable<T> items) {
			Guard.NotNull(items, nameof(items));
			StringBuilder result = new StringBuilder();
			foreach (T item in items) {
				_ = result.Append(item);
			}
			return result.ToString();
		}

		/// <summary>
		/// Joins the <paramref name="chars"/> with <paramref name="separator"/> into a string.
		/// </summary>
		/// <param name="chars">The <see cref="Array"/> of <see cref="Char"/> to join.</param>
		/// <param name="separator">The <see cref="Char"/> to interleave.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this Char[] chars, Char separator) {
			Guard.NotNull(chars, nameof(chars));
			Char[] result = new Char[(chars.Length * 2) - 1];
			for (Int32 i = 0; i < (chars.Length * 2) - 1; i++) {
				result[i] = i % 2 == 0 ? chars[i / 2] : separator;
			}
			return result.Join();
		}

		/// <summary>
		/// Joins the <paramref name="chars"/> with <paramref name="separator"/> into a string.
		/// </summary>
		/// <param name="chars">The <see cref="IEnumerable{T}"/> of <see cref="Char"/> to join.</param>
		/// <param name="separator">The <see cref="Char"/> to interleave.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this IEnumerable<Char> chars, Char separator) {
			Guard.NotNull(chars, nameof(chars));
			StringBuilder result = new StringBuilder();
			IEnumerator<Char> enumerator = chars.GetEnumerator();
			if (enumerator.MoveNext()) {
				_ = result.Append(enumerator.Current);
			} else {
				return String.Empty;
			}
			while (enumerator.MoveNext()) {
				_ = result.Append(separator);
				_ = result.Append(enumerator.Current);
			}
			return result.ToString();
		}

		/// <summary>
		/// Joins the <paramref name="chars"/> with <paramref name="separator"/> into a string.
		/// </summary>
		/// <param name="chars">The <see cref="IEnumerable{T}"/> of <see cref="Char"/> to join.</param>
		/// <param name="separator">The <see cref="Rune"/> to interleave.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this IEnumerable<Char> chars, Rune separator) {
			Guard.NotNull(chars, nameof(chars));
			StringBuilder result = new StringBuilder();
			IEnumerator<Char> enumerator = chars.GetEnumerator();
			if (enumerator.MoveNext()) {
				_ = result.Append(enumerator.Current);
			} else {
				return String.Empty;
			}
			while (enumerator.MoveNext()) {
				_ = result.Append(separator);
				_ = result.Append(enumerator.Current);
			}
			return result.ToString();
		}

		/// <summary>
		/// Concatenates all the elements of a string array, using the specified separator between each element.
		/// </summary>
		/// <param name="strings">An array that contains the strings to concatenate.</param>
		/// <param name="separator">The <see cref="Char"/> to use as a separator. Separator is included in the returned string only if value has more than one element.</param>
		/// <returns>A string that consists of the elements in value delimited by the separator char. If value is an empty array, the method returns Empty.</returns>
		public static String Join(this IEnumerable<String> strings, Char separator) {
			Guard.NotNull(strings, nameof(strings));
			StringBuilder result = new StringBuilder();
			IEnumerator<String> enumerator = strings.GetEnumerator();
			if (enumerator.MoveNext()) {
				_ = result.Append(enumerator.Current);
			} else {
				return String.Empty;
			}
			while (enumerator.MoveNext()) {
				_ = result.Append(separator);
				_ = result.Append(enumerator.Current);
			}
			return result.ToString();
		}

		/// <summary>
		/// Concatenates all the elements of a string array, using the specified separator between each element.
		/// </summary>
		/// <param name="strings">An array that contains the strings to concatenate.</param>
		/// <param name="separator">The <see cref="Rune"/> to use as a separator. Separator is included in the returned string only if value has more than one element.</param>
		/// <returns>A string that consists of the elements in value delimited by the separator rune. If value is an empty array, the method returns Empty.</returns>
		public static String Join(this IEnumerable<String> strings, Rune separator) {
			Guard.NotNull(strings, nameof(strings));
			StringBuilder result = new StringBuilder();
			IEnumerator<String> enumerator = strings.GetEnumerator();
			if (enumerator.MoveNext()) {
				_ = result.Append(enumerator.Current);
			} else {
				return String.Empty;
			}
			while (enumerator.MoveNext()) {
				_ = result.Append(separator);
				_ = result.Append(enumerator.Current);
			}
			return result.ToString();
		}

		/// <summary>
		/// Concatenates all the elements of an object enumerable, using the specified separator between each element.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="items"/> to join.</typeparam>
		/// <param name="items">An enumerable that contains the objects to concatenate.</param>
		/// <param name="separator">The <see cref="Char"/> to use as a separator. Separator is included in the returned string only if <paramref name="items"/> has more than one element.</param>
		/// <returns>A string that consists of the elements in <paramref name="items"/> delimited by the <paramref name="separator"/> char. If <paramref name="items"/> is an empty enumerable, the method returns <see cref="String.Empty"/>.</returns>
		public static String Join<T>(this IEnumerable<T> items, Char separator) {
			Guard.NotNull(items, nameof(items));
			StringBuilder result = new StringBuilder();
			IEnumerator<T> enumerator = items.GetEnumerator();
			if (enumerator.MoveNext()) {
				_ = result.Append(enumerator.Current);
			} else {
				return String.Empty;
			}
			while (enumerator.MoveNext()) {
				_ = result.Append(separator);
				_ = result.Append(enumerator.Current);
			}
			return result.ToString();
		}

		/// <summary>
		/// Concatenates all the elements of an object enumerable, using the specified separator between each element.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="items"/> to join.</typeparam>
		/// <param name="items">An enumerable that contains the objects to concatenate.</param>
		/// <param name="separator">The <see cref="Rune"/> to use as a separator. Separator is included in the returned string only if <paramref name="items"/> has more than one element.</param>
		/// <returns>A string that consists of the elements in <paramref name="items"/> delimited by the <paramref name="separator"/> char. If <paramref name="items"/> is an empty enumerable, the method returns <see cref="String.Empty"/>.</returns>
		public static String Join<T>(this IEnumerable<T> items, Rune separator) {
			Guard.NotNull(items, nameof(items));
			StringBuilder result = new StringBuilder();
			IEnumerator<T> enumerator = items.GetEnumerator();
			if (enumerator.MoveNext()) {
				_ = result.Append(enumerator.Current);
			} else {
				return String.Empty;
			}
			while (enumerator.MoveNext()) {
				_ = result.Append(separator);
				_ = result.Append(enumerator.Current);
			}
			return result.ToString().TrimEnd(separator);
		}
	}
}
