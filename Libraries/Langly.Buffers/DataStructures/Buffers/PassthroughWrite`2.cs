using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Langly.DataStructures.Buffers {
	/// <summary>
	/// Represents a passthrough write buffer.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the buffer.</typeparam>
	/// <typeparam name="TWrite">The type of the write source.</typeparam>
	/// <remarks>
	/// This is conceptually a sentinel, allowing identical use in cases where a buffer is not actually used.
	/// </remarks>
	public class PassthroughWrite<TElement, TWrite> : Object, IWrite<TElement, PassthroughWrite<TElement, TWrite>> where TWrite : IWrite<TElement, TWrite> {
		/// <summary>
		/// The write sink.
		/// </summary>
		[DisallowNull, NotNull]
		protected readonly TWrite Sink;

		/// <summary>
		/// Initializes a new <see cref="PassthroughWrite{TElement, TWrite}"/>.
		/// </summary>
		/// <param name="sink">The write sink.</param>
		public PassthroughWrite([DisallowNull] TWrite sink) => Sink = sink;

		/// <inheritdoc/>
		public Boolean Writable => Sink.Writable;

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull]
		public PassthroughWrite<TElement, TWrite> Write([AllowNull] TElement element) => Sink.Write(element) is not null ? this : null;
	}
}
