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
			Pattern Capturer = (+Pattern.Letter).Capture(out Capture Capture);
			Result Result;

			Result = Capturer.Consume("Hello");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello", Result);
			Assert.That.Captures("Hello", Capture);

			Result = ("Hello " & Capturer).Consume("Hello World");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello World", Result);
			Assert.That.Captures("World", Capture);
		}

		[TestMethod]
		public void ConsumeRange() {
			Pattern Start = "Hello " & (+Pattern.Letter).Capture(out Capture Capture) & "!";
			Pattern Stop = (Pattern)"Goodbye " & Capture & ".";
			Result Result;
			Pattern Range = (From: Start, To: Stop);

			Result = Range.Consume("Hello World! How are you today? Goodbye World. Have a good day.");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello World! How are you today? Goodbye World.", Result);
			Assert.That.Captures("World", Capture);
		}
	}
}
