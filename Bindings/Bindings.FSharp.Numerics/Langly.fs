namespace Langly

open System
open Langly
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
    /// Contains different averaging functions
    /// </summary>
    module mean =
        /// <summary>
        /// Finds the arithmetic mean of the <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The values to find the mean of.</param>
        /// <returns>The mean of the <paramref name="values"/>.</returns>
        let inline arithmetic (values:^values):^result = ArithmeticMean<NumericExtensions, ^values, ^result> values

        /// <summary>
        /// Finds the geometric mean of the <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The values to find the mean of.</param>
        /// <returns>The mean of the <paramref name="values"/>.</returns>
        let inline geometric (values:^values):^result = GeometricMean<NumericExtensions, ^values, ^result> values

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
