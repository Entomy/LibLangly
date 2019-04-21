using System;

namespace System.Text.Patterns {
	public static class StringExtensions {
		public static Result Consume(this String Pattern, String Candidate) => String.Equals(Pattern, Candidate.Substring(0, Pattern.Length)) ? new Result(true, Candidate.Remove(0, Pattern.Length)) : new Result(false, Candidate);
	}
}
