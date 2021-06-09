using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using MSFT = System.Collections.Generic;

namespace Langly {
	public static partial class Program {
		//! Here we provide extensions that simplifying benchmarking code.

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Add<T>([DisallowNull] this C5.CircularQueue<T> queue, T item) => queue.Enqueue(item);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Add<T>([DisallowNull] this MSFT.LinkedList<T> list, T item) => list.AddLast(new MSFT.LinkedListNode<T>(item));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Add<T>([DisallowNull] this MSFT.Queue<T> queue, T item) => queue.Enqueue(item);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Add<T>([DisallowNull] this MSFT.Stack<T> stack, T item) => stack.Push(item);
	}
}
