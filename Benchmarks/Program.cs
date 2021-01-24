using System;
using BenchmarkDotNet.Running;
using Langly;
using Console = Langly.Console;

namespace Benchmarks {
	public static class Program {
		public static void Main() {
			using ScreenBuffer buffer = Console.Buffer;
		}
	}
}
