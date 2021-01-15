using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents any possible data structure.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the data structure.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for this data structure.</typeparam>
	/// <remarks>
	/// This is extremely anemic in order to avoid the false assumption and leaky abstraction problems most collection libraries get themselves into. This class only sets up things that are truly common for all data structures.
	/// </remarks>
	[DebuggerDisplay("{ToString(5),nq}")]
	public abstract class DataStructure<TElement, TSelf, TEnumerator> : Record<TSelf>,
		ISequence<TElement, TEnumerator>
		where TSelf : DataStructure<TElement, TSelf, TEnumerator>
		where TEnumerator : IEnumerator<TElement> {
		/// <summary>
		/// The <see cref="Filter{TIndex, TElement}"/> being used.
		/// </summary>
		/// <remarks>
		/// This is never <see langword="null"/>; a sentinel is used by default.
		/// </remarks>
		[NotNull, DisallowNull]
		protected readonly Filter<nint, TElement> Filter;

		/// <summary>
		/// Initializes a new <see cref="DataStructure{TElement, TSelf, TEnumerator}"/>.
		/// </summary>
		/// <param name="filter">Flags designating which filters to set up.</param>
		protected DataStructure(Filter filter) {
			if ((filter & DataStructures.Filter.Sparse) != 0) {
				Filter = Sparse<nint, TElement>.Instance;
			} else {
				Filter = Null<nint, TElement>.Instance;
			}
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
		protected DataStructure(Filter<nint, TElement> filter) => Filter = filter;

		/// <inheritdoc/>
		public virtual nint Count { get; protected set; }

		/// <summary>
		/// Determines if the two sequences aren't equal.
		/// </summary>
		/// <param name="left">The lefthand sequence.</param>
		/// <param name="right">The righthand sequence.</param>
		/// <returns><see langword="true"/> if the two sequences aren't equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] DataStructure<TElement, TSelf, TEnumerator> left, [AllowNull] DataStructure<TElement, TSelf, TEnumerator> right) {
			if (left is null && right is null) {
				return false;
			} else if (left is null || right is null) {
				return true;
			} else {
				return !left.Equals(right);
			}
		}

		/// <summary>
		/// Determines if the two sequences are equal.
		/// </summary>
		/// <param name="left">The lefthand sequence.</param>
		/// <param name="right">The righthand sequence.</param>
		/// <returns><see langword="true"/> if the two sequences are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] DataStructure<TElement, TSelf, TEnumerator> left, [AllowNull] DataStructure<TElement, TSelf, TEnumerator> right) {
			if (left is null && right is null) {
				return true;
			} else if (left is null || right is null) {
				return false;
			} else {
				return left.Equals(right);
			}
		}

		/// <inheritdoc/>
		Boolean IContains<TElement>.Contains([AllowNull] TElement element) {
			TEnumerator ths = GetEnumerator();
			while (ths.MoveNext()) {
				if (ths.Current is null && element is null) {
					return true;
				} else if (element?.Equals(ths.Current) ?? false) {
					return true;
				}
			}
			return false;
		}

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] TSelf other) => ReferenceEquals(this, other) || Equals<TEnumerator>(other);

		/// <summary>
		/// Determines if the two sequences are equal.
		/// </summary>
		/// <typeparam name="TOtherEnumerator">The type of the enumerator for the <paramref name="other"/> sequence.</typeparam>
		/// <param name="other">The other sequence.</param>
		/// <returns><see langword="true"/> if the two sequences are equal; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals<TOtherEnumerator>([AllowNull] ISequence<TElement, TOtherEnumerator> other) where TOtherEnumerator : IEnumerator<TElement> {
			// We're calling this off an instance, so if the other is null
			if (other is null) {
				// They aren't equal
				return false;
			}
			// Get enumerators for each
			using TEnumerator ths = GetEnumerator();
			using TOtherEnumerator oth = other.GetEnumerator();
			// Now iterate through both
			while (ths.MoveNext() && oth.MoveNext()) {
				// If the current elements are not equal to each other
				if (!(oth.Current?.Equals(ths.Current) ?? false)) {
					// The sequences aren't equal
					return false;
				}
			}
			// If any enumerator can still advance
			if (ths.MoveNext() || oth.MoveNext()) {
				// They aren't the same length and therefore aren't equal
				return false;
			}
			// We've validated that the sequences are the same length, and contain the same elements in the same order, so are therefore equal.
			return true;
		}

		/// <summary>
		/// Determines if the two sequences are equal.
		/// </summary>
		/// <typeparam name="TOtherEnumerator">The type of the enumerator for the <paramref name="other"/> sequence.</typeparam>
		/// <param name="other">The other sequence.</param>
		/// <returns><see langword="true"/> if the two sequences are equal; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals<TOtherEnumerator>([AllowNull] ISequence<IEquals<TElement>, TOtherEnumerator> other) where TOtherEnumerator : IEnumerator<IEquals<TElement>> {
			// We're calling this off an instance, so if the other is null
			if (other is null) {
				// They aren't equal
				return false;
			}
			// Get enumerators for each
			using TEnumerator ths = GetEnumerator();
			using TOtherEnumerator oth = other.GetEnumerator();
			// Now iterate through both
			while (ths.MoveNext() && oth.MoveNext()) {
				// If the current elements are not equal to each other
				if (!(oth.Current?.Equals(ths.Current) ?? false)) {
					// The sequences aren't equal
					return false;
				}
			}
			// If any enumerator can still advance
			if (ths.MoveNext() || oth.MoveNext()) {
				// They aren't the same length and therefore aren't equal
				return false;
			}
			// We've validated that the sequences are the same length, and contain the same elements in the same order, so are therefore equal.
			return true;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public abstract TEnumerator GetEnumerator();

		/// <inheritdoc/>
		public sealed override String ToString() => ToString(Count);

		/// <summary>
		/// Returns a string that represents the current object, with no more than <paramref name="amount"/> elements.
		/// </summary>
		/// <param name="amount">The maximum amount of elements to display.</param>
		public String ToString(nint amount) {
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			foreach (TElement element in this) {
				if (++i == Count) {
					_ = builder.Append(element);
					break;
				} else if (i == amount) {
					_ = builder.Append(element).Append("...");
					break;
				} else {
					_ = builder.Append(element).Append(", ");
				}
			}
			return $"[{builder}]";
		}
	}
}
