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
Literal patternName = "Text to match";
~~~~
or
~~~~csharp
Pattern patternName = literalPattern1 & (literalPattern2 | literalPattern3);
~~~~

### Matching

~~~~csharp
patternName.Consume("Candidate text");
//Assuming Consume captures "Candidate" this will return true and " text"
~~~~
or
~~~~csharp
patternName.Consume("Candidate text", out String Capture);
//Assuming Consume captures "Candidate" this will return true and " text"
//And Capture will be "Candidate"
~~~~

### Inline (Quick Match)

~~~~csharp
"Hello".Consume("Hello World!");
//Captures "Hello" and returns true and " World!"
~~~~

## Concepts

### Multiple return values

Pattern matching is largely based around the idea of goal-direction. The two most likely languages you're using this library from **C#** and **VB.NET** don't support goal-direction (if you're using **F#** then [FParsec](http://www.quanttec.com/fparsec/) is going to match that programming style better anyways). Goal-directed semantics require both a success state and the result to be returned from every function call (or just the success state for a `void` return).

> But wait, C# can't return multiple values!

While true, this is remarkably pedantic. Whether you return an array, a struct, a class, or a tuple, you are returning multiple values as one conceptual value. All the parsing methods return `Result` which contains both the success state (`Boolean`) and the result of the operation (`String`). `Result` implicitly casts to both `Boolean` and `String` and can be used as such. This allows some conveniences without adding new methods.

Only want to check if a `String` begins with a certain pattern?

~~~~csharp
if (patternName.Consume("Candidate")) { /* do something */ }
~~~~

It's that easy.

It's also important to note that all parsing methods operate on `Result`, which you can't call any meaningful constructor for (`Result` is a `readonly struct` so it has a publically visible default constructor, but this isn't useful). However you don't need a constructor nor overload to use these methods. `String` implicitly converts to a `Result` with success.

### Literal

~~~~csharp
Literal patternName = "Literal Pattern";
~~~~

This is an exact 1:1 match pattern, and is equivalent to
~~~~csharp
"pattern" == "candidate"`
~~~~~
**Literal** is meant mostly as a building block for patterns. Because pattern operators expect to use a **Literal**, which is not a string, the convenient syntax shown above only applies to **Literal**. Use inside a pattern operator might require a cast like
~~~~csharp
(Literal)"Literal Pattern" & "Other Literal Pattern"
~~~~

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

### Spanner

~~~~csharp
Pattern patternName = pattern.Span();
~~~~

Spanners require the pattern to exist at least once, but will repeat until the pattern can no longer be matched, and are equivalent to the regex `pattern+`.

### OptorSpanners

~~~~csharp
Pattern patternName = ~pattern.Span();
~~~~

Technically not its own type, but this does represent a Regex symbol that doesn't have a direct matching. It is equivalent to the regex `pattern*`.
