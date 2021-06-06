using System;
using MSFT = System.Collections.Generic;

namespace Langly {
	public static partial class Program {
		public static void Add<T>(this C5.CircularQueue<T> queue, T item) => queue.Enqueue(item);

		public static void Add<T>(this MSFT.LinkedList<T> list, T item) => list.AddLast(new MSFT.LinkedListNode<T>(item));

		public static void Add<T>(this MSFT.Queue<T> queue, T item) => queue.Enqueue(item);

		public static void Add<T>(this MSFT.Stack<T> stack, T item) => stack.Push(item);
	}
}
