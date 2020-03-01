using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class LinesTests : Trial {
		[Theory]
		[InlineData("Some example text.\nWith some line breaks.\nWhich will be split up", new[] { "Some example text.", "With some line breaks.", "Which will be split up"})]
		public void Lines(String source, String[] expected) => Claim.That(source.Lines()).SequenceEquals(expected);
	}
}
