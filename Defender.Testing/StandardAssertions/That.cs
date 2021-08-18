using System;

namespace Defender {
	public static partial class StandardAssertions {
		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="actual"/>.</typeparam>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <typeparamref name="T"/> to make assertions against.</param>
		/// <returns>An <see cref="Asserter{T}"/> instance.</returns>
		public static Asserter<T> That<T>(this Assert _, T actual) => new Asserter<T>(actual);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="Action"/> to make assertions against.</param>
		/// <returns>An <see cref="Asserter{T}"/> instance.</returns>
		public static Asserter<Action> That(this Assert _, Action actual) => new Asserter<Action>(actual);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="Array"/> to make assertions against.</param>
		/// <returns>An <see cref="ArrayAsserter{T}"/> instance.</returns>
		public static ArrayAsserter<T> That<T>(this Assert _, T[] actual) => new ArrayAsserter<T>(actual);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="ArraySegment{T}"/> to make assertions against.</param>
		/// <returns>An <see cref="SpanAsserter{T}"/> instance.</returns>
		public static SpanAsserter<T> That<T>(this Assert _, ArraySegment<T> actual) => new SpanAsserter<T>(actual);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="Memory{T}"/> to make assertions against.</param>
		/// <returns>An <see cref="SpanAsserter{T}"/> instance.</returns>
		public static SpanAsserter<T> That<T>(this Assert _, Memory<T> actual) => new SpanAsserter<T>(actual);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="ReadOnlyMemory{T}"/> to make assertions against.</param>
		/// <returns>An <see cref="SpanAsserter{T}"/> instance.</returns>
		public static SpanAsserter<T> That<T>(this Assert _, ReadOnlyMemory<T> actual) => new SpanAsserter<T>(actual);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="Span{T}"/> to make assertions against.</param>
		/// <returns>An <see cref="SpanAsserter{T}"/> instance.</returns>
		public static SpanAsserter<T> That<T>(this Assert _, Span<T> actual) => new SpanAsserter<T>(actual);

		/// <summary>
		/// Prepares <paramref name="actual"/> to make assertions against it.
		/// </summary>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="actual">The instance of <see cref="ReadOnlySpan{T}"/> to make assertions against.</param>
		/// <returns>An <see cref="SpanAsserter{T}"/> instance.</returns>
		public static SpanAsserter<T> That<T>(this Assert _, ReadOnlySpan<T> actual) => new SpanAsserter<T>(actual);
	}
}
