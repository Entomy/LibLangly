using System;
using System.Runtime.InteropServices;

namespace Consolator {
	/// <summary>
	/// Specifies the possible colors for the console.
	/// </summary>
	/// <remarks>
	/// At absolute minimum, this supports the traditional 16 colors of the console. However, it is an enum-struct and not a standard enum to allow for more complex color schemes to be possible.
	/// </remarks>
	[StructLayout(LayoutKind.Auto)]
	public readonly struct Color {
		public static Color Black { get; } = new Color(0);

		public static Color Blue { get; } = new Color(9);

		public static Color Cyan { get; } = new Color(11);

		public static Color DarkBlue { get; } = new Color(1);

		public static Color DarkCyan { get; } = new Color(3);

		public static Color DarkGray { get; } = new Color(8);

		public static Color DarkGreen { get; } = new Color(2);

		public static Color DarkMagenta { get; } = new Color(5);

		public static Color DarkRed { get; } = new Color(4);

		public static Color DarkYellow { get; } = new Color(6);

		public static Color Gray { get; } = new Color(7);

		public static Color Green { get; } = new Color(10);

		public static Color Magenta { get; } = new Color(13);

		public static Color Red { get; } = new Color(12);

		public static Color White { get; } = new Color(15);

		public static Color Yellow { get; } = new Color(14);

		/// <summary>
		/// The console color code.
		/// </summary>
		private readonly Int32 Code;

		/// <summary>
		/// Initializes a new <see cref="Color"/> value.
		/// </summary>
		/// <param name="code">The console color code.</param>
		private Color(Int32 code) => Code = code;
	}
}
