using System;
using System.Collections;
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
				if (Object.Equals(element, item)) {
					return;
				}
			}
			throw new AssertFailedException();
		}

		/// <inheritdoc/>
		public void Empty([DisallowNull] IEnumerable sequence) {
			foreach (Object item in sequence) {
				throw new AssertFailedException();
			}
		}

		/// <inheritdoc/>
		public void Equals<T>([AllowNull] T expected, [AllowNull] T actual) => Assert.AreEqual(expected, actual);

		/// <inheritdoc/>
		public void Equals<T>([AllowNull] IEnumerable<T> expected, [AllowNull] IEnumerable<T> actual) {
			Collections.Generic.IEnumerator<T> exp = expected.GetEnumerator();
			Collections.Generic.IEnumerator<T> act = expected.GetEnumerator();
			while (exp.MoveNext() && act.MoveNext()) {
				if (!Object.Equals(exp.Current, act.Current)) {
					throw new AssertFailedException();
				}
			}
		}

		/// <inheritdoc/>
		public void IsNull([AllowNull] Object value) => Assert.IsNull(value);
	}
}
