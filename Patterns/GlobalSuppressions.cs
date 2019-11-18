using System.Diagnostics.CodeAnalysis;

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: SuppressMessage("Minor Code Smell", "S3604:Member initializer values should not be redundant", Justification = "Explicit is more clear than implicit. This is important not just for clarity, but also where the typical implicit rules are violated (String is a reference type, who's default initialization is not null like you would expect). I strongly disagree with Sonar on this matter.")]
[assembly: SuppressMessage("Minor Code Smell", "S3626:Jump statements should not be redundant", Justification = "This is another case of explicit being better than implicit. Curly brace delimited languages admittedly aren't the easiest of languages to understand, and many people don't have access to or can't afford tools to work around this issue. So being clear about \"we're done here\" in larger methods considerably improves readability, regardless of what Sonar thinks.")]
[assembly: SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "Well tell that to Microsoft. You shouldn't be readily using goto's. However certain domains, especially text processing, is remarkably unsuited for common languages and simply lacks more specialized control structures. Because we don't have those, goto has to be allowed.")]

// You'll notice overwhelming supressions of Sonar issues, with little if any supressions of Microsoft.Analyzers, Roslynator, ErrorProne.NET and others. All of these are being used by me. One of them is... severely inaccurate.