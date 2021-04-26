namespace Numbersome

open System
open System.Runtime.InteropServices
open Numbersome
open Bindings

[<AutoOpen>]
module Functions =
    [<assembly: CLSCompliant(false)>]
    [<assembly: ComVisible(false)>]
    [<assembly: Guid("79755BDF-1F01-40E6-A809-59EC5FC1784E")>]
    do ()

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
