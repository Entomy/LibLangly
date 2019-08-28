using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CaptureTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = (+Pattern.Letter).Capture(out Capture _);
		}

		[TestMethod]
		public void Consume() {
			Capture Capture;
			Pattern Capturer = (+Pattern.Letter).Capture(out Capture);
			Result Result;

			Result = Capturer.Consume("Hello");
			Assert.That.Captures("Hello", Result);
			Assert.That.Captures("Hello", Capture);
			Assert.That.Succeeds(Result);

			Pattern Start = "Hello " & (+Pattern.Letter).Capture(out Capture) & "!";

			Result = Start.Consume("Hello World!");
			Assert.That.Captures("Hello World!", Result);
			Assert.That.Captures("World", Capture);
			Assert.That.Succeeds(Result);

			Pattern Stop = (Pattern)"Goodbye " & Capture & ".";

			Result = Stop.Consume("Goodbye World.");
			Assert.That.Captures("Goodbye World.", Result);
			Assert.That.Succeeds(Result);

			Result = Start.Consume("Hello Range!");
			Assert.That.Captures("Hello Range!", Result);
			Assert.That.Captures("Range", Capture);
			Assert.That.Succeeds(Result);

			Pattern Range = (Start, Stop);

			Result = Range.Consume("Hello Range! How are you today? Goodbye Range. Have a good day.");
			Assert.That.Captures("Range", Capture);
			Assert.That.Captures("Hello Range! How are you today? Goodbye Range.", Result);
			Assert.That.Succeeds(Result);
		}
	}
}
