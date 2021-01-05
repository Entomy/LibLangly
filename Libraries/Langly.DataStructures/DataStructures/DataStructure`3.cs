using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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
	[DebuggerDisplay("{DebuggerDisplay(),nq}")]
	public abstract class DataStructure<TElement, TSelf, TEnumerator> : Record<TSelf>,
		ICount,
		ISequence<TElement, TEnumerator>
		where TSelf : DataStructure<TElement, TSelf, TEnumerator>
		where TEnumerator : IEnumerator<TElement> {

		/// <inheritdoc/>
		public abstract nint Count { get; }

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
		public sealed override String ToString() {
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			foreach (TElement element in this) {
				if (++i == Count) {
					builder.Append(element);
				} else {
					builder.Append(element).Append(',').Append(' ');
				}
			}
			return $"{StructurePrefix()}[{builder}]";
		}

		/// <summary>
		/// Provides the structure prefix (commonly, it's name) for <see cref="ToString()"/>.
		/// </summary>
		/// <returns>The structure prefix as a <see cref="String"/>.</returns>
		[return: NotNull]
		protected abstract String StructurePrefix();

		/// <summary>
		/// Returns a string that represents the current object, suitable for display in the debugger.
		/// </summary>
		private String DebuggerDisplay() {
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			foreach (TElement element in this) {
				_ = i < 5 && i++ < Count ? builder.Append(element).Append(',').Append(' ') : builder.Append(element);
			}
			return $"{StructurePrefix()}[{builder}]";
		}
	}
}
