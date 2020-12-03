using System;

namespace Langly {
	/// <summary>
	/// Indicates the collection is countable.
	/// </summary>
	public interface ICountable {
		/// <summary>
		/// Gets the number of elements contained in the collection.
		/// </summary>
		/// <value>The number of elements contained in the collection.</value>
		nint Count { get; }
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Gets the number of elements contained in the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <value>The number of elements contained in the collection.</value>
		public static nint Count(this ICountable collection) => !(collection is null) ? collection.Count : 0;
	}
}
