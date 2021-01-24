using System;

namespace Langly {
	internal sealed class SimpleColor : Color, IEquatable<SimpleColor> {
		/// <summary>
		/// The console color code.
		/// </summary>
		internal readonly Byte Code;

		/// <summary>
		/// Initializes a new <see cref="SimpleColor"/>.
		/// </summary>
		/// <param name="code">The console color code.</param>
		internal SimpleColor(Byte code) => Code = code;

		/// <inheritdoc/>
		public override Boolean Equals(Color other) {
			switch (other) {
			case SimpleColor color:
				return Equals(color);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(SimpleColor other) => other?.Code.Equals(Code) ?? false;
	}
}
