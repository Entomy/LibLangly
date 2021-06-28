# Introduction

## What is LibLangly?

Simply put, **LibLangly** is a collection of libraries meant to make text processing, parsing, and manipulation a far better experience than existing tooling out there. To help support this goal, numerous subprojects were spun off, and have become standalone libraries, but are managed under the same project umbrella.

Because of the developmental history of this project, the organization and naming is a bit unique. Rather than a whole history dump, however, that history will be given when explaining why things were done, throughout the various introductory articles.

**LibLangly** is extremely modular as far as libraries typically go. This helps with keeping the size down if you use any of its components. This has become especially important as Microsoft thinks it's a good idea to bring back static linking. Furthermore, it improves build times, making contributors time better spent, and even helps with API design, since contributors are required to use the same public API as downstream.
