using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Internals;

namespace Langly {
	/// <summary>
	/// Represents the standard input, output, and error streams.
	/// </summary>
	/// <remarks>
	/// This is intended as a replacement for <see cref="System.Console"/>. It bypasses much of the .NET runtime functionality, instead binding to the native console API's directly. It also operates in a uniquely different way, going for the direct API's than operating as a stream.
	/// </remarks>
	[SuppressMessage("Blocker Code Smell", "S3427:Method overloads with default parameter values should not overlap ", Justification = "Sonar has absolutely no idea what's going on here.")]
	public static partial class Console {
		/// <summary>
		/// The current background color.
		/// </summary>
		[AllowNull, MaybeNull]
		private static Color background = null;

		/// <summary>
		/// The current foreground color.
		/// </summary>
		[AllowNull, MaybeNull]
		private static Color foreground = null;

		/// <summary>
		/// The color of the console background.
		/// </summary>
		[AllowNull, MaybeNull]
		public static Color Background {
			get => background;
			set {
				ConsoleComponents.StateManager.SetBackground(value);
				background = value;
			}
		}

		/// <summary>
		/// Gets the alternate screen buffer, and actives it.
		/// </summary>
		public static ScreenBuffer Buffer {
			get {
				ConsoleComponents.StateManager.UseAlternateScreenBuffer();
				return new ScreenBuffer();
			}
		}

		/// <summary>
		/// The color of the console foreground; the text color.
		/// </summary>
		[AllowNull, MaybeNull]
		public static Color Foreground {
			get => foreground;
			set {
				ConsoleComponents.StateManager.SetForeground(value);
				foreground = value;
			}
		}

		/// <summary>
		/// Sets the console window title.
		/// </summary>
		[SuppressMessage("Major Code Smell", "S2376:Write-only properties should not be used", Justification = "There's no corresponding get-title sequence we can use.")]
		[DisallowNull, NotNull]
		public static String Title {
			set => ConsoleComponents.StateManager.SetTitle(value);
		}
	}
}
