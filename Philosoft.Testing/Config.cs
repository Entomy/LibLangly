using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Testing {
	/// <summary>
	/// Represents a <see cref="Tests"/> configurer.
	/// </summary>
	public readonly ref struct Config {
		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Boolean Equals([AllowNull] Object obj) => throw new NotSupportedException();

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Int32 GetHashCode() => throw new NotSupportedException();

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override String ToString() => throw new NotSupportedException();
	}
}
