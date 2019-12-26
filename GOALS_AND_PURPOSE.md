# Goals & Purpose

This document exists to elaborate on the goals and purpose of this project. Matters are listed in order of priority, from highest to lowest. This document should be treated as a perscriptive design.

This document will not use overloaded or vague buzzwords, such as "simple" or "elegant", as these words are so overused that they mean drastically different and unrelated things between people. Instead, specific words with detailed explainations are used. If you do not beleive something is clear enough, that should be treated as an [issue](https://github.com/Entomy/Stringier/issues/new/choose), so request clarification.

## Usability

First and foremost, this project exists to be highly usable. People do not use things that are difficult to use. People do not encourage others to use things that are difficult to use. High usability is acheived through several means, all equally as important.

### Good documentation

Everything should be documented, both external and internal API's. This project makes use of [docfx](https://github.com/dotnet/docfx) to provide a documentation website. As such, providing good documentation is just a matter of maintaining doc-comments and a few articles. These doc-comments describe the API and intended behavior. Any deviation of the code is likely an error, but file an [issue](https://github.com/Entomy/Stringier/issues/new/choose) so the matter can be looked into.

### Consistent API

The API should behave as consistently as possible. This means orthagonality is a high priority, but not necessarily absolute orthagonality. If you've worked with alternative parsing engines, especially parser combinators, you may have encountered how drastically different the return types can be. This is not considered acceptable. Users should not have to memorize which parsers have which return type, nor change their code because of a change to their parser.

See: [Principal of Least Astonishment](https://en.wikipedia.org/wiki/Principle_of_least_astonishment); [Krug, S. Don't Make Me Think](http://www.sensible.com/dmmt.html)

Aside: [Patterns](https://github.com/Entomy/Stringier/tree/master/Patterns) provides a parsing engine, not a full blown parser, and this is by design. Everything it returns is basically a `String` (not actually, as it uses [`Result`](https://entomy.github.io/Stringier/api/Stringier.Patterns.Result.html), but it's readily and implicitly converted to `String`). Because this approach was designed to be resumable, a parser can provide return types like [`IEnumerable<>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) or a full parse tree, while the engine has consistent and predictable behavior.

### Clean API

The API should be as clean as possible. This means as few parameters as absolutely possible to still acheive the necessary function, with as much encapsulation as appropriate. This is part of the reason why [`Result`](https://entomy.github.io/Stringier/api/Stringier.Patterns.Result.html) and [`Source`](https://entomy.github.io/Stringier/api/Stringier.Patterns.Source.html) exist; they encapsulate various individual fields into one conceptual unit that is much easier to work with. Encapsulation must be logically consistent, and should not be done purely to reduce parameter count. This also means that there should be as few calls as possible to do what is meant. `String("Hello").Then(String("World"))` is rediculous; use extension methods to get `"Hello".Then("World")`. The methods should [Do The Right Thing](https://en.wikipedia.org/wiki/DWIM).

### Do The Right Thing

Also called [Do What I Mean](https://en.wikipedia.org/wiki/DWIM). This means that the API should strive to translate descriptions and intent, not literal commands, into executable action. This forms the basis of [Self Optimization](https://entomy.github.io/Stringier/articles/patterns-optimization.html) that the parsing engine uses.

In absolutely no way should "the right thing" be taken as "fixing mistakes". Any changes must have no change in actual behavior, just in execution. For example, there's no point in processing a double negation, as the outcome of no negation at all is exactly the same and executes faster. Mistakes are mistakes and need to be fixed by the programmer. Autocorrect is not "the right thing".

### Feels Right

The API should "feel right" within the context of the language being used. This means a [`CLSCompliant`](https://docs.microsoft.com/en-us/dotnet/api/system.clscompliantattribute) core with language specific bindings when necessary to provide that feeling. Programmers should not have to suddenly and radically change programming paradigms just to use a library; this is jarring and discouraging. However, by relying on a [`CLSCompliant`](https://docs.microsoft.com/en-us/dotnet/api/system.clscompliantattribute) core, the same approach can be used across all languages if necessary, keeping the learning curve lower. Neither approach is forced, and this is actually very easy to maintain.

## Performance

Performance should be good. Being the highest performing parser is not the end goal, but performance should be competitive with existing solutions, and ideally be in the top quarter of performers. Understanding performance is very important, and extensive benchmarks should be kept, and publicly accessible, to ensure performance is reasonable.