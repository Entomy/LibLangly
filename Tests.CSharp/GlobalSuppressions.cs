// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "xUnit1024:Test methods cannot have overloads", Justification = "As long as this is carefully done, it's fine. This is often required with testing ToString() without using a different name for it. Everything is far clearer if the test matches the name.")]
