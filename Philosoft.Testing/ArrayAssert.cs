using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Traits.Testing {
	/// <summary>
	/// Represents a <see cref="Tests"/> asserter.
	/// </summary>
	[ExcludeFromCodeCoverage]
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "This isn't really possible given what this class is, and how it's meant to be used. What this analyzer is trying to catch isn't an issue, anyways.")]
	public readonly ref struct ArrayAssert<T> {
		/// <summary>
		/// Initializes a new <see cref="ArrayAssert{T}"/>.
		/// </summary>
		/// <param name="actual">The actual array being asserted.</param>
		public ArrayAssert([AllowNull] T[] actual) => Actual = actual;

		/// <summary>
		/// Initializes a new <see cref="ArrayAssert{T}"/>.
		/// </summary>
		/// <param name="actual">The actual span being asserted.</param>
		public ArrayAssert(Span<T> actual) => Actual = actual;

		/// <summary>
		/// Initializes a new <see cref="ArrayAssert{T}"/>.
		/// </summary>
		/// <param name="actual">The actual span being asserted.</param>
		public ArrayAssert(ReadOnlySpan<T> actual) => Actual = actual;

		/// <summary>
		/// The actual span being asserted.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public ReadOnlySpan<T> Actual { get; }

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected <see cref="Object"/>.</param>
		/// <returns>This <see cref="ArrayAssert{T}"/>.</returns>
		[DoesNotReturn]
		[Obsolete("Spans do not support equality comparisons to Object.", error: true)]
		new public ArrayAssert<T> Equals([AllowNull] Object expected) => throw new NotSupportedException($"Spans can not be compared to {typeof(Object)}.");

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> span.
		/// </summary>
		/// <param name="expected">The expected <see cref="Array"/>.</param>
		/// <returns>This <see cref="ArrayAssert{T}"/>.</returns>
		public ArrayAssert<T> Equals([AllowNull] params T[] expected) => Equals(expected.AsSpan());

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> span.
		/// </summary>
		/// <param name="expected">The expected <see cref="Memory{T}"/>.</param>
		/// <returns>This <see cref="ArrayAssert{T}"/>.</returns>
		public ArrayAssert<T> Equals(Memory<T> expected) => Equals(expected.Span);

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> span.
		/// </summary>
		/// <param name="expected">The expected <see cref="ReadOnlyMemory{T}"/>.</param>
		/// <returns>This <see cref="ArrayAssert{T}"/>.</returns>
		public ArrayAssert<T> Equals(ReadOnlyMemory<T> expected) => Equals(expected.Span);

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> span.
		/// </summary>
		/// <param name="expected">The expected <see cref="Span{T}"/>.</param>
		/// <returns>This <see cref="ArrayAssert{T}"/>.</returns>
		public ArrayAssert<T> Equals(Span<T> expected) => Equals((ReadOnlySpan<T>)expected);

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> span.
		/// </summary>
		/// <param name="expected">The expected <see cref="ReadOnlySpan{T}"/>.</param>
		/// <returns>This <see cref="ArrayAssert{T}"/>.</returns>
		public ArrayAssert<T> Equals(ReadOnlySpan<T> expected) {
			if (Actual.Length != expected.Length) goto Throw;
			for (Int32 i = 0; i < Actual.Length; i++) {
				if (!Object.Equals(Actual[i], expected[i])) goto Throw;
			}
			return this;
		Throw:
			throw new AssertException($"The instance did not equal what was expected.\nActual: {Print(5, Actual)}\nExpected: {Print(5, expected)}");
		}

		private String Print(Int32 amount, ReadOnlySpan<T> span) {
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
