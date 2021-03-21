using System;

namespace Langly.Linguistics {
	/// <summary>
	/// The directions a <see cref="Script"/> is written.
	/// </summary>
	[Flags]
	public enum Directions {
		/// <summary>
		/// No direction.
		/// </summary>
		[Obsolete("This should never actually be used, and is only present for completeness.")]
		None = 0,

		/// <summary>
		/// Left-to-Right
		/// </summary>
		LeftToRight = 1,

		/// <summary>
		/// Right-to-Left
		/// </summary>
		RightToLeft = 1 << 1,

		/// <summary>
		/// Top-to-Bottom
		/// </summary>
		TopToBottom = 1 << 2,

		/// <summary>
		/// Any direction is acceptable.
		/// </summary>
		Any = LeftToRight | RightToLeft | TopToBottom,
	}
}
