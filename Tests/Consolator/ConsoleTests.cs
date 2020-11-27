using System;
using Langly.Internals;
using Xunit;
using Console = Langly.Console;

namespace Langly {
	public class ConsoleTests {
		TestConsole tester = new TestConsole();

		public ConsoleTests() {
			Console.Internals.Reader = tester;
			Console.Internals.Writer = tester;
			Console.Internals.ErrorWriter = tester;
			Console.Internals.StateManager = new StubStateManager();
		}

		[Theory]
		[InlineData("Hello")]
		public void Write(String text) {
			Console.Write(text);
			Assert.Equal(text, tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public void Write_Color(String text) {
			Console.Write(text, Color.Blue);
			Assert.Equal(text, tester.Written);
		}
	}
}
