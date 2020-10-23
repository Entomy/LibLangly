# Stringier.Glyph

## Including

# [C#](#tab/cs)

~~~~csharp
using Stringier;
~~~~

# [VB](#tab/vb)

~~~~vbnet
Imports Stringier
~~~~

# [F#](#tab/fs)

~~~~fsharp
open Stringier
~~~~

***

## Usage

This package is centered around one major type `Glyph` whos purpose is to represent glyphs, that is, the visuals of a "character", not how the computer represents them. This greatly simplifies cases where there's numerous representations for what is visually identical. Consider the following:

# [C#](#tab/cs)

~~~~csharp
"cafe"[3] == 'é'
~~~~

# [VB](#tab/vb)

~~~~vbnet
"cafe"(3) = "é"c
~~~~

# [F#](#tab/fs)

~~~~fsharp
"cafe".[3] = 'é'
~~~~

***

This should obviously return true, right? Try it. It won't. The problem is, the glyph we are testing is U+0065, U+0301, while the glyph we are testing against is U+00E9. Because indexing a string works on UTF-16 code units, not glyphs, the comparison is actually:

~~~~csharp
0x0065 == 0x00E9
~~~~

Which is obviously not true.

**Stringier.Glyph** wraps up concepts like extended grapheme boundaries and UNICODE normalization into an API that looks very similar to `Char` and `Rune`. Because you should already know how to work with this. It shouldn't be spread between three to five helper `*Info*` classes. This package also provides some auxillary features, such as a system for generating variant encodings of the same glyph or even entire string.
