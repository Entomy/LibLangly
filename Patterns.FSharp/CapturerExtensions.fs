namespace Stringier.Patterns

open System.Runtime.InteropServices

[<AutoOpen>]
module CapturerExtensions =
        
    let inline ( => )(pattern:Pattern)([<Out>] into:Capture ref) = pattern.Capture(into)
