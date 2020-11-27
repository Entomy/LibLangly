using System;

namespace Langly {
	internal sealed class ComplexColor : Color, IEquatable<ComplexColor> {
		internal readonly Byte Red;
		internal readonly Byte Green;
		internal readonly Byte Blue;

		/// <summary>
		/// Initializes a new <see cref="ComplexColor"/>.
		/// </summary>
		/// <param name="red">Red value.</param>
		/// <param name="green">Green value.</param>
		/// <param name="blue">Blue value.</param>
		internal ComplexColor(Byte red, Byte green, Byte blue) {
			Red = red;
			Green = green;
			Blue = blue;
		}

		/// <inheritdoc/>
		public override Boolean Equals(Color other) {
			switch (other) {
			case ComplexColor color:
				return Equals(color);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(ComplexColor other) => !(other is null) && Red.Equals(other.Red) && Green.Equals(other.Green) && Blue.Equals(other.Blue);
	}
}
