using System;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Chop the <paramref name="string"/> into chunks of <paramref name="size"/>
		/// </summary>
		/// <param name="string">String to chop</param>
		/// <param name="size">Size of chunks to chop into</param>
		/// <returns>Array of chunks</returns>
		public static String[] Chop(this String @string, Int32 size) {
			Guard.NotNull(@string, nameof(@string));
			return Chop(@string.AsSpan(), size);
		}

		/// <summary>
		/// Chop the <paramref name="span"/> into chunks of <paramref name="size"/>
		/// </summary>
		/// <param name="span">Span to chop</param>
		/// <param name="size">Size of chunks to chop into</param>
		/// <returns>Array of chunks</returns>
		public static String[] Chop(this ReadOnlySpan<Char> span, Int32 size) {
			if (size <= 0) {
				throw new ArgumentOutOfRangeException(nameof(size), "Size must be greater than 0");
			} else if (size >= span.Length) {
				return new[] { span.ToString() };
			} else {
				Int32 i = 0;
				Int32 j = 0;
				Int32 k = (Int32)Math.Ceiling((Double)span.Length / size);
				String[] Result = new String[k];
				while (i < k) {
					Result[i] = (j + size) > span.Length ? span.Slice(j, span.Length - j).ToString() : span.Slice(j, size).ToString();
					i++;
					j += size;
				}
				return Result;
			}
		}
	}
}
