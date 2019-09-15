# Stringier.Patterns Concepts

**Stringier.Patterns** is a parsing engine with a radically different approach from what you're probably familiar with. It was primarily designed with reusability of patterns in mind, and general usability second. That being said, it happens to be extremely fast and lightweight, without being theory heavy.

It's also a cross language library, and will work on at least [C#](https://en.wikipedia.org/wiki/C_Sharp_%28programming_language%29), [VisualBasic](https://en.wikipedia.org/wiki/Visual_Basic_.NET) and [F#](https://en.wikipedia.org/wiki/F_Sharp_(programming_language)).

## Pattern

Patterns form the base of this system. Similar to how patterns work in **Regex** they represent what the parser will attempt to parse. However that's basically the end of the similarities.

`Pattern` is a first class type. `Regex` lives inside of [String](https://docs.microsoft.com/en-us/dotnet/api/system.string). This has a major implication: You work with `Pattern` with whatever [.NET](https://dotnet.microsoft.com/) language you feel like. You assign them to proper variables, and can combine them. No [copypasta](https://www.urbandictionary.com/define.php?term=copypasta).

`Pattern` was designed for complex grammars. `Regex` was designed for [regular languages](https://en.wikipedia.org/wiki/Regular_language), one of the simpliest forms of language. This makes `Patter` far more capable in what it can parse. In fact, the features of **Stringier.Patterns** was designed around needing to parse complex languages like programming languages.

### Literal

Literals in the context of `Pattern` are just like literals in your programming language. In fact, they are even the same thing.

~~~~csharp
Pattern Example = "Hello";
~~~~

We now have a pattern, named `Example`, which is literally `hello`. On its own, this isn't very useful, but it does make for an efficient building block.

Whenever possible, an implicit conversion from `Char` or `String` to `Pattern` will occur. The exact rules about this will depend on your programming language. You may need to occasionally cast to `Pattern`, especially at the start of combinators of literals.

It's worth noting as an implementation detail, unlike [Parser Combinators](https://en.wikipedia.org/wiki/Parser_combinator) like [parsec](https://wiki.haskell.org/Parsec) or [Bennu](http://bennu-js.com/) the base component is not a `Char`, but rather, any literal. There are literals defined for `Char` and `String`, as well as some advanced concepts that will be covered in later articles.

### Modifier

Modifiers _modify_ patterns. This includes concepts like making a pattern optional, or negating a pattern. Modifiers are most often declared with prefix operators, although there are exceptions.

Method calls exist in the event a programming language does not support operator overloading. Their use is generally discouraged because it hampers readability.

### Combinator

Combinators _combine_ patterns. This includes concepts like concatenation or alternates. Combinators are most often declared with binary operators, although there are exceptions.

A special class of combinators is that of the `Range`, which is declared as a [`Tuple`](https://docs.microsoft.com/en-us/dotnet/api/system.tuple) instead. This serves two main purposes. One is that most languages do not have a satisfactory operator to use to represent the concept. Two is that certain `Range` types have third parameters and lack any possible operator.

Method calls exist in the event a programming language does not support operator overloading. Their use is generally discouraged because it hampers readability.

## Source

`Source` is a buffer that keeps track of the position during and after parsing operations. Importantly, it always reverts back to the starting position if a parse fails. This position is not manipulatable from code outside of the library, so there is no (easy) ability to tamper. (Abuse through reflection is technically always possible). New parsing operations always occur at the current position, so you don't need to manage anything. `Source` objects can be construction both from `Stream` and `String`.

## Parsers

Very unique to **Stringier.Patterns** is multiple parsing models.

### Equals

This parser checks that the `Pattern` exactly matches the input `String`, and returns a `Boolean`. because it is an exact match, no position needs to be kept track of, so this type only accepts `String`. While this may seem limiting, the intent behind this parser is field validation in forms, such as validating an email address is of the correct format.

### Consume

This parser tries to match the `Pattern` starting at the very beginning of the `Source` (or where it last left off), and returns a `Result`. It is naively like prefixing a `^` anchor to every `Regex`. This is generally the parser you want to use, as it parses from left to right in as obvious of a way as possible.

## Result

`Result` holds the result state of _most_ parser operations, with `Equals` being the major exception. It contains both the matched text, and a success/failure state. The exact implementation of these is subject to change, but this type will always be castable to `String` and `Boolean`, and if allowed, will implicitly convert to those types.