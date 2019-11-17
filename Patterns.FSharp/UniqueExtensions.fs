namespace Stringier.Patterns

[<AutoOpen>]
module UniqueExtensions =

    let inline kleene pattern = option(span(pattern))