// This file is used by Code Analysis to maintain SuppressMessage  attributes that are applied to the entire solution. This should be linked into each project.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Class Design", "AV1010:Member hides inherited member", Justification = "This isn't intrinsically a problem, and depends on the situation.")]
[assembly: SuppressMessage("Maintainability", "AV1535:Missing block in case or default clause of switch statement", Justification = "Case's are already blocks, making this superfluous.")]
