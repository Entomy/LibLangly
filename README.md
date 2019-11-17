[![Build Status](https://dev.azure.com/p-kell/Stringier/_apis/build/status/Entomy.Stringier?branchName=master)](https://dev.azure.com/p-kell/Stringier/_build/latest?definitionId=2&branchName=master)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/02ab838da67f4c929ef985b3f7d8a732)](https://www.codacy.com/app/Entomy/Stringier?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=Entomy/Stringier&amp;utm_campaign=Badge_Grade)
[![Beerpay](https://img.shields.io/beerpay/Entomy/Stringier.svg)](https://beerpay.io/Entomy/Stringier)

Stringier is a collection of projects to make working with text better.

Extension methods? ✔️ High performance parsing? ✔️ Easy to use? ✔️

Everyone works with text. Let's make it better.

# Documentation:

Thanks to [GitHub Pages](https://pages.github.com/), documentation is available [here](https://entomy.github.io/Stringier/)

# Subprojects:

## [Extensions](https://github.com/Entomy/Stringier/tree/master/Extensions) [![Nuget](https://img.shields.io/nuget/dt/Stringier.svg?label=Stringier&logo=Nuget)](https://www.nuget.org/packages/Stringier/)


**Stringier** was born out of my typical use case of C#: working with text. While I generally really like the language, it could be better. Some of this is syntax related. Some of this is missing features. This project exists to remedy that.

## [Stringier.Patterns](https://github.com/Entomy/Stringier/tree/master/Stringier.Patterns) [![Nuget](https://img.shields.io/nuget/dt/Stringier.Patterns.svg?label=Stringier.Patterns&logo=nuget)](https://www.nuget.org/packages/Stringier.Patterns/) [![Nuget](https://img.shields.io/nuget/dt/Stringier.Patterns.FSharp?label=F%23%20Extension&logo=nuget)](https://www.nuget.org/packages/Stringier.Patterns.FSharp/)


**Stringier.Patterns** extends **Stringier** with further support for pattern declaration and parsing of those patterns. If you're doing a lot of text parsing or text processing, this is probably of interest to you.

## [Stringier.Patterns.Testing](https://github.com/Entomy/Stringier/tree/master/Stringier.Patterns.Testing) [![Nuget](https://img.shields.io/nuget/dt/Stringier.Patterns.Testing?label=Stringier.Patterns.Testing&logo=nuget)](https://www.nuget.org/packages/Stringier.Patterns.Testing/)

**Stringier.Patterns.Testing** extends [MSTest](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest) with special asserters used for testing correct behavior of **Stringier.Patterns**. This has been packaged to help others with testing and debugging their patterns.
