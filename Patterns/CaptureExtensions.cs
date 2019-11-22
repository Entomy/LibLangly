using Stringier.Patterns.Nodes;

namespace Stringier.Patterns {
	public static class CaptureExtensions {
		/// <summary>
		/// Compare this <paramref name="capture"/> with the given <paramref name="comparisonType"/>.
		/// </summary>
		/// <param name="capture">The <see cref="Capture"/> object.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A new <see cref="Pattern"/> representing the <paramref name="capture"/> compared with <paramref name="comparisonType"/>.</returns>
		public static Pattern With(this Capture capture, Compare comparisonType) => new Pattern(new CaptureLiteral(capture, comparisonType));
	}
}
