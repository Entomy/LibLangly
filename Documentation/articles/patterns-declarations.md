# Stringier.Patterns Declarations

**Stringier.Patterns** primarily works through a declarative programming approach, as such, it's very important to understand the different ways to declare patterns and how they work.

This article also serves to demonstrate a distinct advantage over [`Regex`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex).

## Literal Declaration

Literals are just the exact value, converted into a `Pattern`. All literals perform exact matches, and are the base component of all `Pattern`.

~~~~csharp
Pattern patternName = 'c';
//Matches the specified character
~~~~
~~~~fsharp
let patternName = p'c'
~~~~
**or**
~~~~csharp
Pattern patternName = "Text to match";
//Matches the entire piece of text
~~~~
~~~~fsharp
let patternName = p"Text to match"
~~~~
**or**
~~~~csharp
Pattern patternName = ("Text to match", StringComparison.Ordinal);
//Matches the entire peice of text using ordinal case-sensitive rules
~~~~
~~~~fsharp
let patternName = p ("Text to match", StringComparison.Ordinal);
~~~~

As F# does not support implicit conversions, `p` exists as a function to do this conversion. The name comes from the convention used with [`FParsec`](http://www.quanttec.com/fparsec/). Note that you should only need to do this for literals, as pattern operators were made sufficiently generic to automagically convert `Char` and `String`.

## Combinators

Combinators take two (or more) different patterns and combine them into a single pattern.

### Alternate

Alternates allow either pattern to match. If one fails, the other will be attempted.

~~~~csharp
Pattern patternName = firstPattern | secondPattern;
~~~~
~~~~fsharp
let patternName = firstPattern || secondPattern
~~~~
***or***
~~~~csharp
Pattern patternName = firstPattern | "Literal";
~~~~
~~~~fsharp
let patternName = firstPattern || "Literal"
~~~~
***or***
~~~~csharp
Pattern patternName = "Literal" | secondPattern;
~~~~
~~~~fsharp
let patternName = "Literal" || secondPattern
~~~~
***or***
~~~~csharp
Pattern patternName = (Pattern)"First Literal" | "Second Literal"
~~~~
~~~~fsharp
let patternName = "First Literal" || "Second Literal"
~~~~

*Note*: The order of these is dependent on the parser and specific behavior should not be assumed

### Concatenate

Concatenates the two patterns, checking them in order. This is identical in concept to string concatenation, and if concatenating literals, will function entirely the same way.

~~~~csharp
Pattern patternName = firstPattern & secondPattern;
~~~~
~~~~fsharp
let patternName = firstPattern && secondPattern
~~~~
***or***
~~~~csharp
Pattern patternName = firstPattern & "Literal";
~~~~
~~~~fsharp
let patternName = firstPattern && "Literal"
~~~~
***or***
~~~~csharp
Pattern patternName = "Literal" & secondPattern;
~~~~
~~~~fsharp
let patternName = "Literal" && secondPattern
~~~~
***or***
~~~~csharp
Pattern patternName = (Pattern)"First Literal" & "Second Literal"
~~~~
~~~~fsharp
let patternName = "First Literal" && "Second Literal"
~~~~

### Range

#### Basic Range

Matches everything from `From` to `To`.

~~~~csharp
Pattern patternName = (From: fromPattern, To: toPattern);
~~~~
~~~~fsharp
let patternName = range fromPattern toPattern
~~~~

#### Escaped Range

Matches everything from `From` to `To`, but allows an `Escape` sequence.

~~~~csharp
Pattern patternName = (From: fromPattern, To: toPattern, Escape: escapePattern);
~~~~
~~~~fsharp
let patternName = erange fromPattern toPattern escapePattern
~~~~

#### Nested Range

Matches everything from `From` to `To`, but allows nesting of the pattern.

~~~~csharp
Pattern patternName = (From: fromPattern, To: toPattern, Nested: true);
~~~~
~~~~fsharp
let patternName = nrange fromPattern toPattern
~~~~

*Note*: if `Nested: false` instead, a `Basic Range` is constructed as if `Nested:` was never declared.

## Modifiers

Modifiers alter the semantics of pattern

### Negate

Modifies the pattern in a way that it will match anything _not_ the pattern. That is, it will match the same length of the pattern, but only if it would not be a match normally.

~~~~csharp
Pattern patternName = !otherPattern;
~~~~
~~~~fsharp
let patternName = -otherPattern
~~~~
***or***
~~~~csharp
Pattern patternName = !(Pattern)"Literal";
~~~~
~~~~fsharp
let patternName = -"Literal"
~~~~

### Option

Modifies the pattern in a way that allows it to be present or absent and still match. This is accomplished by marking the result successful regardless of whether it really is or not.

~~~~csharp
Pattern patternName = -otherPattern;
~~~~
~~~~fsharp
let patternName = ~~otherPattern
~~~~
***or***
~~~~csharp
Pattern patternName = -(Pattern)"Literal";
~~~~
~~~~fsharp
let patternName = ~~"Literal"
~~~~

### Repeat

Modifies the pattern in a way that repeats it a specified amount.

~~~~csharp
Pattern patternName = otherPattern * 3;
~~~~
~~~~fsharp
let patternName = otherPattern * 3
~~~~
***or***
~~~~csharp
Pattern patternName = (Pattern)"Literal" * 3;
~~~~
~~~~fsharp
let patternName = "Literal" * 3
~~~~

### Span

Modifies the pattern in a way that lets it repeat until it no longer can, "spanning" a section of text.

~~~~csharp
Pattern patternName = +otherPattern;
~~~~
~~~~fsharp
let patternName = +otherPattern
~~~~
***or***
~~~~csharp
Pattern patternName = +(Pattern)"Literal";
~~~~
~~~~fsharp
let patternName = +"Literal"
~~~~