# Glyph

[`Glyph`](https://entomy.github.io/LibLangly/api/Langly.Glyph.html) is an analog of [`Rune`](https://docs.microsoft.com/en-us/dotnet/api/system.text.rune) in that both represent higher-level text elements. Where [`Rune`](https://docs.microsoft.com/en-us/dotnet/api/system.text.rune) represents UNICODE Scalar Values, [`Glyph`](https://entomy.github.io/LibLangly/api/Langly.Glyph.html) represents UNICODE Grapheme Clusters and is far more similar to how we view text elements. This type helps better express the intent most programmers have while working with text.

## Including

# [C#](#tab/cs)

~~~~csharp
using Langly;
~~~~

# [VB](#tab/vb)

~~~~vbnet
Imports Langly
~~~~

# [F#](#tab/fs)

~~~~fsharp
open Langly
~~~~

***

## Usage

Because of how UNICODE works, there's many cases where a letter has multiple representations. [`Glyph`](https://entomy.github.io/LibLangly/api/Langly.Glyph.html) address this by greatly simplifying cases where there's numerous representations for what is visually identical. Consider the following:

# [C#](#tab/cs)

~~~~csharp
"café"[3] == 'é'
~~~~

# [VB](#tab/vb)

~~~~vbnet
"café"(3) = "é"c
~~~~

# [F#](#tab/fs)

~~~~fsharp
"café".[3] = 'é'
~~~~

***

This should obviously return true, right? Try it. It won't. The problem is, the glyph we are testing is `U+0065, U+0301,` while the glyph we are testing against is `U+00E9`. Because indexing a string works on UTF-16 code units, not graphemes, the comparison is actually:

~~~~csharp
0x0065 == 0x00E9
~~~~

Which is obviously not true.

While UNICODE Normalization addresses this particular issue, Normalization is particularly vulnerable to certain mismatch errors that've caused data loss in the past. Furthermore, [`Glyph`](https://entomy.github.io/LibLangly/api/Langly.Glyph.html) addresses additional problems that Normalization doesn't tackle. All while performing faster than a Normalization algorithm.

[`Glyph`](https://entomy.github.io/LibLangly/api/Langly.Glyph.html) wraps up concepts like extended grapheme boundaries and UNICODE normalization into an API that looks very similar to `Char` and `Rune`. Because you should already know how to work with this. It shouldn't be spread between three to five helper `*Info*` classes.
