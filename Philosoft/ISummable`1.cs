using System;

namespace Langly {
	/// <summary>
	/// Indicates the type can be added.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public interface ISummable<TSelf> where TSelf : ISummable<TSelf> {
		/// <summary>
		/// Addition; summation.
		/// </summary>
		TSelf Add(TSelf other);
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Addition; summation.
		/// </summary>
		/// <typeparam name="T">The type of the element.</typeparam>
		/// <param name="element">This element.</param>
		/// <param name="other">The other element.</param>
		/// <returns>The sum of the two elements.</returns>
		public static T Add<T>(this T element, T other) where T : ISummable<T> => element.Add(other);

		#region Primitives
		public static Int32 Add(Byte element, Byte other) => element + other;

		[CLSCompliant(false)]
		public static Int32 Add(SByte element, SByte other) => element + other;

		public static Int32 Add(Int16 element, Int16 other) => element + other;

		[CLSCompliant(false)]
		public static Int32 Add(UInt16 element, UInt16 other) => element + other;

		public static Int32 Add(Int32 element, Int32 other) => element + other;

		[CLSCompliant(false)]
		public static UInt32 Add(UInt32 element, UInt32 other) => element + other;

		public static Int64 Add(Int64 element, Int64 other) => element + other;

		[CLSCompliant(false)]
		public static UInt64 Add(UInt64 element, UInt64 other) => element + other;

		public static nint Add(nint element, nint other) => element + other;

		[CLSCompliant(false)]
		public static nuint Add(nuint element, nuint other) => element + other;

		public static Single Add(Single element, Single other) => element + other;

		public static Double Add(Double element, Double other) => element + other;
		#endregion
	}
}
