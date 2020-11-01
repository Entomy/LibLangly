# Consolator

**Consolator** is a reimagining of how the [`Console`](https://docs.microsoft.com/en-us/dotnet/api/system.console) should work. Despite numerous advances in graphics technology, console apps have become quite trendy. This is a welcome trend, as not only are console apps more efficient and generally more accessible, but it's also forced us to relook at console app design through a more modern lens.

[!WARNING]
<Consolator completely bypasses [`System.Console`](https://docs.microsoft.com/en-us/dotnet/api/system.console) and uses its own internals. Of particular note is using virtual terminal escape sequences across all platforms. This is inline with the [Windows Console and Terminal roadmap](https://docs.microsoft.com/en-us/windows/console/ecosystem-roadmap) but will mean older platforms aren't supported.>

Generally speaking, **Consolator** looks like the same [`System.Console`](https://docs.microsoft.com/en-us/dotnet/api/system.console) you're used to, and in many cases drop-in replacement is possible. Include it like so:

# [C#](#tab/cs)

~~~~csharp
using Console = Consolator.Console;
~~~~

# [VB](#tab/cs)

~~~~vbnet
Imports Console = Consolator.Console
~~~~

# [F#](#tab/fs)

~~~~fsharp
// Not implemented yet
~~~~

***

For additional features you'll need to include the `Consolator` namespace, not just the `Console` alias.

# [C#](#tab/cs)

~~~~csharp
Console.WriteLine("Hello from Consolator!");
~~~~

# [VB](#tab/cs)

~~~~vbnet
Console.WriteLine("Hello from Consolator!")
~~~~

# [F#](#tab/fs)

~~~~fsharp
// Not implemented yet
~~~~

***