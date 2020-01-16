using System.Diagnostics.CodeAnalysis;

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: SuppressMessage("Design", "MA0048:File name must match type name", Justification = "Certain classes grow to absolutely massive sizes, and are easier to organize based on concept or method overload. This is why partial classes are a thing.")]
[assembly: SuppressMessage("Security", "MA0023:Add RegexOptions.ExplicitCapture", Justification = "There's no capturing even happening. Why do you think there is here?")]
[assembly: SuppressMessage("Usage", "MA0011:IFormatProvider is missing", Justification = "In many cases these are mappings, and when they aren't, the default behavior is appropriate. If passing a formatter was appropriate, the method would have a formatter parameter as well.")]
[assembly: SuppressMessage("Performance", "MA0008:Add StructLayoutAttribute", Justification = "Why? If there's no explicit layout it's because I don't care and the compiler is free to do whatever it wants. The compiler understands the performance implications better than I do. Explicit layouts are only for atypical cases like protocols or unions.")]
[assembly: SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "Well tell that to Microsoft. You shouldn't be readily using goto's. However certain domains, especially text processing, is remarkably unsuited for common languages and simply lacks more specialized control structures. Because we don't have those, goto has to be allowed.")]
