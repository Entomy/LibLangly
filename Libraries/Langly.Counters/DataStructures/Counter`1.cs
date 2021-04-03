using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Langly.Traits;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents a counter, a structure to assist with sophisticated counting operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements being counted.</typeparam>
	/// <remarks>
	/// <para>This isn't intended for counting a single thing over and over. Rather, it's meant for counting collections of things all at once, and then doing things with those counts.</para>
	/// <para>This isn't derived from <see cref="DataStructure{TIndex, TElement, TSelf, TEnumerator}"/>, and instead uses its own hardcoded behavior. As such, custom filtration isn't possible, with it instead doing its own combination of unique and sparse filtration as appropriate.</para>
	/// </remarks>
	[DebuggerDisplay("{ToString(5),nq}")]
	public sealed partial class Counter<TElement> : Record<Counter<TElement>>,
		IAdd<TElement, Counter<TElement>>,
		IClear<Counter<TElement>>,
		IContains<TElement>,
		IIndexReadOnly<TElement, nint> {
		/// <summary>
		/// The head node of this counter.
		/// </summary>
		[AllowNull, MaybeNull]
		private Node Head;

		/// <summary>
		/// The tail node of this counter.
		/// </summary>
		[AllowNull, MaybeNull]
		private Node Tail;

		/// <summary>
		/// Initializes a new <see cref="Counter{TElement}"/>.
		/// </summary>
		public Counter() { }

		/// <inheritdoc/>
		public nint Count { get; private set; }

		/// <summary>
		/// Get the element with the highest count.
		/// </summary>
		public TElement Highest {
			get {
				Node N = Head;
				Node M = Head;
				while (N is not null) {
					if (N.Element > M!.Element) {
						M = N;
					}
					N = N.Next;
				}
				if (M is not null) {
					return M.Index;
				} else {
					throw new InvalidOperationException("No entries are being counted.");
				}
			}
		}

		/// <summary>
		/// Get the element with the lowest count.
		/// </summary>
		public TElement Lowest {
			get {
				Node N = Head;
				Node M = Head;
				while (N is not null) {
					if (N.Element < M!.Element) {
						M = N;
					}
					N = N.Next;
				}
				if (M is not null) {
					return M.Index;
				} else {
					throw new InvalidOperationException("No entries are being counted.");
				}
			}
		}

		/// <inheritdoc/>
		public nint this[[AllowNull] TElement index] {
			get {
				Node N = Head;
				while (N is not null) {
					if ((N.Index is null && index is null) || (N.Index?.Equals(index) ?? false)) {
						return N.Element;
					}
					N = N.Next;
				}
				return default;
			}
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		Counter<TElement> IAdd<TElement, Counter<TElement>>.Add([AllowNull] TElement element) {
			Node N = Head;
			while (N is not null) {
				if ((N.Index is null && element is null) || (N.Index?.Equals(element) ?? false)) {
					N.Element++;
					return this;
				}
				N = N.Next;
			}
			Tail = new Node(element, 1, Tail, null);
			if (Tail.Previous is not null) {
				Tail.Previous.Next = Tail;
			}
			if (Head is null) {
				Head = Tail;
			}
			Count++;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		Counter<TElement> IClear<Counter<TElement>>.Clear() {
			Node P = null;
			Node N = Head;
			while (N is not null) {
				if (N.Previous is not null) {
					P = N.Previous;
					P.Next = null;
				}
				N.Previous = null;
			}
			Head = null;
			Tail = null;
			Count = 0;
			return this;
		}

		/// <inheritdoc/>
		Boolean IContains<TElement>.Contains([AllowNull] TElement element) {
			Node N = Head;
			while (N is not null) {
				if ((N.Index is null && element is null) || (N.Index?.Equals(element) ?? false)) {
					return true;
				}
				N = N.Next;
			}
			return false;
		}

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] Counter<TElement> other) {
			// We're calling this off an instance, so if the other is null
			if (other is null) {
				// They aren't equal
				return false;
			}
			// Get head nodes for each
			Node ths = Head;
			Node oth = other.Head;
			// Now iterate through both
			while (ths is not null && oth is not null) {
				// If the current elements are not equal to each other
				if (!oth.Equals(ths)) {
					// The sequences aren't equal
					return false;
				}
			}
			// If any sequence can still advance
			if (ths is not null || oth is not null) {
				// They aren't the same length and therefore aren't equal
				return false;
			}
			// We've validated that the sequences are the same length, and contain the same elements in the same order, so are therefore equal.
			return true;
		}

		/// <inheritdoc/>
		public override String ToString() => ToString(5);

		/// <summary>
		/// Returns a string that represents the current object, with no more than <paramref name="amount"/> elements.
		/// </summary>
		/// <param name="amount">The maximum amount of elements to display.</param>
		public String ToString(nint amount) {
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			Node N = Head;
			while (N is not null) {
				if (++i == Count) {
					_ = builder.Append(N.Index).Append(':').Append(N.Element);
					break;
				} else if (i == amount) {
					_ = builder.Append(N.Index).Append(':').Append(N.Element).Append("...");
					break;
				} else {
					_ = builder.Append(N.Index).Append(':').Append(N.Element).Append(", ");
				}
				N = N.Next;
			}
			return $"[{builder}]";
		}
	}
}
