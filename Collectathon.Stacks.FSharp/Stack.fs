namespace Collectathon.Stacks

open System
open System.Runtime.InteropServices
open Collectathon.Stacks
open Bindings

/// <summary>
/// Represents a stack, a type of FIFO data structure.
/// </summary>
type stack<'e> = Stack<'e>

/// <summary>
/// Provides functions for working with stacks.
/// </summary>
module Stack =
    [<assembly: CLSCompliant(false)>]
    [<assembly: ComVisible(false)>]
    [<assembly: Guid("8D94C334-AF68-46B6-B0FA-4F0A3BC0D560")>]
    do ()

    let inline abs (stack:^a stack):^a stack = Abs<StackExtensions, ^a> stack

    let inline add (stack:^a stack):^a stack = Add<StackExtensions, ^a> stack

    let inline cbrt (stack:^a stack):^a stack = Cbrt<StackExtensions, ^a> stack
