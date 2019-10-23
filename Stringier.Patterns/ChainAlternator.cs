namespace System.Text.Patterns {
	internal sealed class ChainAlternator : Pattern, IEquatable<ChainAlternator> {
		internal readonly Pattern[] Patterns;

		internal ChainAlternator(params Pattern[] Patterns) {
			this.Patterns = Patterns;
		}

		internal ChainAlternator(Pattern FirstPattern, Pattern[] OtherPatterns) {
			Patterns = new Pattern[OtherPatterns.Length + 1];
			Patterns[0] = FirstPattern;
			OtherPatterns.CopyTo(Patterns, 1);
		}

		internal ChainAlternator(Pattern[] OtherPatterns, Pattern LastPattern) {
			Patterns = new Pattern[OtherPatterns.Length + 1];
			OtherPatterns.CopyTo(Patterns, 0);
			Patterns[Patterns.Length - 1] = LastPattern;
		}

		internal ChainAlternator(Pattern[] FirstPatterns, Pattern[] LastPatterns) {
			Patterns = new Pattern[FirstPatterns.Length + LastPatterns.Length];
			FirstPatterns.CopyTo(Patterns, 0);
			LastPatterns.CopyTo(Patterns, FirstPatterns.Length);
		}

		internal override Boolean CheckHeader(ref Source Source) {
			foreach (Pattern Pattern in Patterns) {
				if (Pattern.CheckHeader(ref Source)) { return true; }
			}
			return false;
		}

		internal override void Consume(ref Source Source, ref Result Result) {
			foreach (Pattern Pattern in Patterns) {
				Pattern.Consume(ref Source, ref Result);
				if (Result) {
					return;
				}
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			Int32 OriginalPosition = Source.Position;
			Int32 OriginalLength = Result.Length;
			Int32 ShortestPattern = Int32.MaxValue;
			for (Int32 i = Patterns.Length - 1; i >= 0; i--) {
				Patterns[i].Neglect(ref Source, ref Result);
				if (Result.Length < ShortestPattern) { ShortestPattern = Result.Length - OriginalLength; }
				if (Result) {
					Source.Position = OriginalPosition;
					Result.Length = OriginalLength;
				} else {
					return;
				}
			}
			Source.Position += ShortestPattern;
			Result.Length += ShortestPattern;
		}

		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case ChainAlternator other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(ChainAlternator other) => Patterns.Equals(other.Patterns);

		public override Int32 GetHashCode() => Patterns.GetHashCode();

		public override String ToString() {
			StringBuilder Builder = new StringBuilder("┃");
			foreach (Pattern Pattern in Patterns) {
				Builder.Append($"{Pattern}│");
			}
			Builder.Remove(Builder.Length - 1, 1);
			Builder.Append("┃");
			return Builder.ToString();
		}

		#region Alternate

		internal override Pattern Alternate(Char Right) => new ChainAlternator(Patterns, new CharLiteral(Right));

		internal override Pattern Alternate(String Right) => new ChainAlternator(Patterns, new StringLiteral(Right));

		internal override Pattern Alternate(Pattern Right) {
			switch (Right) {
			case ChainAlternator chain:
				return new ChainAlternator(Patterns, chain.Patterns);
			default:
				return base.Alternate(Right);
			}
		}

		#endregion

		#region Spanner

		internal override Pattern Span() {
			foreach (Pattern Pattern in Patterns) {
				if (Pattern is Optor) { throw new PatternConstructionException("One or more of the components of this alternator are optional, and the alternator is marked as spanning. Options can not span, as it creates an infinite loop. While this potentially could succeed, this is absolutely an error."); }
			}
			return base.Span();
		}

		#endregion
	}
}
