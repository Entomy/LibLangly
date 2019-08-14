# Stringier

## Including

This package merely extends `Char`, `Char[]`, `String`, `String[]`, and `IEnumerable<String>`, so it exists with `System`. You can use it through:

~~~~csharp
using System;
~~~~

## Usage

Everything within this library is extension methods, so you will automatically see them through IntelliSense when using applicable types. That being said, all extensions exist within two modules: `CharExtensions` and `StringExtensions` and can be browsed that way. All methods ~~are~~ *should be* well documented. If they are not either consider adding documentation in a pull request, or filing an issue.

For the most part the methods supplied in this library are unique. However, for convenience or orthogonality with library supplied features, there are several extension methods which map to static class method calls. These mappings do not ever introduce new behavior and simply call the method directly.