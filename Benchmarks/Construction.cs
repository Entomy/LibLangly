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
	public class Construction {
		[Benchmark(Baseline = true)]
		public void Array() => _ = new Int32[32];

		[Benchmark]
		public void C5_ArrayList() => _ = new C5.ArrayList<Int32>(32);

		[Benchmark]
		public void C5_CircularQueue() => _ = new C5.CircularQueue<Int32>(32);

		[Benchmark]
		public void C5_HashBag() => _ = new C5.HashBag<Int32>();

		[Benchmark]
		public void C5_HashDictionary() => _ = new C5.HashDictionary<Char, String>();

		[Benchmark]
		public void C5_HashedArrayList() => _ = new C5.HashedArrayList<Int32>(32);

		[Benchmark]
		public void C5_HashedLinkedList() => _ = new C5.HashedLinkedList<Int32>();

		[Benchmark]
		public void C5_HashSet() => _ = new C5.HashSet<Int32>();

		[Benchmark]
		public void C5_IntervalHeap() => _ = new C5.IntervalHeap<Int32>(32);

		[Benchmark]
		public void C5_LinkedList() => _ = new C5.LinkedList<Int32>();

		[Benchmark]
		public void C5_SortedArray() => _ = new C5.SortedArray<Int32>(32);

		[Benchmark]
		public void C5_TreeBag() => _ = new C5.TreeBag<Int32>();

		[Benchmark]
		public void C5_TreeDictionary() => _ = new C5.TreeDictionary<Char, String>();

		[Benchmark]
		public void C5_TreeSet() => _ = new C5.TreeSet<Int32>();

		[Benchmark]
		public void Collectathon_AssociativeBoundedArray() => _ = new BoundedArray<Char, String>(32);

		[Benchmark]
		public void Collectathon_AssociativeDynamicArray() => _ = new DynamicArray<Char, String>(32);

		[Benchmark]
		public void Collectathon_BoundedArray() => _ = new BoundedArray<Int32>(32);

		[Benchmark]
		public void Collectathon_DynamicArray() => _ = new DynamicArray<Int32>(32);

		[Benchmark]
		public void Collectathon_Queue() => _ = new Queue<Int32>();

		[Benchmark]
		public void Collectathon_SinglyLinkedList() => _ = new SinglyLinkedList<Int32>();

		[Benchmark]
		public void Collectathon_Stack() => _ = new Stack<Int32>();

		[Benchmark]
		public void MSFT_Dictionary() => _ = new MSFT.Dictionary<Char, String>(32);

		[Benchmark]
		public void MSFT_HashSet() => _ = new MSFT.HashSet<Int32>(32);

		[Benchmark]
		public void MSFT_LinkedList() => _ = new MSFT.LinkedList<Int32>();

		[Benchmark]
		public void MSFT_List() => _ = new MSFT.List<Int32>();

		[Benchmark]
		public void MSFT_Queue() => _ = new MSFT.Queue<Int32>(32);

		[Benchmark]
		public void MSFT_SegmentedList() => _ = new MSFT.SegmentedList<Int32>(8, 32);

		[Benchmark]
		public void MSFT_SortedDictionary() => _ = new MSFT.SortedDictionary<Char, String>();

		[Benchmark]
		public void MSFT_SortedSet() => _ = new MSFT.SortedSet<Int32>();

		[Benchmark]
		public void MSFT_Stack() => _ = new MSFT.Stack<Int32>(32);

		[Benchmark]
		public void Numbersome_Set() => _ = new Set<Int32>((_) => true);
	}
}

