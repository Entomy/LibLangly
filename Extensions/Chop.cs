namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Chop the <paramref name="string"/> into chunks of <paramref name="size"/>
		/// </summary>
		/// <param name="string">String to chop</param>
		/// <param name="size">Size of chunks to chop into</param>
		/// <returns>Array of chunks</returns>
		public static String[] Chop(this String @string, Int32 size) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			if (size <= 0) {
				throw new ArgumentOutOfRangeException(nameof(size), "Size must be greater than 0");
			} else if (size >= @string.Length) {
				return new[] { @string };
			} else {
				Int32 i = 0;
				Int32 j = 0;
				Int32 k = (Int32)Math.Ceiling((Double)@string.Length / size);
				String[] Result = new String[k];
				while (i < k) {
					Result[i] = (j + size) > @string.Length ? @string.Substring(j, @string.Length - j) : @string.Substring(j, size);
					i++;
					j += size;
				}
				return Result;
			}
		}
	}
}
