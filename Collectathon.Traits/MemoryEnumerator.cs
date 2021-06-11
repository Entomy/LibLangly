﻿using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;

namespace Collectathon {
	/// <summary>
	/// Provides enumeration over contiguous regions of memory.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements being enumerated.</typeparam>
	[StructLayout(LayoutKind.Auto)]
	public struct MemoryEnumerator<TElement> : IEnumerator<TElement> {
		/// <summary>
		/// The <see cref="ReadOnlyMemory{T}"/> being enumerated.
		/// </summary>
		private readonly ReadOnlyMemory<TElement> Memory;

		/// <summary>
		/// The current index into the <see cref="Memory"/>.
		/// </summary>
		private Int32 i;

		/// <summary>
		/// Initializes a new <see cref="MemoryEnumerator{TElement}"/>.
		/// </summary>
		/// <param name="memory">The memory to enumerate over.</param>
		/// <param name="length">The length of the active <paramref name="memory"/>.</param>
		/// <remarks>
		/// At first it might seem like <paramref name="length"/> is superfluous, as <see cref="ReadOnlyMemory{T}"/> has a known length. However, many data structures use an array as an allocated chunk of memory, with the actual array as a portion of this, up to the entire chunk. <paramref name="length"/> is the actually used portion.
		/// </remarks>
		public MemoryEnumerator(ReadOnlyMemory<TElement> memory, nint length) {
			Memory = memory;
			Count = length;
			i = -1;
		}

		/// <inheritdoc/>
		[MaybeNull]
		public TElement Current => Memory.Span[i];

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MaybeNull]
		Object System.Collections.IEnumerator.Current => Current;

		/// <inheritdoc/>
		public nint Count { get; }

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose() { /* No-op */ }

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		public IEnumerator<TElement> GetEnumerator() => this;

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this;

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => this;

		/// <inheritdoc/>
		public Boolean MoveNext() => ++i < Count;

		/// <inheritdoc/>
		public void Reset() => i = -1;

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		public override String ToString() => Collection.ToString(Memory);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		public String ToString(nint amount) => Collection.ToString(Memory, amount);

	}
}