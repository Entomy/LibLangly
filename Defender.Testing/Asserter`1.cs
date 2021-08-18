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
		/// Prints the <paramref name="span"/> up to <paramref name="amount"/> elements.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> to format.</param>
		/// <param name="amount">The maximum amount of elements to print.</param>
		/// <returns>The formatted <paramref name="span"/> for printing.</returns>
		internal protected static String Print(ReadOnlySpan<T> span, Int32 amount) {
			StringBuilder builder = new StringBuilder();
			for (Int32 i = 0; i < span.Length; i++) {
				if (i + 1 == span.Length) {
					_ = builder.Append(span[i]);
					break;
				} else if (i + 1 == amount) {
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
