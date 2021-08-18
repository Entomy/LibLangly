using System;
using System.Diagnostics.CodeAnalysis;
using Defender;
using Xunit;

namespace Philosoft {
	public class BehavioralAnalyzer_Tests : Tests {
		public BehavioralAnalyzer_Tests() => Config.SetPath("Philosoft/Data");

		[Theory]
		[InlineData("ThrownExceptionNotDeclared.cs", "BA00")]
		public void Tests(String file, String id) => Assert.That<BehavioralAnalyzer>(file).Reports(id);
	}
}
