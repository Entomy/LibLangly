using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Testing {
	/// <summary>
	/// Represents the base of all test classes.
	/// </summary>
	/// <remarks>
	/// Inheriting from this provides the Philosoft testing framework to unit tests contained in the derived class.
	/// </remarks>
	[ExcludeFromCodeCoverage]
	public abstract class Tests {
		/// <summary>
		/// Provides a collection of contracts that validate types designed with the Trait and Concept APIs.
		/// </summary>
		[NotNull]
		protected static Contracts Contract { get; } = new Contracts();

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="actual"/>.</typeparam>
		/// <param name="actual">The instance of <typeparamref name="T"/> to make assertions against.</param>
		/// <returns>An <see cref="Testing.Assert{T}"/> instance.</returns>
		protected static Assert<T> Assert<T>([AllowNull] T actual) => new Assert<T>(actual);

		/// <summary>
		/// Prepares <paramref name="action"/> to make assertions against it.
		/// </summary>
		/// <param name="action">The <see cref="Action"/> to make assertions against.</param>
		/// <returns>An <see cref="Testing.Assert{T}"/> instance.</returns>
		protected static Assert<Action> Assert([AllowNull] Action action) => new Assert<Action>(action);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the <paramref name="actual"/> <see cref="Array"/>.</typeparam>
		/// <param name="actual">The instance of <see cref="Array"/> to make assertions against.</param>
		/// <returns>A <see cref="ArrayAssert{T}"/> instance.</returns>
		protected static ArrayAssert<T> Assert<T>([AllowNull] T[] actual) => new ArrayAssert<T>(actual);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the <paramref name="actual"/> <see cref="Memory{T}"/>.</typeparam>
		/// <param name="actual">The instance of <see cref="Memory{T}"/> to make assertions against.</param>
		/// <returns>A <see cref="ArrayAssert{T}"/> instance.</returns>
		protected static ArrayAssert<T> Assert<T>(Memory<T> actual) => new ArrayAssert<T>(actual.Span);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the <paramref name="actual"/> <see cref="ReadOnlyMemory{T}"/>.</typeparam>
		/// <param name="actual">The instance of <see cref="ReadOnlyMemory{T}"/> to make assertions against.</param>
		/// <returns>A <see cref="ArrayAssert{T}"/> instance.</returns>
		protected static ArrayAssert<T> Assert<T>(ReadOnlyMemory<T> actual) => new ArrayAssert<T>(actual.Span);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the <paramref name="actual"/> <see cref="Span{T}"/>.</typeparam>
		/// <param name="actual">The instance of <see cref="Span{T}"/> to make assertions against.</param>
		/// <returns>A <see cref="ArrayAssert{T}"/> instance.</returns>
		protected static ArrayAssert<T> Assert<T>(Span<T> actual) => new ArrayAssert<T>(actual);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the <paramref name="actual"/> <see cref="ReadOnlySpan{T}"/>.</typeparam>
		/// <param name="actual">The instance of <see cref="ReadOnlySpan{T}"/> to make assertions against.</param>
		/// <returns>A <see cref="ArrayAssert{T}"/> instance.</returns>
		protected static ArrayAssert<T> Assert<T>(ReadOnlySpan<T> actual) => new ArrayAssert<T>(actual);
	}
}
