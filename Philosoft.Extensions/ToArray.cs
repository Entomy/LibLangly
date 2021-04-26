using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Creates an array from a <see cref="ISequence{TElement, TEnumerator}"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the sequence.</typeparam>
		/// <param name="sequence">This sequence.</param>
		/// <returns>An array that contains the elements from the input sequence.</returns>
		[return: MaybeNull, NotNullIfNotNull("sequence")]
		public static TElement[] ToArray<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> sequence) where TEnumerator : IEnumerator<TElement> => sequence?.ToArray();
	}
}
