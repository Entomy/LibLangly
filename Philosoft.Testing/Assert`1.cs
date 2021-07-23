using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Testing {
	/// <summary>
	/// Represents a <see cref="Tests"/> asserter.
	/// </summary>
	public readonly ref struct Assert<T> {
		/// <summary>
		/// Initializes a new <see cref="Assert{T}"/>.
		/// </summary>
		/// <param name="actual">The actual object being asserted.</param>
		public Assert(T actual) => Actual = actual;

		/// <summary>
		/// The actual object being asserted.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public T Actual { get; }

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="Assert{T}"/>.</returns>
		new public Assert<T> Equals(Object? expected) {
			if (!(Actual?.Equals(expected) ?? expected is null)) {
				throw new AssertException($"The instance did not equal what was expected.\nActual: {Actual}\nExpected: {expected}");
			}
			return this;
		}

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <see cref="Assert{T}"/>.</returns>
		public Assert<T> Equals(Object? expected, String additionalMessage) {
			if (!(Actual?.Equals(expected) ?? expected is null)) {
				throw new AssertException($"The instance did not equal what was expected.\nActual: {Actual}\nExpected: {expected}\n{additionalMessage}");
			}
			return this;
		}

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <returns>This <see cref="Assert{T}"/>.</returns>
		public Assert<T> Equals(T expected) {
			if (!(Actual?.Equals(expected) ?? expected is null)) {
				throw new AssertException($"The instance did not equal what was expected.\nActual: {Actual}\nExpected: {expected}");
			}
			return this;
		}

		/// <summary>
		/// Asserts that the instance equals the <paramref name="expected"/> object.
		/// </summary>
		/// <param name="expected">The expected object.</param>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <see cref="Assert{T}"/>.</returns>
		public Assert<T> Equals([AllowNull] T expected, [DisallowNull] String additionalMessage) {
			if (!(Actual?.Equals(expected) ?? expected is null)) {
				throw new AssertException($"The instance did not equal what was expected.\nActual: {Actual}\nExpected: {expected}\n{additionalMessage}");
			}
			return this;
		}

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("The asserter isn't meant to be used as a normal type.", error: true)]
		public override Int32 GetHashCode() => throw new NotSupportedException();

		/// <summary>
		/// Asserts that the instances hash code is the <paramref name="expected"/> value.
		/// </summary>
		/// <param name="expected">The expected hash code.</param>
		/// <returns>This <see cref="Assert{T}"/>.</returns>
		public Assert<T> HashCode(Int32 expected) {
			Int32 actual = Actual?.GetHashCode() ?? 0;
			if (!Equals(actual, expected)) {
				throw new AssertException($"The hash code did not equal what was expected.\nActual: {actual}\nExpected: {expected}");
			}
			return this;
		}

		/// <summary>
		/// Asserts that the instances hash code is the <paramref name="expected"/> value.
		/// </summary>
		/// <param name="expected">The expected hash code.</param>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <see cref="Assert{T}"/>.</returns>
		public Assert<T> HashCode(Int32 expected, [DisallowNull] String additionalMessage) {
			Int32 actual = Actual?.GetHashCode() ?? 0;
			if (!Equals(actual, expected)) {
				throw new AssertException($"The hash code did not equal what was expected.\nActual: {actual}\nExpected: {expected}\n{additionalMessage}");
			}
			return this;
		}

		/// <summary>
		/// Asserts that the instance is of the <typeparamref name="TExpected"/> type.
		/// </summary>
		/// <typeparam name="TExpected">The expected type.</typeparam>
		/// <returns>This <see cref="Assert{T}"/>.</returns>
		public Assert<T> Type<TExpected>() {
			if (!Equals(Actual?.GetType(), typeof(TExpected))) {
				throw new AssertException($"The instance was not of the expected type.\nActual: {Actual?.GetType() ?? typeof(Object)}\nExpected: {typeof(TExpected)}");
			}
			return this;
		}

		/// <summary>
		/// Asserts that the instance is of the <typeparamref name="TExpected"/> type.
		/// </summary>
		/// <typeparam name="TExpected">The expected type.</typeparam>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <see cref="Assert{T}"/>.</returns>
		public Assert<T> Type<TExpected>([DisallowNull] String additionalMessage) {
			if (!Equals(Actual?.GetType(), typeof(TExpected))) {
				throw new AssertException($"The instance was not of the expected type.\nActual: {Actual?.GetType() ?? typeof(Object)}\nExpected: {typeof(TExpected)}\n{additionalMessage}");
			}
			return this;
		}
	}
}
