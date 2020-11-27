namespace Langly {
	/// <summary>
	/// Provides batch operations.
	/// </summary>
	/// <remarks>
	/// This differs from <see cref="Text"/> in three major ways. First, is that these functions always take a collection of text elements. Second, is that these functions apply the operation to each text element individually, returning a new collection of the results, corresponding to each respective elements. As an example, consider testing for whether something contains something else. The <see cref="Text"/> variants will scan the entire parameter, even if it's a collection, and return a single result. The <see cref="Batch"/> variants scan the collection, returning a result for each text element of the collection. Third, is that these functions are never extension methods and must be explicitly called through <see cref="Batch"/>.
	/// </remarks>
	public static partial class Batch {
	}
}
