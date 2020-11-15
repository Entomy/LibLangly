namespace Philosoft

open Bindings
open System

[<AutoOpen>]
module Operators =
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
