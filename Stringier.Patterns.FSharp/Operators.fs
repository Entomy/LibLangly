namespace System.Text.Patterns

#nowarn "86" // Shut your pedantic ass up

[<AutoOpen>]
module Operators =
    let inline ( || ) left right = altern<AlternatorExtensions, _, _, _> left right
    let inline ( >> ) left right = concat<ConcatenatorExtensions, _, _, _> left right
    let inline ( ~- ) value = negate<NegatorExtensions, _, _> value
    let inline ( ~~ ) value = option<OptorExtensions, _, _> value
    let inline ( * ) left right = repeat<RepeaterExtensions, _, _, _> left right
    let inline ( ~+ ) value = spannr<SpannerExtensions, _, _> value