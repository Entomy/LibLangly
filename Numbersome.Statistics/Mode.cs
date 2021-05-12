using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Numbersome {
	public static partial class StatisticsExtensions {
		/// <summary>
		/// Finds the mode of the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the <paramref name="values"/>.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mode of.</param>
		/// <returns>The mode of the <paramref name="values"/>.</returns>
		[return: MaybeNull]
		public static TElement Mode<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> values) where TEnumerator : IEnumerator<TElement> {
			Counter<TElement> counter = new Counter<TElement>();
			counter.Add(values);
			return counter.Highest;
		}
	}
}
