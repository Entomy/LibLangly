using System.Threading;
using Langly;
using Console = Langly.Console;

namespace Benchmarks {
	public static class Program {
		public static void Main() {
			Console.Title = "Langly Benchmarks";
			using ScreenBuffer Screen = Console.ScreenBuffer;
			Console.WriteLine("Hello World");
			Thread.Sleep(1000);
		}
	}
}
