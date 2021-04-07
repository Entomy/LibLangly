using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type is resizable.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	/// <remarks>
	/// This implementation technically leaks an implementation detail, in that the underlying data structure is of a fixed size, and uses array swapping to appear as a dynamic data structure.
	/// </remarks>
	public interface IResize<out TResult> : ICapacity where TResult : IResize<TResult> {
		/// <summary>
		/// Phi, the golden ratio.
		/// </summary>
		[SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "Phi is a well known math constant.")]
		protected const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;

		/// <summary>
		/// The current capacity of the collection before needing to be resized.
		/// </summary>
		new nint Capacity { get; set; }

		/// <inheritdoc/>
		nint ICapacity.Capacity => Capacity;

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		[return: MaybeNull]
		TResult Grow() => Capacity <= 8 ? Resize(13) : Resize((nint)(Capacity * φ));

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: MaybeNull]
		TResult Resize(nint capacity);

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		[return: MaybeNull]
		TResult Shrink() => Resize((nint)(Capacity / φ));
	}
}

namespace Langly {
	public static partial class TraitExtensions {
		/// <summary>
		/// Phi, the golden ratio.
		/// </summary>
		[SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "Phi is a well known math constant.")]
		private const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;

		#region Grow()
		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TSelf Grow<TSelf>([AllowNull] this IResize<TSelf> collection) where TSelf : IResize<TSelf> => collection is not null ? collection.Grow() : default;

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] Grow<TElement>([AllowNull] this TElement[] collection) => collection is null || collection.Length <= 8 ? collection.Resize(13) : collection.Resize((nint)(collection.Length * φ));

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static Memory<TElement> Grow<TElement>(this Memory<TElement> collection) => collection.Length <= 8 ? collection.Resize(13) : collection.Resize((nint)(collection.Length * φ));

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static ReadOnlyMemory<TElement> Grow<TElement>(this ReadOnlyMemory<TElement> collection) => collection.Length <= 8 ? collection.Resize(13) : collection.Resize((nint)(collection.Length * φ));
		#endregion

		#region Resize()
		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: MaybeNull]
		public static TSelf Resize<TSelf>([AllowNull] this IResize<TSelf> collection, nint capacity) where TSelf : IResize<TSelf> => collection is not null ? collection.Resize(capacity) : default;

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] Resize<TElement>([AllowNull] this TElement[] collection, nint capacity) {
			if (collection is null) {
				return null;
			} else if (collection.Length == 0) {
				return new TElement[capacity];
			}
			TElement[] Array = new TElement[capacity];
			System.Array.Copy(collection, Array, collection.Length);
			return Array;
		}

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static Memory<TElement> Resize<TElement>(this Memory<TElement> collection, nint capacity) {
			if (collection.Length == 0) {
				return new TElement[capacity];
			}
			TElement[] Array = new TElement[capacity];
			collection.CopyTo(Array);
			return Array;
		}

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static ReadOnlyMemory<TElement> Resize<TElement>(this ReadOnlyMemory<TElement> collection, nint capacity) {
			if (collection.Length == 0) {
				return new TElement[capacity];
			}
			TElement[] Array = new TElement[capacity];
			collection.CopyTo(Array);
			return Array;
		}
		#endregion

		#region Shrink
		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TSelf Shrink<TSelf>([AllowNull] this IResize<TSelf> collection) where TSelf : IResize<TSelf> => collection is not null ? collection.Shrink() : default;

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] Shrink<TElement>([AllowNull] this TElement[] collection) => collection is not null ? collection.Resize((nint)(collection.Length / φ)) : null;

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static Memory<TElement> Shrink<TElement>(this Memory<TElement> collection) => collection.Resize((nint)(collection.Length / φ));

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static ReadOnlyMemory<TElement> Shrink<TElement>(this ReadOnlyMemory<TElement> collection) => collection.Resize((nint)(collection.Length / φ));
		#endregion
	}
}
