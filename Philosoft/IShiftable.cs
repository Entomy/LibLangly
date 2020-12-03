using System;

namespace Langly {
	/// <summary>
	/// Indicates the collection can be shifted in position.
	/// </summary>
	public interface IShiftable {
		/// <summary>
		/// Shifts the collection left one position.
		/// </summary>
		void ShiftLeft();

		/// <summary>
		/// Shifts the collection left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftLeft(nint amount);

		/// <summary>
		/// Shifts the collection right one position.
		/// </summary>
		void ShiftRight();

		/// <summary>
		/// Shifts the collection right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftRight(nint amount);
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Shifts the <paramref name="collection"/> left one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void ShiftLeft(this IShiftable collection) {
			if (collection is null) {
				return;
			}
			collection.ShiftLeft();
		}

		/// <summary>
		/// Shifts the <paramref name="array"/> left one position.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">This array.</param>
		public static void ShiftLeft<T>(this T[] array) {
			if (array is null) {
				return;
			}
			for (nint i = 0; i < array.Length - 1;) {
				array[i] = array[++i];
			}
			array[array.Length - 1] = default;
		}

		/// <summary>
		/// Shifts the <paramref name="memory"/> left on position.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="memory">This memory.</param>
		public static void ShiftLeft<T>(this Memory<T> memory) => ShiftLeft(memory.Span);

		/// <summary>
		/// Shifts the <paramref name="span"/> left on position.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="span">This span.</param>
		public static void ShiftLeft<T>(this Span<T> span) {
			for (Int32 i = 0; i < span.Length - 1;) {
				span[i] = span[++i];
			}
			span[span.Length - 1] = default;
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void ShiftLeft(this IShiftable collection, nint amount) {
			if (collection is null) {
				return;
			}
			collection.ShiftLeft(amount);
		}

		/// <summary>
		/// Shifts the <paramref name="array"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">This array.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void ShiftLeft<T>(this T[] array, nint amount) {
			if (array is null) {
				return;
			}
			nint i = 0;
			for (; i < array.Length - amount; i++) {
				array[i] = array[i + amount];
			}
			for (; i < array.Length; i++) {
				array[i] = default;
			}
		}

		/// <summary>
		/// Shifts the <paramref name="memory"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="memory">This memory.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void ShiftLeft<T>(this Memory<T> memory, nint amount) => ShiftLeft(memory.Span, amount);

		/// <summary>
		/// Shifts the <paramref name="span"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="span">This span.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void ShiftLeft<T>(this Span<T> span, nint amount) {
			Int32 i = 0;
			for (; i < span.Length - amount; i++) {
				span[i] = span[(Int32)(i + amount)];
			}
			for (; i < span.Length; i++) {
				span[i] = default;
			}
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void ShiftRight(this IShiftable collection) {
			if (collection is null) {
				return;
			}
			collection.ShiftRight();
		}

		/// <summary>
		/// Shifts the <paramref name="array"/> right one position.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">This array.</param>
		public static void ShiftRight<T>(this T[] array) {
			if (array is null) {
				return;
			}
			for (nint i = array.Length - 1; i > 0;) {
				array[i--] = array[i];
			}
			array[0] = default;
		}

		/// <summary>
		/// Shifts the <paramref name="memory"/> right one position.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="memory">This meory.</param>
		public static void ShiftRight<T>(this Memory<T> memory) => ShiftRight(memory.Span);

		/// <summary>
		/// Shifts the <paramref name="span"/> right one position.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="span">This span.</param>
		public static void ShiftRight<T>(this Span<T> span) {
			for (Int32 i = span.Length - 1; i > 0;) {
				span[i--] = span[i];
			}
			span[0] = default;
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void ShiftRight(this IShiftable collection, nint amount) {
			if (collection is null) {
				return;
			}
			collection.ShiftRight(amount);
		}

		/// <summary>
		/// Shifts the <paramref name="array"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">This array.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void ShiftRight<T>(this T[] array, nint amount) {
			if (array is null) {
				return;
			}
			nint i = array.Length - 1;
			for (; i >= amount; i--) {
				array[i] = array[i - amount];
			}
			for (; i >= 0; i--) {
				array[i] = default;
			}
		}

		/// <summary>
		/// Shifts the <paramref name="memory"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="memory">This memory.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void ShiftRight<T>(this Memory<T> memory, nint amount) => ShiftRight(memory.Span, amount);

		/// <summary>
		/// Shifts the <paramref name="span"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="span">This span.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void ShiftRight<T>(this Span<T> span, nint amount) {
			Int32 i = span.Length - 1;
			for (; i >= amount; i--) {
				span[i] = span[(Int32)(i - amount)];
			}
			for (; i >= 0; i--) {
				span[i] = default;
			}
		}
	}
}
