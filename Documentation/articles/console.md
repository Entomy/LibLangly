# Console

[`Console`](https://entomy.github.io/LibLangly/api/Langly.Console.html) is a reimagining of how the [.NET `Console`](https://docs.microsoft.com/en-us/dotnet/api/system.console) should work. Despite numerous advances in graphics technology, console apps have become quite trendy. This is a welcome trend, as not only are console apps more efficient and generally more accessible, but it's also forced us to relook at console app design through a more modern lens.

> [!WARNING]
> This completely bypasses [`System.Console`](https://docs.microsoft.com/en-us/dotnet/api/system.console) and uses its own internals. Of particular note is using virtual terminal escape sequences across all platforms. This is inline with the [Windows Console and Terminal roadmap](https://docs.microsoft.com/en-us/windows/console/ecosystem-roadmap) but will mean older platforms aren't supported out-of-the-box.

Generally speaking, [`Console`](https://entomy.github.io/LibLangly/api/Langly.Console.html) looks like the same [`System.Console`](https://docs.microsoft.com/en-us/dotnet/api/system.console) you're used to, and in many cases drop-in replacement is possible. Include it like so:

# [C#](#tab/cs)

~~~~csharp
using Langly; // If System is not used
// Or
using Console = Langly.Console; // If System is used
~~~~

# [VB](#tab/vb)

~~~~vbnet
Imports Langly 'If System is not used
'Or
Imports Console = Langly.Console 'If System is used
~~~~

# [F#](#tab/fs)

~~~~fsharp
open Langly
~~~~

***

For additional features you'll need to include the `Langly` namespace, not just the `Console` alias.

# [C#](#tab/cs)

~~~~csharp
Console.WriteLine("Hello from Langly.Console!");
~~~~

# [VB](#tab/vb)

~~~~vbnet
Console.WriteLine("Hello from Langly.Console!")
~~~~

# [F#](#tab/fs)

~~~~fsharp
Console.WriteLine("Hello from Langly.Console!")
~~~~

***