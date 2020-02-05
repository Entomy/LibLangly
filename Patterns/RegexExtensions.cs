using System;
using System.Text.RegularExpressions;
using Stringier.Patterns.Nodes;
using Defender;

namespace Stringier.Patterns {
	public static class RegexExtensions {
		/// <summary>
		/// Converts this <see cref="Regex"/> to a <see cref="Pattern"/>.
		/// </summary>
		/// <remarks>
		/// This does verification of the <paramref name="regex"/> because not everything can be correctly represented and there are certain requirements.
		/// All <see cref="Regex"/> must be anchored to the begining of the line; that is, start with <c>^</c>.
		/// </remarks>
		/// <param name="regex">The <see cref="Regex"/> to convert.</param>
		/// <returns>A <see cref="Pattern"/> which represents the closest approximation of the given <paramref name="regex"/>.</returns>
		public static Pattern AsPattern(this Regex regex) {
			Guard.NotNull(regex, nameof(regex));
			String Pattern = regex.ToString();
			if (Pattern[0] != '^') {
				throw new PatternConstructionException("Regex me be anchored to the begining");
			}
			return new RegexAdapter(regex);
		}
	}
}
