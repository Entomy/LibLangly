using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Letter case comparison mode.
	/// </summary>
	[SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Where to begin on this one? First of all, assuming every language uses the same keywords as C# is irresponsible at best, and wrong at worst. And it is wrong. Additionally, the terminology for this is quite literally \"casing\", or, to be grammatically correct with how it's used at the callsite: \"case\".")]
	public enum Case {
		/// <summary>
		/// Comparisons should be done without regards to letter casing.
		/// </summary>
		Insensitive = 0,

		/// <summary>
		/// Comparisons should be done with regards to letter casing.
		/// </summary>
		Sensitive = 1,
	}
}
