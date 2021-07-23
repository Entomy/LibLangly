using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="actual"/>.</typeparam>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <typeparamref name="T"/> to make assertions against.</param>
		/// <returns>An <see cref="Assert{T}"/> instance.</returns>
		public static Assert<T> That<T>(this Assert _, T actual) => new Assert<T>(actual);

		/// <summary>
		/// Prepares <paramref name="action"/> to make assertions against it.
		/// </summary>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="action">The <see cref="Action"/> to make assertions against.</param>
		/// <returns>An <see cref="Assert{T}"/> instance.</returns>
		public static Assert<Action> That(this Assert _, Action action) => new Assert<Action>(action);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the <paramref name="actual"/> <see cref="Array"/>.</typeparam>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="Array"/> to make assertions against.</param>
		/// <returns>A <see cref="ArrayAssert{T}"/> instance.</returns>
		public static ArrayAssert<T> That<T>(this Assert _, T[] actual) => new ArrayAssert<T>(actual);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the <paramref name="actual"/> <see cref="Memory{T}"/>.</typeparam>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="Memory{T}"/> to make assertions against.</param>
		/// <returns>A <see cref="ArrayAssert{T}"/> instance.</returns>
		public static ArrayAssert<T> That<T>(this Assert _, Memory<T> actual) => new ArrayAssert<T>(actual.Span);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the <paramref name="actual"/> <see cref="ReadOnlyMemory{T}"/>.</typeparam>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="ReadOnlyMemory{T}"/> to make assertions against.</param>
		/// <returns>A <see cref="ArrayAssert{T}"/> instance.</returns>
		public static ArrayAssert<T> That<T>(this Assert _, ReadOnlyMemory<T> actual) => new ArrayAssert<T>(actual.Span);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the <paramref name="actual"/> <see cref="Span{T}"/>.</typeparam>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="Span{T}"/> to make assertions against.</param>
		/// <returns>A <see cref="ArrayAssert{T}"/> instance.</returns>
		public static ArrayAssert<T> That<T>(this Assert _, Span<T> actual) => new ArrayAssert<T>(actual);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the <paramref name="actual"/> <see cref="ReadOnlySpan{T}"/>.</typeparam>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="ReadOnlySpan{T}"/> to make assertions against.</param>
		/// <returns>A <see cref="ArrayAssert{T}"/> instance.</returns>
		public static ArrayAssert<T> That<T>(this Assert _, ReadOnlySpan<T> actual) => new ArrayAssert<T>(actual);
	}
}
