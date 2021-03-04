namespace System

open System

[<AutoOpen>]
module Extensions =
    type Memory<'t> with
        member this.GetSlice(start, stop) = this.Slice(start, stop - start)

    type ReadOnlyMemory<'t> with
        member this.GetSlice(start, stop) = this.Slice(start, stop - start)

    type Span<'t> with
        member this.GetSlice(start, stop) = this.Slice(start, stop - start)

    type ReadOnlySpan<'t> with
        member this.GetSlice(start, stop) = this.Slice(start, stop - start)
