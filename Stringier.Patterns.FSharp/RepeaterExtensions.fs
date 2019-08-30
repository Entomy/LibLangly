namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

type RepeaterExtensions =
    static member Repeat(left:Pattern, right:Int32) = PatternBindings.Repeater(left, right)
    static member Repeat(left:String, right:Int32) = PatternBindings.Repeater(left, right)
    static member Repeat(left:Char, right:Int32) = PatternBindings.Repeater(left, right)
