using System;
using System.Diagnostics.CodeAnalysis;

namespace Philosoft {
	/// <summary>
	/// Indicates the collection is indexable, read-only.
	/// </summary>
	/// <typeparam name="TElement">The type in the collection.</typeparam>
	[SuppressMessage("Major Code Smell", "S3246:Generic type parameters should be co/contravariant when possible", Justification = "Agreed, they should. However this isn't even remotely possible in this situation.")]
	public interface IReadOnlyIndexable<TElement> : IReadOnlyIndexable<nint, TElement> {
	}
}
