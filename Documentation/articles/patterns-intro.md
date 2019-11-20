# Patterns Intro

Patterns, probably introduced with SNOBOL, and also seen with SPITBOL and UNICON, are considerably more powerful than Regular Expressions. So what do you do when you need to parse something more complicated than a Regex? Hacky Regex extensions aren't great, and still lack what some advanced alternatives can offer. Parser Concatenators? Actually these are great. I'm not going to bash them at all. Pattern Matching and Parser Concatenators share a huge amount of theory and implementation details. You could consider them alternative interpretations of the same concept. That being said, you'll notice a few small differences, but the advantages apply to both.

## Including

~~~~csharp
using Stringier.Patterns;
~~~~