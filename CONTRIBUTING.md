# Contributing

**LibLangly** utilizes a tiered or hierarchial `CONTRIBUTING.md` system, whereby any component will have its own `CONTRIBUTING.md` explaining the procedure for contributions to that component. This is increasingly granular, with each component potentially having more and more specific rules. Generally speaking you will be able to read a `CONTRIBUTING.md` file in the directory you're working in that explains what is expected for contributors.

Who can contribute? **Anyone**.

What do you need to contribute? The most recent version of [.NET](https://dotnet.microsoft.com/) is recommended. This document is not going to track the actual lowest required version. Chances are if you've got [.NET](https://dotnet.microsoft.com/) installed somehow you're good to go right now. That's it. The barrier for contributions was kept extremely low for this project because honestly how wants to spend several hours setting up a development environment just to fix some broken shit? Naw fam. [Visual Studio](https://visualstudio.microsoft.com/vs/) will provide the overall best experience, as this project does make use of `.dgml` and `.cd` documents to assist with understanding components, but in no way is the code or build system tied directly to an IDE or editor.

Nevertheless, there are common expectations that are laid out here.

1. _Firstly_, contributors should file an issue about the change. This lets maintainers know there's demand, and allows thought and discussion about the implementation to begin. There may be good reason why the issue should not be implemented, and it's better to find this out early than have your work and time go wasted.
2. Get assigned to that issue.
3. Fork the repository.
4. Create a _draft_ pull request related to the issue. This lets maintainers know the issue is being worked on.
5. Implement the contributions with respect to that components `CONTRIBUTING.md`.
6. Document your code. This does not necessarily have to include articles, but must have documentation comments on at least the public members. Sufficiently complex functionality will require additional documentation regardless of its accessibility modifiers. 
7. Write any necessary benchmarks for new features.
8. Write any necessary tests for new features; all tests must pass.
9. Take the pull request out of draft status and have it reviewed.
10. Comply with relevant feedback.
