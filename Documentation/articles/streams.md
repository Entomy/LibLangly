# Streams

[.NET Streams](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream) are tragically flawed in some not obvious ways. **Streamy** intends to fix these flaws by introducing a completely new Stream API with its own design. The public API isn't radically different, although there are some modernizations. Most of the redesign has to do with internals, especially striving for a much higher degree of modularity.

## What's a stream?

Simply put, a stream is an abstraction, a representation of the _flow_ of data. When you stream a movie this is exactly what's going on. Because of the abstract nature of streams, they are useful for handling all kinds of data in a consistent way. This can be anything from streaming data over the network, like with a movie; to streaming songs of a disc; to streaming a file from the hard drive; to streaming data already in memory. The highly versatile nature of streams makes them a very useful abstraction. Vastly different data sources can be handled in a consistent way.

**C** did the world of programming a lot of good. Given its UNIX roots, it helped popularize the notion of a file being just as abstract as a stream. In fact, **C** handles them as the same thing. This is another highly powerful abstraction, but is one this project disagrees with, although only slightly. Instead of streams and files being synonymous, this project considers a file to be a specialization of a stream. Simply put, all files are streams, but not all streams are files. This allows specialized operations to be possible, but _only_ when you know you're working with a file. Because of this, the `Stream` type can actually be reasonably hardened and less error-prone.

## What's wrong with the .NET Stream?

[.NET `Stream`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream) uses a multi-component model. This is a _good_ thing. However, it exposes those components to you, the developer. This is a _bad_ thing. For one, it means implementation details leak out. Some of these might not be obvious, but it does happen. Second, is that it means you, the developer, are responsible for properly orchestrating operations between components. Some of these also aren't obvious, but it does happen. Third, it means that some operations are outright broken.

The most severe problem I have come across, although far from the only one, is the result of multi-buffering across `Stream`, `TextReader`, and `TextWriter`. So what's the problem? Say you're stream parsing, an incredibly common thing to do. It's quite common for parsers to do some backtracking. This isn't required by any means, but does greatly simplify operations. Regardless, many parsers exist which backtrack. Attempt to parse something. Backtrack because it wasn't there. Attempt to parse another possibility. Watch as everything fails spectacularly. You can get around this by adding yet-another-buffer which you manage and use to backtrack. But this is the wrong way to design a system.

Furthermore, duplex scenarios with streams have been fairly common in my experience. Talking to others who use streams often further backs this up. The [.NET `Stream`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream) model complicates this, by requiring a total of _3_ objects be created and managed. This is tedious and cumbersome. This can also be problematic given how buffering works.

## How's it work?

`Stream` entirely redesigns the internals and exposes everything through one simple type. Once you have a stream, you have everything you need to work with a stream. In fact, unlike the [.NET `Stream`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream), all the `Stream` type actually is, is orchestration logic for the individual components that do the work. As such, it makes sense to explain these components.

### `StreamBase`

This is the absolute most basic "stream" you could possibly write. No buffering. No encoding/decoding. No serialization/deserialization. Not even support for larger objects than `Byte`!

These limitations are actually hugely useful. Supporting additional datastreams is as simple as providing a derived `StreamBase` that is capable of communicating the intended way. Need to communicate over RS-232 and an implementation hasn't been provided? All that needs to be done is deriving this base type with how to read/write `Byte` over that medium. Buffering, encoding/decoding, and everything else are separate components and will _just work_. No Todd Howarding here.

> [!Note]
> These types often rely on native system libraries. Small deviations in behavior may happen because of this.
> This project attempts to provide a common API across platforms, not identical behavior across platforms.

### `IReadBuffer` and `IWriteBuffer`

These provide buffering behavior, or lack thereof, for the stream. By having these as separate objects, the situation in which a single shared buffer is competed over resulting in overwritten data is not a problem. Data that was read and still in the buffer won't be written on a flush. `Stream` constructors _should_ always expose an overload which accepts these as a form of dependency injection. Whenever possible, there should also be an overload which determines reasonable defaults.

