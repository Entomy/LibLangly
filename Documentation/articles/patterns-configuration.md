# Stringier.Patterns Configuration

This engine needs very little configuration, however, there are some things where there is no clear choice, or where this choice may need to be made differently despite a "reasonable default".

All of these configurations are exposed as fields or properties inside of the [`Stringier`](https://entomy.github.io/Stringier/api/System.Text.Patterns.Stringier.html) static class

## [DefaultComparisonType](https://entomy.github.io/Stringier/api/System.Text.Patterns.Stringier.html)

This field is automatically used for all `Char` and `String` literals within patterns as the [`StringComparison`](https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison) when none is explicitly specified. This is initialized to `StringComparison.CurrentCultureIgnoreCase`, but is freely overridable.

The primarily intention for this setting is to make it easier on those not parsing language text, such as those working with programming languages, or object exchange formats, or similar.

***Warning***: As it effects parser behavior, it should only be set once, preferablly at the very beginning of program execution. Absolutely never set this in a concurrent environment; if any form of concurrency is being used set this before entering that environment.