using System;
using Collectathon.Queues;
using Xunit;

namespace Langly {
	public class Queue_Tests {
		[Fact]
		public void Invoke_Action() {
			Int32 x = 0;
			Queue<Action> queue = new Queue<Action>(() => x = 1, () => x = 2);
			queue.Invoke();
			Assert.Equal(1, x);
			queue.Invoke();
			Assert.Equal(2, x);
		}

		[Fact]
		public void Invoke_Func() {
			Queue<Func<Int32>> queue = new Queue<Func<Int32>>(() => 1, () => 2);
			Assert.Equal(1, queue.Invoke());
			Assert.Equal(2, queue.Invoke());
		}

		[Fact]
		public void Requeue() {
			Queue<Int32> queue = new Queue<Int32>(1, 2);
			queue.Requeue();
			Assert.Equal(2, queue.Dequeue());
			Assert.Equal(1, queue.Dequeue());
		}
	}
}
