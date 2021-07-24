using System;
using System.Threading;
using System.Threading.Tasks;
using EasyConsole;
using Figgle;

namespace Langly {
	public sealed class Program : EasyConsole.Program {
		private Program() : base("LibLangly Benchmarks", breadcrumbHeader: true) {
			AddPage(new MainMenu(this));
			AddPage(new CollectathonMenu(this));
			_ = SetPage<MainMenu>();
		}

		public static async Task Main() {
			Output.WriteLine(ConsoleColor.Magenta, FiggleFonts.Standard.Render("LibLangly"));
			Output.WriteLine(ConsoleColor.Cyan, FiggleFonts.Standard.Render("Benchmarks"));
			await new Program().Run(new CancellationToken());
		}
	}
}
