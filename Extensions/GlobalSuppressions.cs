using System.Diagnostics.CodeAnalysis;

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: SuppressMessage("Design", "MA0048:File name must match type name", Justification = "When certain classes grow beyond a certain size, it's beneficial to split them up. This is why partial classes exist.")]
[assembly: SuppressMessage("Security", "MA0023:Add RegexOptions.ExplicitCapture", Justification = "There's no capturing even happening. Why do you think there is here?")]
[assembly: SuppressMessage("Usage", "MA0011:IFormatProvider is missing", Justification = "In many cases these are mappings, and when they aren't, the default behavior is appropriate. If passing a formatter was appropriate, the method would have a formatter parameter as well.")]
[assembly: SuppressMessage("Performance", "MA0008:Add StructLayoutAttribute", Justification = "Why? If there's no explicit layout it's because I don't care and the compiler is free to do whatever it wants. The compiler understands the performance implications better than I do. Explicit layouts are only for atypical cases like protocols or unions.")]
