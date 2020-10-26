// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Maintainability", "AV1506:File should be named in Pascal casing without underscores or generic arity.", Justification = "Okay, so we what? Put multiple types in the same file? No! That's even worse for maintainability!")]
[assembly: SuppressMessage("Design", "MA0048:File name must match type name", Justification = "We're intentionally splitting these up based on method name, since there's a large amount of method overloads in some cases.")]
[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "Absolutely not. Explicit typing yields far better maintainability.")]
[assembly: SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Any argument exception formats the message in a specific way, ensuring consistent output. Exluding the parameterless constructor helps will keeping people from throwing an exception about an argument with no information about the argument.")]
[assembly: SuppressMessage("Design", "RCS1194:Implement exception constructors.", Justification = "Any argument exception formats the message in a specific way, ensuring consistent output. Exluding the parameterless constructor helps will keeping people from throwing an exception about an argument with no information about the argument.")]
[assembly: SuppressMessage("Usage", "MA0015:Specify the parameter name", Justification = "There isn't a single analyzer that's going to understand the exception pattern occuring here.")]
[assembly: SuppressMessage("Class Design", "AV1010:Member hides inherited member", Justification = "This is fine in certain situations and even part of a pattern at times; whether this is acceptable or not has to be assessed by human reviewer.")]
[assembly: SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "Then implement better control structures.")]
[assembly: SuppressMessage("Class Design", "AV1008:Class should not be static", Justification = "Oh, everything that isn't explicit object-oriented is badly designed code is it? There's massive bodies of design research that disagrees. So do my previously gathered benchmarks.")]
[assembly: SuppressMessage("Layout", "AV2407:Region should be removed", Justification = "I would LOVE to see someone develop a very complex system without ever resorting to regions or partial classes. Above a certain threshold these actually help maintainability, and we're well above that threshold.")]
[assembly: SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "When this fits with a convention, such as i/j for iteration variables, or n for node traversal, this is acceptable. Ideally this analyzer would be convention aware, but since it isn't a human has to review this.")]
[assembly: SuppressMessage("Maintainability", "AV1500:Member or local function contains too many statements", Justification = "This is entirely dependent on cognitive complexity and functional boundaries, not SLOC; a human must review this.")]
[assembly: SuppressMessage("Style", "CC0105:You should use 'var' whenever possible.", Justification = "Absolutely not.")]
[assembly: SuppressMessage("Maintainability", "AV1562:Do not declare a parameter as ref or out", Justification = "This depends so much on what data is actually being worked with. Oftentimes, yes, a fully declared object should be returned. However sometimes you have loosely coupled data that's relevant only for a particular operation. These can also be very important for performance reasons. A human has to review appropriate calling convetions.")]
[assembly: SuppressMessage("Maintainability", "AV1522:Assign each property, field, parameter or variable in a separate statement", Justification = "I don't necessarily have a problem with this, but it depends how much is going on. Other than increment/decrement this generally won't be tollerated.")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "If this is because the method conceptually only works on that type, and the type is either the caller or primary, this is acceptable.")]
