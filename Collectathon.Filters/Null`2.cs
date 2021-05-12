namespace Collectathon {
	/// <summary>
	/// Represents the null filter, a dummy filter which does nothing.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the collection being filtered.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the collection being filtered.</typeparam>
	internal sealed class Null<TIndex, TElement> : Filter<TIndex, TElement> {
		/// <summary>
		/// Initializes a new <see cref="Null{TIndex, TElement}"/> filter.
		/// </summary>
		private Null() { }

		/// <summary>
		/// A <see cref="Null{TIndex, TElement}"/> filter singleton.
		/// </summary>
		public static Null<TIndex, TElement> Instance => Singleton.Instance;

		private static class Singleton {
			internal static readonly Null<TIndex, TElement> Instance = new Null<TIndex, TElement>();

			static Singleton() { }
		}
	}
}
