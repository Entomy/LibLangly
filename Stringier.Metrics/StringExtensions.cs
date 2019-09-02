namespace System.Text.Metrics {
	public static class StringExtensions {
		/// <summary>
		/// Calculates the Levenshtein edit distance between <paramref name="String"/> and <paramref name="Other"/>
		/// </summary>
		/// <param name="String"></param>
		/// <param name="Other"></param>
		/// <returns>The number of changes required to edit <paramref name="String"/> into <paramref name="Other"/></returns>
		public static Int32 LevenshteinDistance(this String String, String Other) {
			Int32 N = String.Length;
			Int32 M = Other.Length;
			Int32[,] D = new Int32[N + 1, M + 1];

			if (N == 0) { return M; }
			if (M == 0) { return N; }

			for (Int32 i = 0; i <= N; i++) { D[i, 0] = i; }
			for (Int32 j = 0; j <= M; j++) { D[0, j] = j; }

			for (Int32 j = 1; j <= M; j++) {
				for (Int32 i = 1; i <= N; i++) {
					if (String[i - 1] == Other[j - 1]) {
						D[i, j] = D[i - 1, j - 1]; //No Difference
					} else {
						D[i, j] = Math.Min(
							Math.Min(
								D[i - 1, j] + 1, //Deletion
								D[i, j - 1] + 1), //Insertion
							D[i - 1, j - 1] + 1); //Substitution
					}
				}
			}
			return D[N, M];
		}
	}
}
