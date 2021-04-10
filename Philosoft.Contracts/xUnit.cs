using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace System.Traits.Contracts {
	/// <summary>
	/// xUnit assertion driver.
	/// </summary>
	public sealed class xUnit : IAssert {
		/// <inheritdoc/>
		public void Contains<T>([AllowNull] T element, [DisallowNull] IEnumerable<T> sequence) => Assert.Contains(element, sequence);

		/// <inheritdoc/>
		public void IsNull([AllowNull] Object value) => Assert.Null(value);
	}
}
