namespace System

[<AutoOpen>]
module Functions =
    let inline ( == ) (left) (right) = left = right

    let inline ( != ) (left) (right) = left <> right

    /// <summary>
    /// Asserts the <paramref name="value"/>
    /// </summary>
    let inline ( ~+ ) (value:^a):^b = ((^a or ^b) : (static member op_UnaryPlus : ^a -> ^b)(value))

    /// <summary>
    /// Negates the <paramref name="value"/>
    /// </summary>
    let inline ( ~- ) (value:^a):^b = ((^a or ^b) : (static member op_UnaryNegation : ^a -> ^b)(value))

    /// <summary>
    /// Adds <paramref name="left"/> and <paramref name="right"/>.
    /// </summary>
    let inline ( + ) (left:^a) (right:^b):^c = ((^a or ^b or ^c) : (static member op_Addition : ^a -> ^b -> ^c)(left, right))

    /// <summary>
    /// Subtractions <paramref name="right"/> from <paramref name="left"/>.
    /// </summary>
    let inline ( - ) (left:^a) (right:^b):^c = ((^a or ^b or ^c) : (static member op_Subtraction : ^a -> ^b -> ^c)(left, right))

    /// <summary>
    /// Multiplies <paramref name="left"/> by <paramref name="right"/>.
    /// </summary>
    let inline ( * ) (left:^a) (right:^b):^c = ((^a or ^b or ^c) : (static member op_Multiply : ^a -> ^b -> ^c)(left, right))

    /// <summary>
    /// Divides <paramref name="left"/> by <paramref name="right"/>.
    /// </summary>
    let inline ( / ) (left:^a) (right:^b):^c = ((^a or ^b or ^c) : (static member op_Division : ^a -> ^b -> ^c)(left, right))

    /// <summary>
    /// Divides <paramref name="left"/> by <paramref name="right"/>, returning the remainder.
    /// </summary>
    let inline ( % ) (left:^a) (right:^b):^c = ((^a or ^b or ^c) : (static member op_Modulus : ^a -> ^b -> ^c)(left, right))

    /// <summary>
    /// Shifts <paramref name="value"/> left by <paramref name="amount"/>.
    /// </summary>
    let inline ( <<< ) (value:^a) (amount:^b):^c = ((^a or ^b or ^c) : (static member op_LeftShift : ^a -> ^b -> ^c)(value, amount))

    /// <summary>
    /// Shifts <paramref name="value"/> right by <paramref name="amount"/>.
    /// </summary>
    let inline ( >>> ) (value:^a) (amount:^b):^c = ((^a or ^b or ^c) : (static member op_RightShift : ^a -> ^b -> ^c)(value, amount))

    /// <summary>
    /// Bitwise Ands <paramref name="left"/> and <paramref name="right"/>.
    /// </summary>
    let inline ( &&& ) (left:^a) (right:^b):^c = ((^a or ^b or ^c) : (static member op_BitwiseAnd : ^a -> ^b -> ^c)(left, right))

    /// <summary>
    /// Bitwise Ors <paramref name="left"/> and <paramref name="right"/>.
    /// </summary>
    let inline ( ||| ) (left:^a) (right:^b):^c = ((^a or ^b or ^c) : (static member op_BitwiseOr : ^a -> ^b -> ^c)(left, right))

    /// <summary>
    /// Bitwise XOrs <paramref name="left"/> and <paramref name="right"/>.
    /// </summary>
    let inline ( ^^^ ) (left:^a) (right:^b):^c = ((^a or ^b or ^c) : (static member op_ExclusiveOr : ^a -> ^b -> ^c)(left, right))
