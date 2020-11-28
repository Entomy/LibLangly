# Patterns Advanced Concepts

## Captures

Captures are a system of ``Capturer``, ``Capture``, and ``CaptureLiteral`` that are used to implement backreferences or other concepts.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = otherPattern.Capture(out Capture capture).Then(".");
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim capture As Capture
Dim patternName = otherPattern.Capture(capture).Then(".")
~~~~

# [F#](#tab/fs)

~~~~fsharp
let mutable capture = ref null
let patternName = (otherPattern => capture) >> "."
~~~~

***

Regardless of the language, the mechanism remains the same. The pattern is still matched as if the capture and capturing parts were not there. During parsing the `capture` variable is "filled in" with whatever matched at that point. Because of this, make sure that a parse occurs before using a `Capture` outside of a pattern, so that it's actually holding captured text. Inside of patterns, there's a special mechanism to lazily resolve the capture, so you can use a `Capture` as a backreference inside of the same pattern as it was captured in.

A common use case is combining Captures with `Pattern.Range()` and similar, for languages with an indentifier at both the begining and ending of a block. You can capture the identifier at the begining, and reference it at the end, ensuring an exact match. The lazy resolution that occurs ensures this works even though it's the same pattern.

## Checkers

Checkers are a special pattern type which are not meant for normal use. Unlike the typical case where the pattern describes what to match, a checker is a function which is ran against a candidate when determining a match. This is substantially faster and should be viewed as hand writing parts of the resulting parser.

Many of the predefined patterns are implemented in whole or in part through these, because of their performance.

These were formerlly exposed through implicit/explicit conversions of a single delegate into the pattern, then from a tuple of the name and delegate into the pattern. As more checkers were added, it became clear expanding this approach was not viable. The entire approach now is exposed through a static method `Pattern.Check()`, which is well documented about its behavior.

### CharChecker

Checks a `Char` with the specified function.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = Pattern.Check(nameof(patternName), (Char) => /* Boolean check here */ );
~~~~

# [VB](#tab/vb)


# [F#](#tab/fs)

~~~~fsharp
let patternName = Pattern.Check((nameof patternName), (fun (char) -> (* Boolean check here *) ));
~~~~

***

> [!Note]
> `nameof()` can be any string, but this is recommended.

The function lambda must take a `Char` as a parameter and return a `Boolean`, but otherwise you are free to declare whatever logic desired.

In F#, either the standard lambdas `Func<Char, Boolean>` or F# lambdas `(char -> bool)` are viable.

### StringChecker

Checks a variable length `String` with the specified function.
* The first entry checks the "head" or first character, and is followed by whether a "head" is required.
* The second entry checks the "body" or the middle characters, and is followed by whether a "body" is required.
* The third entry checks the "tail" or the last character, and is followed by whether a "tail" is required.

This is used to define fairly sophisticated and otherwise complex patterns for single strings, like identifiers in programming languages, although it has other uses.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = Pattern.Check(nameof(patternName),
	(Char) => /* Boolean check here */, true,
	(Char) => /* Boolean check here */, true,
	(Char) => /* Boolean check here */, true);
~~~~

# [VB](#tab/vb)



# [F#](#tab/fs)

~~~~fsharp
// This feature is not available from F# yet
~~~~

***

> [!Note]
> `nameof()` can be any string, but this is recommended.

The function lambda must take a `Char` as a parameter and return a `Boolean`, but otherwise you are free to declare whatever logic desired.

As a shorthand, if all three are required, the boolean parameters may be omitted.

### WordChecker

Checks a variable length `String` with the specified function.
* The first entry checks the "head" or first character, and is followed by whether a "head" is required.
* The second entry checks the "body" or the middle characters, and is followed by whether a "body" is required.
* The third entry checks the "tail" or the last character, and is followed by whether a "tail" is required.

This is used to define fairly sophisticated and otherwise complex patterns for single strings, like identifiers in programming languages, although it has other uses.

It is a variation of `StringChecker` and uses rules more similar to how humans read words, but is otherwise very similar.

# [C#](#tab/cs)

~~~~csharp
Pattern patternName = Pattern.Check(nameof(patternName), Bias.Head,
	(Char) => /* Boolean check here */,
	(Char) => /* Boolean check here */,
	(Char) => /* Boolean check here */);
~~~~

# [VB](#tab/vb)

# [F#](#tab/fs)

~~~~fsharp
// This feature is not available from F# yet
~~~~

***

`nameof()` can be any string, but this recommended.

The function lambda must take a `Char` as a parameter and return a `Boolean`, but otherwise you are free to declare whatever logic desired.

The bias is used when a "word" is only one letter long, and decides whether the head or tail is most important (must be present).

### EndChecker

# [C#](#tab/cs)

~~~~csharp
Pattern endOfSource = Pattern.End;
~~~~

# [VB](#tab/vb)

# [F#](#tab/fs)

~~~~fsharp
let endOfSource = Pattern.End;
~~~~

***

Checks that the parser is currently at the end of the source, setting a `ConsumeParserError` if not. This is essentially a highly specialized lookahead.

## Adapters

Sometimes this approach isn't the most optimal, or is just easier to express in another approach. We take the cooperative approach to dealing with this, believing we're all made better, and you have a more productive solution, this way.

### RegexAdapter

Regex, with some concessions, can be made to work with Patterns, essentially deferring that part of the pattern to Microsoft's Regex engine, but still otherwise working with this system.

# [C#](#tab/cs)

~~~~csharp
Pattern regexPattern = new Regex("^hello").AsPattern();
~~~~

# [VB](#tab/vb)

# [F#](#tab/fs)

~~~~fsharp
let regexPattern = Regex("^hello").AsPattern()
~~~~

***

One important concession is that the Regex pattern must be anchored to the start of the line (`^`). This will be validated for you, and will raise an exception during initialization if this is not the case.

The Regex `Match` is not returned, instead, being adapted into `Source` and `Result`. Everything inside of the Regex still works exactly as expected, including more advanced things like capturing groups and back references. These are not compatable with **Stringier's** `Capturer` or `Capture` however. The approach only defers execution to the `Regex` engine, and then modifies `Source` and `Result` according to the `Match`.

## MutablePattern

This concept is deliberately not documented in how to use this type because it's incredibly dangerous. The basic idea is the pattern is modified in place, rather than each operation returning a new pattern. This is how recursion is acheived, but it can easily be done wrong. I've got a project in the works that utilizes this engine/project to provide a DSL for grammars/parsing. At the point where you would need the features this type provides, you'd be better served (and have a much better time) using that language.
