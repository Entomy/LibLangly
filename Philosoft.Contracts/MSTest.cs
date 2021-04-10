using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Traits.Contracts {
	/// <summary>
	/// MSTest assertion driver.
	/// </summary>
	public sealed class MSTest : IAssert {
		/// <inheritdoc/>
		public void Contains<T>([AllowNull] T element, [DisallowNull] IEnumerable<T> sequence) {
			foreach (T item in sequence) {
				if (Equals(element, item)) {
					return;
				}
			}
			throw new AssertFailedException();
		}

		/// <inheritdoc/>
		public void IsNull([AllowNull] Object value) => Assert.IsNull(value);
	}
}
