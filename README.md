[![Gitter](https://badges.gitter.im/Stringier/community.svg)](https://gitter.im/Stringier/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
[![Build Status](https://dev.azure.com/p-kell/Stringier/_apis/build/status/Entomy.Stringier?branchName=master)](https://dev.azure.com/p-kell/Stringier/_build/latest?definitionId=2&branchName=master)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/02ab838da67f4c929ef985b3f7d8a732)](https://www.codacy.com/app/Entomy/Stringier?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=Entomy/Stringier&amp;utm_campaign=Badge_Grade)
[![Beerpay](https://img.shields.io/beerpay/Entomy/Stringier.svg)](https://beerpay.io/Entomy/Stringier)

Stringier is a collection of projects to make working with text better.

Extension methods? ✔️ High performance parsing? ✔️ Support for modern conventions and APIs? ✔️ Easy to use? ✔️ Well documented? ✔️

Everyone works with text. Let's make it better.

# Documentation:

Thanks to [GitHub Pages](https://pages.github.com/), documentation is available [here](https://entomy.github.io/Stringier/)

Contributor documentation is provided [here](https://github.com/Entomy/Stringier/blob/master/CONTRIBUTING.md) and in the [wiki](https://github.com/Entomy/Stringier/wiki).

The goals and purpose of this project is provided [here](https://github.com/Entomy/Stringier/blob/master/GOALS_AND_PURPOSE.md)

# Subprojects: [![Nuget](https://img.shields.io/nuget/dt/Stringier?label=Meta%20Package&logo=nuget)](https://www.nuget.org/packages/Stringier/)

## [Extensions](https://github.com/Entomy/Stringier/tree/master/Extensions) [![Nuget](https://img.shields.io/nuget/dt/Stringier.Extensions.svg?label=Extensions&logo=Nuget)](https://www.nuget.org/packages/Stringier.Extensions/) [![Nuget](https://img.shields.io/nuget/dt/Stringier.Extensions.FSharp?label=F%23%20&logo=nuget)](https://www.nuget.org/packages/Stringier.Extensions.FSharp/)

**Stringier** was born out of my typical use case of C#: working with text. While I generally really like the language, it could be better. Some of this is syntax related. Some of this is missing features. This project exists to remedy that.

## [Patterns](https://github.com/Entomy/Stringier/tree/master/Patterns) [![Nuget](https://img.shields.io/nuget/dt/Stringier.Patterns.svg?label=Patterns&logo=nuget)](https://www.nuget.org/packages/Stringier.Patterns/) [![Nuget](https://img.shields.io/nuget/dt/Stringier.Patterns.FSharp?label=F%23%20&logo=nuget)](https://www.nuget.org/packages/Stringier.Patterns.FSharp/) [![Nuget](https://img.shields.io/nuget/dt/Stringier.Patterns.MSTest?label=MSTest&logo=nuget)](https://www.nuget.org/packages/Stringier.Patterns.MSTest/) [![Nuget](https://img.shields.io/nuget/dt/Stringier.Patterns.MSTest?label=NUnit&logo=nuget)](https://www.nuget.org/packages/Stringier.Patterns.NUnit/)

**Patterns** extends **Stringier** with further support for pattern declaration and parsing of those patterns. If you're doing a lot of text parsing or text processing, this is probably of interest to you.

## [Streams](https://github.com/Entomy/Stringier/tree/master/Streams) [![Nuget](https://img.shields.io/nuget/dt/Stringier.Streams?label=Streams&logo=nuget)](https://www.nuget.org/packages/Stringier.Streams/) [![Nuget](https://img.shields.io/nuget/dt/Stringier.Streams.FSharp?label=F%23&logo=nuget)](https://www.nuget.org/packages/Stringier.Streams.FSharp/)

**Streams** provides extensions to [`Stream`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream) to make it easier to work with text streams. This includes both new `Stream` types, and extension methods for all streams.
