using System.Text;
using System.Text.RegularExpressions;

namespace System {
	/// <summary>
	/// Holds state values, like settings, for the Stringier library
	/// </summary>
	public static class Stringier {

		/// <summary>
		/// The default <see cref="RegexOptions"/> to use with Regex operations
		/// </summary>
		/// <remarks>
		/// This can be useful when the same <see cref="RegexOptions"/> are used over and over.
		/// </remarks>
		public static RegexOptions DefaultRegexOptions = RegexOptions.None;

	}
}
