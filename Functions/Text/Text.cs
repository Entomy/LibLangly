using Stringier.Categories;

namespace Stringier {
	/// <summary>
	/// Provides a vast collection of text processing functions.
	/// </summary>
	public static partial class Text {
		private static readonly Category Surrogate = new Surrogate();

		private static readonly Category WhiteSpace = new WhiteSpace();
	}
}
