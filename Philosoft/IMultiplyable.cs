using System;

namespace Langly {
	/// <summary>
	/// Indicates the type can be multiplied.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public interface IMultiplyable<TSelf> where TSelf : IMultiplyable<TSelf> {
		/// <summary>
		/// Multiplication; scaling; times.
		/// </summary>
		TSelf Multiply(TSelf other);
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Multiplication; scaling; times.
		/// </summary>
		/// <typeparam name="T">The type of the element.</typeparam>
		/// <param name="element">This element.</param>
		/// <param name="other">The other element.</param>
		/// <returns>The product of the two elements.</returns>
		public static T Multiply<T>(this T element, T other) where T : IMultiplyable<T> => element.Multiply(other);

		#region Primitives
		public static Int32 Multiply(Byte element, Byte other) => element * other;

		[CLSCompliant(false)]
		public static Int32 Multiply(SByte element, SByte other) => element * other;

		public static Int32 Multiply(Int16 element, Int16 other) => element * other;

		[CLSCompliant(false)]
		public static Int32 Multiply(UInt16 element, UInt16 other) => element * other;

		public static Int32 Multiply(Int32 element, Int32 other) => element * other;

		[CLSCompliant(false)]
		public static UInt32 Multiply(UInt32 element, UInt32 other) => element * other;

		public static Int64 Multiply(Int64 element, Int64 other) => element * other;

		[CLSCompliant(false)]
		public static UInt64 Multiply(UInt64 element, UInt64 other) => element * other;

		public static nint Multiply(nint element, nint other) => element * other;

		[CLSCompliant(false)]
		public static nuint Multiply(nuint element, nuint other) => element * other;

		public static Single Multiply(Single element, Single other) => element * other;

		public static Double Multiply(Double element, Double other) => element * other;
		#endregion
	}
}
