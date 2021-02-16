using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Langly.DataStructures.Buffers {
	/// <summary>
	/// Represents a passthrough read buffer that additionally supports peeking.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the buffer.</typeparam>
	/// <typeparam name="TPeek">The type of the peekable read source.</typeparam>
	/// <remarks>
	/// This is conceptually a sentinel, allowing identical use in cases where a buffer is not actually used.
	/// </remarks>
	public class PassthroughPeek<TElement, TPeek> : PassthroughRead<TElement, TPeek>, IPeek<TElement, PassthroughPeek<TElement, TPeek>> where TPeek : IPeek<TElement, TPeek> {
		/// <summary>
		/// Initializes a new <see cref="PassthroughPeek{TElement, TPeek}"/>.
		/// </summary>
		/// <param name="source">The peekable read source.</param>
		public PassthroughPeek([DisallowNull] TPeek source) : base(source) { }

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull]
		public PassthroughPeek<TElement, TPeek> Peek([MaybeNull] out TElement element) => Source.Peek(out element) is not null ? this : null;

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull]
		public PassthroughPeek<TElement, TPeek> Read([MaybeNull] out TElement element) => Source.Read(out element) is not null ? this : null;
	}
}
