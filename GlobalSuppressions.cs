// This file is used by Code Analysis to maintain SuppressMessage  attributes that are applied to the entire solution. This should be linked into each project.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Class Design", "AV1010:Member hides inherited member", Justification = "This is the point of the `new` keyword.")]
[assembly: SuppressMessage("Member Design", "AV1130:Return type in method signature should be a collection interface instead of a concrete type", Justification = "This shouldn't be done for performance and fluent-chaining reasons.")]
[assembly: SuppressMessage("Member Design", "AV1135:Do not return null for strings, collections or tasks", Justification = "Nullability attributes and analyzers are used to address this. It's better than throwing exceptions unexpectedly.")]
[assembly: SuppressMessage("Maintainability", "AV1500:Member or local function contains too many statements", Justification = "I agree with this in principal, but arbitrary limits are flawed.")]
[assembly: SuppressMessage("Maintainability", "AV1522:Assign each property, field, parameter or variable in a separate statement", Justification = "This is fine for certain situations. Needs human review.")]
[assembly: SuppressMessage("Maintainability", "AV1535:Missing block in case or default clause of switch statement", Justification = "Cases are already blocks.")]
[assembly: SuppressMessage("Maintainability", "AV1551:Method overload should call another overload", Justification = "Agreed, but this analyzer often doesn't understand design patterns for this.")]
[assembly: SuppressMessage("Maintainability", "AV1561:Signature contains too many parameters", Justification = "Especially when dealing with pointers, methods require many parameters.")]
[assembly: SuppressMessage("Maintainability", "AV1562:Do not declare a parameter as ref or out", Justification = "This is fine, well understood, a common CLR pattern, and necessary at times.")]
[assembly: SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "This is fine in many cases, and isn't worth suppressing all the times it is fine. Instead, human review has to catch bad naming.")]
[assembly: SuppressMessage("Layout", "AV2407:Region should be removed", Justification = "Regions are often used for grouping overloads.")]

[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "Absolutely not, being explicit is far better for readability.")]
[assembly: SuppressMessage("Design", "CC0031:Check for null before calling a delegate", Justification = "This analyzer doesn't work correctly.")]
[assembly: SuppressMessage("Usage", "CC0057:Unused parameters", Justification = "This analyzer doesn't work correctly.")]
[assembly: SuppressMessage("Style", "CC0105:You should use 'var' whenever possible.", Justification = "Absolutely not, being explicit is far better for readability.")]

[assembly: SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "There's a reason justification parameters exist, and are always filled out.")]

[assembly: SuppressMessage("Design", "MA0012:Do not raise reserved exception type", Justification = "This is fine when used in the right situations, like IndexOfOutRangeException.")]
[assembly: SuppressMessage("Design", "MA0048:File name must match type name", Justification = "Especially for large types, like extension method classes, it's easier to organize this way.")]
[assembly: SuppressMessage("Design", "MA0051:Method is too long", Justification = "I agree with this in principal, but arbitrary limits are flawed.")]
[assembly: SuppressMessage("Design", "MA0102:Make member readonly", Justification = "This analyzer doesn't work correctly.")]

[assembly: SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "This is fine when used in the right situations, like IndexOfOutRangeException.")]
[assembly: SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "https://www.youtube.com/watch?v=OLpeX4RRo28")]

[assembly: SuppressMessage("Usage", "xUnit1024:Test methods cannot have overloads", Justification = "This is fine if it's used only for the Object overloads.")]
