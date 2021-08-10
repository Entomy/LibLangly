using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MSFT = System.Collections.Generic;

namespace Collectathon {
	[SimpleJob(RuntimeMoniker.Net50)]
	[MemoryDiagnoser]
	public class AddMany {
		private static C5.ArrayList<Int32> c5_arraylist = new C5.ArrayList<Int32>(32);

		private static C5.CircularQueue<Int32> c5_circularqueue = new C5.CircularQueue<Int32>(32);

		private static C5.HashBag<Int32> c5_hashbag = new C5.HashBag<Int32>();

		private static C5.HashedArrayList<Int32> c5_hashedarraylist = new C5.HashedArrayList<Int32>(32);

		private static C5.HashedLinkedList<Int32> c5_hashedlinkedlist = new C5.HashedLinkedList<Int32>();

		private static C5.HashSet<Int32> c5_hashset = new C5.HashSet<Int32>();

		private static C5.IntervalHeap<Int32> c5_intervalheap = new C5.IntervalHeap<Int32>(32);

		private static C5.LinkedList<Int32> c5_linkedlist = new C5.LinkedList<Int32>();

		private static C5.SortedArray<Int32> c5_sortedarray = new C5.SortedArray<Int32>(32);

		private static C5.TreeBag<Int32> c5_treebag = new C5.TreeBag<Int32>();

		private static C5.TreeSet<Int32> c5_treeset = new C5.TreeSet<Int32>();

		private static BoundedArray<Int32> collectathon_boundedarray = new BoundedArray<Int32>(32);

		private static DynamicArray<Int32> collectathon_dynamicarray = new DynamicArray<Int32>(32);

		private static SinglyLinkedList<Int32> collectathon_singlylinkedlist = new SinglyLinkedList<Int32>();

		private static NetFabric.DoublyLinkedList<Int32> netfabric_doublylinkedlist = new NetFabric.DoublyLinkedList<Int32>();

		private static MSFT.HashSet<Int32> msft_hashset = new MSFT.HashSet<Int32>(32);

		private static MSFT.LinkedList<Int32> msft_linkedlist = new MSFT.LinkedList<Int32>();

		private static MSFT.List<Int32> msft_list = new MSFT.List<Int32>(32);

		private static MSFT.Queue<Int32> msft_queue = new MSFT.Queue<Int32>(32);

		private static MSFT.SegmentedList<Int32> msft_segmentedlist = new MSFT.SegmentedList<Int32>(8, 32);

		private static MSFT.SortedSet<Int32> msft_sortedset = new MSFT.SortedSet<Int32>();

		private static MSFT.Stack<Int32> msft_stack = new MSFT.Stack<Int32>(32);

		[Params(new Int32[] { 1 }, new Int32[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new Int32[] { 3, 1, 4, 2, 7, 5, 8, 6 }, new Int32[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 }, new Int32[] { 3, 1, 4, 2, 7, 5, 8, 6, 11, 9, 12, 10, 15, 13, 16, 14, 17, 18, 21, 19, 22, 20, 25, 23, 26, 24, 29, 27, 30, 28, 32, 31 })]
		public Int32[] Items { get; set; }

		[Benchmark]
		public void C5_ArrayList() => c5_arraylist.AddAll(Items);

		[Benchmark]
		public void C5_CircularQueue() {
			foreach (Int32 item in Items) {
				c5_circularqueue.Enqueue(item);
			}
		}

		[Benchmark]
		public void C5_HashBag() => c5_hashbag.AddAll(Items);

		[Benchmark]
		public void C5_HashedArrayList() => c5_hashedarraylist.AddAll(Items);

		[Benchmark]
		public void C5_HashedLinkedList() => c5_hashedlinkedlist.AddAll(Items);

		[Benchmark]
		public void C5_HashSet() => c5_hashset.AddAll(Items);

		[Benchmark]
		public void C5_IntervalHeap() => c5_intervalheap.AddAll(Items);

		[Benchmark]
		public void C5_LinkedList() => c5_linkedlist.AddAll(Items);

		[Benchmark]
		public void C5_SortedArray() => c5_sortedarray.AddAll(Items);

		[Benchmark]
		public void C5_TreeBag() => c5_treebag.AddAll(Items);

		[Benchmark]
		public void C5_TreeSet() => c5_treeset.AddAll(Items);

		[Benchmark]
		public void Collectathon_BoundedArray() => collectathon_boundedarray.Add(Items);

		[Benchmark]
		public void Collectathon_DynamicArray() => collectathon_dynamicarray.Add(Items);

		[Benchmark]
		public void Collectathon_SinglyLinkedList() => collectathon_singlylinkedlist.Add(Items);

		[Benchmark]
		public void NetFabric_Doubly_LinkedList() => netfabric_doublylinkedlist.AddLast(Items);

		[Benchmark]
		public void MSFT_HashSet() {
			foreach (Int32 item in Items) {
				msft_hashset.Add(item);
			}
		}

		[Benchmark]
		public void MSFT_LinkedList() {
			foreach (Int32 item in Items) {
				msft_linkedlist.AddLast(item);
			}
		}

		[Benchmark]
		public void MSFT_List() => msft_list.AddRange(Items);

		[Benchmark]
		public void MSFT_Queue() {
			foreach (Int32 item in Items) {
				msft_queue.Enqueue(item);
			}
		}

		[Benchmark]
		public void MSFT_SegmentedList() {
			foreach (Int32 item in Items) {
				msft_segmentedlist.Add(item);
			}
		}

		[Benchmark]
		public void MSFT_SortedSet() {
			foreach (Int32 item in Items) {
				msft_sortedset.Add(item);
			}
		}

		[Benchmark]
		public void MSFT_Stack() {
			foreach (Int32 item in Items) {
				msft_stack.Push(item);
			}
		}

		[IterationCleanup]
		public void IterationCleanup() {
			c5_arraylist.Clear();
			while (c5_circularqueue.Count > 0) {
				_ = c5_circularqueue.Dequeue(); // There's no Clear() so we have to do this
			}
			c5_hashbag.Clear();
			c5_hashedarraylist.Clear();
			c5_hashedlinkedlist.Clear();
			c5_hashset.Clear();
			while (c5_intervalheap.Count > 0) {
				_ = c5_intervalheap.DeleteMax(); // There's no Clear() so we have to do this
			}
			c5_linkedlist.Clear();
			c5_sortedarray.Clear();
			c5_treebag.Clear();
			c5_treeset.Clear();
			collectathon_boundedarray.Clear();
			collectathon_dynamicarray.Clear();
			collectathon_singlylinkedlist.Clear();
			msft_hashset.Clear();
			msft_linkedlist.Clear();
			msft_list.Clear();
			msft_queue.Clear();
			msft_segmentedlist.Clear();
			msft_sortedset.Clear();
			msft_stack.Clear();
		}
	}
}
