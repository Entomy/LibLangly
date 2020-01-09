# Extensions

## Including

This package merely extends `Char`, `Char[]`, `IEnumerable<Char>`, `Rune`, `Rune[]`, `IEnumerable<Rune>`, `String`, `String[]`, and `IEnumerable<String>`. You can use it through:

~~~~csharp
using Stringier;
~~~~
~~~~fsharp
open Stringier
~~~~

## Usage

Everything within this library is extension methods, so you will automatically see them through IntelliSense when using applicable types. That being said, all extensions exist within the module: `StringierExtensions` and can be browsed that way. All methods ~~are~~ *should be* well documented. If they are not either consider adding documentation in a pull request, or filing an issue.

For the most part the methods supplied in this library are unique. However, for convenience or orthogonality with library supplied features, there are several extension methods which map to static class method calls. These mappings do not ever introduce new behavior and simply call the method directly.