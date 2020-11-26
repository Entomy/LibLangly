using System;

namespace Langly {
	/// <summary>
	/// Indicates the type is a logical type with at least three parts.
	/// </summary>
	public interface ITrivalentLogic<T> : IBivalentLogic<T> where T : struct, ITrivalentLogic<T> {
		/// <summary>
		/// Logical contingency; it is unknown.
		/// </summary>
		Boolean Contingent();

		/// <summary>
		/// Logical necessity; it is true.
		/// </summary>
		Boolean Necessary();

		/// <summary>
		/// Logical possibly; it is not false.
		/// </summary>
		Boolean Possible();
	}
}
