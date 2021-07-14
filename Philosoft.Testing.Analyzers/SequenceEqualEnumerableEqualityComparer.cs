using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Traits.Testing {
	internal sealed class SequenceEqualEnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>?> {
		private readonly IEqualityComparer<T> _itemEqualityComparer;

		public SequenceEqualEnumerableEqualityComparer(IEqualityComparer<T>? itemEqualityComparer) {
			_itemEqualityComparer = itemEqualityComparer ?? EqualityComparer<T>.Default;
		}

		public Boolean Equals(IEnumerable<T>? x, IEnumerable<T>? y) {
			if (ReferenceEquals(x, y)) { return true; }
			if (x is null || y is null) { return false; }

			return x.SequenceEqual(y, _itemEqualityComparer);
		}

		public Int32 GetHashCode(IEnumerable<T>? obj) {
			if (obj is null) {
				return 0;
			}

			// From System.Tuple
			//
			// The suppression is required due to an invalid contract in IEqualityComparer<T>
			// https://github.com/dotnet/runtime/issues/30998
			return obj
				.Select(item => _itemEqualityComparer.GetHashCode(item!))
				.Aggregate(
					0,
					(aggHash, nextHash) => ((aggHash << 5) + aggHash) ^ nextHash);
		}
	}

}
