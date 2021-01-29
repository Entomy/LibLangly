using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type is resizable.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <remarks>
	/// This implementation technically leaks an implementation detail, in that the underlying data structure is of a fixed size, and uses array swapping to appear as a dynamic data structure.
	/// </remarks>
	public interface IResizable<out TSelf> : ICapacity where TSelf : IResizable<TSelf> {
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
		[return: NotNull]
		TSelf Grow() {
			if (Capacity <= 8) {
				Resize(13);
			} else {
				Resize((nint)(Capacity * φ));
			}
			return (TSelf)this;
		}

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: NotNull]
		TSelf Resize(nint capacity);

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		[return: NotNull]
		TSelf Shrink() {
			Resize((nint)(Capacity / φ));
			return (TSelf)this;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TSelf Grow<TSelf>([AllowNull] this IResizable<TSelf> collection) where TSelf : IResizable<TSelf> => collection is not null ? collection.Grow() : default;

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TSelf Resize<TSelf>([AllowNull] this IResizable<TSelf> collection, nint capacity) where TSelf : IResizable<TSelf> => collection is not null ? collection.Resize(capacity) : default;

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TSelf Shrink<TSelf>([AllowNull] this IResizable<TSelf> collection) where TSelf : IResizable<TSelf> => collection is not null ? collection.Shrink() : default;
	}
}
