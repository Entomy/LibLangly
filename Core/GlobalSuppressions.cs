using System.Diagnostics.CodeAnalysis;

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: SuppressMessage("Design", "MA0048:File name must match type name", Justification = "When certain classes grow beyond a certain size, it's beneficial to split them up. This is why partial classes exist.")]
[assembly: SuppressMessage("Minor Code Smell", "S1116:Empty statements should be removed", Justification = "Well then implement better control structures.")]
[assembly: SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "Well then implement better control structures.")]