Two common default buffers are entirely internal and are meant to cover certain common cases. These are the `MinimalBuffer`, a read-buffer, and `PassthroughBuffer`, a write-buffer. `PassthroughBuffer` doesn't actually buffer, and is meant for cases where no buffering is desired. Everything is passed directly to the underlying stream. This can be viewed in a similar way to a sentinel-node in data structures; it exists only to simplify code by eliminating null checks. If no write-buffer is appropriate or specified, this will be used. `MinimalBuffer` is the read-buffer analogue to `PassthroughBuffer`. However, because of some of the operations `Stream` supports, there must be at least a small buffer in place. `MinimalBuffer` provides 8-Bytes worth of buffer slots, enough to handle any built-in blittable value type. More on this soon.

The two interfaces, `IReadBuffer` and `IWriteBuffer` provide a sort of in-process communication protocol that all sorts of different buffering strategies communicate over. As such, `Stream` doesn't assume any particular kind of buffering, but rather, tells the buffers what it needs, with the buffers doing whatever they need to accomplish that.

> [!Note]
> The buffers used effect the capabilities of certain extra functionality, like seeking. A stream that isn't normally seekable can support limited seeks within buffered spaces.

### `Stream`

As mentioned `Stream` actually just handles orchestration. Because of this, you only ever work directly with one object: the stream instance.

Normally when working with streams you're given two options: read/write binary data as bytes, or read/write textual data as strings. This is far less than ideal. `Stream` provides a better way. Overloads allow for discriminating behavior based on the amount or type of the parameters. That last part is what's important. Overload the type.

`Stream` supports writing any built-in blittable value type, handling the conversions for you. More complex types and reference types are possible through the serialization mechanism. Writing is done exactly like you're familiar with:

# [C#](#tab/cs)

~~~~csharp
Byte b = 0;
stream.Write(b);
Int32 i = 0;
stream.Write(i);
Double d = 0.0;
stream.Write(d);
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim b As Byte = 0
stream.Write(b)
Dim i As Integer = 0
stream.Write(i)
Dim d As Double = 0.0
stream.Write(d)
~~~~

# [F#](#tab/fs)

~~~~fsharp
write 0uy stream |> ignore
write 0 stream |> ignore
write 0.0 stream |> ignore
~~~~

***

> [!Warning]
> Stream operations can fail, however, so unless you know the operation will absolutely succeed, prefer `TryWrite()` over `Write()`. `TryWrite()` has an overload which additionally reports the error conditions, if this information is desired.

> [!Note]
> **F#**'s `write` behaves similarly to `TryWrite()` and will return an `Option` where `None` is success and `Some` contains the error that occurred.

Reading is a bit different however. Many CLS Consumers, like C# and VisualBasic don't support overload resolution on return types. As such, we can't feasibly support this the most obvious way. What many opt for is a pseudo-hungarian-notation style, like `ReadByte()`, `ReadInt32()`, and so on. This is considered unsatisfactory for three reasons. One, it's extra typing, especially in the common case of reusing a single variable. Two, it litters intellisense with numerous extra methods which all conceptually do the same thing. Three, is relies on the programmer to provide type information, rather than doing the sensible thing of letting the compiler determine the type, and therefore the correct overload, as is normal in .NET. Instead, both read and peek are overloaded on an `out` parameter.

# [C#](#tab/cs)

~~~~csharp
stream.Read(out Byte b);
stream.Read(out Int32 i);
stream.Read(out Double d);
~~~~

# [VB](#tab/vb)

~~~~vbnet
Dim b As Byte
stream.Read(b)
Dim i As Integer
stream.Read(i)
Dim d As Double
stream.Read(d)
~~~~

# [F#](#tab/fs)

~~~~fsharp
read stream |> ignore
read stream |> ignore
read stream |> ignore
~~~~

***

> [!Warning]
> Stream operations can fail, however, so unless you know the operation will absolutely succeed, prefer `TryRead()` over `Read()`. `TryRead()` has an overload which additionally reports the error conditions, if this information is desired.

> [!Note]
> **F#**'s `read` behaves similarly to `TryRead()` and will return a `Choice<'a, 'b>` where `Choice1Of2` contains the value that was read, if successful, and `Choice2Of2` contains the error that occurred, if failed.

For every `Read()` or `TryRead()` there is an equivalent `Peek()` and `TryPeek()`.

## Going further

`Stream` isn't `sealed`, and this is a deliberate decision. Sometimes, additional orchestration needs to be done, as is the case with textual streams. Sometimes, additional functionality needs to be exposed for a subset of streams, as is the case with files. By leaving this possibility open, a huge amount of functionality is possible.