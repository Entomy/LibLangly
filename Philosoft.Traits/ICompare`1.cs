using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can be compared to another.
	/// </summary>
	/// <typeparam name="TElement">The type this can be compared to.</typeparam>
	public interface ICompare<TElement> : IComparable, IComparable<TElement>, IEquatable<TElement> {
#if !NETSTANDARD1_3
		/// <inheritdoc/>
		Int32 IComparable.CompareTo([AllowNull] Object obj) {
			switch (obj) {
			case TElement other:
				return CompareTo(other);
			default:
				throw new ArgumentException("obj is not the same type as this instance.", nameof(obj));
			}
		}

		/// <inheritdoc/>
		Boolean IEquatable<TElement>.Equals([AllowNull] TElement other) => CompareTo(other) == 0;
#endif
	}
}
