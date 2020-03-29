using System;
using System.Collections.Generic;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Chop the <paramref name="string"/> into chunks of <paramref name="size"/>
		/// </summary>
		/// <param name="string">String to chop</param>
		/// <param name="size">Size of chunks to chop into</param>
		/// <returns>Array of chunks</returns>
		public static IReadOnlyCollection<ValueString> Chop(this String @string, Int32 size) {
			Guard.NotNull(@string, nameof(@string));
			return Chop(@string.AsSpan(), size);
		}

		/// <summary>
		/// Chop the <paramref name="string"/> into chunks of <paramref name="size"/>
		/// </summary>
		/// <param name="string">String to chop</param>
		/// <param name="size">Size of chunks to chop into</param>
		/// <returns>Array of chunks</returns>
		public static IReadOnlyCollection<ValueString> Chop(this ValueString @string, Int32 size) => Chop(@string.AsSpan(), size);

		/// <summary>
		/// Chop the <paramref name="span"/> into chunks of <paramref name="size"/>
		/// </summary>
		/// <param name="span">Span to chop</param>
		/// <param name="size">Size of chunks to chop into</param>
		/// <returns>Array of chunks</returns>
		public static IReadOnlyCollection<ValueString> Chop(this ReadOnlySpan<Char> span, Int32 size) {
			if (size <= 0) {
				throw new ArgumentOutOfRangeException(nameof(size), "Size must be greater than 0");
			} else if (size >= span.Length) {
				return new[] { new ValueString(span) };
			} else {
				Int32 i = 0;
				Int32 j = 0;
				Int32 k = (Int32)Math.Ceiling((Double)span.Length / size);
				ValueString[] Result = new ValueString[k];
				while (i < k) {
					Result[i] = (j + size) > span.Length ? new ValueString(span.Slice(j, span.Length - j)) : new ValueString(span.Slice(j, size));
					i++;
					j += size;
				}
				return Result;
			}
		}
	}
}
