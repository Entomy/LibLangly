using System.Collections.Generic;

namespace System.Traits.Testing.Contracts {
	/// <summary>
	/// Contract for testing <see cref="IReplace{TElement}"/> and <see cref="IReplace{TSearch, TReplace}"/>.
	/// </summary>
	public interface IReplaceContract {
		/// <summary>
		/// Tests behavior of <see cref="IReplace{TSearch, TReplace}.Replace(TSearch, TReplace)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Replace_Simple<TElement>(TElement[] initial, TElement search, TElement replace, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IReplace{TSearch, TReplace}.Replace(TSearch, TReplace)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TSearch">The type of the element to search for.</typeparam>
		/// <typeparam name="TReplace">The type of the replacement element.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Replace_Complex<TElement, TSearch, TReplace>(TElement[] initial, TSearch search, TReplace replace, TElement[] expected);
	}

	/// <summary>
	/// Represents data used with <see cref="IReplaceContract"/>.
	/// </summary>
	public sealed class ReplaceContractData {
		/// <summary>
		/// Test data for <see cref="IReplace{TSearch, TReplace}.Replace(TSearch, TReplace)"/> where the search and replace are the same type; always the case with <see cref="IReplace{TElement}"/>.
		/// </summary>
		public static IEnumerable<Object?[]> Replace_Simple() {
			yield return new Object?[] { new Int32[] { }, 0, 0, new Int32[] { } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 0, 0, new Int32[] { 1, 2, 3, 4, 5 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 1, 0, new Int32[] { 0, 2, 3, 4, 5 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 2, 0, new Int32[] { 1, 0, 3, 4, 5 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 3, 0, new Int32[] { 1, 2, 0, 4, 5 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 4, 0, new Int32[] { 1, 2, 3, 0, 5 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 5, 0, new Int32[] { 1, 2, 3, 4, 0 } };
			yield return new Object?[] { new Int32[] { 1, 2, 1, 2, 1 }, 1, 0, new Int32[] { 0, 2, 0, 2, 0 } };
			yield return new Object?[] { new Int32[] { 1, 2, 1, 2, 1 }, 2, 0, new Int32[] { 1, 0, 1, 0, 1 } };
		}

		/// <summary>
		/// Test data for <see cref="IReplace{TSearch, TReplace}.Replace(TSearch, TReplace)"/> where the search and replace are different types.
		/// </summary>
		public static IEnumerable<Object?[]> Replace_Complex() {
			foreach (Object?[] row in Replace_Simple()) {
				yield return row;
			}
		}
	}
}
