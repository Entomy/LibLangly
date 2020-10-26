using System.Diagnostics.CodeAnalysis;

namespace Philosoft {
	/// <summary>
	/// Provides extension methods for the traits in <see cref="Philosoft"/>.
	/// </summary>
	[SuppressMessage("Maintainability", "AV1551:Method overload should call another overload", Justification = "This entire thing essentially already does. Each extension method calls an instance method that does the same thing, but with additional protections in the event the caller is null.")]
	public static partial class Extensions { }
}
