#if !NETSTANDARD2_1
using System;
#endif
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the collection is sliceable.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface ISlice<out TResult> : ICount where TResult : ISlice<TResult> {
#if !NETSTANDARD2_1
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
#endif

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

	public static partial class TraitExtensions {
		/// <summary>
		/// Forms a slice out of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <returns>A slice that consists of all elements of the current collection.</returns>
		[return: MaybeNull]
		public static TResult Slice<TResult>([AllowNull] this ISlice<TResult> collection) where TResult : ISlice<TResult> => collection is not null ? collection.Slice() : default;

		/// <summary>
		/// Forms a slice out of the collection that begins at a specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <returns>A slice that consists of all elements of the current collection from <paramref name="start"/> to the end of the collection.</returns>
		[return: MaybeNull]
		public static TResult Slice<TResult>([AllowNull] this ISlice<TResult> collection, nint start) where TResult : ISlice<TResult> => collection is not null ? collection.Slice(start) : default;

		/// <summary>
		/// Forms a slice out of the current span starting at a specified index for a specified length.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <returns>A slice that consists of <paramref name="length"/> elements from the current collection starting at <paramref name="start"/>.</returns>
		[return: MaybeNull]
		public static TResult Slice<TResult>([AllowNull] this ISlice<TResult> collection, nint start, nint length) where TResult : ISlice<TResult> => collection is not null ? collection.Slice(start, length) : default;
	}
}
