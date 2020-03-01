// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0058:Expression value is never used", Justification = "It's fine, it's throwaways for testing")]
[assembly: SuppressMessage("Performance", "HAA0603:Delegate allocation from a method group", Justification = "It's test code, we're not worried about performance")]
