using System;

namespace Logician {
	/// <summary>
	/// Łukasiewicz trivalent non-paradoxical logic value.
	/// </summary>
	/// <remarks>
	/// Łukasiewicz logic is useful in situations where you know somethings state has to be <see langword="true"/> or <see langword="false"/>, but it's possible to not know its state. That is, there are no paradoxes, only unknowns.
	/// </remarks>
	public readonly struct Ł3 : ITrivalentLogic<Ł3>, IEquatable<Boolean> {
		/// <summary>
		/// The proposition is known to be false.
		/// </summary>
		public static readonly Ł3 False = new Ł3(Val.False);

		/// <summary>
		/// The proposition is known to be true.
		/// </summary>
		public static readonly Ł3 True = new Ł3(Val.True);

		/// <summary>
		/// The proposition is not known to be true or false.
		/// </summary>
		public static readonly Ł3 Unknown = new Ł3(Val.Unknown);

		private readonly Val Value;

		private Ł3(Val value) => Value = value;

		private Ł3(Boolean value) => Value = value ? Val.True : Val.False;

		/// <summary>
		/// The actual enum values of <see cref="Ł3"/>.
		/// </summary>
		private enum Val {
			False = -1,
			Unknown = 0,
			True = 1,
		}

		public static implicit operator Ł3(Boolean value) => new Ł3(value);

		/// <summary>
		/// Logical negation; not
		/// </summary>
		public static Ł3 operator !(Ł3 value) => value.Not();

		public static Boolean operator !=(Ł3 left, Ł3 right) => !left.Equals(right);

		public static Boolean operator !=(Ł3 left, Boolean right) => !left.Equals(right);

		public static Boolean operator !=(Boolean left, Ł3 right) => !right.Equals(left);

		/// <summary>
		/// Logical conjunction; and.
		/// </summary>
		public static Ł3 operator &(Ł3 left, Ł3 right) => left.And(right);

		/// <summary>
		/// Logical conjunction; and.
		/// </summary>
		public static Ł3 operator &(Ł3 left, Boolean right) => left.And(right);

		/// <summary>
		/// Logical conjunction; and.
		/// </summary>
		public static Ł3 operator &(Boolean left, Ł3 right) => right.And(left);

		/// <summary>
		/// Logical exclusion; xor.
		/// </summary>
		public static Ł3 operator ^(Ł3 left, Ł3 right) => left.XOr(right);

		/// <summary>
		/// Logical exclusion; xor.
		/// </summary>
		public static Ł3 operator ^(Ł3 left, Boolean right) => left.XOr(right);

		/// <summary>
		/// Logical exclusion; xor.
		/// </summary>
		public static Ł3 operator ^(Boolean left, Ł3 right) => right.XOr(left);

		/// <summary>
		/// Logical inclusion; or.
		/// </summary>
		public static Ł3 operator |(Ł3 left, Ł3 right) => left.Or(right);

		/// <summary>
		/// Logical inclusion; or.
		/// </summary>
		public static Ł3 operator |(Ł3 left, Boolean right) => left.Or(right);

		/// <summary>
		/// Logical inclusion; or.
		/// </summary>
		public static Ł3 operator |(Boolean left, Ł3 right) => right.Or(left);

		public static Boolean operator ==(Ł3 left, Ł3 right) => left.Equals(right);

		public static Boolean operator ==(Ł3 left, Boolean right) => left.Equals(right);

		public static Boolean operator ==(Boolean left, Ł3 right) => right.Equals(left);

		/// <inheritdoc/>
		public Ł3 And(Ł3 other) => new Ł3((Val)Math.Min((Int32)Value, (Int32)other.Value));

		/// <inheritdoc/>
		public Ł3 And(Boolean other) => And((Ł3)other);

		/// <inheritdoc/>
		public Boolean Contingent() => Value == Val.Unknown;

		/// <inheritdoc/>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Ł3 l:
				return Equals(l);
			case Boolean b:
				return Equals(b);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Ł3 other) => Value == other.Value;

		/// <inheritdoc/>
		public Boolean Equals(Boolean other) {
			switch (Value) {
			case Val.True:
				return other;
			case Val.False:
				return !other;
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Ł3 Equivalent(Ł3 other) => new Ł3((Val)(1 - Math.Abs((Int32)Value - (Int32)other.Value)));

		/// <inheritdoc/>
		public Ł3 Equivalent(Boolean other) => Equivalent((Ł3)other);

		/// <inheritdoc/>
		public override Int32 GetHashCode() => Value.GetHashCode();

		/// <inheritdoc/>
		public Ł3 Implies(Ł3 value) => new Ł3((Val)Math.Min(1, 1 - (Int32)Value + (Int32)value.Value));

		/// <inheritdoc/>
		public Ł3 Implies(Boolean other) => Implies((Ł3)other);

		/// <inheritdoc/>
		public Ł3 NAnd(Ł3 other) => !(this & other);

		/// <inheritdoc/>
		public Ł3 NAnd(Boolean other) => NAnd((Ł3)other);

		/// <inheritdoc/>
		public Boolean Necessary() => Value == Val.True;

		/// <inheritdoc/>
		public Ł3 NOr(Ł3 other) => !(this | other);

		/// <inheritdoc/>
		public Ł3 NOr(Boolean other) => NOr((Ł3)other);

		/// <inheritdoc/>
		public Ł3 Not() => new Ł3((Val)(-(Int32)Value));

		/// <inheritdoc/>
		public Ł3 Or(Ł3 other) => new Ł3((Val)Math.Max((Int32)Value, (Int32)other.Value));

		/// <inheritdoc/>
		public Ł3 Or(Boolean other) => Or((Ł3)other);

		/// <summary>
		/// Logical possibly
		/// </summary>
		public Boolean Possible() => Value != Val.False;

		/// <inheritdoc/>
		public override String ToString() => Value.ToString();

		/// <inheritdoc/>
		public Ł3 XNOr(Ł3 other) => !(this ^ other);

		/// <inheritdoc/>
		public Ł3 XNOr(Boolean other) => XNOr((Ł3)other);

		/// <inheritdoc/>
		public Ł3 XOr(Ł3 other) => (this | other) & (!this | !other);

		/// <inheritdoc/>
		public Ł3 XOr(Boolean other) => XOr((Ł3)other);
	}
}
