using System;

namespace Langly {
	/// <summary>
	/// Provides extension methods for the logic types in LibLangly.
	/// </summary>
	/// <remarks>
	/// These, really, are just for binding purposes and orthogonality. Because all logic types are structs, and in fact required to be by the interfaces, there's no need for the null-tolerant extension pattern to be used. As such, <see cref="Boolean"/> is the only type that gains anything here. It does put everything in one consistent place for binding purposes, however.
	/// </remarks>
	public static class LogicExtensions {
		#region Not
		/// <summary>
		/// Logical negation; not.
		/// </summary>
		/// <param name="value">The value to negate.</param>
		/// <returns>The logical negation of <paramref name="value"/>.</returns>
		public static Boolean Not(this Boolean value) => !value;

		/// <summary>
		/// Logical negation; not.
		/// </summary>
		/// <param name="value">The value to negate.</param>
		/// <returns>The logical negation of <paramref name="value"/>.</returns>
		public static Ł3 Not(this Ł3 value) => !value;
		#endregion

		#region And
		/// <summary>
		/// Logical conjunction; and.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical conjunction of the parameters.</returns>
		public static Boolean And(this Boolean value, Boolean other) => value && other;

		/// <summary>
		/// Logical conjunction; and.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical conjunction of the parameters.</returns>
		public static Ł3 And(this Ł3 value, Ł3 other) => value & other;

		/// <summary>
		/// Logical conjunction; and.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical conjunction of the parameters.</returns>
		public static Ł3 And(this Boolean value, Ł3 other) => value & other;

		/// <summary>
		/// Logical conjunction; and.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical conjunction of the parameters.</returns>
		public static Ł3 And(this Ł3 value, Boolean other) => value & other;
		#endregion

		#region Or
		/// <summary>
		/// Logical inclusion; or.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical inclusion of the parameters.</returns>
		public static Boolean Or(this Boolean value, Boolean other) => value || other;

		/// <summary>
		/// Logical inclusion; or.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical inclusion of the parameters.</returns>
		public static Ł3 Or(this Ł3 value, Ł3 other) => value | other;

		/// <summary>
		/// Logical inclusion; or.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical inclusion of the parameters.</returns>
		public static Ł3 Or(this Boolean value, Ł3 other) => value | other;

		/// <summary>
		/// Logical inclusion; or.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical inclusion of the parameters.</returns>
		public static Ł3 Or(this Ł3 value, Boolean other) => value | other;
		#endregion

		#region XOr
		/// <summary>
		/// Logical exclusion; either-or.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical exclusion of the parameters.</returns>
		public static Boolean XOr(this Boolean value, Boolean other) => value ^ other;

		/// <summary>
		/// Logical exclusion; either-or.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical exclusion of the parameters.</returns>
		public static Ł3 XOr(this Ł3 value, Ł3 other) => value ^ other;

		/// <summary>
		/// Logical exclusion; either-or.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical exclusion of the parameters.</returns>
		public static Ł3 XOr(this Boolean value, Ł3 other) => value ^ other;

		/// <summary>
		/// Logical exclusion; either-or.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The logical exclusion of the parameters.</returns>
		public static Ł3 XOr(this Ł3 value, Boolean other) => value ^ other;
		#endregion

		#region Implies
		/// <summary>
		/// Material implication; if this then that.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The material implication of the parameters.</returns>
		public static Boolean Implies(this Boolean value, Boolean other) => !value || other;

		/// <summary>
		/// Material implication; if this then that.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The material implication of the parameters.</returns>
		public static Ł3 Implies(this Ł3 value, Ł3 other) => value.Implies(other);

		/// <summary>
		/// Material implication; if this then that.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The material implication of the parameters.</returns>
		public static Ł3 Implies(this Boolean value, Ł3 other) => ((Ł3)value).Implies(other);

		/// <summary>
		/// Material implication; if this then that.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The material implication of the parameters.</returns>
		public static Ł3 Implies(this Ł3 value, Boolean other) => value.Implies(other);
		#endregion

		#region Equivalent
		/// <summary>
		/// Material equivalence; if this then that.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The material equivalence of the parameters.</returns>
		public static Boolean Equivalent(this Boolean value, Boolean other) => value == other;

		/// <summary>
		/// Material implication; if this then that.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The material equivalence of the parameters.</returns>
		public static Ł3 Equivalent(this Ł3 value, Ł3 other) => value.Equivalent(other);

		/// <summary>
		/// Material implication; if this then that.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The material equivalence of the parameters.</returns>
		public static Ł3 Equivalent(this Boolean value, Ł3 other) => ((Ł3)value).Equivalent(other);

		/// <summary>
		/// Material implication; if this then that.
		/// </summary>
		/// <param name="value">The first value.</param>
		/// <param name="other">The other value.</param>
		/// <returns>The material equivalence of the parameters.</returns>
		public static Ł3 Equivalent(this Ł3 value, Boolean other) => value.Equivalent(other);
		#endregion

		#region Contingent
		/// <summary>
		/// Logical contingency; it is unknown.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The logical contingency of <paramref name="value"/>.</returns>
		public static Boolean Contingent(this Boolean value) => false;

		/// <summary>
		/// Logical contingency; it is unknown.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The logical contingency of <paramref name="value"/>.</returns>
		public static Boolean Contingent(this Ł3 value) => value.Contingent();
		#endregion

		#region Necessary
		/// <summary>
		/// Logical necessity; it is true.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The logical necessity of <paramref name="value"/>.</returns>
		public static Boolean Necessary(this Boolean value) => value;

		/// <summary>
		/// Logical necessity; it is true.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The logical necessity of <paramref name="value"/>.</returns>
		public static Boolean Necessary(this Ł3 value) => value.Necessary();
		#endregion

		#region Possible
		/// <summary>
		/// Logical possibly; it is not false.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The logical possibility of <paramref name="value"/>.</returns>
		public static Boolean Possible(this Boolean value) => value;

		/// <summary>
		/// Logical possibly; it is not false.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The logical possibility of <paramref name="value"/>.</returns>
		public static Boolean Possible(this Ł3 value) => value.Possible();
		#endregion
	}
}
