using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class SourceStateTests {
		[TestMethod]
		public void StoreAndRestoreTest() {
			Source source = new Source("hello world");
			SourceState state = source.Store();
			ResultAssert.Succeeds("hello".Consume(ref source));
			source.Restore(ref state);
			//The only way this can succeed is if the restore worked
			ResultAssert.Succeeds("hello".Consume(ref source));
		}
	}
}
