using System;
using System.Threading.Tasks;
using EasyConsole;

namespace Langly {
	internal sealed class MainMenu : MenuPage {
		public MainMenu(Program program) : base("Main Menu", program,
			new Option("Collectathon", (_) => Task.Run(() => program.NavigateTo<CollectathonMenu>(_))),
			new Option("Quit", (_) => Task.Run(() => Environment.Exit(0)))) { }
	}
}
