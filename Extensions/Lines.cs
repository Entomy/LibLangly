using System.IO;

namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Separate the <paramref name="String"/> into its lines.
		/// </summary>
		/// <param name="String">String to separate.</param>
		/// <returns>Array of lines within the <paramref name="String"/>.</returns>
		public static String[] Lines(this String String) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			return String.Split(Path.DirectorySeparatorChar);
		}
	}
}
