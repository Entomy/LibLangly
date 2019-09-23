namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

[<AutoOpen>]
module ResultExtensions =
    /// <summary>Get whether the parse was successful</summary>
    let inline success(result:Result):Boolean = ResultBindings.Success(result)

    /// <summary>Get the captured text during the parse</summary>
    let inline captured(result:Result):String = ResultBindings.Text(result)