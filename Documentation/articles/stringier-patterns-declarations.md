# Stringier.Patterns Declarations

**Stringier.Patterns** primarily works through a declarative programming approach, as such, it's very important to understand the different ways to declare patterns and how they work.

## Literal Declaration

Literals are just the exact value, converted into a `Pattern`. All literals perform exact matches, and are the base component of all `Pattern`.

# [C#](#tab/cs)

~~~~csharp
Pattern matchChar = 'c'; //Matches the specified character
Pattern matchString = "Text to match"; //Matches the entire string
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim MatchChar As Pattern = "c"c 'Matches the specified character
Dim MatchString As Pattern = "Text to match" 'Matches the entire string
~~~~

# [F#](#tab/fs)

~~~~fsharp
let matchChar = p 'c' //Matches the specified character
let matchString = p"Text to match" //Matches the entire string
~~~~

***

As F# does not support implicit conversions, `p` exists as a function to do this conversion. The name comes from the convention used with [`FParsec`](http://www.quanttec.com/fparsec/). Note that you should only need to do this for literals, as pattern operators were made sufficiently generic to automagically convert `Char` and `String`.

## Combinators

Combinators take two (or more) different patterns and combine them into a single pattern.

### Alternate

Alternates allow either pattern to match. If one fails, the other will be attempted.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = firstPattern.Or(secondPattern); //Fluent syntax
Pattern patternName = firstPattern | secondPattern; //Expression syntax
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim patternName As Pattern = FirstPattern.Or(SecondPattern) 'Fluent syntax
Dim patternName As Pattern = FirstPattern Or SecondPattern 'Expression syntax
~~~~

# [F#](#tab/fs)

~~~~fsharp
let patternName = firstPattern || secondPattern
~~~~

***

_Note_: Any case of `firstPattern` or `secondPattern` in these examples can be replaced with any literal, since those are themselves patterns.

### Concatenate

Concatenates the two patterns, checking them in order. This is identical in concept to string concatenation, and if concatenating literals, will function entirely the same way.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = firstPattern.Then(secondPattern); //Fluent syntax
Pattern pattern = firstPattern & secondPattern; //Expression syntax
~~~~

~~~~vbnet
Dim PatternName As Pattern = FirstPattern.Then(SecondPattern) 'Fluent syntax
Dim PatternName As Pattern = FirstPattern And SecondPattern 'Expression syntax
~~~~

# [F#](#tab/fs)

~~~~fsharp
let patternName = firstPattern >> secondPattern
~~~~

***

### Ranges

#### Basic Range

Matches everything from `From` to `To`.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = Pattern.Range(fromPattern, toPattern);
~~~~

# [VB](#tab/cs)

~~~~vbnet
Dim PatternName As Pattern = Pattern.Range(fromPattern, toPattern)
~~~~

# [F#](#tab/fs)

~~~~fsharp
let patternName = range fromPattern toPattern
~~~~

***

#### Escaped Range

Matches everything from `From` to `To`, but allows an `Escape` sequence.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = Pattern.Range(fromPattern, toPattern, escapePattern);
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim PatternName As Pattern = Pattern.Range(fromPattern, toPattern, escapePattern)
~~~~

# [F#](#tab/fs)

~~~~fsharp
let patternName = erange fromPattern toPattern escapePattern
~~~~

***

#### Nested Range

Matches everything from `From` to `To`, but allows nesting of the pattern.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = Pattern.NestedRange(fromPattern, toPattern);
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim PatternName As Pattern = Pattern.NestedRange(fromPattern, toPattern)
~~~~

# [F#](#tab/fs)

~~~~fsharp
let patternName = nrange fromPattern toPattern
~~~~

***

## Modifiers

Modifiers alter the semantics of pattern

### Fuzzy

Modifies the pattern to allow for fuzzy parsing. The general idea is that if spellcheck would recognize it, this would recognize it.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = Fuzzy("Literal");
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim PatternName As Pattern = Fuzzy("Literal")
~~~~

# [F#](#tab/fs)

~~~~fsharp
let patternName = fuzzy "Literal"
~~~~

***

There are some limitations in order to make this work. For example, making a single `Char` fuzzy just can't be made to work, as it would either enable everything to match, or would be so restricted as to only allow the specific `Char` to match, in which case it shouldn't be modified at all. Furthermore, when working with `String`, the possible matches have to be exactly the same length. Edits such as an additional `Char` in a `String` aren't supported.

### Negate

Modifies the pattern in a way that it will match anything _not_ the pattern. That is, it will match the same length of the pattern, but only if it would not be a match normally.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = Not(otherPattern); //Method syntax
Pattern patternName = !otherPattern; //Expression syntax
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim PatternName As Pattern = Not(OtherPattern) 'Method syntax
Dim PatternName As Pattern = Not OtherPattern 'Expression syntax
~~~~

# [F#](#tab/vb)

~~~~fsharp
let patternName = not otherPattern
~~~~

***

### Option

Modifies the pattern in a way that allows it to be present or absent and still be considered a successful match.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = Maybe(otherPattern);
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim PatternName As Pattern = Maybe(OtherPattern)
~~~~

# [F#](#tab/fs)

~~~~fsharp
let patternName = maybe otherPattern
~~~~

***

### Repeat

Modifies the pattern in a way that repeats it a specified amount.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = otherPattern.Repeat(3); //Fluent syntax
Pattern patternName = otherPattern * 3; //Expression syntax
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim PatternName As Pattern = OtherPattern.Repeat(3) 'Fluent syntax
Dim PatternName As Pattern = OtherPattern * 3 'Expression syntax
~~~~

# [F#](#tab/fs)

~~~~fsharp
let patternName = otherPattern * 3
~~~~

***

### Span

Modifies the pattern in a way that lets it repeat until it no longer can, "spanning" a section of text.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = Many(otherPattern);
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim PatternName = Many(OtherPattern)
~~~~

# [F#](#tab/fs)

~~~~fsharp
let patternName = many otherPattern
~~~~

***