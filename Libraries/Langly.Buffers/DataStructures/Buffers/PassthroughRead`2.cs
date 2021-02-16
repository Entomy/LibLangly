using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Langly.DataStructures.Buffers {
	/// <summary>
	/// Represents a passthrough read buffer.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the buffer.</typeparam>
	/// <typeparam name="TRead">The type of the read source.</typeparam>
	/// <remarks>
	/// This is conceptually a sentinel, allowing identical use in cases where a buffer is not actually used.
	/// </remarks>
	public class PassthroughRead<TElement, TRead> : Object, IRead<TElement, PassthroughRead<TElement, TRead>> where TRead : IRead<TElement, TRead> {
		/// <summary>
		/// The read source.
		/// </summary>
		[DisallowNull, NotNull]
		protected readonly TRead Source;

		/// <summary>
		/// Initializes a new <see cref="PassthroughRead{TElement, TRead}"/>.
		/// </summary>
		/// <param name="source">The read source.</param>
		public PassthroughRead([DisallowNull] TRead source) => Source = source;

		/// <inheritdoc/>
		public Boolean Readable => Source.Readable;

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull]
		public PassthroughRead<TElement, TRead> Read([MaybeNull] out TElement element) => Source.Read(out element) is not null ? this : null;
	}
}
