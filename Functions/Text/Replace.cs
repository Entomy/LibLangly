using Defender;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stringier {
	public static partial class Text {
		//NOTE: This overload includes some small map count versions. The reason being is, it's actually optimal to pass parameters this way, and it handles the most common cases without requiring an allocation.

		#region Replace(Text, (Char, Char))
		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this String text, (Char seek, Char replace) m1) {
			Guard.NotNull(text, nameof(text));
			return Replace(text.AsSpan(), m1);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this Char[] text, (Char seek, Char replace) m1) {
			Guard.NotNull(text, nameof(text));
			return Replace(text.AsSpan(), m1);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this Span<Char> text, (Char seek, Char replace) m1) => Replace((ReadOnlySpan<Char>)text, m1);

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this ReadOnlySpan<Char> text, (Char seek, Char replace) m1) {
			Span<Char> result = new Char[text.Length];
			text.CopyTo(result);
			for (Int32 r = 0; r < result.Length; r++) {
				if (result[r] == m1.seek) {
					result[r] = m1.replace;
				}
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		[CLSCompliant(false)]
		public static unsafe String Replace(Char* text, Int32 length, (Char seek, Char replace) m1) {
			Guard.NotNull(text, nameof(text));
			return Replace(new ReadOnlySpan<Char>(text, length), m1);
		}
		#endregion

		#region Replace(Text, (Rune, Rune))
		#endregion

		#region Replace(Text, (String, String))
		/// <summary>
		/// Returns a new string in which all occurrences of a specified string in this instance are replaced with another specified string.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="String"/> to seek and <see cref="String"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this String text, (String seek, String replace) m1) {
			Guard.NotNull(text, nameof(text));
			return Replace(text.AsSpan(), m1);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified string in this instance are replaced with another specified string.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="String"/> to seek and <see cref="String"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this Char[] text, (String seek, String replace) m1) {
			Guard.NotNull(text, nameof(text));
			return Replace(text.AsSpan(), m1);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified string in this instance are replaced with another specified string.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="String"/> to seek and <see cref="String"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this ReadOnlySpan<Char> text, (String seek, String replace) m1) {
			IList<Int32> indicies = new List<Int32>(capacity: text.Length / 4);
			HorspoolTable table = new HorspoolTable(m1.seek);
			Int32 index = -1;
			while ((index = Search.Horspool(text, table, index + 1)) >= 0) {
				indicies.Add(index);
			}
			index = 0;
			StringBuilder builder = new StringBuilder(capacity: text.Length);
			foreach (Int32 item in indicies) {
				_ = builder.Append(text.Slice(index, item - index).ToString());
				_ = builder.Append(m1.replace);
				index = item;
			}
			_ = builder.Append(text.Slice(index + 1).ToString());
			return builder.ToString();
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified string in this instance are replaced with another specified string.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="m1">The first mapping of <see cref="String"/> to seek and <see cref="String"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		[CLSCompliant(false)]
		public static unsafe String Replace(Char* text, Int32 length, (String seek, String replace) m1) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return Replace(new ReadOnlySpan<Char>(text, length), m1);
		}
		#endregion

		#region Replace(Text, (Char, Char), (Char, Char))
		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m2">The second mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this String text, (Char seek, Char replace) m1, (Char seek, Char replace) m2) {
			Guard.NotNull(text, nameof(text));
			return Replace(text.AsSpan(), m1, m2);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m2">The second mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this Char[] text, (Char seek, Char replace) m1, (Char seek, Char replace) m2) {
			Guard.NotNull(text, nameof(text));
			return Replace(text.AsSpan(), m1, m2);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m2">The second mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this Span<Char> text, (Char seek, Char replace) m1, (Char seek, Char replace) m2) => Replace((ReadOnlySpan<Char>)text, m1, m2);

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m2">The second mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this ReadOnlySpan<Char> text, (Char seek, Char replace) m1, (Char seek, Char replace) m2) {
			Span<Char> result = new Char[text.Length];
			text.CopyTo(result);
			for (Int32 r = 0; r < result.Length; r++) {
				if (result[r] == m1.seek) {
					result[r] = m1.replace;
				} else if (result[r] == m2.seek) {
					result[r] = m2.replace;
				}
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m2">The second mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Replace(Char* text, Int32 length, (Char seek, Char replace) m1, (Char seek, Char replace) m2) {
			Guard.NotNull(text, nameof(text));
			return Replace(new ReadOnlySpan<Char>(text, length), m1, m2);
		}
		#endregion

		#region Replace(Text, (Rune, Rune), (Rune, Rune))
		#endregion

		#region Replace(Text, (String, String), (String, String))
		#endregion

		#region Replace(Text, (Char, Char), (Char, Char), (Char, Char))
		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m2">The second mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m3">The third mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this String text, (Char seek, Char replace) m1, (Char seek, Char replace) m2, (Char seek, Char replace) m3) {
			Guard.NotNull(text, nameof(text));
			return Replace(text.AsSpan(), m1, m2, m3);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m2">The second mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this Char[] text, (Char seek, Char replace) m1, (Char seek, Char replace) m2, (Char seek, Char replace) m3) {
			Guard.NotNull(text, nameof(text));
			return Replace(text.AsSpan(), m1, m2, m3);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m2">The second mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this Span<Char> text, (Char seek, Char replace) m1, (Char seek, Char replace) m2, (Char seek, Char replace) m3) => Replace((ReadOnlySpan<Char>)text, m1, m2, m3);

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m2">The second mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this ReadOnlySpan<Char> text, (Char seek, Char replace) m1, (Char seek, Char replace) m2, (Char seek, Char replace) m3) {
			Span<Char> result = new Char[text.Length];
			text.CopyTo(result);
			for (Int32 r = 0; r < result.Length; r++) {
				if (result[r] == m1.seek) {
					result[r] = m1.replace;
				} else if (result[r] == m2.seek) {
					result[r] = m2.replace;
				} else if (result[r] == m3.seek) {
					result[r] = m3.replace;
				}
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m2">The second mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		[CLSCompliant(false)]
		public static unsafe String Replace(Char* text, Int32 length, (Char seek, Char replace) m1, (Char seek, Char replace) m2, (Char seek, Char replace) m3) {
			Guard.NotNull(text, nameof(text));
			return Replace(new ReadOnlySpan<Char>(text, length), m1, m2, m3);
		}
		#endregion

		#region Replace(Text, (Rune, Rune), (Rune, Rune), (Rune, Rune))
		#endregion

		#region Replace(Text, (String, String), (String, String), (String, String))
		#endregion

		#region Replace(Text, params (Char, Char)[])
		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="map">A mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this String text, params (Char seek, Char replace)[] map) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(map, nameof(map));
			return Replace(text.AsSpan(), map);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="map">A mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this Char[] text, params (Char seek, Char replace)[] map) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(map, nameof(map));
			return Replace(text.AsSpan(), map);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="map">A mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this Span<Char> text, params (Char seek, Char replace)[] map) => Replace((ReadOnlySpan<Char>)text, map);

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="map">A mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this ReadOnlySpan<Char> text, params (Char seek, Char replace)[] map) {
			Guard.NotNull(map, nameof(map));
			Span<Char> result = new Char[text.Length];
			text.CopyTo(result);
			for (Int32 r = 0; r < result.Length; r++) {
				foreach ((Char seek, Char replace) in map) {
					if (result[r] == seek) {
						result[r] = replace;
					}
				}
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="map">A mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		[CLSCompliant(false)]
		public static unsafe String Replace(Char* text, Int32 length, params (Char seek, Char replace)[] map) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(map, nameof(map));
			return Replace(new ReadOnlySpan<Char>(text, length), map);
		}
		#endregion

		#region Replace(Text, params (Rune, Rune)[])
		#endregion

		#region Replace(Text, params (String, String)[])
		/// <summary>
		/// Returns a new string in which all occurrences of a specified string in this instance are replaced with another specified string.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="map">A mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this String text, params (String seek, String replace)[] map) {
			Guard.NotNull(text, nameof(text));
			return Replace(text.AsSpan(), map);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified string in this instance are replaced with another specified string.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="map">A mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this Char[] text, params (String seek, String replace)[] map) {
			Guard.NotNull(text, nameof(text));
			return Replace(text.AsSpan(), map);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified string in this instance are replaced with another specified string.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="map">A mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this Span<Char> text, params (String seek, String replace)[] map) => Replace((ReadOnlySpan<Char>)text, map);

		/// <summary>
		/// Returns a new string in which all occurrences of a specified string in this instance are replaced with another specified string.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="map">A mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static String Replace(this ReadOnlySpan<Char> text, params (String seek, String replace)[] map) {
			Guard.NotNull(map, nameof(map));
			String result = text.ToString();
			foreach ((String seek, String replace) m in map) {
				result = result.Replace(m);
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified string in this instance are replaced with another specified string.
		/// </summary>
		/// <param name="text">The source text.</param>
		/// <param name="map">A mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements have been performed.</returns>
		public static unsafe String Replace(Char* text, Int32 length, params (String seek, String replace)[] map) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return Replace(new ReadOnlySpan<Char>(text, length), map);
		}
		#endregion
	}
}
