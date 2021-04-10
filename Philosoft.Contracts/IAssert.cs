using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Represents any test asserter.
	/// </summary>
	public interface IAssert {
		/// <summary>
		/// Tests whether the specified sequence contains the specified element and throws an exception if the element is not in the sequence.
		/// </summary>
		/// <typeparam name="T">The type of the elements.</typeparam>
		/// <param name="element">The element that is expected to be in the collection.</param>
		/// <param name="sequence">The sequence in which to search for the element.</param>
		void Contains<T>([AllowNull] T element, [DisallowNull] IEnumerable<T> sequence);

		/// <summary>
		/// Tests whether the specified object is null and throws an exception if it is not.
		/// </summary>
		/// <param name="value">The object the test expects to be null.</param>
		void IsNull([AllowNull] Object value);
	}
}
