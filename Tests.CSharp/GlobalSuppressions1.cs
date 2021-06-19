// This file is used by Code Analysis to maintain SuppressMessage attributes that are applied to this project. Project-level suppressions either have no target or are given a specific target and scoped to a namespace, type, member, etc.
// Unlike the solution level GlobalSuppressions.cs that's linked into each project, this file is exclusive to tests, and suppresses things that would normally be an issue, but aren't because of the testing context.

using System.Diagnostics.CodeAnalysis;

[assembly: UnconditionalSuppressMessage("Documentation", "CS1591", Justification = "This is testing code, it's fine.")]

[assembly: SuppressMessage("Performance", "HAA0302:Display class allocation to capture closure", Justification = "This is testing code, it's fine.")]

[assembly: SuppressMessage("Usage", "xUnit1024:Test methods cannot have overloads", Justification = "This is fine if it's used only for the Object overloads.")]
