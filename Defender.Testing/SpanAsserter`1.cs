using System;

namespace Defender {
	/// <summary>
	/// Represents the object having assertions made against it.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the array.</typeparam>
	public readonly ref struct SpanAsserter<T> {
		/// <summary>
		/// Initializes a new <see cref="SpanAsserter{T}"/>
		/// </summary>
		/// <param name="actual">The actual object being asserted.</param>
		public SpanAsserter(ArraySegment<T> actual) => Actual = actual.AsSpan();

		/// <summary>
		/// Initializes a new <see cref="SpanAsserter{T}"/>
		/// </summary>
		/// <param name="actual">The actual object being asserted.</param>
		public SpanAsserter(Memory<T> actual) => Actual = actual.Span;

		/// <summary>
		/// Initializes a new <see cref="SpanAsserter{T}"/>
		/// </summary>
		/// <param name="actual">The actual object being asserted.</param>
		public SpanAsserter(ReadOnlyMemory<T> actual) => Actual = actual.Span;

		/// <summary>
		/// Initializes a new <see cref="SpanAsserter{T}"/>
		/// </summary>
		/// <param name="actual">The actual object being asserted.</param>
		public SpanAsserter(Span<T> actual) => Actual = actual;

		/// <summary>
		/// Initializes a new <see cref="SpanAsserter{T}"/>
		/// </summary>
		/// <param name="actual">The actual object being asserted.</param>
		public SpanAsserter(ReadOnlySpan<T> actual) => Actual = actual;

		/// <summary>
		/// The actual object being asserted.
		/// </summary>
		public ReadOnlySpan<T> Actual { get; }

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="SpanAsserter{T}"/>.</returns>
		new public SpanAsserter<T> Equals(Object expected) {
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
				throw new AssertException($"This instance was not what was expected.\nActual: {Asserter<T>.Print(Actual, 5)}\nExpected: {expected}");
			}
		}

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="SpanAsserter{T}"/>.</returns>
		public SpanAsserter<T> Equals(T[] expected) => Equals(expected.AsSpan());

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="SpanAsserter{T}"/>.</returns>
		public SpanAsserter<T> Equals(ArraySegment<T> expected) => Equals(expected.AsSpan());

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="SpanAsserter{T}"/>.</returns>
		public SpanAsserter<T> Equals(Memory<T> expected) => Equals(expected.Span);

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="SpanAsserter{T}"/>.</returns>
		public SpanAsserter<T> Equals(ReadOnlyMemory<T> expected) => Equals(expected.Span);

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="SpanAsserter{T}"/>.</returns>
		public SpanAsserter<T> Equals(Span<T> expected) => Equals((ReadOnlySpan<T>)expected);

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="SpanAsserter{T}"/>.</returns>
		public SpanAsserter<T> Equals(ReadOnlySpan<T> expected) {
			if (Actual.Length != expected.Length) {
				throw new AssertException($"The length of this instance was not what was expected.\nActual: {Actual.Length}\nExpected: {expected.Length}");
			}
			return this;
		}
	}
}
