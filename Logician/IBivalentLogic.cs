using System;

namespace Langly {
	/// <summary>
	/// Indicates the type is a logical type with at least two parts.
	/// </summary>
	public interface IBivalentLogic<T> : IConjoinable<T>, IEquatable<T>, IIncludable<T>, INegatable<T> where T : struct, IBivalentLogic<T> {
		/// <summary>
		/// Logical conjunction; and.
		/// </summary>
		T And(Boolean other);

		/// <summary>
		/// Negated logical conjunction; not and.
		/// </summary>
		T NAnd(T other);

		/// <summary>
		/// Negated logical conjunction; not and.
		/// </summary>
		T NAnd(Boolean other);

		/// <summary>
		/// Logical inclusion; or.
		/// </summary>
		T Or(Boolean other);

		/// <summary>
		/// Negated logical inclusion; not or.
		/// </summary>
		T NOr(T other);

		/// <summary>
		/// Negated logical inclusion; nor or.
		/// </summary>
		T NOr(Boolean other);

		/// <summary>
		/// Logical exclusion; either-or.
		/// </summary>
		T XOr(Boolean other);

		/// <summary>
		/// Negated logical exclusion; not either-or.
		/// </summary>
		T XNOr(T other);

		/// <summary>
		/// Negated logical exclusion; not either-or.
		/// </summary>
		T XNOr(Boolean other);

		/// <summary>
		/// Material implication; if this then that.
		/// </summary>
		T Implies(T value);

		/// <summary>
		/// Material implication; if this then that.
		/// </summary>
		T Implies(Boolean other);

		/// <summary>
		/// Material equivalence; if and only if.
		/// </summary>
		T Equivalent(T other);

		/// <summary>
		/// Material equivalence; if and only if.
		/// </summary>
		T Equivalent(Boolean other);
	}
}
