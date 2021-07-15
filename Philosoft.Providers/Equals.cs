using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Concepts {
	public static partial class Collection {
		/// <summary>
		/// Determines whether the specified sequences are considered equal.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in both sequences.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <see cref="ISequence{TElement, TEnumerator}"/>.</typeparam>
		/// <param name="first">The first sequence to compare.</param>
		/// <param name="second">The second sequence to compare.</param>
		/// <returns><see langword="true"/> if the objects are considered equal; otherwise, <see langword="false"/>. If both <paramref name="first"/> and <paramref name="second"/> are <see langword="null"/>, the method returns <see langword="true"/>.</returns>
		public static Boolean Equals<TElement, TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> first, [AllowNull] ISequence<TElement, TEnumerator> second) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset {
			if (first is null && second is null) { return true; }
			if (first is null || second is null) { return false; }
			if (first.Count != second.Count) { return false; } // Because ISequence has a length/count property, we can check this upfront
			TEnumerator fst = first.GetEnumerator();
			TEnumerator snd = second.GetEnumerator();
			while (fst.MoveNext() && snd.MoveNext()) {
				if (!Equals(fst.Current, snd.Current)) { return false; }
			}
			return true;
		}

		/// <summary>
		/// Determines whether the specified sequences are considered equal.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in both sequences.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <see cref="ISequence{TElement, TEnumerator}"/>.</typeparam>
		/// <param name="first">The first sequence to compare.</param>
		/// <param name="second">The second sequence to compare.</param>
		/// <returns><see langword="true"/> if the objects are considered equal; otherwise, <see langword="false"/>. If both <paramref name="first"/> and <paramref name="second"/> are <see langword="null"/>, the method returns <see langword="true"/>.</returns>
		public static Boolean Equals<TElement, TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> first, [AllowNull] Collections.Generic.IEnumerable<TElement> second) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset {
			if (first is null && second is null) { return true; }
			if (first is null || second is null) { return false; }
			TEnumerator fst = first.GetEnumerator();
			using Collections.Generic.IEnumerator<TElement> snd = second.GetEnumerator();
			while (fst.MoveNext() && snd.MoveNext()) {
				if (!Equals(fst.Current, snd.Current)) { return false; }
			}
			if (fst.MoveNext() || snd.MoveNext()) { return false; } // If either of the enumerators can still be moved the sequences are different lengths
			return true;
		}

		/// <summary>
		/// Determines whether the specified sequences are considered equal.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in both sequences.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <see cref="ISequence{TElement, TEnumerator}"/>.</typeparam>
		/// <param name="first">The first sequence to compare.</param>
		/// <param name="second">The second sequence to compare.</param>
		/// <returns><see langword="true"/> if the objects are considered equal; otherwise, <see langword="false"/>. If both <paramref name="first"/> and <paramref name="second"/> are <see langword="null"/>, the method returns <see langword="true"/>.</returns>
		public static Boolean Equals<TElement, TEnumerator>([AllowNull] Collections.Generic.IEnumerable<TElement> first, [AllowNull] ISequence<TElement, TEnumerator> second) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset {
			if (first is null && second is null) { return true; }
			if (first is null || second is null) { return false; }
			using Collections.Generic.IEnumerator<TElement> fst = first.GetEnumerator();
			TEnumerator snd = second.GetEnumerator();
			while (fst.MoveNext() && snd.MoveNext()) {
				if (!Equals(fst.Current, snd.Current)) { return false; }
			}
			if (fst.MoveNext() || snd.MoveNext()) { return false; } // If either of the enumerators can still be moved the sequences are different lengths
			return true;
		}
	}
}
