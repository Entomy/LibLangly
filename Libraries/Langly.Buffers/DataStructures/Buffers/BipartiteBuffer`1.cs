//# Copyright (c) 2003 Simon Cooke, All Rights Reserved
// Licensed royalty-free for commercial and non-commercial use, without warranty or guarantee of suitability for any purpose. All that I ask is that you send me an email telling me that you're using my code. It'll make me feel warm and fuzzy inside. spectecjr@gmail.com

//Note: This is a reimplementation of the bipartite buffer designed by Simon Cook, adapted for use with LibLangly. Credit therefore goes to Simon Cooke.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Langly.Traits;

namespace Langly.DataStructures.Buffers {
	/// <summary>
	/// Represents a bipartite buffer.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the buffer.</typeparam>
	/// <remarks>
	/// This is a type of large buffer exhibiting ring-like behavior. It doesn't operate in the same way as a ring, keeping memory contiguous, which is a major advantage. It operates through partitioning the memory into two regions, advancing them like a ring-buffer would, but preventing breaking either partition. As a result, this buffer can return direct <see cref="ReadOnlyMemory{T}"/>, rather than allocate-fill-return.
	/// </remarks>
	public sealed partial class BipartiteBuffer<TElement> : DataStructure<TElement, BipartiteBuffer<TElement>, BipartiteBuffer<TElement>.Enumerator>,
		IAdd<TElement, BipartiteBuffer<TElement>>,
		ICapacity,
		IClear<BipartiteBuffer<TElement>>,
		IIndex<TElement>,
		IPeek<TElement, BipartiteBuffer<TElement>>,
		IWrite<TElement, BipartiteBuffer<TElement>> {
		/// <summary>
		/// The backing memory of the buffer.
		/// </summary>
		private readonly Memory<TElement> Memory;

		/// <summary>
		/// Primary partition.
		/// </summary>
		private Partition Primary;

		/// <summary>
		/// Secondary partition.
		/// </summary>
		private Partition Secondary;

		/// <summary>
		/// Initializes a new <see cref="BipartiteBuffer{TElement}"/> buffer.
		/// </summary>
		/// <remarks>
		/// This uses an entire memory page as the buffer. This is by far the best for performance, and the most common use case for a bipartite buffer. It may, however, be way more memory than your application requires.
		/// </remarks>
		public BipartiteBuffer() : this(Environment.SystemPageSize / Unsafe.SizeOf<TElement>(), DataStructures.Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="BipartiteBuffer{TElement}"/> buffer with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity of the buffer.</param>
		/// <param name="filter">Flags designating which filters to set up.</param>
		public BipartiteBuffer(nint capacity, Filter filter) : base(filter) {
			Memory = new TElement[capacity];
			Primary = new Partition(Memory, Filter).Allocate(0, (Int32)Capacity);
			Secondary = new Partition(Memory, Filter);
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[[DisallowNull] nint index] {
			get {
				if (Secondary.Readable && index > Primary.Capacity) {
					return Secondary[Primary.Capacity - index];
				} else if (Primary.Readable) {
					return Primary[index];
				} else {
					return Filter.IndexOutOfBounds(this, index);
				}
			}
			set => throw new NotImplementedException();
		}

		/// <inheritdoc/>
		public override nint Count => Primary.Count + Secondary.Count;

		/// <inheritdoc/>
		public Boolean Readable => Primary.Readable || Secondary.Readable;

		/// <inheritdoc/>
		public Boolean Writable => Primary.Writable || Secondary.Writable;

		/// <inheritdoc/>
		public nint Capacity => Memory.Length;

		/// <inheritdoc/>
		[return: MaybeNull]
		BipartiteBuffer<TElement> IAdd<TElement, BipartiteBuffer<TElement>>.Add([AllowNull] TElement element) => ((IWrite<TElement, BipartiteBuffer<TElement>>)this).Write(element);

		/// <inheritdoc/>
		[return: NotNull]
		BipartiteBuffer<TElement> IClear<BipartiteBuffer<TElement>>.Clear() {
			Primary = Primary.Clear();
			Secondary = Secondary.Clear();
			return this;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		BipartiteBuffer<TElement> IPeek<TElement, BipartiteBuffer<TElement>>.Peek([MaybeNull] out TElement element) {
			if (Secondary.Readable) {
				_ = Secondary.Peek(out element);
				return this;
			} else if (Primary.Readable) {
				_ = Primary.Peek(out element);
				return this;
			} else {
				element = default;
				return null;
			}
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		BipartiteBuffer<TElement> IRead<TElement, BipartiteBuffer<TElement>>.Read([MaybeNull] out TElement element) {
			if (Secondary.Readable) {
				_ = Secondary.Read(out element);
				return this;
			} else if (Primary.Readable) {
				_ = Primary.Read(out element);
				return this;
			} else {
				element = default;
				return null;
			}
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		BipartiteBuffer<TElement> IWrite<TElement, BipartiteBuffer<TElement>>.Write([AllowNull] TElement element) {
			if (Secondary.Writable) {
				_ = Secondary.Write(element);
				return this;
			} else if (Primary.Writable) {
				_ = Primary.Write(element);
				return this;
			} else {
				return null;
			}
		}
	}
}
