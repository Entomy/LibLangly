using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		/// <summary>
		/// Clears the <paramref name="collection"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TSelf Clear<TSelf>([AllowNull] this IClear<TSelf> collection) where TSelf : IClear<TSelf> => collection is not null ? collection.Clear() : default;
	}
}
