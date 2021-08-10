using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void Shrink(this IResize collection) => collection.Resize((Int32)(collection.Capacity / φ));
	}
}
