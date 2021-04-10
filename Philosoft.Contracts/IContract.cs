using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Base of all contracts.
	/// </summary>
	/// <typeparam name="TAssert">The type of the test asserter to use.</typeparam>
	public interface IContract<out TAssert> where TAssert : IAssert, new() {
		/// <summary>
		/// The test asserter being used.
		/// </summary>
		[DisallowNull, NotNull]
		protected static TAssert Assert { get; } = new TAssert();
	}
}
