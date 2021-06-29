using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Testing {
	/// <summary>
	/// Represents a <see cref="Tests"/> asserter.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "This isn't really possible given what this class is, and how it's meant to be used. What this analyzer is trying to catch isn't an issue, anyways.")]
	public readonly ref struct Assert<T> {
		/// <summary>
		/// Initializes a new <see cref="Assert{T}"/>.
		/// </summary>
		/// <param name="actual">The actual object being asserted.</param>
		public Assert([AllowNull] T actual) => Actual = actual;

		/// <summary>
		/// The actual object being asserted.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[AllowNull, MaybeNull]
		public T Actual { get; }

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="Assert{T}"/>.</returns>
		new public Assert<T> Equals([AllowNull] Object expected) {
			if (!Equals(Actual, expected)) {
				throw new AssertException($"The instance did not equal what was expected.\nActual: {Actual}\nExpected: {expected}");
			}
			return this;
		}

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="Assert{T}"/>.</returns>
		public Assert<T> Equals([AllowNull] T expected) {
			if (!Equals(Actual, expected)) {
				throw new AssertException($"The instance did not equal what was expected.\nActual: {Actual}\nExpected: {expected}");
			}
			return this;
		}

		/// <summary>
		/// Asserts that the instance is of the <typeparamref name="TExpected"/> type.
		/// </summary>
		/// <typeparam name="TExpected">The expected type.</typeparam>
		/// <returns>This <see cref="Assert{T}"/>.</returns>
		public Assert<T> Type<TExpected>() {
			if (!Equals(Actual.GetType(), typeof(TExpected))) {
				throw new AssertException($"The instance was not of the expected type.\nActual: {Actual.GetType()}\nExpected: {typeof(TExpected)}");
			}
			return this;
		}
	}
}
