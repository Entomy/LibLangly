using System;

namespace Defender {
	/// <summary>
	/// Represents the object having assertions made against it.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the array.</typeparam>
	public class ArrayAsserter<T> : Asserter<T[]> {
		/// <summary>
		/// Initializes a new <see cref="ArrayAsserter{T}"/>.
		/// </summary>
		/// <param name="actual">The actual object being asserted.</param>
		public ArrayAsserter(T[] actual) : base(actual) { }

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="ArrayAsserter{T}"/>.</returns>
		public override ArrayAsserter<T> Equals(Object expected) {
			switch (expected) {
			case T[] array:
				return Equals(array);
			case ArraySegment<T> segment:
				return Equals(segment);
			case Memory<T> memory:
				return Equals(memory);
			case ReadOnlyMemory<T> memory:
				return Equals(memory);
			default:
				return (ArrayAsserter<T>)base.Equals(expected);
			}
		}

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="ArrayAsserter{T}"/>.</returns>
		public ArrayAsserter<T> Equals(T[] expected) => Equals(expected.AsSpan());

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="ArrayAsserter{T}"/>.</returns>
		public ArrayAsserter<T> Equals(ArraySegment<T> expected) => Equals(expected.AsSpan());

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="ArrayAsserter{T}"/>.</returns>
		public ArrayAsserter<T> Equals(Memory<T> expected) => Equals(expected.Span);

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="ArrayAsserter{T}"/>.</returns>
		public ArrayAsserter<T> Equals(ReadOnlyMemory<T> expected) => Equals(expected.Span);

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="ArrayAsserter{T}"/>.</returns>
		public ArrayAsserter<T> Equals(Span<T> expected) => Equals((ReadOnlySpan<T>)expected);

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="ArrayAsserter{T}"/>.</returns>
		public virtual ArrayAsserter<T> Equals(ReadOnlySpan<T> expected) {
			if (Actual.Length != expected.Length) {
				throw new AssertException($"The length of this instance was not what was expected.\nActual: {Actual.Length}\nExpected: {expected.Length}");
			}
			return this;
		}
	}
}
