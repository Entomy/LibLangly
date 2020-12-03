using System;

namespace Langly {
	/// <summary>
	/// Indicates the type can be divided.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public interface IDividable<TSelf> where TSelf : IDividable<TSelf> {
		/// <summary>
		/// Division.
		/// </summary>
		TSelf Divide(TSelf other);
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Division.
		/// </summary>
		/// <typeparam name="T">The type of the element.</typeparam>
		/// <param name="element">This element.</param>
		/// <param name="other">The other element.</param>
		/// <returns>The quotient of the two elements.</returns>
		public static T Divide<T>(this T element, T other) where T : IDividable<T> => element.Divide(other);

		#region Primitives
		public static Single Divide(Byte element, Byte other) => (Single)element / (Single)other;

		[CLSCompliant(false)]
		public static Single Divide(SByte element, SByte other) => (Single)element / (Single)other;

		public static Single Divide(Int16 element, Int16 other) => (Single)element / (Single)other;

		[CLSCompliant(false)]
		public static Single Divide(UInt16 element, UInt16 other) => (Single)element / (Single)other;

		public static Double Divide(Int32 element, Int32 other) => (Double)element / (Double)other;

		[CLSCompliant(false)]
		public static Double Divide(UInt32 element, UInt32 other) => (Double)element / (Double)other;

		public static Double Divide(Int64 element, Int64 other) => (Double)element / (Double)other;

		[CLSCompliant(false)]
		public static Double Divide(UInt64 element, UInt64 other) => (Double)element / (Double)other;

		public static Double Divide(nint element, nint other) => (Double)element / (Double)other;

		[CLSCompliant(false)]
		public static Double Divide(nuint element, nuint other) => (Double)element / (Double)other;

		public static Single Divide(Single element, Single other) => element / other;

		public static Double Divide(Double element, Double other) => element / other;
		#endregion
	}
}
