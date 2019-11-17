# Patterns.MSTest

This project provides testing extensions to [Patterns](https://github.com/Entomy/Stringier/tree/master/Patterns) for use with [MS Test](https://github.com/microsoft/testfx).

## But isn't [xunit](https://xunit.net/) superior? Microsoft is using it instead of their own product!

Yes.

For the most part.

There's a problem for library developers however. There's always problems for library developers.

[xunit](https://xunit.net/) is extended through downloading the [xunit.assert.source](https://www.nuget.org/packages/xunit.assert.source/) package and extending `Assert` by adding new methods in a `partial class Assert`.

Sounds great right? Direct and consistent extensions, since everything winds up in `Assert`.

It's great when you're an application developer. When you're a library developer, what do you do when your downstream needs to also extend `Assert`? What do you do when your downstream includes packages that also extended `Assert`?

You can violate this convention by instead creating your own assert class which doesn't have these collision problems. From experience, what then happens is people who don't understand these problems and don't even think to inquire, then rant about the necessary decision as if it's a product of unintelligence.

Or we can support a less common testing framework which is library/extension friendly and just get the rare "you should migrate to X" that you'll get no matter what.