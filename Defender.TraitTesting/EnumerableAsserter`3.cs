using System;
using System.Traits;

namespace Defender {
	/// <summary>
	/// Represents the object having assertions made against it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	/// <typeparam name="TCollection">The type of the collection being asserted.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator of the collection.</typeparam>
	public class EnumerableAsserter<TElement, TCollection, TEnumerator> : Asserter<TCollection> where TCollection : IGetEnumerator<TElement, TEnumerator> where TEnumerator : ICurrent<TElement>, IMoveNext {
		/// <summary>
		/// Initializes a new <see cref="EnumerableAsserter{TElement, TCollection, TEnumerator}"/>.
		/// </summary>
		/// <param name="actual">The actual object being asserted.</param>
		public EnumerableAsserter(TCollection actual) : base(actual) { }

		/// <inheritdoc/>
		public EnumerableAsserter<TElement, TCollection, TEnumerator> Enumerates(params TElement[] expected) => Enumerates(expected.AsSpan());

		/// <inheritdoc/>
		public EnumerableAsserter<TElement, TCollection, TEnumerator> Enumerates(ArraySegment<TElement> expected) => Enumerates(expected.AsSpan());

		/// <inheritdoc/>
		public EnumerableAsserter<TElement, TCollection, TEnumerator> Enumerates(Memory<TElement> expected) => Enumerates(expected.Span);

		/// <inheritdoc/>
		public EnumerableAsserter<TElement, TCollection, TEnumerator> Enumerates(ReadOnlyMemory<TElement> expected) => Enumerates(expected.Span);

		/// <inheritdoc/>
		public EnumerableAsserter<TElement, TCollection, TEnumerator> Enumerates(Span<TElement> expected) => Enumerates((ReadOnlySpan<TElement>)expected);

		/// <inheritdoc/>
		public EnumerableAsserter<TElement, TCollection, TEnumerator> Enumerates(ReadOnlySpan<TElement> expected) {
			Int32 e = 0;
			foreach (TElement actual in Actual) {
				if (!(actual?.Equals(expected[e]) ?? expected[e] is null)) {
					throw new AssertException($"This instance was not what was expected.\nActual: {Actual}\nExpected: {Print(expected)}");
				}
			}
			if (e != expected.Length) {
				throw new AssertException($"The length of this instance was not what was expected.\nActual: {e}\nExpected: {expected.Length}");
			}
			return this;
		}
	}
}
