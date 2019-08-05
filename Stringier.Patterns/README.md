# Stringier.Patterns

Patterns, probably introduced with SNOBOL, and also seen with SPITBOL and UNICON, are considerably more powerful than Regular Expressions. So what do you do when you need to parse something more complicated than a Regex? Hacky Regex extensions aren't great, and still lack what some advanced alternatives can offer. Parser Combinators? Actually these are great. I'm not going to bash them at all. Pattern Matching and Parser Combinators share a huge amount of theory and implementation details. You could consider them alternative interpretations of the same concept. That being said, you'll notice a few small differences, but the advantages apply to both.

## Including

~~~~csharp
using System.Text.Patterns;
~~~~

## Usage

In most situations, there's only three usage patterns you'll need to know.

### Declaration

~~~~csharp
Pattern patternName = "Text to match";
// Comparison of a Literal
~~~~
or
~~~~csharp
Pattern patternName = ("Text to match", StringComparison.CurrentCultureIgnoreCase);
// Comparisons of this Literal will use the StringComparison value
~~~~
or
~~~~csharp
Pattern patternName = literalPattern1 & (literalPattern2 | literalPattern3);
// Comparison of an actual pattern
~~~~

### Matching

~~~~csharp
patternName.Consume("Candidate text");
//Assuming Consume captures "Candidate" this will return true and "Candidate"
~~~~

### Inline (Quick Match)

~~~~csharp
"Hello".Consume("Hello World!");
//Assuming "Hello" captures "Hello" (which it obviously will) this will return true and "Hello"
~~~~

## Concepts

### Multiple return values

Pattern matching is largely based around the idea of goal-direction. The two most likely languages you're using this library from **C#** and **VB.NET** don't support goal-direction (if you're using **F#** then [FParsec](http://www.quanttec.com/fparsec/) is going to match that programming style better anyways). Goal-directed semantics require both a success state and the result to be returned from every function call (or just the success state for a `void` return).

> But wait, C# can't return multiple values!

While true, this is remarkably pedantic. Whether you return an array, a struct, a class, or a tuple, you are returning multiple values as one conceptual value. All the parsing methods return `Result` which contains both the success state (`Boolean`) and the result of the operation (`String`). `Result` implicitly casts to both `Boolean` and `String` and can be used as such. This allows some conveniences without adding new methods.

> So every return passes two values? Isn't that a lot of extra memory?

One, no not really, a single `Boolean` isn't very large. Two, it doesn't actually pass a `Boolean` at all. An empty string is recognized as a failure. Essentially `Result` is a box of `String` with special comparisons and implicit conversions. In other words, the behavior of `Parse` and `TryParse` combined into one method. And, getting technical, we're not actually passing around `String` either. We're actually passing around [`Span<Char>`](https://docs.microsoft.com/en-us/dotnet/api/system.span-1) for performance reasons; actually passing around references to parts of the string, preventing copying in most situations.

### Literal

~~~~csharp
Pattern patternName = "Literal Pattern";
~~~~

This is an exact 1:1 match pattern, and is equivalent to
~~~~csharp
"pattern" == "candidate"`
~~~~~
**Literal** is meant mostly as a building block for patterns. Because pattern operators expect to use a **Literal**, which is not a string, the convenient syntax shown above only applies to **Literal**. Use inside a pattern operator might require a cast like
~~~~csharp
(Pattern)"Literal Pattern" & "Other Literal Pattern"
~~~~
This is generally only required as the very first member

### Alternator

~~~~csharp
Pattern patternName = pattern1 | pattern2;
~~~~

Alternators accept either pattern, and are equivalent to the regex `(pattern1|pattern2)`.

### Combinator

~~~~csharp
Pattern patternName = pattern1 & pattern2;
~~~~

Combinators require both patterns in sequence and are equivalent to the regex `(pattern1)(pattern2)` with the unnecessary parenthesis added for readability.

### Optor

~~~~csharp
Pattern patternName = ~pattern;
~~~~

Optors make the pattern completly optional, so success is always true, and are equivalent to the regex `(pattern)?`.

### Repeater

~~~~csharp
Pattern patternName = pattern * 3; //repeats the pattern three times
~~~~

Repeaters require the pattern to repeat the specified number of times, and can be thought of the multiplcation to patterns when combinators are addition. The above example would be equivalent to the regex `pattern{3}`.