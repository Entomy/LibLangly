using System;
using System.Threading;
using Consolator;
using Console = Consolator.Console;

namespace Benchmarks {
	public static class Program {
		public static void Main() {
			Console.Title = nameof(Benchmarks);
			using var buffer = Console.Buffer;
			Console.WriteLine("Hello");
			Console.WriteLine("Γεια σας", Color.Red);
			Console.WriteLine("Превет", Color.Yellow);
			Console.WriteLine("Dia duit", Color.Green);
			Console.WriteLine("नमस्कार", Color.Cyan);
			Console.WriteLine("שלום", Color.Blue);
			Console.WriteLine("こんにちは", Color.Magenta);
			Console.WriteLine("From not the .NET Runtime", Color.RGB(0, 0, 0), Color.RGB(255, 255, 255));
			Console.WriteError(new ApplicationException("Yeah idk, some error message..."));
			Thread.Sleep(5000);
		}
	}
}
