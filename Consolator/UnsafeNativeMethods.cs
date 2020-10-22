using System.Diagnostics.CodeAnalysis;
using System.Security;

namespace Consolator {
	/// <summary>
	/// Provides bindings to native methods.
	/// </summary>
	[SuppressUnmanagedCodeSecurity]
	[SuppressMessage("Class Design", "AV1008:Class should not be static", Justification = "This is the appropriate name for p/invoke bindings... CA1060 is very clear about this.")]
	[SuppressMessage("Maintainability", "AV1562:Do not declare a parameter as ref or out", Justification = "These are p/invoke bindings, we don't have a choice how things are called or passed.")]
	internal static partial class UnsafeNativeMethods {
	}
}
