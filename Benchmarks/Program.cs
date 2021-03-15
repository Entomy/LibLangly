using System.Threading;
using Langly;
using Console = Langly.Console;

namespace Benchmarks {
	public static class Program {
		public static void Main() {
			Console.Title = "Langly Benchmarks";
			using ScreenBuffer Screen = Console.ScreenBuffer;
			Screen.WriteLine("Hello World");
			string Prompt = Screen.Prompt("Prompt");
			Screen.WriteLine($"Entered: {Prompt}");
			Thread.Sleep(1000);
		}
	}
}
