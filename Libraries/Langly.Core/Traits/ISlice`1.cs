using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the collection is sliceable.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface ISlice<out TResult> : ICount {
		/// <summary>
		/// Gets a slice out of the collection within the specified range.
		/// </summary>
		/// <param name="range">The zero-based range of the elements.</param>
		/// <returns>A slice that consists of all the elements of the current collection within the <paramref name="range"/>.</returns>
		[MaybeNull, AllowNull]
		TResult this[Range range] {
			get {
				(Int32 start, Int32 length) = range.GetOffsetAndLength((Int32)Count);
				return Slice(start, length);
			}
		}

		/// <summary>
		/// Forms a slice out of the collection.
		/// </summary>
		/// <returns>A slice that consists of all elements of the current collection.</returns>
		[return: MaybeNull]
		TResult Slice() => Slice(0, Count);

		/// <summary>
		/// Forms a slice out of the collection that begins at a specified index.
		/// </summary>
		/// <param name="start">The index at which to begin the slice</param>
		/// <returns>A slice that consists of all elements of the current collection from <paramref name="start"/> to the end of the collection.</returns>
		[return: MaybeNull]
		TResult Slice(nint start) => Slice(start, Count - start);

		/// <summary>
		/// Forms a slice out of the current span starting at a specified index for a specified length.
		/// </summary>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <returns>A slice that consists of <paramref name="length"/> elements from the current collection starting at <paramref name="start"/>.</returns>
		[return: MaybeNull]
		TResult Slice(nint start, nint length);
	}
}

namespace Langly {
	public static partial class TraitExtensions {
		#region Slice()
		/// <summary>
		/// Forms a slice out of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <returns>A slice that consists of all elements of the current collection.</returns>
		[return: MaybeNull]
		public static TResult Slice<TResult>([AllowNull] this ISlice<TResult> collection) => collection is not null ? collection.Slice() : default;

		/// <summary>
		/// Forms a slice out of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>A slice that consists of all elements of the current collection.</returns>
		public static ReadOnlyMemory<Char> Slice([AllowNull] this String collection) => collection is not null ? collection.AsMemory() : default;

		/// <summary>
		/// Forms a slice out of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>A slice that consists of all elements of the current collection.</returns>
		public static Memory<TElement> Slice<TElement>([AllowNull] this TElement[] collection) => collection is not null ? collection.AsMemory() : default;

		/// <summary>
		/// Forms a slice out of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>A slice that consists of all elements of the current collection.</returns>
		public static Memory<TElement> Slice<TElement>(this Memory<TElement> collection) => collection;

		/// <summary>
		/// Forms a slice out of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>A slice that consists of all elements of the current collection.</returns>
		public static ReadOnlyMemory<TElement> Slice<TElement>(this ReadOnlyMemory<TElement> collection) => collection;
		#endregion

		#region Slice(nint)
		/// <summary>
		/// Forms a slice out of the collection that begins at a specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <returns>A slice that consists of all elements of the current collection from <paramref name="start"/> to the end of the collection.</returns>
		[return: MaybeNull]
		public static TResult Slice<TResult>([AllowNull] this ISlice<TResult> collection, nint start) => collection is not null ? collection.Slice(start) : default;

		/// <summary>
		/// Forms a slice out of the collection that begins at a specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <returns>A slice that consists of all elements of the current collection from <paramref name="start"/> to the end of the collection.</returns>
		public static ReadOnlyMemory<Char> Slice([AllowNull] this String collection, nint start) => collection is not null ? collection.AsMemory().Slice((Int32)start) : default;

		/// <summary>
		/// Forms a slice out of the collection that begins at a specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <returns>A slice that consists of all elements of the current collection from <paramref name="start"/> to the end of the collection.</returns>
		public static Memory<TElement> Slice<TElement>([AllowNull] this TElement[] collection, nint start) => collection is not null ? collection.AsMemory().Slice((Int32)start) : default;

		/// <summary>
		/// Forms a slice out of the collection that begins at a specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <returns>A slice that consists of all elements of the current collection from <paramref name="start"/> to the end of the collection.</returns>
		public static Memory<TElement> Slice<TElement>(this Memory<TElement> collection, nint start) => collection.Slice((Int32)start);

		/// <summary>
		/// Forms a slice out of the collection that begins at a specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <returns>A slice that consists of all elements of the current collection from <paramref name="start"/> to the end of the collection.</returns>
		public static ReadOnlyMemory<TElement> Slice<TElement>(this ReadOnlyMemory<TElement> collection, nint start) => collection.Slice((Int32)start);
		#endregion

		#region Slice(nint, nint)
		/// <summary>
		/// Forms a slice out of the current span starting at a specified index for a specified length.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <returns>A slice that consists of <paramref name="length"/> elements from the current collection starting at <paramref name="start"/>.</returns>
		[return: MaybeNull]
		public static TResult Slice<TResult>([AllowNull] this ISlice<TResult> collection, nint start, nint length) => collection is not null ? collection.Slice(start, length) : default;

		/// <summary>
		/// Forms a slice out of the current span starting at a specified index for a specified length.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <returns>A slice that consists of <paramref name="length"/> elements from the current collection starting at <paramref name="start"/>.</returns>
		public static ReadOnlyMemory<Char> Slice([AllowNull] this String collection, nint start, nint length) => collection is not null ? collection.AsMemory().Slice((Int32)start, (Int32)length) : default;

		/// <summary>
		/// Forms a slice out of the current span starting at a specified index for a specified length.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <returns>A slice that consists of <paramref name="length"/> elements from the current collection starting at <paramref name="start"/>.</returns>
		public static Memory<TElement> Slice<TElement>([AllowNull] this TElement[] collection, nint start, nint length) => collection is not null ? collection.AsMemory().Slice((Int32)start, (Int32)length) : default;

		/// <summary>
		/// Forms a slice out of the current span starting at a specified index for a specified length.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <returns>A slice that consists of <paramref name="length"/> elements from the current collection starting at <paramref name="start"/>.</returns>
		public static Memory<TElement> Slice<TElement>(this Memory<TElement> collection, nint start, nint length) => collection.Slice((Int32)start, (Int32)length);

		/// <summary>
		/// Forms a slice out of the current span starting at a specified index for a specified length.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <returns>A slice that consists of <paramref name="length"/> elements from the current collection starting at <paramref name="start"/>.</returns>
		public static ReadOnlyMemory<TElement> Slice<TElement>(this ReadOnlyMemory<TElement> collection, nint start, nint length) => collection.Slice((Int32)start, (Int32)length);
		#endregion
	}
}
