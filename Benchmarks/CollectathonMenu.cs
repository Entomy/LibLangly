using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using Collectathon;
using EasyConsole;

namespace Langly {
	internal sealed class CollectathonMenu : MenuPage {
		public CollectathonMenu(Program program) : base("Collectathon", program,
			new Option("Add - Many", (_) => Task.Run(() => BenchmarkRunner.Run<AddMany>())),
			new Option("Add - Single", (_) => Task.Run(() => BenchmarkRunner.Run<AddSingle>())),
			new Option("Construction", (_) => Task.Run(() => BenchmarkRunner.Run<Construction>())),
			new Option("Contains", (_) => Task.Run(() => BenchmarkRunner.Run<Contains>())),
			new Option("Index", (_) => Task.Run(() => BenchmarkRunner.Run<Index>()))) { }
	}
}
