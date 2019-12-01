# Patterns Optimization

There's no need to take optimization of patterns into consideration. The approach taken avoids the need to meticulous optimization required for [Parser Combinators](https://en.wikipedia.org/wiki/Parser_combinator) ([[fparsec]](http://www.quanttec.com/fparsec/users-guide/performance-optimizations.html), others tend to sneak these hints in throughout the documentation).

## Self Optimization

**Stringier's** ***Patterns*** holds a unique and rare feature: it is self optimizing. This means that you do not need to be intimately aware of what the fastest way to do something is; generally speaking the pattern will become, at construction time (that is, when what you declared is initialized), the most optimal equivalent declaration. This is not an exhaustive description of these optimizations, but merely seeks to explain the approach taken. The only reason why this approach is possible, is that you are describing what to parse, not how to parse. So equivalent descriptions can be freely swapped out.

Typically, patterns are declared with operators that combine or modify them. These operators call methods which are dispatching, so it just happens without any additional performance overhead. These all have "reasonable default" behaviors defined, but are overridden in certain cases to provide specific optimizations.

You know how compilers optimize code by changing what you wrote to an equivalent but faster representation? This does that.

Consider the case of a combinator of literals such as `"Hello".Then(' ').Then("there")`. Normally this would be implemented as the following:

~~~~
Concatenator
├─Concatenator
│ ├─"Hello"
│ └─' '
└─"there"
~~~~

Notice however, the lefthand and righthand components are actually literals. All literals are either `Char` or `String` which means instead of pattern concatenation, we can use string concatenation. Any time a concatenation of two literals is called, instead of constructing a concatenator, we can construct a `StringLiteral` which contains the lefthand and righthand components after string concatenation. This gives us the following:

~~~~
Concatenator
├─"Hello "
└─"there"
~~~~

And suddenly we have the same situation, which can further be reduced into the following:

~~~~
"Hello there"
~~~~

This has the obvious advantage of reducing memory usage, as the tree has been reduced down to a single node. There is also the not so obvious advantage in that matching a literal is slightly faster than matching a concatenator. This works whether the components are literals defined in-line, or coming from pre-existing patterns.