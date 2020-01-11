using System;

namespace Stringier {
	public static partial class Search {
		public static Int32 RabinKarp(String text, String pattern) {
			Int32 siga = 0;
			Int32 sigb = 0;
			Int32 Q = 100007;
			Int32 D = 256;
			for (Int32 i = 0; i < pattern.Length; i++) {
				siga = (siga * D + text[i]) % Q;
				sigb = (sigb * D + pattern[i]) % Q;
			}
			if (siga == sigb) {
				return 0;
			}
			Int32 pow = 1;
			for (Int32 k = 1; k <= pattern.Length - 1; k++) {
				pow = (pow * D) % Q;
			}

			for (Int32 j = 1; j <= text.Length - pattern.Length; j++) {
				siga = (siga + Q - pow * text[j - 1] % Q) % Q;
				siga = (siga * D + text[j + pattern.Length - 1]) % Q;
				if (siga == sigb) {
					if (text.Substring(j, pattern.Length) == pattern) {
						return j;
					}
				}
			}
			return -1;
		}
	}
}
