using System.Diagnostics.CodeAnalysis;

namespace System.Text.Patterns {
	[SuppressMessage("Microsoft.Analyzers", "CA1720", Justification = "This is an extension library, of course I'm naming the calling type the type itself")]
	public static class StringExtensions {
		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Candidate"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Candidate">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the remaining string</returns>
		public static Result Consume(this String Pattern, String Candidate) {
			if (Pattern.Length > Candidate.Length) {
				return new Result(false, Candidate);
			}
			if (String.Equals(Pattern, Candidate.Substring(0, Pattern.Length), StringComparison.InvariantCulture)) {
				return new Result(true, Candidate.Remove(0, Pattern.Length));
			} else {
				return new Result(false, Candidate);
			}
		}
	}
}
