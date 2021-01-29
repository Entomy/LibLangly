using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can be cleared.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public interface IClear<out TSelf> where TSelf : IClear<TSelf> {
		/// <summary>
		/// Clears this collection.
		/// </summary>
		[return: NotNull]
		TSelf Clear();
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Clears the <paramref name="collection"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TSelf Clear<TSelf>([AllowNull] this IClear<TSelf> collection) where TSelf : IClear<TSelf> => collection is not null ? collection.Clear() : default;
	}
}
