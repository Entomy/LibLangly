using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Defender.Patterns {
	/// <summary>
	/// Implements a very resiliant <see cref="IDisposable"/> base that's easy and safe to extend.
	/// </summary>
	/// <remarks>
	/// <para>This uses an extension of the <see cref="IDisposable"/> pattern, extending it even further in a safe way.</para>
	/// <para>What's wrong with the current <see cref="IDisposable"/> pattern? Nothing really, as long as downstream is fully aware of how to override <see cref="Dispose(Boolean)"/> and always overrides it the safe way. Will they? Who knows. The pattern implemented here simply de<see langword="virtual"/>ized the <see cref="Dispose(Boolean)"/> implementation, implementing it with three <see langword="virtual"/> methods, <see cref="DisposeManaged()"/>, <see cref="DisposeUnmanaged()"/>, <see cref="NullLargeFields()"/>. They are obvious in what should be done, and what is done gets put in the right place. Consider it accident proof <see cref="IDisposable"/>.</para>
	/// <para>This is inspired by, but implemented very differently from, the Controlled type in Ada. Unlike the Ada implementation, this actually uses interfaces, which greatly solves many problems. However, like Ada, it uses a base class approach which internalizes many details, encapsulating the complexity of the pattern.</para>
	/// </remarks>
	[SuppressMessage("Major Code Smell", "S3881:\"IDisposable\" should be implemented correctly", Justification = "This is the correct pattern. Individual parts are explicitly overridden, instead of this entire member.")]
	public abstract class Controlled : IDisposable, IAsyncDisposable {
		/// <summary>
		/// Used to detect and handle redundant calls.
		/// </summary>
		protected Boolean Disposed { get; private set; }

		/// <summary>
		/// Destruct the object.
		/// </summary>
		[SuppressMessage("Design", "MA0055:Do not use destructor", Justification = "Tell that to Microsoft, this is derived from their pattern, which also uses a destructor.")]
		~Controlled() => Dispose(disposing: false);

		/// <inheritdoc/>
		public void Dispose() {
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		/// <inheritdoc/>
		[SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "This is the correct pattern.")]
		public ValueTask DisposeAsync() {
			try {
				Dispose();
				return default;
			} catch (Exception ex) {
				return new ValueTask(Task.FromException(ex));
			}
		}

		/// <summary>
		/// Dispose of managed resources. Part of <see cref="Dispose()"/>.
		/// </summary>
		protected virtual void DisposeManaged() { }

		/// <summary>
		/// Dispose of unmanaged resources. Part of <see cref="Dispose()"/>.
		/// </summary>
		protected virtual void DisposeUnmanaged() { }

		/// <summary>
		/// Null out large fields. Part of <see cref="Dispose()"/>.
		/// </summary>
		protected virtual void NullLargeFields() { }

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <param name="disposing">Whether managed resources should be disposed.</param>
		[SuppressMessage("Design", "CA1063:Implement IDisposable Correctly", Justification = "This is the correct pattern. Individual parts are explicitly overridden, instead of this entire member.")]
		private void Dispose(Boolean disposing) {
			if (!Disposed) {
				if (disposing) {
					DisposeManaged();
				}
				DisposeUnmanaged();
				NullLargeFields();
				Disposed = true;
			}
		}
	}
}
