// This file is used by Code Analysis to maintain SuppressMessage  attributes that are applied to the entire solution. This should be linked into each project.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Member Design", "AV1130:Return type in method signature should be a collection interface instead of a concrete type", Justification = "This shouldn't be done for performance and fluent-chaining reasons.")]
[assembly: SuppressMessage("Maintainability", "AV1551:Method overload should call another overload", Justification = "Agreed, but this analyzer often doesn't understand design patterns for this.")]
[assembly: SuppressMessage("Maintainability", "AV1562:Do not declare a parameter as ref or out", Justification = "This is fine, well understood, a common CLR pattern, and necessary at times.")]
[assembly: SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "This is fine in many cases, and isn't worth suppressing all the times it is fine. Instead, human review has to catch bad naming.")]
[assembly: SuppressMessage("Layout", "AV2407:Region should be removed", Justification = "Regions are often used for grouping overloads.")]

[assembly: SuppressMessage("Style", "CC0001:You should use 'var' whenever possible.", Justification = "Absolutely not, being explicit is far better for readability.")]
[assembly: SuppressMessage("Design", "CC0031:Check for null before calling a delegate", Justification = "This analyzer doesn't work correctly.")]
[assembly: SuppressMessage("Usage", "CC0057:Unused parameters", Justification = "This analyzer doesn't work correctly.")]
[assembly: SuppressMessage("Style", "CC0105:You should use 'var' whenever possible.", Justification = "Absolutely not, being explicit is far better for readability.")]

[assembly: SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "There's a reason justification parameters exist, and are always filled out.")]

[assembly: SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "https://www.youtube.com/watch?v=OLpeX4RRo28")]

[assembly: SuppressMessage("Usage", "xUnit1024:Test methods cannot have overloads", Justification = "This is fine if it's used only for the Object overloads.")]
