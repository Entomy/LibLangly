using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits;
using Collectathon.Stacks;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents a node of a <see cref="Stack{TElement}"/>.
	/// </summary>
	public sealed class StackNode<TElement> : ICapacity, IContains<TElement>, IIndex<nint, TElement>, INext<StackNode<TElement>>, IUnlink {
		/// <summary>
		/// The elements contained in the node.
		/// </summary>
		private readonly TElement?[] Elements;

		/// <summary>
		/// Initializes a new <see cref="StackNode{TElement}"/>.
		/// </summary>
		/// <param name="next">The next node of the stack.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public StackNode([AllowNull] StackNode<TElement> next) {
			Elements = new TElement[Stack<TElement>.ChunkSize];
			Next = next;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[nint index] {
			get => Elements[index];
			set => Elements[index] = value;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public StackNode<TElement> Next { get; private set; }

		/// <inheritdoc/>
		public nint Count { get; private set; }

		/// <inheritdoc/>
		public nint Capacity => Elements.Length;

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Boolean Contains([AllowNull] TElement element) => Collection.Contains(Elements, element);

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public override String ToString() => Collection.ToString(Elements);

		/// <summary>
		/// Peeks at the top element of this <see cref="Stack{TElement}"/>.
		/// </summary>
		/// <returns>The top element.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull]
		public TElement Peek() => Elements[Count - 1];

		/// <summary>
		/// Pops the top element off this <see cref="Stack{TElement}"/>.
		/// </summary>
		/// <returns>The top element.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull]
		public TElement Pop() => Elements[--Count];

		/// <summary>
		/// Pushes the <paramref name="element"/> onto this <see cref="Stack{TElement}"/>.
		/// </summary>
		/// <param name="element">The element to push.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Push([AllowNull] TElement element) => Elements[Count++] = element;

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Unlink() => Next = null;
	}
}
