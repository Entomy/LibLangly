using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can be cleared.
	/// </summary>
	public interface IClear {
		/// <summary>
		/// Clears this collection.
		/// </summary>
		void Clear();
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Clears the <paramref name="collection"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void Clear([AllowNull] this IClear collection) => collection?.Clear();
	}
}
