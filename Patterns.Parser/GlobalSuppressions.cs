using System.Diagnostics.CodeAnalysis;

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "Well tell that to Microsoft. You shouldn't be readily using goto's. However certain domains, especially text processing, is remarkably unsuited for common languages and simply lacks more specialized control structures. Because we don't have those, goto has to be allowed.")]
