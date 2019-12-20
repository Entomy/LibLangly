# Patterns Declarations

**Stringier.Patterns** primarily works through a declarative programming approach, as such, it's very important to understand the different ways to declare patterns and how they work.

## Literal Declaration

Literals are just the exact value, converted into a `Pattern`. All literals perform exact matches, and are the base component of all `Pattern`.

~~~~csharp
Pattern patternName = 'c';
//Matches the specified character
~~~~
~~~~fsharp
let patternName = p 'c'
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
Pattern patternName = "Text to match".With(StringComparison.Ordinal);
//Matches the entire piece of text using ordinal case-sensitive rules
~~~~
~~~~fsharp
let patternName = "Text to match"/=StringComparison.Ordinal; //This operator is weird looking. It was chosen just because of its precedence and nothing more
~~~~

As F# does not support implicit conversions, `p` exists as a function to do this conversion. The name comes from the convention used with [`FParsec`](http://www.quanttec.com/fparsec/). Note that you should only need to do this for literals, as pattern operators were made sufficiently generic to automagically convert `Char` and `String`.

## Combinators

Combinators take two (or more) different patterns and combine them into a single pattern.

### Alternate

Alternates allow either pattern to match. If one fails, the other will be attempted.

~~~~csharp
Pattern patternName = firstPattern.Or(secondPattern);
~~~~
~~~~fsharp
let patternName = firstPattern || secondPattern
~~~~
***or***
~~~~csharp
Pattern patternName = firstPattern.Or("Literal");
~~~~
~~~~fsharp
let patternName = firstPattern || "Literal"
~~~~
***or***
~~~~csharp
Pattern patternName = "Literal".Or(secondPattern);
~~~~
~~~~fsharp
let patternName = "Literal" || secondPattern
~~~~
***or***
~~~~csharp
Pattern patternName = "First Literal".Or("Second Literal");
~~~~
~~~~fsharp
let patternName = "First Literal" || "Second Literal"
~~~~

*Note*: The order of these is dependent on the parser. Generally speaking they will be checked in order, with the first match indicated success.

### Concatenate

Concatenates the two patterns, checking them in order. This is identical in concept to string concatenation, and if concatenating literals, will function entirely the same way.

~~~~csharp
Pattern patternName = firstPattern.Then(secondPattern);
~~~~
~~~~fsharp
let patternName = firstPattern >> secondPattern
~~~~
***or***
~~~~csharp
Pattern patternName = firstPattern.Then("Literal");
~~~~
~~~~fsharp
let patternName = firstPattern >> "Literal"
~~~~
***or***
~~~~csharp
Pattern patternName = "Literal".Then(secondPattern);
~~~~
~~~~fsharp
let patternName = "Literal" >> secondPattern
~~~~
***or***
~~~~csharp
Pattern patternName = "First Literal".Then("Second Literal");
~~~~
~~~~fsharp
let patternName = "First Literal" >> "Second Literal"
~~~~

### Range

#### Basic Range

Matches everything from `From` to `To`.

~~~~csharp
Pattern patternName = Pattern.Range(fromPattern, toPattern);
~~~~
~~~~fsharp
let patternName = range fromPattern toPattern
~~~~

#### Escaped Range

Matches everything from `From` to `To`, but allows an `Escape` sequence.

~~~~csharp
Pattern patternName = Pattern.Range(fromPattern, toPattern, escapePattern);
~~~~
~~~~fsharp
let patternName = erange fromPattern toPattern escapePattern
~~~~

#### Nested Range

Matches everything from `From` to `To`, but allows nesting of the pattern.

~~~~csharp
Pattern patternName = Pattern.NestedRange(fromPattern, toPattern);
~~~~
~~~~fsharp
let patternName = nrange fromPattern toPattern
~~~~

## Modifiers

Modifiers alter the semantics of pattern

### Negate

Modifies the pattern in a way that it will match anything _not_ the pattern. That is, it will match the same length of the pattern, but only if it would not be a match normally.

~~~~csharp
Pattern patternName = Not(otherPattern);
~~~~
~~~~fsharp
let patternName = negate otherPattern
~~~~
***or***
~~~~csharp
Pattern patternName = Not("Literal");
~~~~
~~~~fsharp
let patternName = negate "Literal"
~~~~

### Option

Modifies the pattern in a way that allows it to be present or absent and still be considered a successful match.

~~~~csharp
Pattern patternName = Maybe(otherPattern);
~~~~
~~~~fsharp
let patternName = option otherPattern
~~~~
***or***
~~~~csharp
Pattern patternName = Maybe("Literal");
~~~~
~~~~fsharp
let patternName = option "Literal"
~~~~

### Repeat

Modifies the pattern in a way that repeats it a specified amount.

~~~~csharp
Pattern patternName = otherPattern.Repeat(3);
~~~~
~~~~fsharp
let patternName = otherPattern * 3
~~~~
***or***
~~~~csharp
Pattern patternName = "Literal".Repeat(3);
~~~~
~~~~fsharp
let patternName = "Literal" * 3
~~~~

### Span

Modifies the pattern in a way that lets it repeat until it no longer can, "spanning" a section of text.

~~~~csharp
Pattern patternName = Many(otherPattern);
~~~~
~~~~fsharp
let patternName = span otherPattern
~~~~
***or***
~~~~csharp
Pattern patternName = Many("Literal");
~~~~
~~~~fsharp
let patternName = span "Literal"
~~~~
