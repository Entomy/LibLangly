using System;

namespace Philosoft {
	/// <summary>
	/// Indicates the type is resizable.
	/// </summary>
	/// <remarks>
	/// This interface leaks an implementation detail, specifically that the underlying data structure is of a fixed size, and uses array replacement/resizing to appear as a dynamic data structure.
	/// </remarks>
	public interface IResizable {
		/// <summary>
		/// Phi, the golden ratio.
		/// </summary>
		private const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;

		/// <summary>
		/// The current capacity of the collection before needing to be resized.
		/// </summary>
		nint Capacity { get; }

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The new capacity of the collection.</param>
		void Resize(nint capacity);

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
		/// Shrinks the collection by a computed factor.
		/// </summary>
		void Shrink() => Resize((nint)(Capacity / φ));
	}

	public static partial class Extensions {
		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void Grow(this IResizable collection) {
			if (collection is null) {
				return;
			}
			collection.Grow();
		}

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		public static void Resize(this IResizable collection, nint capacity) {
			if (collection is null) {
				return;
			}
			collection.Resize(capacity);
		}

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void Shrink(this IResizable collection) {
			if (collection is null) {
				return;
			}
			collection.Shrink();
		}
	}
}
