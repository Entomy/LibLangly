namespace Langly {
	/// <summary>
	/// Unsafe variants of algorithms.
	/// </summary>
	/// <remarks>
	/// <para>These are typically unsafe because they aren't type safe, don't have guarded parameters, etc. Whether generic or weakly typed, they are highly adaptable though. Intended use is to use this to implement a safe variant of the method for downstream use, but the unsafe method internally.</para>
	/// <para>These also slightly optimize many cases, as type information isn't necessary so the creation of a struct or ref struct never needs to happen.</para>
	/// </remarks>
	internal static partial class Unsafe { }
}
