using System;
using System.Collections.Generic;
using System.Traits;

namespace Defender.Contracts {
	/// <summary>
	/// Contract for testing <see cref="IClear"/>.
	/// </summary>
	public interface IClearContract {
		/// <summary>
		/// Tests behavior of <see cref="IClear.Clear"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to add.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		void Clear<TElement>(TElement[] initial);
	}

	/// <summary>
	/// Represents data used with <see cref="IClearContract"/>.
	/// </summary>
	public sealed class ClearContractData {
		/// <summary>
		/// Test data for <see cref="IClearContract.Clear{TElement}(TElement[])"/>.
		/// </summary>
		public static IEnumerable<Object?[]> Clear() {
			yield return new Object?[] { new Int32[] { } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4 } };
		}
	}
}
