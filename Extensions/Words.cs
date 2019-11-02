namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Separate the <paramref name="String"/> into its words.
		/// </summary>
		/// <param name="String">String to separate.</param>
		/// <returns>Array of words within the <paramref name="String"/>.</returns>
		public static String[] Words(this String String) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			return String.Clean().Split(' ');
		}
	}
}