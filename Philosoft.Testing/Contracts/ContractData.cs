using System.Collections;
using System.Collections.Generic;

namespace System.Traits.Testing.Contracts {
	/// <summary>
	/// Represents the data payloads of a test contract.
	/// </summary>
	/// <remarks>
	/// This provides a base to create strongly typed unit test data, working around a design issue with xUnit and other frameworks.
	/// </remarks>
	public abstract class ContractData : IEnumerable<Object?[]> {
		/// <summary>
		/// The data payloads.
		/// </summary>
		protected readonly IList<Object?[]> Data;

		/// <summary>
		/// Initializes a new <see cref="ContractData"/>.
		/// </summary>
		protected ContractData() => Data = new List<Object?[]>();

		/// <inheritdoc/>
		public IEnumerator<Object?[]> GetEnumerator() => Data.GetEnumerator();

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
