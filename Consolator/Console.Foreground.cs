namespace Langly {
	public static partial class Console {
		/// <summary>
		/// Represents the foreground of the <see cref="Console"/>.
		/// </summary>
		public static class Foreground {
			/// <summary>
			/// The current foreground color.
			/// </summary>
			internal static Color Current = null;

			/// <summary>
			/// The color of the console foreground; the text color.
			/// </summary>
			public static Color Color {
				get => Current;
				set {
					Internals.StateManager.SetForeground(value);
					Current = value;
				}
			}
		}
	}
}
