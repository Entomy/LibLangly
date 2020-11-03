using System;

namespace Consolator {
	public static partial class Console {
		#region WriteError()
		/// <summary>
		/// Writes the exception message to the standard error stream.
		/// </summary>
		/// <param name="exception">The exception providing the message to write.</param>
		public static void WriteError(Exception exception) {
			if (exception is null) {
				return;
			}
			Internals.StateManager.SetForeground(Color.Red);
			Internals.ErrorWriter.Write(" Error: ");
			Foreground.Color = Foreground.Current;
			Internals.ErrorWriter.Write(exception.Message);
		}
		#endregion
	}
}
