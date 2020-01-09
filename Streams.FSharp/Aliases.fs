namespace Stringier.Streams

open System.IO

/// <summary>Provides a generic view of a sequence of bytes.</summary>
type stream = Stream

/// <summary>Specifies the position in a stream to use for seeking.</summary>
[<Struct>]
type origin = Begin
            | Current
            | End
