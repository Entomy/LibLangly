using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Internals;

namespace Langly {
	public static partial class Console {
		#region WriteError()
		/// <summary>
		/// Writes the exception message to the standard error stream.
		/// </summary>
		/// <param name="exception">The exception providing the message to write.</param>
		public static void WriteError([AllowNull] Exception exception) {
			if (exception is null) {
				return;
			}
			ConsoleComponents.StateManager.SetForeground(Color.Red);
			ConsoleComponents.Error.Write(" Error: ");
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.Error.Write(exception.Message);
		}
		#endregion
	}
}
