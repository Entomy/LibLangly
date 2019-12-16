using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Consolator.UI;
using Consolator.UI.Theming;
using Console = Consolator.Console;
using Stringier.Patterns;

namespace ptndbg {
	public static partial class Program {
		[SuppressMessage("Redundancy", "RCS1038:Remove empty statement.", Justification = "They are used for break-points, they don't hurt anything, stfu.")]
		public static void Main() {
			Theme.DefaultDark.Apply();

			Source source = GetSource();
			Pattern pattern = GetPattern();
			;
		}
	}
}