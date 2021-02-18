using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can be cleared.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IClear<out TResult> where TResult : IClear<TResult> {
		/// <summary>
		/// Clears this collection.
		/// </summary>
		[return: NotNull]
		TResult Clear();
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
