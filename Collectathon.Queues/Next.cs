using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Queues {
	public static partial class QueueExtensions {
		/// <summary>
		/// Invokes the next <see cref="Action"/> in the <paramref name="queue"/>.
		/// </summary>
		/// <param name="queue">This queue.</param>
		public static void Invoke([DisallowNull] this Queue<Action> queue) {
			queue.Read(out Action? action);
			action?.Invoke();
		}

		/// <summary>
		/// Invokes the next <see cref="Func{TResult}"/> in the <paramref name="queue"/>.
		/// </summary>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <returns>The result of the next <see cref="Func{TResult}"/>.</returns>
		[return: MaybeNull]
		public static TResult Invoke<TResult>([DisallowNull] this Queue<Func<TResult>> queue) {
			queue.Read(out Func<TResult>? func);
			return func is not null ? func.Invoke() : throw new InvalidOperationException();
		}
	}
}
