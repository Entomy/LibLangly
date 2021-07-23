using System;

namespace Langly.Patterns {
	/// <summary>
	/// Represents a text literal.
	/// </summary>
	public sealed partial class Text : Token, ILiteral {
		/// <summary>
		/// Initializes a new <see cref="Text"/>.
		/// </summary>
		/// <param name="location">The location int he source this text literal was found.</param>
		/// <param name="length"></param>
		public Text(Int32 location, Int32 length) : base(location, length) { }

		/// <inheritdoc/>
		public override Boolean IsStatic => true;
	}
}
