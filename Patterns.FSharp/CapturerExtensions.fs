namespace Stringier.Patterns

open System
open Stringier.Patterns.Bindings
open System.Runtime.InteropServices

[<AutoOpen>]
module CapturerExtensions =
        
    let inline ( => )(pattern)([<Out>] into) = PatternBindings.Capturer(pattern, into)