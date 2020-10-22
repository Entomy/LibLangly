// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Layout", "AV2407:Region should be removed", Justification = "I would LOVE to see someone develop a very complex system without ever resorting to regions or partial classes. Above a certain threshold these actually help maintainability, and we're well above that threshold.")]
