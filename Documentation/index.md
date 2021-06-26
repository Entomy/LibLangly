# LibLangly Documentation

This is the combined documentation for all parts of **LibLangly**. If you're looking for the docs for **Stringier**, **Collectathon**, or other components that had their own discrete documentation before, that's all been merged together here.

## Articles or API docs?

Articles are generally broken down by concept, rather than specific bit of code. This is done because all code units are documented, and that documentation is always up to date with the most recent repo contents. That documentation, especially in the `<remarks>` section, discusses any technical details about that specific unit. Instead, it makes more sense for the articles to discuss the high level stuff. Why are the collections designed the way they are and how do you pick which one to use? That is article content.

## Cross Language

**LibLangly** has been designed with cross-language use in mind. There are some caveats however. C# and F# consumers should largely be fine. C# directly, and F# through the use of language bindings to provide a function/pipeline-first experience. VisualBasic.NET has been abandoned by Microsoft in everything except a formal statement. Many parts of these libraries are still usable from VB, but anything requiring heavy use of references, which is the overwhelming majority of **Collectathon**, as well as many parts of **Stringier** and **Philosoft** are going to regularly run into problems. Other CLS Consumers such as RemObjects' [Mercury](https://www.elementscompiler.com/elements/mercury/), a VB "clone", but really more of a successor, _should_ work well regardless. However, I do not have a license for RemObjects' [Elements](https://www.elementscompiler.com/elements/default.aspx), and therefore am unable to personally verify this.