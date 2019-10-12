# Multitarget Information

This project uses framework multitargeting to support as broad of a userbase as possible. This does mean on certain targets, some functionality will be missing. Over time, the hope is to implement as much as possible missing from .NET Standard 1.6 to allow near parity between them. Serialization and tuples will never be planned however.

## Stringier:

* `IsSurrogatePair()` because of a lack of `Tuple` or `ValueTuple` support.
* `ToCamelCase()`
* `ToPascalCase()`
* `ToTitleCase()`
* Exceptions are not [`Serializable`](https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute).


## Stringier.Patterns

* `CharLiteral` and `StringLiteral` can not include a cultural comparison because of a lack of `Tuple` or `ValueTuple` support.
* `StringComparison` can not be `InvariantCulture` or `InvariantCultureIgnoreCase`.
* Creation of certain `Pattern` types throught tuples is not possible, although this has become [`Obsolete`](https://docs.microsoft.com/en-us/dotnet/api/system.obsoleteattribute) anyways.
* Exceptions are not [`Serializable`](https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute).