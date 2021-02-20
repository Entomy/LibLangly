using System;
using System.Diagnostics;
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
				ConsoleComponents.Writer.Write($"\x1B[{40 + color.Code}m");
				break;
			case ComplexColor color:
				ConsoleComponents.Writer.Write($"\x1B[48;2;{color.Red};{color.Green};{color.Blue}m");
				break;
			default:
				ConsoleComponents.Writer.Write("\x1B[49m");
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
				ConsoleComponents.Writer.Write($"\x1B[{30 + color.Code}m");
				break;
			case ComplexColor color:
				ConsoleComponents.Writer.Write($"\x1B[38;2;{color.Red};{color.Green};{color.Blue}m");
				break;
			default:
				ConsoleComponents.Writer.Write("\x1B[39m");
				break;
			}
		}

		/// <inheritdoc/>
		public void UseAlternateScreenBuffer() => ConsoleComponents.Writer.Write("\x1B[?1049h");

		/// <inheritdoc/>
		public void UseMainScreenBuffer() => ConsoleComponents.Writer.Write("\x1B[?1049l");

		/// <inheritdoc/>
		public void SetTitle([AllowNull] String title) {
			if (title is not null) {
				ConsoleComponents.Writer.Write($"\x1B]2;{title}\b");
			} else {
				using Process process = Process.GetCurrentProcess();
				ConsoleComponents.Writer.Write($"\x1B]2;{process.ProcessName}\b");
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
