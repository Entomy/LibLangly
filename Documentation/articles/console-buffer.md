# Console Screen Buffer

Alternate screen buffers are extremely useful for interactive console applications. However, managing these through ANSI Escape Sequences is obnoxious.

[`Console`](https://entomy.github.io/LibLangly/api/Langly.Console.html) contains a property [`ScreenBuffer`](https://entomy.github.io/LibLangly/api/Langly.Console.html#Langly_Console_ScreenBuffer) that, when accessed, creates a [`ScreenBuffer`](https://entomy.github.io/LibLangly/api/Langly.ScreenBuffer.html) object. Upon access, the alternate screen buffer is activated, and upon disposal, the alternative screen buffer is also disposed. Using it is as simple as follows:

# [C#](#tab/cs)

~~~~csharp
using var ScreenBuffer = Console.ScreenBuffer;
~~~~

# [VB](#tab/vb)

~~~~vbnet
Using ScreenBuffer As ScreenBuffer = Console.ScreenBuffer
End Using
~~~~

# [F#](#tab/fs)

~~~~fsharp
use screenBuffer = Console.ScreenBuffer
~~~~

***

As a matter of convenience [`ScreenBuffer`](https://entomy.github.io/LibLangly/api/Langly.ScreenBuffer.html) rexposes the same operations that [`Console`](https://entomy.github.io/LibLangly/api/Langly.Console.html) has. Furthermore, it also serves as a convenient way to extend what's normally thought of as a non-extendable type. Because the property returns an instance (even if it's a ref struct), it's possible to write extension methods for things like interactive console applications or even text-mode user interfaces.
