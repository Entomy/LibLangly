using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Streams {
	/// <summary>
	/// The access mode of a <see cref="Stream"/>.
	/// </summary>
	[Flags]
	[SuppressMessage("Naming", "CA1714:Flags enums should have plural names", Justification = "'Access' is both a countable and uncountable noun depending on context. In the context of the callsites, it's always uncountable. Only in the context of talking about these access modes is 'accesses' used, so it makes far more sense to stick to the uncountable form exclusively.")]
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
		Write = 1 << 1,

		/// <summary>
		/// Seek access.
		/// </summary>
		Seek = 1 << 2,

		/// <summary>
		/// Full access.
		/// </summary>
		/// <remarks>
		/// This should, ideally, be used when full access is intended, as the exact definition could possible change, but will always keep the same intention.
		/// </remarks>
		Full = Read | Write | Seek,

		/// <summary>
		/// The stream already exists.
		/// </summary>
		Existing = 1 << 3,

		/// <summary>
		/// The stream should be created.
		/// </summary>
		Create = 1 << 4,

		/// <summary>
		/// The stream should be opened if it already exists, or created if it doesn't.
		/// </summary>
		Open = Existing | Create,
	}
}
