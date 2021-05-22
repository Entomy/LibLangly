using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits;

namespace Langly {
	internal static partial class Collection {
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <param name="collection">The collection to dispose.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[SuppressMessage("Major Code Smell", "S3971:\"GC.SuppressFinalize\" should not be called", Justification = "According to the pattern, this should be called.")]
		public static void Dispose([DisallowNull] IControlled collection) {
			collection.Dispose(disposing: true);
			GC.SuppressFinalize(collection);
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <param name="collection">The collection to dispose.</param>
		/// <param name="disposing">Whether managed resources should be disposed.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[SuppressMessage("Maintainability", "AV1564:Parameter in public or internal member is of type bool or bool?", Justification = "I don't control of this API.")]
		public static void Dispose([DisallowNull] IControlled collection, Boolean disposing) {
			if (!collection.Disposed) {
				if (disposing) {
					collection.DisposeManaged();
				}
				collection.DisposeUnmanaged();
				collection.NullLargeFields();
				collection.Disposed = true;
			}
		}
	}
}
