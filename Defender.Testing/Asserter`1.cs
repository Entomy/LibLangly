using System;
using System.Text;

namespace Defender {
	/// <summary>
	/// Represents the object having assertions made against it.
	/// </summary>
	/// <typeparam name="T">The type of the object being asserted.</typeparam>
	public class Asserter<T> {
		/// <summary>
		/// Initializes a new <see cref="Asserter{T}"/>.
		/// </summary>
		/// <param name="actual">The actual object being asserted.</param>
		public Asserter(T actual) => Actual = actual;

		/// <summary>
		/// The actual object being asserted.
		/// </summary>
		public T Actual { get; }

		/// <summary>
		/// Asserts that this instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="Asserter{T}"/>.</returns>
		new public virtual Asserter<T> Equals(Object expected) {
			switch (expected) {
			case T other:
				if (!(Actual?.Equals(other) ?? false)) {
					throw new AssertException($"This instance was not what was expected.\nActual: {Actual}\nExpected: {expected}");
				}
				break;
			}
			return this;
		}

		/// <summary>
		/// Prints the <paramref name="array"/> up to <see cref="State.PrintCount"/> elements.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to format.</param>
		/// <returns>The formatted <paramref name="array"/> for printing.</returns>
		internal protected static String Print<T>(T[] array) => Print(array.AsSpan());

		/// <summary>
		/// Prints the <paramref name="segment"/> up to <see cref="State.PrintCount"/> elements.
		/// </summary>
		/// <param name="segment">The <see cref="ArraySegment{T}"/> to format.</param>
		/// <returns>The formatted <paramref name="segment"/> for printing.</returns>
		internal protected static String Print<T>(ArraySegment<T> segment) => Print(segment.AsSpan());

		/// <summary>
		/// Prints the <paramref name="memory"/> up to <see cref="State.PrintCount"/> elements.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> to format.</param>
		/// <returns>The formatted <paramref name="memory"/> for printing.</returns>
		internal protected static String Print<T>(Memory<T> memory) => Print(memory.Span);

		/// <summary>
		/// Prints the <paramref name="memory"/> up to <see cref="State.PrintCount"/> elements.
		/// </summary>
		/// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> to format.</param>
		/// <returns>The formatted <paramref name="memory"/> for printing.</returns>
		internal protected static String Print<T>(ReadOnlyMemory<T> memory) => Print(memory.Span);

		/// <summary>
		/// Prints the <paramref name="span"/> up to <see cref="State.PrintCount"/> elements.
		/// </summary>
		/// <param name="span">The <see cref="Span{T}"/> to format.</param>
		/// <returns>The formatted <paramref name="span"/> for printing.</returns>
		internal protected static String Print<T>(Span<T> span) => Print((ReadOnlySpan<T>)span);

		/// <summary>
		/// Prints the <paramref name="span"/> up to <see cref="State.PrintCount"/> elements.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> to format.</param>
		/// <returns>The formatted <paramref name="span"/> for printing.</returns>
		internal protected static String Print<T>(ReadOnlySpan<T> span) {
			StringBuilder builder = new StringBuilder();
			for (Int32 i = 0; i < span.Length; i++) {
				if (i + 1 == span.Length) {
					_ = builder.Append(span[i]);
					break;
				} else if (i + 1 == State.PrintCount) {
					_ = builder.Append(span[i]).Append("...");
					break;
				} else {
					_ = builder.Append(span[i]).Append(", ");
				}
			}
			return $"[{builder}]";
		}
	}
}
