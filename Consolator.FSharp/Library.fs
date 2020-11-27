namespace Langly

open System

type private Con = Langly.Console

type Console private () =
    static let instance = Console()
    static member internal Instance = instance

    /// <summary>
    /// Gets the alternate screen buffer, and actives it.
    /// </summary>
    member _.Buffer = Con.Buffer

    /// <summary>
    /// Sets the console window title.
    /// </summary>
    member _.Title with set value = Con.Title <- value

    interface IWritable<String, Object> with
        member val Writable = true with get
        member _.Write(text) = Con.Write(text)
        member _.TryWrite(text, _) =
            Con.Write(text)
            true
    interface IWritable<Char array, Object> with
        member val Writable = true with get
        member _.Write(text) = Con.Write(text)
        member _.TryWrite(text, _) =
            Con.Write(text)
            true
    interface IWritable<Memory<Char>, Object> with
        member val Writable = true with get
        member _.Write(text) = Con.Write(text)
        member _.TryWrite(text, _) =
            Con.Write(text)
            true
    interface IWritable<ReadOnlyMemory<Char>, Object> with
        member val Writable = true with get 
        member _.Write(text) = Con.Write(text)
        member _.TryWrite(text, _) =
            Con.Write(text)
            true
    interface IWritable<Object, Object> with
        member val Writable = true with get
        member _.Write(object) = Con.Write(object)
        member _.TryWrite(object, _) =
            Con.Write(object)
            true

[<AutoOpen>]
module Library =
    /// <summary>
    /// The system console
    /// </summary>
    let console = Console.Instance
