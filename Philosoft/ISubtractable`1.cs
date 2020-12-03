using System;

namespace Langly {
	/// <summary>
	/// Indicates the type can be subtracted.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public interface ISubtractable<TSelf> where TSelf : ISubtractable<TSelf> {
		/// <summary>
		/// Subtraction; difference.
		/// </summary>
		TSelf Subtract(TSelf other);
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Subtraction; difference.
		/// </summary>
		/// <typeparam name="T">The type of the element.</typeparam>
		/// <param name="element">This element.</param>
		/// <param name="other">The other element.</param>
		/// <returns>The difference of the two elements.</returns>
		public static T Subtract<T>(this T element, T other) where T : ISubtractable<T> => element.Subtract(other);

		#region Primitives
		public static Int32 Subtract(Byte element, Byte other) => element - other;

		[CLSCompliant(false)]
		public static Int32 Subtract(SByte element, SByte other) => element - other;

		public static Int32 Subtract(Int16 element, Int16 other) => element - other;

		[CLSCompliant(false)]
		public static Int32 Subtract(UInt16 element, UInt16 other) => element - other;

		public static Int32 Subtract(Int32 element, Int32 other) => element - other;

		[CLSCompliant(false)]
		public static UInt32 Subtract(UInt32 element, UInt32 other) => element - other;

		public static Int64 Subtract(Int64 element, Int64 other) => element - other;

		[CLSCompliant(false)]
		public static UInt64 Subtract(UInt64 element, UInt64 other) => element - other;

		public static nint Subtract(nint element, nint other) => element - other;

		[CLSCompliant(false)]
		public static nuint Subtract(nuint element, nuint other) => element - other;

		public static Single Subtract(Single element, Single other) => element - other;

		public static Double Subtract(Double element, Double other) => element - other;
		#endregion
	}
}
