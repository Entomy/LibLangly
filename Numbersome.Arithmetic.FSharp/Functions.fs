namespace Numbersome

open System
open Numbersome
open Bindings

[<AutoOpen>]
module Functions =
    /// <summary>
    /// Multiplies the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to sum.</param>
    /// <returns>The sum of the <paramref name="values"/>.</returns>
    let inline product (values:^values):^result = Product<ArithmeticExtensions, ^values, ^result> values

    /// <summary>
    /// Sums the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to sum.</param>
    /// <returns>The sum of the <paramref name="values"/>.</returns>
    let inline sum (values:^values):^result = Sum<ArithmeticExtensions, ^values, ^result> values
