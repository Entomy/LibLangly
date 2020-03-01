using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class SplitTests : Trial {
		[Theory]
		[InlineData("comma,separated,values", ',', new[] { "comma", "separated", "values" })]
		public void Split_Char(String source, Char separator, String[] expected) {
			Claim.That(source.Split(separator)).SequenceEquals(expected);
			Claim.That(source.AsSpan().Split(separator)).SequenceEquals(expected);
		}

		[Theory]
		[InlineData("comma, separated, values, 1,300", ", ", new[] { "comma", "separated", "values", "1,300" })]
		public void Split_String(String source, String separator, String[] expected) {
			Claim.That(source.Split(separator)).SequenceEquals(expected);
			Claim.That(source.AsSpan().Split(separator)).SequenceEquals(expected);
		}
	}
}
