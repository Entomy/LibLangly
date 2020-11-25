namespace Philosoft

open Bindings
open System

[<AutoOpen>]
module Operators =
    //TODO: Find a different way to do these. It's a neat prototype, but these are function composition operators.

    /// <summary>
    /// Stream injection
    /// </summary>
    let inline (<<) (collection) (elements) =
        Write<Extensions, _, _> collection elements
        collection

    /// <summary>
    /// Stream extraction
    /// </summary>
    let inline (>>) (collection) (elements:'b ref) =
        elements := Read<Extensions, _, _> collection
        collection
