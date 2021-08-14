using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Advances the enumerator to the next element of the collection.
		/// </summary>
		/// <typeparam name="T">The type of the enumerator.</typeparam>
		/// <param name="enumerator">This enumerator.</param>
		/// <param name="count">The current count of elements in the collection, updated as it moves.</param>
		/// <returns><see langword="true"/> if the enumerator was successfully advanced to the next element; <see langword="false"/> if the enumerator has passed the end of the collection.</returns>
		/// <remarks>
		/// Many operations use the enumerator but still need to count the elements as it does so. This method makes these operations much simpler than you might guess.
		/// </remarks>
		public static Boolean MoveNext<T>(this T enumerator, ref Int32 count) where T : IMoveNext {
			Boolean result = enumerator.MoveNext();
			if (result) { count++; }
			return result;
		}
	}
}
