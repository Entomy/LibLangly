using System;
using System.ComponentModel;
using Consolator.Internals;

namespace Consolator {
	public static partial class Console {
		/// <summary>
		/// The internal components of the <see cref="Console"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static class Internals {
			private static IConsoleErrorWriter errorWriter = StandardConsole.Instance;

			private static IConsoleReader reader = StandardConsole.Instance;

			private static IConsoleStateManager stateManager = VTEscapeSequenceStateManager.Instance;

			private static IConsoleWriter writer = StandardConsole.Instance;

			/// <summary>
			/// The object responsible for handling writes of errors.
			/// </summary>
			/// <remarks>
			/// By default this performs normal write operations, but another object can be injected through this property that provides atypical behavior, such as for debugging. Setting to <see langword="null"/> will reset to standard behavior.
			/// </remarks>
			[CLSCompliant(false)]
			public static IConsoleErrorWriter ErrorWriter {
				get => errorWriter;
				set => errorWriter = value ?? StandardConsole.Instance;
			}

			/// <summary>
			/// The object responsible for handling reads.
			/// </summary>
			/// <remarks>
			/// By default this performs normal read operations, but another object can be injected through this property that provides atypical behavior, such as for debugging. Setting to <see langword="null"/> will reset to standard behavior.
			/// </remarks>
			[CLSCompliant(false)]
			public static IConsoleReader Reader {
				get => reader;
				set => reader = value ?? StandardConsole.Instance;
			}

			/// <summary>
			/// The object responsible for managing console state.
			/// </summary>
			/// <remarks>
			/// By default this performs state adjustment through VT Escape Sequences, but another object can be injected through this property that provides atypical behavior, such as for debugging. Setting <see langword="null"/> will reset to standard behavior.
			/// </remarks>
			public static IConsoleStateManager StateManager {
				get => stateManager;
				set => stateManager = value ?? VTEscapeSequenceStateManager.Instance;
			}

			/// <summary>
			/// The object responsible for handling writes.
			/// </summary>
			/// <remarks>
			/// By default this performs normal write operations, but another object can be injected through this property that provides atypical behavior, such as for debugging. Setting to <see langword="null"/> will reset to standard behavior.
			/// </remarks>
			[CLSCompliant(false)]
			public static IConsoleWriter Writer {
				get => writer;
				set => writer = value ?? StandardConsole.Instance;
			}
		}
	}
}
