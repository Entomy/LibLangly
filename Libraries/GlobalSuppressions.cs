// This file is used by Code Analysis to maintain SuppressMessage  attributes that are applied to the entire solution. This should be linked into each project.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Class Design", "AV1008:Class should not be static", Justification = "Static classes serve a purpose, hence their existance.")]
[assembly: SuppressMessage("Class Design", "AV1010:Member hides inherited member", Justification = "This isn't intrinsically a problem, and depends on the situation.")]
[assembly: SuppressMessage("Member Design", "AV1130:Return type in method signature should be a collection interface instead of a concrete type", Justification = "Better yet, the return type should be generic. I agree with this in theory, but in practice, no.")]
[assembly: SuppressMessage("Member Design", "AV1135:Do not return null for strings, collections or tasks", Justification = "Langly handles null specially so this is a non-issue.")]
[assembly: SuppressMessage("Maintainability", "AV1500:Member or local function contains too many statements", Justification = "What matters has a lot more to do with the complexity of the code and not the number of statements. ")]
[assembly: SuppressMessage("Maintainability", "AV1505:Namespace should match with assembly name", Justification = "This entire solution is using a different approach where multiple libraries overlay onto the same namespaces with the added features.")]
[assembly: SuppressMessage("Maintainability", "AV1506:File should be named in Pascal casing without underscores or generic arity.", Justification = "Too many types have analogues that vary only by their generic arity. It makes far more sense, then, to always name them with generic arity. Otherwise we, what, put multiple types in the same file?")]
[assembly: SuppressMessage("Maintainability", "AV1522:Assign each property, field, parameter or variable in a separate statement", Justification = "This is fine as long as people don't go crazy with it. I'm leaving this for human review.")]
[assembly: SuppressMessage("Maintainability", "AV1535:Missing block in case or default clause of switch statement", Justification = "Case's are already blocks, making this superfluous.")]
[assembly: SuppressMessage("Maintainability", "AV1537:If-else-if construct should end with an unconditional else clause", Justification = "This is too context insensitive. Either approach may be fine.")]
[assembly: SuppressMessage("Maintainability", "AV1551:Method overload should call another overload", Justification = "Typically, what's being done is these are extension methods calling an instance method. This will have to be reviewed by a human since the analyzer doesn't like this pattern.")]
[assembly: SuppressMessage("Maintainability", "AV1561:Signature contains too many parameters", Justification = "Generally this is true, and should be enforced. Excessive parameters are obnoxious. But it depends greatly and needs to be assessed by a human.")]
[assembly: SuppressMessage("Maintainability", "AV1562:Do not declare a parameter as ref or out", Justification = "I don't consider this a problem as long as its used reasonably. Strong type or tuple returns should generally be preferred but aren't always appropriate, especially with fluent pipelines.")]
[assembly: SuppressMessage("Layout", "AV2407:Region should be removed", Justification = "I'm using regions to group things like overloads with otherwise common behavior. They serve a very useful purpose.")]

[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "No. Explicit is better than implicit.")]
[assembly: SuppressMessage("Design", "CC0031:Check for null before calling a delegate", Justification = "This analyzer is broken. There are others which do the checks correctly.")]
[assembly: SuppressMessage("Usage", "CC0057:Unused parameters", Justification = "This analyzer is broken. There are others which do the checks correctly.")]
[assembly: SuppressMessage("Style", "CC0105:You should use 'var' whenever possible.", Justification = "No. Explicit is better than implicit.")]

[assembly: SuppressMessage("Design", "MA0018:Do not declare static members on generic types", Justification = "This is clearly the path Microsoft is taking with more modern stuff, as especially evident with Memory<T> and Span<T>. It makes more sense to stay orthogonal to expectations. Not doing this will often require the creation of a second static class just for this purpose, which will cause confusion about which variant has which operations.")]
[assembly: SuppressMessage("Design", "MA0048:File name must match type name", Justification = "I'm using a design in which generic types have file names with `x where x is the number of generic parameters. This is useful in the many cases where multiple types only differ by these parameters.")]
[assembly: SuppressMessage("Style", "MA0071:Avoid using redundant else", Justification = "This is too context insensitive. Either approach may be fine.")]
[assembly: SuppressMessage("Design", "MA0095:A class that implements IEquatable<T> should override Equals(object)", Justification = "It often is, but this analyzer doesn't check for a base class providing one of these.")]

[assembly: SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "I'm fine with goto as long as it's not abused. It can, in certain cases, actually result in easier to read code. It's often required in text processing where needed control structures aren't available in most languages.")]
[assembly: SuppressMessage("Major Code Smell", "S1168:Empty arrays and collections should be returned instead of null", Justification = "Langly handles null specially so this is a non-issue.")]
