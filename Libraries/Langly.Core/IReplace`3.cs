using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have its elements replaced.
	/// </summary>
	/// <typeparam name="TSearch">The type of the elements to replace.</typeparam>
	/// <typeparam name="TReplace">The type of the elements to use instead.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IReplace<in TSearch, in TReplace, out TResult> {
		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
		[return: NotNull]
		TResult Replace([AllowNull] TSearch search, [AllowNull] TReplace replace);
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <typeparam name="TSearch">The type of the elements to replace.</typeparam>
		/// <typeparam name="TReplace">The type of the elements to use instead.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		/// <returns>The result of replacing <paramref name="search"/> with <paramref name="replace"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Replace<TSearch, TReplace, TResult>([AllowNull] this IReplace<TSearch, TReplace, TResult> collection, [AllowNull] TSearch search, [AllowNull] TReplace replace) => collection is not null ? collection.Replace(search, replace) : (TResult)collection;
	}
}
