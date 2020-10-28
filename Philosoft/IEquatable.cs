using System;

namespace Philosoft {
	//Note: There's no reason to provide our own IEquatable<T> interface, but there's still useful additions that can be provided.

	public static partial class Extensions {
		public static Boolean Equals<T>(T objA, T objB) where T : IEquatable<T> {
			if (objA is null && objB is null) {
				return true;
			} else if (objA is null || objB is null) {
				return false;
			} else {
				return objA.Equals(objB);
			}
		}

		public static Boolean Equals<TA, TB>(TA objA, TB objB) where TA : IEquatable<TB> {
			if (objA is null && objB is null) {
				return true;
			} else if (objA is null || objB is null) {
				return false;
			} else {
				return objA.Equals(objB);
			}
		}

		public static Boolean Equals<TA, TB>(TB objB, TA objA) where TB : IEquatable<TA> {
			if (objA is null && objB is null) {
				return true;
			} else if (objA is null || objB is null) {
				return false;
			} else {
				return objB.Equals(objA);
			}
		}
	}
}
