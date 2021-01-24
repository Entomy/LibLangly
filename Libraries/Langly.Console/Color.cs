using System;

namespace Langly {
	/// <summary>
	/// Specifies the color for the console.
	/// </summary>
	public abstract class Color : IEquatable<Color> {
		/// <summary>
		/// Terminal defined black.
		/// </summary>
		public static Color Black { get; } = new SimpleColor(0);

		/// <summary>
		/// Terminal defined blue.
		/// </summary>
		public static Color Blue { get; } = new SimpleColor(4);

		/// <summary>
		/// Terminal defined cyan.
		/// </summary>
		public static Color Cyan { get; } = new SimpleColor(6);

		/// <summary>
		/// Terminal defined green.
		/// </summary>
		public static Color Green { get; } = new SimpleColor(2);

		/// <summary>
		/// Terminal defined magenta.
		/// </summary>
		public static Color Magenta { get; } = new SimpleColor(5);

		/// <summary>
		/// Terminal defined red.
		/// </summary>
		public static Color Red { get; } = new SimpleColor(1);

		/// <summary>
		/// Terminal defined white.
		/// </summary>
		public static Color White { get; } = new SimpleColor(7);

		/// <summary>
		/// Terminal defined yellow.
		/// </summary>
		public static Color Yellow { get; } = new SimpleColor(3);

		public static Boolean operator !=(Color left, Color right) => !left.Equals(right);

		public static Boolean operator ==(Color left, Color right) => left.Equals(right);

		/// <summary>
		/// Creates a <see cref="Color"/> from the given components.
		/// </summary>
		/// <param name="red">Red value.</param>
		/// <param name="green">Green value.</param>
		/// <param name="blue">Blue value.</param>
		/// <returns>A <see cref="Color"/> for use with the <see cref="Console"/>.</returns>
		public static Color RGB(Byte red, Byte green, Byte blue) => new ComplexColor(red, green, blue);

		/// <inheritdoc/>
		public override Boolean Equals(System.Object obj) {
			switch (obj) {
			case Color color:
				return Equals(color);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public abstract Boolean Equals(Color other);
	}
}
