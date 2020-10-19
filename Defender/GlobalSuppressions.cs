// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "MA0048:File name must match type name", Justification = "We're intentionally splitting these up based on method name, since there's a large amount of method overloads in some cases.")]
[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "Absolutely not. Explicit typing yields far better maintainability.")]
