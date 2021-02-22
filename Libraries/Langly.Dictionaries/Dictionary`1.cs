using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures;
using Langly.DataStructures.Filters;

namespace Langly {
	/// <summary>
	/// Represents a dictionary, an efficiently packed collection, indexed by text elements.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the dictionary.</typeparam>
	public sealed partial class Dictionary<TElement> :
		IContains<TElement>,
		IIndexText<TElement>, IIndexUnsafe<Char, TElement>,
		IInsertText<TElement, Dictionary<TElement>>,
		IReplace<TElement, Dictionary<TElement>> {
		/// <summary>
		/// The <see cref="Filter{TIndex, TElement}"/> being used.
		/// </summary>
		/// <remarks>
		/// This is never <see langword="null"/>; a sentinel is used by default.
		/// </remarks>
		[NotNull, DisallowNull]
		private readonly Filter<Char, TElement> Filter;

		/// <summary>
		/// The head node of the trie.
		/// </summary>
		/// <remarks>
		/// This uses a sentinel to simplify coding. Since we're calling everything off of this node, if it's never null, the code is simpler.
		/// </remarks>
		private readonly Node Head;

		/// <summary>
		/// Initializes a new <see cref="Dictionary{TElement}"/>.
		/// </summary>
		public Dictionary() : this(DataStructures.Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="Dictionary{TElement}"/>.
		/// </summary>
		/// <param name="filter">Flags designating which filters to set up.</param>
		public Dictionary(Filter filter) {
			Filter = Filter<Char, TElement>.Create(filter);
			Head = new Node(index: '\0', filter: Filter, parent: Head);
		}

		/// <inheritdoc/>
		public nint Count { get; private set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[Char index] {
			get => Head[index].Element;
			set => Head[index].Element = value;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[[DisallowNull] String index] {
			get => Head[index].Element;
			set => Head[index].Element = value;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[[DisallowNull] Char[] index] {
			get => Head[index].Element;
			set => Head[index].Element = value;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[Memory<Char> index] {
			get => Head[index].Element;
			set => Head[index].Element = value;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[ReadOnlyMemory<Char> index] {
			get => Head[index].Element;
			set => Head[index].Element = value;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[Span<Char> index] {
			get => Head[index].Element;
			set => Head[index].Element = value;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[ReadOnlySpan<Char> index] {
			get => Head[index].Element;
			set => Head[index].Element = value;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public unsafe TElement this[[DisallowNull] Char* index, Int32 length] {
			get => Head[index, length].Element;
			set => Head[index, length].Element = value;
		}

		/// <inheritdoc/>
		Boolean IContains<TElement>.Contains([AllowNull] TElement element) => Head.Contains(element);

		/// <inheritdoc/>
		[return: MaybeNull]
		Dictionary<TElement> IInsert<Char, TElement, Dictionary<TElement>>.Insert(Char index, [AllowNull] TElement element) {
			_ = Head.Insert(index, element);
			Count++;
			return this;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		Dictionary<TElement> IInsertText<TElement, Dictionary<TElement>>.Insert(ReadOnlySpan<Char> index, [AllowNull] TElement element) {
			// Insert all the necessary linkage
			Node N = Head;
			foreach (Char item in index) {
				N = N.Insert(item);
				if (N is null) {
					return null;
				}
			}
			// Set the last index node as a proper terminal
			N.Element = element;
			N.Terminal = true;
			// Finish up
			Count++;
			return this;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		Dictionary<TElement> IReplace<TElement, TElement, Dictionary<TElement>>.Replace([AllowNull] TElement search, [AllowNull] TElement replace) => Head.Replace(search, replace) is not null ? this : null;
	}
}
