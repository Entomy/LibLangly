# Patterns

Patterns, probably introduced with [SNOBOL](https://en.wikipedia.org/wiki/SNOBOL), and also seen with [SPITBOL](https://en.wikipedia.org/wiki/SPITBOL) and [UNICON](https://unicon.sourceforge.io/)[[paper]](https://www.cs.nmsu.edu/~sgaikaiw/Thesis.pdf), are considerably more powerful than [Regular Expressions](https://en.wikipedia.org/wiki/Regular_expression). So what do you do when you need to parse something more complicated than a Regex? Hacky [Regex](https://en.wikipedia.org/wiki/Regular_expression) extensions aren't great, and still lack what some advanced alternatives can offer. [Parser Combinators](https://en.wikipedia.org/wiki/Parser_combinator)? The performance of these isn't what it's proponents let on (check the benchmarks in this project's repo for proof, since they don't provide it). Pattern Matching and [Parser Combinators](https://en.wikipedia.org/wiki/Parser_combinator) share a huge amount of theory, however. You could consider them alternative interpretations of the same concept. That being said, you'll notice a few small differences, but the advantages apply to both. There are some divergences from [SNOBOL](https://en.wikipedia.org/wiki/SNOBOL)-style patterns, made where appropriate based on a number of conditions. This project should be seen as inspired by [SNOBOL](https://en.wikipedia.org/wiki/SNOBOL), [Regex](https://en.wikipedia.org/wiki/Regular_expression), and [Parser Combinators](https://en.wikipedia.org/wiki/Parser_combinator), without extremely strict adherence to any particular style. The declarative power of this approach goes as far as to even support recursive grammars.

## Including

# [C#](#tab/cs)

~~~~csharp
using Langly.Patterns;
using static Langly.Patterns.Pattern; // If you want fluent syntax
~~~~

# [VB](#tab/vb)

~~~~vbnet
Imports Langly.Patterns
Imports Langly.Patterns.Pattern 'If you want fluent syntax
~~~~

# [F#](#tab/fs)

~~~~fsharp
open Langly.Patterns
~~~~

***