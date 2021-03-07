# Contributing

Who can contribute? **Anyone**.

What do you need to contribute? The most recent version of [.NET](https://dotnet.microsoft.com/) is recommended. This document is not going to track the actual lowest required version. Chances are if you've got [.NET](https://dotnet.microsoft.com/) installed somehow you're good to go right now. That's it. The barrier for contributions was kept extremely low for this project because honestly how wants to spend several hours setting up a development environment just to fix some broken shit? Naw fam. [Visual Studio](https://visualstudio.microsoft.com/vs/) will provide the overall best experience, as this project does make use of `.dgml` and `.cd` documents to assist with understanding components, but in no way is the code or build system tied directly to an IDE or editor. Analyzers, code coverage, and everything else is set up through [`Nuget`](https://www.nuget.org/) packages and will work anywhere, even the command line. 

Nevertheless, there are common expectations:

1. _Firstly_, contributors should file an issue about the change. This lets maintainers know there's demand, and allows thought and discussion about the implementation to begin. There may be good reason why the issue should not be implemented, and it's better to find this out early than have your work and time go wasted.
2. Get assigned to that issue.
3. Fork the repository.
4. Create a _draft_ pull request related to the issue. This lets maintainers know the issue is being worked on.
5. Document your code. This does not necessarily have to include articles, but must have documentation comments on at least the public members. Sufficiently complex functionality will require additional documentation regardless of its accessibility modifiers. 
6. Write any necessary tests for new features; all tests must pass.
7. Write any necessary benchmarks for new features.
8. Build the project in `Release` mode.
9. Run the benchmarks
10. Take the pull request out of draft status and have it reviewed.
11. Comply with relevant feedback.

*Note*: Because **LibLangly** is partially a _runtime_ library there are native system bindings used quite often throughout. Despite this being a .NET project, it should conceptually be treated like it were native code. Many packages have platform specific monikers and include conditional code for different platforms. You should familiarize yourself with [Target Frameworks](https://docs.microsoft.com/en-us/dotnet/standard/frameworks), [Platform Attributes](https://docs.microsoft.com/en-us/dotnet/standard/analyzers/platform-compat-analyzer), and [C# Directives](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives/) if working with these components.