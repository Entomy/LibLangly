using System;
using System.Globalization;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CultureTests {
		static readonly String encyclopaedia = "encyclopaedia";
		static readonly String encyclopædia = "encyclopædia";
		static readonly String encyclopedia = "encyclopedia";

		static readonly Pattern patternOrdinal = encyclopedia.With(StringComparison.Ordinal);
		static readonly Pattern patternInvariant = encyclopedia.With(StringComparison.InvariantCulture);
		static readonly Pattern patternCurrent = encyclopedia.With(StringComparison.CurrentCulture);

		[TestMethod]
		public void OrdinalEquals() {
			ResultAssert.Fails(patternOrdinal.Consume(encyclopaedia));
			ResultAssert.Fails(patternOrdinal.Consume(encyclopædia));
			ResultAssert.Succeeds(patternOrdinal.Consume(encyclopedia));
		}

		[TestMethod]
		public void InvariantEquals() {
			ResultAssert.Fails(patternInvariant.Consume(encyclopaedia));
			ResultAssert.Fails(patternInvariant.Consume(encyclopædia));
			ResultAssert.Succeeds(patternInvariant.Consume(encyclopedia));
		}

		[TestMethod]
		public void CurrentCultureEquals() {
			CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
			ResultAssert.Succeeds(patternCurrent.Consume(encyclopaedia));
			ResultAssert.Succeeds(patternCurrent.Consume(encyclopædia));
			ResultAssert.Succeeds(patternCurrent.Consume(encyclopedia));
		}
	}
}
