using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures;
using Langly.Traits;

namespace Langly {
	/// <summary>
	/// Represents text as a sequence of <see cref="Glyph"/>.
	/// </summary>
	/// <remarks>
	/// <para>This is, itself, a variation of a Chain, and is very similar to a Rope datastructure, only with some optimizations for ordered data. The Rope name is reused, but in the pedantic sense, this is not a Rope, as it's not a binary tree. Never-the-less, it serves the same role as a proper Rope.</para>
	/// <para>The actual data structure here is a hybridized skip-list and partially-unrolled-list, just like a Chain. However, there is an additional internal list, which maintains the indicies of <see cref="Glyph"/>s. This list is used to rapidly seek and jump to various positions within the <see cref="Rope"/>.</para>
	/// </remarks>
	public sealed partial class Rope : DataStructure<Glyph, Rope, Rope.Enumerator>,
		IAddText<Rope>,
		IConcatText<Rope> {
		/// <summary>
		/// The head node of the rope.
		/// </summary>
		[MaybeNull, AllowNull]
		private Node Head;

		/// <summary>
		/// The tail node of the rope.
		/// </summary>
		[MaybeNull, AllowNull]
		private Node Tail;

		/// <summary>
		/// Initializes a new <see cref="Rope"/>.
		/// </summary>
		public Rope() : base(DataStructures.Filter.None) { }

		/// <summary>
		/// Gets the number of <see cref="Glyph"/> contained in this <see cref="Rope"/>.
		/// </summary>
		public override nint Count {
			get => base.Count;
			protected set => base.Count = value;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		Rope IAdd<Char, Rope>.Add(Char element) => ((IPostpend<Char, Rope>)this).Postpend(element);

		/// <inheritdoc/>
		[return: MaybeNull]
		Rope IAdd<Char, Rope>.Add([AllowNull] params Char[] elements) => ((IPostpend<Char, Rope>)this).Postpend(elements);

		/// <inheritdoc/>
		[return: MaybeNull]
		Rope IAdd<Char, Rope>.Add(Memory<Char> elements) => ((IPostpend<Char, Rope>)this).Postpend(elements);

		/// <inheritdoc/>
		[return: MaybeNull]
		Rope IAdd<Char, Rope>.Add(ReadOnlyMemory<Char> elements) => ((IPostpend<Char, Rope>)this).Postpend(elements);

		/// <inheritdoc/>
		[return: MaybeNull]
		Rope IAdd<Char, Rope>.Add<TEnumerator>([AllowNull] ISequence<Char, TEnumerator> elements) => ((IPostpend<Char, Rope>)this).Postpend(elements);

		/// <inheritdoc/>
		[return: MaybeNull]
		Rope IPostpend<Char, Rope>.Postpend(Char element) {
			Tail = new CharNode(element, previous: Tail, next: null);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			//TODO: Increment Count
			return this;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		Rope IPrepend<Char, Rope>.Prepend(Char element) {
			Head = new CharNode(element, previous: null, next: Head);
			if (Tail is null) {
				Tail = Head;
			} else {
				Head.Next.Previous = Head;
			}
			//TODO: Increment Count
			return this;
		}
	}
}
