# Stringier.Patterns

Patterns, probably introduced with [SNOBOL](https://en.wikipedia.org/wiki/SNOBOL), and also seen with [SPITBOL](https://en.wikipedia.org/wiki/SPITBOL) and [UNICON](https://unicon.sourceforge.io/)[[paper]](https://www.cs.nmsu.edu/~sgaikaiw/Thesis.pdf), are considerably more powerful than [Regular Expressions](https://en.wikipedia.org/wiki/Regular_expression). So what do you do when you need to parse something more complicated than a Regex? Hacky [Regex](https://en.wikipedia.org/wiki/Regular_expression) extensions aren't great, and still lack what some advanced alternatives can offer. [Parser Combinators](https://en.wikipedia.org/wiki/Parser_combinator)? The performance of these isn't what it's proponents let on (check the benchmarks in this project's repo for proof, since they don't provide it). Pattern Matching and [Parser Combinators](https://en.wikipedia.org/wiki/Parser_combinator) share a huge amount of theory, however. You could consider them alternative interpretations of the same concept. That being said, you'll notice a few small differences, but the advantages apply to both. There are some divergences from [SNOBOL](https://en.wikipedia.org/wiki/SNOBOL)-style patterns, made where appropriate based on a number of conditions. This project should be seen as inspired by [SNOBOL](https://en.wikipedia.org/wiki/SNOBOL), [Regex](https://en.wikipedia.org/wiki/Regular_expression), and [Parser Combinators](https://en.wikipedia.org/wiki/Parser_combinator), without extremely strict adherence to any particular style. The declarative power of this approach goes as far as to even support recursive grammars.

Throughout these articles, examples will be provided in both [C#](https://en.wikipedia.org/wiki/C_Sharp_%28programming_language%29) and [F#](https://en.wikipedia.org/wiki/F_Sharp_(programming_language)). If you're a [VisualBasic](https://en.wikipedia.org/wiki/Visual_Basic_.NET) user the [C#](https://en.wikipedia.org/wiki/C_Sharp_%28programming_language%29) examples will still apply to you. In fact the [C#](https://en.wikipedia.org/wiki/C_Sharp_%28programming_language%29) examples are all based on CLS Compliant API's, and should, after minor translation, work everywhere. Specialized language bindings are something of interested though, and these bindings for F# are a first class part of this project.

## Including

# [C#](#tab/cs)

~~~~csharp
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;
~~~~

# [VB](#tab/cs)

~~~~vbnet
Imports Stringier.Patterns
Imports Stringier.Patterns.Pattern
~~~~

# [F#](#tab/fs)

~~~~fsharp
open Stringier.Patterns
~~~~

***