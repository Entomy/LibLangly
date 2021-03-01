namespace Langly

open System
open Bindings

[<AutoOpen>]
module Functions =
    /// <summary>
    /// Finds the maximum of the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to find the maximum of.</param>
    /// <returns>The maximum of the <paramref name="values"/>.</returns>
    let inline max (values:^values):^result = Max<NumericExtensions, ^values, ^result> values

    /// <summary>
    /// Averages the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to find the mean of.</param>
    /// <param name="mean">The type of mean to calculate.</param>
    /// <returns>The mean of the <paramref name="values"/>.</returns>
    let inline mean (kind:Mean)(values:^values):^result = Mean<NumericExtensions, ^values, ^result> values kind

    /// <summary>
    /// Finds the minimum of the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to find the minimum of.</param>
    /// <returns>The minimum of the <paramref name="values"/>.</returns>
    let inline min (values:^values):^result = Min<NumericExtensions, ^values, ^result> values

    /// <summary>
    /// Finds the mode of the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to find the mode of.</param>
    /// <returns>The mode of the <paramref name="values"/>.</returns>
    let inline mode (values:^values):^result = Mode<NumericExtensions, ^values, ^result> values

    /// <summary>
    /// Multiplies the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to sum.</param>
    /// <returns>The sum of the <paramref name="values"/>.</returns>
    let inline product (values:^values):^result = Product<NumericExtensions, ^values, ^result> values

    /// <summary>
    /// Sums the <paramref name="values"/>.
    /// </summary>
    /// <param name="values">The values to sum.</param>
    /// <returns>The sum of the <paramref name="values"/>.</returns>
    let inline sum (values:^values):^result = Sum<NumericExtensions, ^values, ^result> values
