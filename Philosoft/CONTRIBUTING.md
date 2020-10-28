# Contributing to Philosoft

**Philosoft** uses a flat and unstructured organization, because there's no logical organization of the traits. Rather, they just are. As such, alphabetical order works well for navigation. Traits are named using adjective or adverb interface names. In the instance where a trait has overloads, such as `IAddable` where it can be applied to either standard collections or associative collections, the interfaces are split between files for each trait, with suffixes of `` `x `` where `x` is the number of discriminating parameters. If all variations of a trait share the same parameter, that is not considered a discriminating parameter and does not contribute towards the count of `x`. This means, in most situations, `` `1 `` is standard and `` `2 `` is associative, although there are other instances of trait overloading.

When defining new traits, some care should be taken to ensure that only traits that are absolutely required are inherited as well. Typically speaking, we strive for a very shallow hierarchy. `ClassDiagram.cd` exists to assist with visualizing this, and should be kept up to date. New trait definitions should add to this. Furthermore, if the trait defines methods, determine which methods can be defined in terms of other methods, and provide default implementations for those. This allows implementers to rapidly provide huge amounts of functionality using only a few core implementations, while also allowing the performance minded to provide unique implementations where appropriate.

Most traits, but not all, provide functionality that can handle the caller being `null`. Because instance methods inherently can not do this, in these cases extension methods should be provided, where appropriate handling of `null` is done, followed by a call to the instance method. The intended implementation pattern for downstream is then to explicitly implement these features, so the null-tollerant extensions are used. These extension methods are added to `Extensions`, a `partial` class. Rather atypically, these extension methods should be added in the same file as the trait, with `Extensions` existing below the interface. This is to assist with conceptual grouping, as otherwise a concept would span multiple files and need convoluted boundary systems. This is a rare case where multiple types in the same file is justifiable, because of the design pattern in play.

In the case where a trait provides functionality that is not null-tollerant of the caller, an extension method should still be provided, which performs similary to the null-tollerant style with the obvious implication of throwing `NullReferenceException`.

In some cases, a trait can be identified but can't be provided, such as traits on existing types we don't own. In these cases, extension methods can still be provided for them, and are provided in similar fashion to how the trait-based methods are implemented, with the key difference of actually needing a full implementation rather than delegating to the instance method. This is especially common with `Array`, `Memory`, and `Span` types.

These extension methods are what language bindings actually bind to, so they _must_ be provided.

Except in highly specific cases, you _never_ provide extension methods for instance properties. The only acceptable case where this is done has to do with LINQ analogues, and there's very few cases where this happens, so this will be rare.

## Exclusions

There are some necessary exclusions to normal contribution procedures, due to the nature of this library.

### Benchmarks and Tests

Benchmarks and tests have to be done on _implementers_ of these traits, _per trait_. However, it only needs to be done on the implemented functionality, with default-implementations being unecessary to benchmark and test; assuming at least one test for each default-implementation is performed somewhere.