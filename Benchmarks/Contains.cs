using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Collectathon.Arrays;
using Collectathon.Lists;
using Collectathon.Queues;
using Collectathon.Stacks;
using Numbersome;
using MSFT = System.Collections.Generic;

namespace Langly {
	[SimpleJob(RuntimeMoniker.Net50)]
	[MemoryDiagnoser]
	public class Contains {
		private static Int32[] array = new Int32[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static C5.ArrayList<Int32> c5_arraylist = new C5.ArrayList<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static C5.CircularQueue<Int32> c5_circularqueue = new C5.CircularQueue<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static C5.HashBag<Int32> c5_hashbag = new C5.HashBag<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
		
		private static C5.HashDictionary<Char, String> c5_hashdictionary;
		
		private static C5.HashedArrayList<Int32> c5_hashedarraylist = new C5.HashedArrayList<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
		
		private static C5.HashedLinkedList<Int32> c5_hashedlinkedlist = new C5.HashedLinkedList<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static C5.HashSet<Int32> c5_hashset = new C5.HashSet<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static C5.IntervalHeap<Int32> c5_intervalheap = new C5.IntervalHeap<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static C5.LinkedList<Int32> c5_linkedlist = new C5.LinkedList<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static C5.SortedArray<Int32> c5_sortedarray = new C5.SortedArray<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static C5.TreeBag<Int32> c5_treebag = new C5.TreeBag<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static C5.TreeDictionary<Char, String> c5_treedictionary;

		private static C5.TreeSet<Int32> c5_treeset = new C5.TreeSet<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static BoundedArray<Int32> collectathon_boundedarray = new BoundedArray<Int32>(array);

		private static DynamicArray<Int32> collectathon_dynamicarray = new DynamicArray<Int32>(array);

		private static Queue<Int32> collectathon_queue = new Queue<Int32>(array);

		private static SinglyLinkedList<Int32> collectathon_singlylinkedlist = new SinglyLinkedList<Int32>(array);

		private static Stack<Int32> collectathon_stack = new Stack<Int32>(array);

		private static MSFT.Dictionary<Char, String> msft_dictionary;

		private static MSFT.HashSet<Int32> msft_hashset = new MSFT.HashSet<Int32>(array);

		private static MSFT.LinkedList<Int32> msft_linkedlist = new MSFT.LinkedList<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static MSFT.List<Int32> msft_list = new MSFT.List<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static MSFT.Queue<Int32> msft_queue = new MSFT.Queue<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static MSFT.SegmentedList<Int32> msft_segmentedlist = new MSFT.SegmentedList<Int32>(8) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static MSFT.SortedDictionary<Char, String> msft_sorteddictionary;

		private static MSFT.SortedSet<Int32> msft_sortedset = new MSFT.SortedSet<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static MSFT.Stack<Int32> msft_stack = new MSFT.Stack<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };

		private static Set<Int32> numbersome_set = new Set<Int32>(array);

		[Params(1, 16, 32, 0)]
		public Int32 Search { get; set; }

		[Benchmark(Baseline = true)]
		public Boolean Array() {
			foreach (Int32 item in array) {
				if (item == Search) return true;
			}
			return false;
		}

		[Benchmark]
		public void C5_ArrayList() => c5_arraylist.Contains(Search);

		[Benchmark]
		public Boolean C5_CircularQueue() {
			foreach (Int32 item in c5_circularqueue) {
				if (item == Search) return true;
			}
			return false;
		}

		[Benchmark]
		public void C5_HashBag() => c5_hashbag.Contains(Search);

		[Benchmark]
		public void C5_HashedArrayList() => c5_hashedarraylist.Contains(Search);

		[Benchmark]
		public void C5_HashedLinkedList() => c5_hashedlinkedlist.Contains(Search);

		[Benchmark]
		public void C5_HashSet() => c5_hashset.Contains(Search);

		[Benchmark]
		public Boolean C5_IntervalHeap() {
			foreach (Int32 item in c5_intervalheap) {
				if (item == Search) return true;
			}
			return false;
		}

		[Benchmark]
		public void C5_LinkedList() => c5_linkedlist.Contains(Search);

		[Benchmark]
		public void C5_SortedArray() => c5_sortedarray.Contains(Search);

		[Benchmark]
		public void C5_TreeBag() => c5_treebag.Contains(Search);

		[Benchmark]
		public void C5_TreeSet() => c5_treeset.Contains(Search);

		[Benchmark]
		public void Collectathon_BoundedArray() => collectathon_boundedarray.Contains(Search);

		[Benchmark]
		public void Collectathon_DynamicArray() => collectathon_dynamicarray.Contains(Search);

		[Benchmark]
		public void Collectathon_Queue() => collectathon_queue.Contains(Search);

		[Benchmark]
		public void Collectathon_SinglyLinkedList() => collectathon_singlylinkedlist.Contains(Search);

		[Benchmark]
		public void Collectathon_Stack() => collectathon_stack.Contains(Search);

		[Benchmark]
		public void Numbersome_Set() => numbersome_set.Contains(Search);
	}
}
