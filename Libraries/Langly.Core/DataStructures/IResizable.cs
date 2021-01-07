using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Indicates the type is resizable.
	/// </summary>
	/// <remarks>
	/// This implementation technically leaks an implementation detail, in that the underlying data structure is of a fixed size, and uses array swapping to appear as a dynamic data structure.
	/// </remarks>
	public interface IResizable : ICapacity {
		/// <summary>
		/// Phi, the golden ratio.
		/// </summary>
		[SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "Phi is a well known math constant.")]
		private const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;

		/// <summary>
		/// The current capacity of the collection before needing to be resized.
		/// </summary>
		new nint Capacity { get; set; }

		/// <inheritdoc/>
		nint ICapacity.Capacity => Capacity;

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		void Grow() {
			if (Capacity <= 8) {
				Resize(13);
			} else {
				Resize((nint)(Capacity * φ));
			}
		}

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The new capacity of the collection.</param>
		void Resize(nint capacity);
		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		void Shrink() => Resize((nint)(Capacity / φ));
	}

	public static partial class DataStructureExtensions {
		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void Grow([AllowNull] this IResizable collection) => collection?.Grow();

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		public static void Resize([AllowNull] this IResizable collection, nint capacity) => collection?.Resize(capacity);

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void Shrink([AllowNull] this IResizable collection) => collection?.Shrink();
	}
}
