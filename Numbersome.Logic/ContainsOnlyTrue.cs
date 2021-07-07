using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class LogicExtensions {
		/// <summary>
		/// Determines whether this collection contains only <see langword="true"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns><see langword="true"/> if <see langword="true"/> is the only thing contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsOnlyTrue([AllowNull] this Boolean[] collection) => ContainsOnlyTrue(collection.AsSpan());

		/// <summary>
		/// Determines whether this collection contains only <see langword="true"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns><see langword="true"/> if <see langword="true"/> is the only thing contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsOnlyTrue(this ArraySegment<Boolean> collection) => ContainsOnlyTrue(collection.AsSpan());

		/// <summary>
		/// Determines whether this collection contains only <see langword="true"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns><see langword="true"/> if <see langword="true"/> is the only thing contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsOnlyTrue(this Memory<Boolean> collection) => ContainsOnlyTrue(collection.Span);

		/// <summary>
		/// Determines whether this collection contains only <see langword="true"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns><see langword="true"/> if <see langword="true"/> is the only thing contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsOnlyTrue(this ReadOnlyMemory<Boolean> collection) => ContainsOnlyTrue(collection.Span);

		/// <summary>
		/// Determines whether this collection contains only <see langword="true"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns><see langword="true"/> if <see langword="true"/> is the only thing contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsOnlyTrue(this Span<Boolean> collection) => ContainsOnlyTrue((ReadOnlySpan<Boolean>)collection);

		/// <summary>
		/// Determines whether this collection contains only <see langword="true"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns><see langword="true"/> if <see langword="true"/> is the only thing contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsOnlyTrue(this ReadOnlySpan<Boolean> collection) {
			Boolean result = false;
			for (Int32 i = 0; i < collection.Length; i++) {
				result = result || collection[i];
			}
			return result;
		}
	}
}
