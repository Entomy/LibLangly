namespace Consolator {
	public static partial class Console {
		/// <summary>
		/// Represents the background of the <see cref="Console"/>.
		/// </summary>
		public static class Background {
			/// <summary>
			/// The current background color.
			/// </summary>
			internal static Color Current = null;

			/// <summary>
			/// The color of the console background.
			/// </summary>
			public static Color Color {
				get => Current;
				set {
					Internals.StateManager.SetBackground(value);
					Current = value;
				}
			}
		}
	}
}
