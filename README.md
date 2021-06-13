# LibLangly

[![Discord](https://img.shields.io/discord/767866895457714186?label=Chat&logo=discord&logoColor=white)](https://discord.com/channels/767866895457714186)
[![Build Status](https://dev.azure.com/p-kell/Langly/_apis/build/status/Entomy.LibLangly?branchName=master)](https://dev.azure.com/p-kell/Langly/_build/latest?definitionId=36&branchName=master)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/d84f62c513064441a2d6213c58406d8d)](https://www.codacy.com/gh/Entomy/LibLangly/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=Entomy/LibLangly&amp;utm_campaign=Badge_Grade)
[![CLA assistant](https://cla-assistant.io/readme/badge/Entomy/LibLangly)](https://cla-assistant.io/Entomy/LibLangly)
[![GitHub](https://img.shields.io/github/license/Entomy/LibLangly)](https://github.com/Entomy/LibLangly/blob/master/LICENSE)

**LibLangly** is a collection of closely related libraries that, once upon a time, lived in separate repositories. That was confusing for everyone. Read on for information about the various constituent projects.

## Collectathon [![Nuget](https://img.shields.io/nuget/dt/Collectathon?label=Collectathon&logo=nuget)](https://www.nuget.org/packages/Collectathon)

You ever find yourself regularly looking at the documentation of collection types because there's all these little variations in their public API's and how similarly named things behave? You ever find yourself trying to optimize code and rewriting parts to conform with these differences? You ever find yourself wondering _why_ a collection doesn't support an operation you know it can support? **Collectathon** works to solve all of these, and more. It utilizies **Philosoft** to employ a consistent and predictable interface, making discovery and changes as easy as possible.

But **Collectathon** isn't _just_ a collection of... collections. To make things easier on me, there's a framework for creating new collections with as much code sharing as possible. This means everything has better test coverage and can be designed quicker. And best of all, this framework is public and you can use it too!

## Langly [![Nuget](https://img.shields.io/nuget/dt/Langly?label=Langly&logo=nuget)](https://www.nuget.org/packages/Langly/)

Parsing languages is complicated. Handling languages with customizable syntax is even more complicated. **LibLangly** works to make this as easy and pleasant as possible.

## Numbersome [![Nuget](https://img.shields.io/nuget/dt/Numbersome?label=Numbersome&logo=nuget)](https://www.nuget.org/packages/Numbersome/)

Look, I'll talk everything else up, but this is the least useful set of libraries in this entire project. It's just some basic convenience functions and a demonstration of how to use **Philosoft** for designing highly generalized operations. If you're using this with **Collectathon**, you can get math operations directly on the collections, which is pretty nice. If you're doing any serious work with math, you want a major math library, which there's many of.

But there's a few exceptions!

`Set` is something for which I find the common design contentious; I've written about this [before](https://dev.to/entomy/iset-t-considered-harmful-2hpd). **Numbersome** implements a `Set` type with a much stricter adherence to set theory and set algebra, allowing for easier translations from literature to code. It also serves as the foundational type for some other parts of **LibLangly**.

`Random` is, similarly, something for which I find the design contentious. **Numbersome**'s `Random` is a `Stream`, based off **Streamy**, and provides substantially broader type coverage. You can generate random values for any of the primative standard types, easily extend `Random` to generate new types, can generate random values within defined bounds, or even create generators which can be iterated over. In pratice, this has shown highly useful not just as an easier to use random number generator, but also for testing.

## Philosoft [![Nuget](https://img.shields.io/nuget/dt/Philosoft?label=Philosoft&logo=nuget)](https://www.nuget.org/packages/Philosoft/)

Good software architecture is a challenge. I've shot myself in the foot with some past design decisions, and I don't want to see others do the same. Ultimately, architectural designs are opinions, and **Philosoft** takes the opinion that trait-based design is easier to reason about and leads to better code reuse. In practice? I've gotten sometimes as much as 30% reduction in SLOC, and find myself having a much easier time working with my own designs. If you use these traits, not only can you see comparable benefits, but all of my additional libraries are tied to these traits, so will work with your own types as well.

## Streamy [![Nuget](https://img.shields.io/nuget/dt/Streamy?label=Streamy&logo=nuget)](https://www.nuget.org/packages/Streamy/)

Streams are one of the most powerful design abstractions out there, and yet consistently run into some of the worst designs in practice. **Streamy** was born out of a need I had, that you might have run into as well. How do I parse a stream of text? This would enable all sorts of incredibly useful scenarios. But current stream API designs typically only work with `byte`, and expect the developer to manage additional buffers for backtracking, manage decoding themselves, etc. Or alternatively, manage multiple types like both the `Stream` and a `StreamReader`, which use independent buffers which can get out of sync, causing massive problems. **Streamy** internalizes all of this, dealing with these problems _for you_.

Eventually, it became clear these goals couldn't be acheived through simple extensions, and the whole stream architecture needed to be rewritten. This introduced a great opportunity to address numerous OWASP security concerns about serialization, and implement their many suggestions to secure streaming complex types.

Then it became clear most stream API's make one of the cardinal sins of distributed computing, where you see streams used the most: they make assumptions about the underlying hardware. **Streamy** lets you dictate matters like the endianness of the stream or the specific encoding of text. This way, heterogenous computing environments can all easily set up the same standard for communication.

## Stringier [![Nuget](https://img.shields.io/nuget/dt/Stringier?label=Stringier&logo=nuget)](https://www.nuget.org/packages/Stringier/)

Text processing is complicated, let's make it better.

No seriously. Text processing is _really_ complicated, and rife with all sorts of easily forgettable pitfalls. **Stringier** works to provide everything you need, from text manupulation, string search, and edit distance algorithms, to advanced text types, to one of the fastest and most light weight text parsing frameworks in existance. You shouldn't need to understand the intricacies of UNICODE, encoding formats, grapheme cluster boundaries, or language; that's my job, and **Stringier** makes your job easier.