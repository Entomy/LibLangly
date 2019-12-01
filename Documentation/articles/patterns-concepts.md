# Patterns Concepts

**Stringier's** ***Patterns*** is a parsing engine with a radically different approach from what you're probably familiar with. It was primarily designed with reusability of patterns in mind, and general usability second. That being said, it happens to be extremely fast and lightweight, without being theory heavy.

It's also a CLS Compliant, cross language library, and will work on at least [C#](https://en.wikipedia.org/wiki/C_Sharp_%28programming_language%29), [VisualBasic](https://en.wikipedia.org/wiki/Visual_Basic_.NET), and [F#](https://en.wikipedia.org/wiki/F_Sharp_(programming_language)).

## Pattern

Patterns form the base of this system. Similar to how patterns work in **Regex**, they represent what the parser will attempt to parse. However that's basically the end of the similarities.

`Pattern` is a first class type. `Regex` lives inside of [String](https://docs.microsoft.com/en-us/dotnet/api/system.string). This has a major implication: You work with `Pattern` with whatever [.NET](https://dotnet.microsoft.com/) language you feel like. You assign them to proper variables, and can combine them. No [copypasta](https://www.urbandictionary.com/define.php?term=copypasta).

`Pattern` was designed for complex grammars. `Regex` was designed for [regular languages](https://en.wikipedia.org/wiki/Regular_language), one of the simpliest forms of language. This makes `Pattern` far more capable in what it can parse. In fact, the features of **Patterns** was designed around needing to parse complex languages like programming languages. As of [this commit](https://github.com/Entomy/Stringier/commit/ad8fb5719d8e6c4a8843f2dc47385daba6270854) `Pattern` has provably supported right-recursion and mutual-recursion. And since parsers are separate from the pattern representation, a left-recursive supporting parser would be able to support left-recursion as well, but this hasn't been implemented yet.

### Literal

Literals in the context of `Pattern` are just like literals in your programming language. In fact, they are even the same thing.

~~~~csharp
Pattern ImplicitExample = "Hello";
Pattern ExplicitExample = "Hello".AsPattern();
~~~~
~~~~fsharp
let example = p"Hello";
~~~~

We now have a pattern, named `Example`, which is literally `Hello`. On its own, this isn't very useful, but it does make for an efficient building block.

Whenever possible, an implicit conversion from `Char` or `String` to `Pattern` will occur. The exact rules about this will depend on your programming language. You may need to occasionally cast to `Pattern`, especially at the start of combinators of literals.

It's worth noting as an implementation detail, unlike [Parser Combinators](https://en.wikipedia.org/wiki/Parser_combinator) like [parsec](https://wiki.haskell.org/Parsec) or [Bennu](http://bennu-js.com/) the base component is not a `Char`, but rather, any literal. There are literals defined for `Char` and `String`, as well as some advanced concepts that will be covered in later articles. This is extremely important for performance reasons, even though it's not obvious why. In the spirit of fairness, there are rare [Parser Combinators](https://en.wikipedia.org/wiki/Parser_combinator) that do token based parsing (basically built up from `String`), such as [Superpower](https://github.com/datalust/superpower).

### Modifier

Modifiers _modify_ patterns. This includes concepts like making a pattern optional, or negating a pattern.

### Combinator

Combinators _combine_ patterns. This includes concepts like concatenation or alternates.

## Source

`Source` is a buffer that keeps track of the position during and after parsing operations. Importantly, it always reverts back to the starting position if a parse fails. This position is not manipulatable from code outside of the library, so there is no (easy) ability to tamper. (Abuse through reflection is technically always possible). New parsing operations always occur at the current position, so you don't need to manage anything. `Source` objects can be construction both from `Stream` and `String`, among others.

## Result

`Result` holds the result state of parser operations. It contains both the matched text, and a success/failure state. The exact implementation of these is subject to change, but this type will always be castable to `String` and `Boolean`, and if allowed, will implicitly convert to those types.

## Parsers

Very unique to **Patterns** is multiple parsing models. Because my own needs are well met from a very particular set of parsers, I'm not focused on implementing as many as possible. However care was taken to keep the patterns purely descriptive, so that theoretically any parsing approach could be implemented.

### Consume

This parser tries to match the `Pattern` starting at the very beginning of the `Source` (or where it last left off), and returns a `Result`. It is naively like prefixing a `^` anchor to every `Regex`. This is generally the parser you want to use, as it parses from left to right in as obvious of a way as possible.

For the non-technically minded, this works as close to how you would normally read as possible, reading in your normal word order, and considering alternates in order.

For the technically minded, this seems to be closest to a PEG parser, although it wasn't designed with any particular grammar nor algorithm in mind, so this may not be 100% accurate. `Consume` definately considers the order important, however.

### Others

There are other parsers planned, and I will do my best to maintain this documentation with new descriptions of them.
