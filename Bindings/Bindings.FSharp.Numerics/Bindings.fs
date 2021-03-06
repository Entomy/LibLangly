﻿namespace Langly

module internal Bindings =
    let inline Max< ^t, ^a, ^b when (^t or ^a) : (static member Max : ^a -> ^b)> values = ((^t or ^a) : (static member Max : ^a -> ^b)(values))

    let inline ArithmeticMean< ^t, ^a, ^b when (^t or ^a) : (static member ArithmeticMean : ^a -> ^b)> values = ((^t or ^a) : (static member ArithmeticMean : ^a -> ^b)(values))

    let inline GeometricMean< ^t, ^a, ^b when (^t or ^a) : (static member GeometricMean : ^a -> ^b)> values = ((^t or ^a) : (static member GeometricMean : ^a -> ^b)(values))

    let inline Min< ^t, ^a, ^b when (^t or ^a) : (static member Min : ^a -> ^b)> values = ((^t or ^a) : (static member Min : ^a -> ^b)(values))

    let inline Mode< ^t, ^a, ^b when (^t or ^a) : (static member Mode : ^a -> ^b)> values = ((^t or ^a) : (static member Mode : ^a -> ^b)(values))

    let inline Product< ^t, ^a, ^b when (^t or ^a) : (static member Product : ^a -> ^b)> values = ((^t or ^a) : (static member Product : ^a -> ^b)(values))

    let inline Sum< ^t, ^a, ^b when (^t or ^a) : (static member Sum : ^a -> ^b)> values = ((^t or ^a) : (static member Sum : ^a -> ^b)(values))
