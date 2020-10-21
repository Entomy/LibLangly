using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Defender.Exceptions;

namespace Defender {
	public static partial class Guard {
		/// <summary>
		/// Guard against the array being of different size from <paramref name="size"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The array.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="size">The required size.</param>
		/// <exception cref="ArgumentIsNotSizeException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Size<T>(T[] array, String name, Int64 size) {
			if (array is null || array.Length != size) {
				throw ArgumentIsNotSizeException.With(array, name, size);
			}
		}

		/// <summary>
		/// Guard against the span being of different size from <paramref name="size"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="size">The required size.</param>
		/// <exception cref="ArgumentIsNotSizeException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Size<T>(Span<T> span, String name, Int64 size) {
			if (span.Length != size) {
				throw ArgumentIsNotSizeException.With(span, name, size);
			}
		}

		/// <summary>
		/// Guard against the span being of different size from <paramref name="size"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <param name="span">The span.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="size">The required size.</param>
		/// <exception cref="ArgumentIsNotSizeException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Size<T>(ReadOnlySpan<T> span, String name, Int64 size) {
			if (span.Length != size) {
				throw ArgumentIsNotSizeException.With(span, name, size);
			}
		}

		/// <summary>
		/// Guard against the memory being of different size from <paramref name="size"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="size">The required size.</param>
		/// <exception cref="ArgumentIsNotSizeException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Size<T>(Memory<T> memory, String name, Int64 size) {
			if (memory.Length != size) {
				throw ArgumentIsNotSizeException.With(memory, name, size);
			}
		}

		/// <summary>
		/// Guard against the memory being of different size from <paramref name="size"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the memory.</typeparam>
		/// <param name="memory">The memory.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="size">The required size.</param>
		/// <exception cref="ArgumentIsNotSizeException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Size<T>(ReadOnlyMemory<T> memory, String name, Int64 size) {
			if (memory.Length != size) {
				throw ArgumentIsNotSizeException.With(memory, name, size);
			}
		}

		/// <summary>
		/// Guard against the <paramref name="collection"/> being of different size from <paramref name="size"/>.
		/// </summary>
		/// <typeparam name="TCollection">The type of the argument; must be <see cref="ICollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="size">The required size.</param>
		/// <exception cref="ArgumentIsNotSizeException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Size<TCollection>(TCollection collection, String name, Int64 size) where TCollection : ICollection {
			if (collection is null || collection.Count != size) {
				throw ArgumentIsNotSizeException.With(collection, name, size);
			}
		}

		/// <summary>
		/// Guard against the <paramref name="collection"/> being of different size from <paramref name="size"/>.
		/// </summary>
		/// <typeparam name="TCollection">The type of the argument; must be <see cref="ICollection{T}"/> of <typeparamref name="T"/>.</typeparam>
		/// <typeparam name="T">The type of the elements of <typeparamref name="TCollection"/>.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="name">The name of the argument.</param>
		/// <param name="size">The required size.</param>
		/// <exception cref="ArgumentIsNotSizeException">Thrown if the guard clause fails.</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Size<T, TCollection>(TCollection collection, String name, Int64 size) where TCollection : ICollection<T> {
			if (collection is null || collection.Count != size) {
				throw ArgumentIsNotSizeException.With(collection, name, size);
			}
		}
	}
}
