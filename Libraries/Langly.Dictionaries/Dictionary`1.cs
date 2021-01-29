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
		IIndex<Char, TElement>,
		IInsert<Char, TElement, Dictionary<TElement>>,
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

		/// <inheritdoc/>
		public nint Count { get; private set; }

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
			Head = new Node(index: '\0', element: default, filter: Filter, parent: null);
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[Char index] {
			get => Head[index];
			set => Head[index] = value;
		}

		/// <inheritdoc/>
		Boolean IContains<TElement>.Contains([AllowNull] TElement element) => Head.Contains(element);

		/// <inheritdoc/>
		[return: NotNull]
		public Dictionary<TElement> Insert(Char index, [AllowNull] TElement element) {
			_ = Head.Insert(index, element);
			Count++;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		Dictionary<TElement> IReplace<TElement, TElement, Dictionary<TElement>>.Replace([AllowNull] TElement search, [AllowNull] TElement replace) {
			_ = Head.Replace(search, replace);
			return this;
		}
	}
}
