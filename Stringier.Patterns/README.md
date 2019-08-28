# Stringier.Patterns

Patterns, probably introduced with SNOBOL, and also seen with SPITBOL and UNICON, are considerably more powerful than Regular Expressions. So what do you do when you need to parse something more complicated than a Regex? Hacky Regex extensions aren't great, and still lack what some advanced alternatives can offer. Parser Concatenators? Actually these are great. I'm not going to bash them at all. Pattern Matching and Parser Concatenators share a huge amount of theory and implementation details. You could consider them alternative interpretations of the same concept. That being said, you'll notice a few small differences, but the advantages apply to both.

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
or
~~~~csharp
' '.Consume(" okay ");
//Assuming ' ' captures the first character in " okay " (which it obviously will) this will return true and " ".
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
or
~~~~csharp
Pattern patternName = 'p';
~~~~

This is an exact 1:1 match pattern, and is equivalent to
~~~~csharp
"pattern" == "candidate"
~~~~~
**Literal** is meant mostly as a building block for patterns. Because pattern operators expect to use a **Literal**, which is not a string, the convenient syntax shown above only applies to **Literal**. Use inside a pattern operator might require a cast like
~~~~csharp
(Pattern)"Literal Pattern" & "Other Literal Pattern"
~~~~
This is generally only required as the very first member

Consider using characters anywhere a single character should be matched. While a string containing a single element will perform the same match, character matching is quicker.

### Alternator

~~~~csharp
Pattern patternName = pattern1 | pattern2;
~~~~

Alternators accept either pattern, and are equivalent to the regex `(pattern1|pattern2)`.

### Concatenator

~~~~csharp
Pattern patternName = pattern1 & pattern2;
~~~~

Concatenators require both patterns in sequence and are equivalent to the regex `(pattern1)(pattern2)` with the unnecessary parenthesis added for readability.

### Negator

~~~~csharp
Pattern patternName = !pattern;
~~~~

Negators exclude the specified pattern, instead consuming anything of the same length. This is not a concept easy to express with regex, but given the pattern `!"hi"` it would be similar to `/[^h][^i]/`.

### Optor

~~~~csharp
Pattern patternName = ~pattern;
~~~~

Optors make the pattern completly optional, so success is always true, and are equivalent to the regex `(pattern)?`.

### Range Patterns

~~~~csharp
Pattern patternName = (From: startPattern, To: endPattern);
~~~~
or
~~~~csharp
Pattern patternName = (From: startPattern, To: endPattern, Escape: escapePattern);
~~~~
or
~~~~csharp
Pattern patternName = (From: startPattern, To: endPattern, Nested: true);
~~~~

Ranger Patterns are totally foreign to Regex, although some parsers are able to synthesize the behavior. The behavior is to simply try matching the `From` at the current position, then continue to read everything until the `To` is matched, which also consumes that. Optionally, an `Escape` may be defined, which is attempted to be matched before `To` and is used primarily for matching string literals which have language defined escape sequences for the delimiting character.

To provide a few examples of how this behavior is useful:

~~~~csharp
Pattern letStatement = (From: "let", To: ";"); //This will match an entire let statement in a language which has semicolon terminated statements
~~~~

~~~~csharp
Pattern cString = (From: "\"", To: "\"", Escape: "\\\""); //This will match an entire C string literal, while including double-quote escapes
~~~~

~~~~csharp
Pattern cppComment = (From: "/*", To: "*/", Nested: true); //This will match a C++ comment, even if there is another comment nested inside of it
~~~~

It is important to understand that this is not a modified pattern, but rather a new `struct`. That is because some of the modifiers, especially `Negator`, do not conceptually apply to a range (what is a negated range capture?).

### Repeater

~~~~csharp
Pattern patternName = pattern * 3; //repeats the pattern three times
~~~~

Repeaters require the pattern to repeat the specified number of times, and can be thought of the multiplcation to patterns when Concatenators are addition. The above example would be equivalent to the regex `(pattern){3}`.

### Spanner

~~~~csharp
Pattern patternName = +pattern;
~~~~

Spanners require the pattern to exist at least once, but will repeat until the pattern can no longer be matched, and are equivalent to the regex `(pattern)+`.

### Checker

~~~~csharp
Pattern patternName = (Pattern)((Char) =>
    //Logic
);
~~~~

Checkers aren't normally used, but seeing as they form the basis of a lot of predefined patterns because of their usability, they are also exposed publicly to enable certain complex patterns or greatly simplify complex patterns. Instead of doing checks through the pattern API, the check, held only against a single character, is done programmatically. The check is a lamba which takes a single character and returns a boolean. Anything can be done in this context. Overwhelmingly you don't want to use this.
