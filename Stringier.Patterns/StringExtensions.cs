namespace System.Text.Patterns {
	public static class StringExtensions {
		public static Result Consume(this String Pattern, String Candidate) {
			if (Pattern.Length > Candidate.Length) return new Result(false, Candidate);
			if (String.Equals(Pattern, Candidate.Substring(0, Pattern.Length))) {
				return new Result(true, Candidate.Remove(0, Pattern.Length));
			} else {
				return new Result(false, Candidate);
			}
		}
	}
}
