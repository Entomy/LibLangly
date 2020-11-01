using System;
using Consolator;
using Console = Consolator.Console;

namespace Benchmarks {
	class Program {
		static void Main() {
			Console.Title = nameof(Benchmarks);
			Console.WriteLine("Hello");
			Console.WriteLine("Γεια σας", Color.Red);
			Console.WriteLine("Превет", Color.Yellow);
			Console.WriteLine("Dia duit", Color.Green);
			Console.WriteLine("नमस्कार", Color.Cyan);
			Console.WriteLine("שלום", Color.Blue);
			Console.WriteLine("こんにちは", Color.Magenta);
			Console.WriteLine("From not the .NET Runtime", Color.RGB(0, 0, 0), Color.RGB(255, 255, 255));
		}
	}
}
