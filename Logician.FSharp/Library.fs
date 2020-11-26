namespace Langly

open Bindings
open System

[<AutoOpen>]
module Library =
    /// <summary>
    /// Logical negation; not.
    /// </summary>
    let inline not (value) = Not<Extensions, _> value

    /// <summary>
    /// Logical conjunction; and.
    /// </summary>
    let inline (&&) (first) (second) = And<Extensions, _, _, _> first second

    /// <summary>
    /// Logical inclusion; or.
    /// </summary>
    let inline (||) (first) (second) = Or<Extensions, _, _, _> first second

    /// <summary>
    /// Logical exclusion; either-or.
    /// </summary>
    let inline (^^) (first) (second) = XOr<Extensions, _, _, _> first second

    /// <summary>
    /// Material implication; if this then that.
    /// </summary>
    let inline (-->) (this) (that) = Implies<Extensions, _, _, _> this that

    /// <summary>
    /// Logical equality; equal to.
    /// </summary>
    let inline (==) (first) (second) = first = second

    /// <summary>
    /// Logical inequality; not equal to.
    /// </summary>
    let inline (!=) (first) (second) = first <> second

    /// <summary>
    /// Material equivalence; if and only if.
    /// </summary>
    let inline (===) (first) (second) = Equivalent<Extensions, _, _, _> first second

    /// <summary>
    /// Material inequivalence; not if and only if.
    /// </summary>
    let inline (!==) (first) (second) = first ^^ second

    /// <summary>
    /// Logical contingency; it is unknown.
    /// </summary>
    let inline contingent (value) = Contingent<Extensions, _> value

    /// <summary>
    /// Logical necessity; it is true.
    /// </summary>
    let inline necessary (value) = Necessary<Extensions, _> value

    /// <summary>
    /// Logical possibly; it is not false.
    /// </summary>
    let inline possible (value) = Possible<Extensions, _> value
