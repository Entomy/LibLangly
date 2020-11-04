using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Linguistics {
	/// <summary>
	/// The directions a <see cref="Script"/> is written.
	/// </summary>
	[Flags]
	[SuppressMessage("Critical Code Smell", "S2346:Flags enumerations zero-value members should be named \"None\"", Justification = "Except that it's quite literally not 'no direction', it's any direction, and the moment a bit is set the 'any' part forcibly goes away.")]
	public enum Directions {
		/// <summary>
		/// Any direction is acceptable.
		/// </summary>
		Any = 0,

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
	}
}