using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Indicates the type can be shifted in position.
	/// </summary>
	public interface IShift {
		/// <summary>
		/// Shifts the collection left one position.
		/// </summary>
		void ShiftLeft() => ShiftLeft(1);

		/// <summary>
		/// Shifts the collection left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftLeft(nint amount);

		/// <summary>
		/// Shifts the collection right one position.
		/// </summary>
		void ShiftRight() => ShiftRight(1);

		/// <summary>
		/// Shifts the collection right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftRight(nint amount);
	}

	public static partial class DataStructureExtensions {
		/// <summary>
		/// Shifts the <paramref name="collection"/> left one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void ShiftLeft([AllowNull] this IShift collection) => collection?.ShiftLeft();

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void ShiftLeft([AllowNull] this IShift collection, nint amount) => collection?.ShiftLeft(amount);

		/// <summary>
		/// Shifts the <paramref name="collection"/> right one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void ShiftRight([AllowNull] this IShift collection) => collection?.ShiftRight();

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void ShiftRight([AllowNull] this IShift collection, nint amount) => collection?.ShiftRight(amount);
	}
}
