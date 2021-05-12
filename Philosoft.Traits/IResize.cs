#if !NETSTANDARD1_3
using System.Diagnostics.CodeAnalysis;
#endif

namespace System.Traits {
	/// <summary>
	/// Indicates the type is resizable.
	/// </summary>
	/// <remarks>
	/// This implementation technically leaks an implementation detail, in that the underlying data structure is of a fixed size, and uses array swapping to appear as a dynamic data structure.
	/// </remarks>
	public interface IResize : ICapacity {
#if !NETSTANDARD1_3
		/// <summary>
		/// Phi, the golden ratio.
		/// </summary>
		[SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "Phi is a well known math constant.")]
		protected const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;
#endif

		/// <summary>
		/// The current capacity of the collection before needing to be resized.
		/// </summary>
		new nint Capacity { get; set; }

#if !NETSTANDARD1_3
		/// <inheritdoc/>
		nint ICapacity.Capacity => Capacity;
#endif

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The new capacity of the collection.</param>
		void Resize(nint capacity);
	}
}
