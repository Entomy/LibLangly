using System.Diagnostics.CodeAnalysis;
#if !NETSTANDARD1_3
using System.Threading.Tasks;
#endif
using Langly;

namespace System.Traits {
	/// <summary>
	/// Implements a very resiliant <see cref="IDisposable"/> base that's easy and safe to extend.
	/// </summary>
	/// <remarks>
	/// <para>This uses an extension of the <see cref="IDisposable"/> pattern, extending it even further in a safe way.</para>
	/// <para>What's wrong with the current <see cref="IDisposable"/> pattern? Nothing really, as long as downstream is fully aware of how to override <see cref="Dispose(Boolean)"/> and always overrides it the safe way. Will they? Who knows. The pattern implemented here simply de<see langword="virtual"/>ized the <see cref="Dispose(Boolean)"/> implementation, implementing it with three <see langword="virtual"/> methods, <see cref="DisposeManaged()"/>, <see cref="DisposeUnmanaged()"/>, <see cref="NullLargeFields()"/>. They are obvious in what should be done, and what is done gets put in the right place. Consider it accident proof <see cref="IDisposable"/>.</para>
	/// <para>This is inspired by, but implemented very differently from, the Controlled type in Ada. Unlike the Ada implementation, this actually uses interfaces, which greatly solves many problems. However, like Ada, it uses a base class approach which internalizes many details, encapsulating the complexity of the pattern.</para>
	/// </remarks>
	public interface IControlled : IDisposable
#if !NETSTANDARD1_3
		, IAsyncDisposable
#endif
		{
		/// <summary>
		/// Used to detect and handle redundant calls.
		/// </summary>
		Boolean Disposed { get; set; }

#if !NETSTANDARD1_3
		/// <inheritdoc/>
		void IDisposable.Dispose() => Collection.Dispose(this);
#endif

#if !NETSTANDARD1_3
		/// <inheritdoc/>
		[SuppressMessage("Miscellaneous Design", "AV1210:Catch a specific exception instead of Exception, SystemException or ApplicationException", Justification = "This is the correct pattern.")]
		ValueTask IAsyncDisposable.DisposeAsync() {
			try {
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
				return default;
			} catch (Exception exception) {
				return new ValueTask(Task.FromException(exception));
			}
		}
#endif

		/// <summary>
		/// Dispose of managed resources. Part of <see cref="IDisposable.Dispose()"/>.
		/// </summary>
		void DisposeManaged();

		/// <summary>
		/// Dispose of unmanaged resources. Part of <see cref="IDisposable.Dispose()"/>.
		/// </summary>
		void DisposeUnmanaged();

		/// <summary>
		/// Null out large fields. Part of <see cref="IDisposable.Dispose()"/>.
		/// </summary>
		void NullLargeFields();

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <param name="disposing">Whether managed resources should be disposed.</param>
		[SuppressMessage("Blocker Code Smell", "S2953:Methods named \"Dispose\" should implement \"IDisposable.Dispose\"", Justification = "It is, ironically, Sonar is the one that's confused.")]
		void Dispose(Boolean disposing)
#if !NETSTANDARD1_3
			=> Collection.Dispose(this, disposing)
#endif
			;
	}
}
