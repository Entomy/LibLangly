using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Defender.Exceptions;

namespace Defender {
	public static partial class Guard {
		/// <summary>
		/// Guards against the index being invalid for the string.
		/// </summary>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="string">The string being indexed.</param>
		/// <exception cref="ArgumentIndexNotValidException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Index(Int32 value, String name, String @string) {
			if (@string is null || (UInt32)value >= (UInt32)@string.Length) {
				throw ArgumentIndexNotValidException.With(value, name, @string);
			}
		}

		/// <summary>
		/// Guards against the index being invalid for the array.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="array">The array being indexed.</param>
		/// <exception cref="ArgumentIndexNotValidException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Index<T>(Int32 value, String name, T[] array) {
			if (array is null || (UInt32)value >= (UInt32)array.Length) {
				throw ArgumentIndexNotValidException.With(value, name, array);
			}
		}

		/// <summary>
		/// Guards against the index being invalid for the span.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="span">The span being indexed.</param>
		/// <exception cref="ArgumentIndexNotValidException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Index<T>(Int32 value, String name, Span<T> span) {
			if ((UInt32)value >= (UInt32)span.Length) {
				throw ArgumentIndexNotValidException.With(value, name, span);
			}
		}

		/// <summary>
		/// Guards against the index being invalid for the span.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="span">The span being indexed.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Index<T>(Int32 value, String name, ReadOnlySpan<T> span) {
			if ((UInt32)value >= (UInt32)span.Length) {
				throw ArgumentIndexNotValidException.With(value, name, span);
			}
		}

		/// <summary>
		/// Guards against the index being invalid for the memory.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="memory">The memory being indexed.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Index<T>(Int32 value, String name, Memory<T> memory) {
			if ((UInt32)value >= (UInt32)memory.Length) {
				throw ArgumentIndexNotValidException.With(value, name, memory);
			}
		}

		/// <summary>
		/// Guards against the index being invalid for the memory.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="memory">The memory being indexed.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Index<T>(Int32 value, String name, ReadOnlyMemory<T> memory) {
			if ((UInt32)value >= (UInt32)memory.Length) {
				throw ArgumentIndexNotValidException.With(value, name, memory);
			}
		}

		/// <summary>
		/// Guards against the index being invalid for the collection.
		/// </summary>
		/// <typeparam name="TCollection">The type of the collection; must be <see cref="ICollection"/>.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Index<TCollection>(Int32 value, String name, TCollection collection) where TCollection : ICollection {
			if (collection is null || (UInt32)value >= (UInt32)collection.Count) {
				throw ArgumentIndexNotValidException.With(value, name, collection);
			}
		}

		/// <summary>
		/// Guards against the index being invalid for the collection.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TCollection">The type of the collection; must be <see cref="ICollection"/>.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Index<T, TCollection>(Int32 value, String name, TCollection collection) where TCollection : ICollection<T> {
			if (collection is null || (UInt32)value >= (UInt32)collection.Count) {
				throw ArgumentIndexNotValidException.With<Int32, T, TCollection>(value, name, collection);
			}
		}
	}
}
