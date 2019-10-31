namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Chop the <paramref name="String"/> into chunks of <paramref name="Size"/>
		/// </summary>
		/// <param name="String">String to chop</param>
		/// <param name="Size">Size of chunks to chop into</param>
		/// <returns>Array of chunks</returns>
		public static String[] Chop(this String String, Int32 Size) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			if (Size <= 0) {
				throw new ArgumentOutOfRangeException(nameof(Size), "Size must be greater than 0");
			} else if (Size >= String.Length) {
				return new[] { String };
			}
			Int32 i = 0;
			Int32 j = 0;
			Int32 k = (Int32)Math.Ceiling((Double)String.Length / Size);
			String[] Result = new String[k];
			while (i < k) {
				Result[i] = (j + Size) > String.Length ? String.Substring(j, String.Length - j) : String.Substring(j, Size);
				i++;
				j += Size;
			}
			return Result;
		}
	}
}
