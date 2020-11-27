using System.Diagnostics.CodeAnalysis;

namespace Langly.Internals {
	/// <summary>
	/// Provides the standard VT Escape Sequence state manager.
	/// </summary>
	internal sealed class VTEscapeSequenceStateManager : IConsoleStateManager {
		/// <summary>
		/// Sets the background color to the <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The <see cref="Color"/> to set.</param>
		public void SetBackground([MaybeNull] Color value) {
			switch (value) {
			case SimpleColor color:
				Console.Internals.Writer.Write($"\x1B[{40 + color.Code}m");
				break;
			case ComplexColor color:
				Console.Internals.Writer.Write($"\x1B[48;2;{color.Red};{color.Green};{color.Blue}m");
				break;
			default:
				Console.Internals.Writer.Write("\x1B[49m");
				break;
			}
		}

		/// <summary>
		/// Sets the foreground color to the <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The <see cref="Color"/> to set.</param>
		public void SetForeground([MaybeNull] Color value) {
			switch (value) {
			case SimpleColor color:
				Console.Internals.Writer.Write($"\x1B[{30 + color.Code}m");
				break;
			case ComplexColor color:
				Console.Internals.Writer.Write($"\x1B[38;2;{color.Red};{color.Green};{color.Blue}m");
				break;
			default:
				Console.Internals.Writer.Write("\x1B[39m");
				break;
			}
		}

		private VTEscapeSequenceStateManager() { }

		internal static VTEscapeSequenceStateManager Instance => Singleton.Instance;

		private static class Singleton {
			internal static readonly VTEscapeSequenceStateManager Instance = new VTEscapeSequenceStateManager();

			static Singleton() { }
		}
	}
}
