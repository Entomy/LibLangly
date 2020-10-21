// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "MA0048:File name must match type name", Justification = "We're intentionally splitting these up based on method name, since there's a large amount of method overloads in some cases.")]
[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "Absolutely not. Explicit typing yields far better maintainability.")]
[assembly: SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Any argument exception formats the message in a specific way, ensuring consistent output. Exluding the parameterless constructor helps will keeping people from throwing an exception about an argument with no information about the argument.")]
[assembly: SuppressMessage("Design", "RCS1194:Implement exception constructors.", Justification = "Any argument exception formats the message in a specific way, ensuring consistent output. Exluding the parameterless constructor helps will keeping people from throwing an exception about an argument with no information about the argument.")]
[assembly: SuppressMessage("Usage", "MA0015:Specify the parameter name", Justification = "There isn't a single analyzer that's going to understand the exception pattern occuring here.")]
[assembly: SuppressMessage("Class Design", "AV1010:Member hides inherited member", Justification = "This is fine in certain situations and even part of a pattern at times; whether this is acceptable or not has to be assessed by human reviewer.")]
[assembly: SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "Then implement better control structures.")]
[assembly: SuppressMessage("Class Design", "AV1008:Class should not be static", Justification = "Oh, everything that isn't explicit object-oriented is badly designed code is it? There's massive bodies of design research that disagrees. So do my previously gathered benchmarks.")]
