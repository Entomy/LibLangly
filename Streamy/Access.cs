using System;

namespace Streamy {
	/// <summary>
	/// The access mode of a <see cref="Stream"/>.
	/// </summary>
	[Flags]
	public enum Access {
		/// <summary>
		/// No access.
		/// </summary>
		None = 0,

		/// <summary>
		/// Read access.
		/// </summary>
		Read = 1,

		/// <summary>
		/// Write access.
		/// </summary>
		Write = 2,

		/// <summary>
		/// Seek access.
		/// </summary>
		Seek = 4,

		/// <summary>
		/// Full access.
		/// </summary>
		/// <remarks>
		/// This should, ideally, be used when full access is intended, as the exact definition could possible change, but will always keep the same intention.
		/// </remarks>
		Full = Read | Write | Seek,
	}
}
