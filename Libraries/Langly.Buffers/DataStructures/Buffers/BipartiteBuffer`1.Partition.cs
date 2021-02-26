using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures.Buffers {
	public partial class BipartiteBuffer<TElement> {
		/// <summary>
		/// Represents a partition of the buffer.
		/// </summary>
		[StructLayout(LayoutKind.Auto)]
		private struct Partition : ICapacity, IClear<Partition>, ICount, IIndex<TElement>, IPeek<TElement, Partition>, IResize<Partition>, IWrite<TElement, Partition> {
			/// <summary>
			/// The <see cref="Filter{TIndex, TElement}"/> being used.
			/// </summary>
			/// <remarks>
			/// This is never <see langword="null"/>; a sentinel is used by default.
			/// </remarks>
			private readonly Filter<nint, TElement> Filter;

			/// <summary>
			/// The backing memory of the buffer.
			/// </summary>
			private readonly Memory<TElement> Memory;

			/// <summary>
			/// Initializes a new <see cref="Partition"/>.
			/// </summary>
			/// <param name="memory">The buffer memory.</param>
			/// <param name="filter">The buffer filter.</param>
			public Partition(Memory<TElement> memory, Filter<nint, TElement> filter) {
				Memory = memory;
				Filter = filter;
				Start = 0;
				Capacity = 0;
				Count = 0;
			}

			/// <inheritdoc/>
			public nint Capacity { get; set; }

			/// <inheritdoc/>
			public nint Count { get; private set; }

			/// <inheritdoc/>
			public Boolean Readable => Capacity > 0;

			/// <inheritdoc/>
			public Boolean Writable => Capacity > Count;

			/// <summary>
			/// The starting position of this <see cref="Partition"/>.
			/// </summary>
			private nint Start { get; set; }

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public TElement this[[DisallowNull] nint index] {
				get {
					if (0 > Start + index || Start + index >= Count) {
						return Filter.IndexOutOfBounds(this, Start + index);
					}
					return Memory.Span[(Int32)(Start + index)];
				}
				set {
					if (0 > Start + index || Start + index >= Count) {
						Filter.IndexOutOfBounds(this, Start + index, value);
					}
					Memory.Span[(Int32)(Start + index)] = value;
				}
			}

			/// <inheritdoc/>
			public Partition Add([AllowNull] TElement element) {
				Memory.Span[(Int32)Count++] = element;
				return this;
			}

			/// <summary>
			/// Allocations this partition.
			/// </summary>
			/// <param name="start">The start of the partition.</param>
			/// <param name="capacity">The capacity of the partition.</param>
			public Partition Allocate(Int32 start, Int32 capacity) {
				Start = start;
				Capacity = capacity;
				return this;
			}

			/// <inheritdoc/>
			[return: NotNull]
			public Partition Clear() {
				Start = 0;
				Capacity = 0;
				Count = 0;
				return this;
			}

			/// <inheritdoc/>
			public Partition Peek([MaybeNull] out TElement element) {
				element = Memory.Span[(Int32)Start];
				return this;
			}

			/// <inheritdoc/>
			public Partition Read([MaybeNull] out TElement element) {
				element = Memory.Span[(Int32)Start++];
				Count--;
				return this;
			}

			/// <inheritdoc/>
			public Partition Resize(nint capacity) {
				Capacity = capacity;
				return this;
			}

			/// <inheritdoc/>
			public Partition Write([AllowNull] TElement element) => Add(element);
		}
	}
}
