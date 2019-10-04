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
			ResultAssert.Captures("Hello", Result);
			CaptureAssert.Captures("Hello", Capture);

			Pattern Start = "Hello " & (+Pattern.Letter).Capture(out Capture) & "!";

			Result = Start.Consume("Hello World!");
			ResultAssert.Captures("Hello World!", Result);
			CaptureAssert.Captures("World", Capture);

			Pattern Stop = (Pattern)"Goodbye " & Capture & ".";

			Result = Stop.Consume("Goodbye World.");
			ResultAssert.Captures("Goodbye World.", Result);

			Result = Start.Consume("Hello Range!");
			ResultAssert.Captures("Hello Range!", Result);
			CaptureAssert.Captures("Range", Capture);

			Pattern Range = (Start, Stop);

			Result = Range.Consume("Hello Range! How are you today? Goodbye Range. Have a good day.");
			ResultAssert.Captures("Hello Range! How are you today? Goodbye Range.", Result);
			CaptureAssert.Captures("Range", Capture);
		}
	}
}
