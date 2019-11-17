using System.IO;

namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Separate the <paramref name="string"/> into its lines.
		/// </summary>
		/// <param name="string">String to separate.</param>
		/// <returns>Array of lines within the <paramref name="string"/>.</returns>
		public static String[] Lines(this String @string) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			return @string.Split(Path.DirectorySeparatorChar);
		}
	}
}
