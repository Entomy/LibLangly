using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Concepts {
	/// <summary>
	/// Provides various operations to help with developing collections.
	/// </summary>
	/// <remarks>
	/// 	<para>These are primarily intended for the creation of new collections, with any of the contained operations being "reasonable defaults" for the implementation of the equivalent public API.</para>
	/// </remarks>
	public static partial class Collection {
		/// <summary>
		/// Phi, the golden ratio.
		/// </summary>
		[SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "Phi is a well known math constant.")]
		private const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;
	}
}
