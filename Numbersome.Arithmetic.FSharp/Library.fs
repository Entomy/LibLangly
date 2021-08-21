namespace Numbersome

open System
open System.Traits
open System.Traits.Concepts

[<AutoOpen>]
module Functions =
    /// <summary>
    /// Returns the absolute value of a number.
    /// </summary>
    /// <param name="value">A numerical value.</param>
    /// <returns>The absolute value of <paramref name="value"/>.</returns>
    let inline abs< ^t when ^t :> INumber< ^t>> (value:^t):^t = value.Abs()

    /// <summary>
    /// Returns the next smallest value that compares less than <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to decrement.</param>
    /// <returns>The next smallest value that compares less than <paramref name="value"/>.</returns>
    let inline bitDecrement< ^t when ^t :> IFloatingPoint< ^t>> (value:^t):^t = value.BitDecrement()

    /// <summary>
    /// Returns the next largest value that compares greater than <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to increment.</param>
    /// <returns>The next largest value that compares greater than <paramref name="value"/>.</returns>
    let inline bitIncrement< ^t when ^t :> IFloatingPoint< ^t>> (value:^t):^t = value.BitIncrement()

    /// <summary>
    /// Returns the cube root of a specified number.
    /// </summary>
    /// <param name="value">A number whos cube root is to be found.</param>
    /// <returns>The cube root of <paramref name="value"/>.</returns>
    let inline cbrt< ^t when ^t :> IFloatingPoint< ^t>> (value:^t):^t = value.Cbrt()

    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to the specified number.
    /// </summary>
    /// <param name="value">A floating-point number.</param>
    /// <returns>The smallest integral value that is greater than or equal to <paramref name="value"/>.</returns>
    let inline ceiling< ^t when ^t :> IFloatingPoint< ^t>> (value:^t):^t = value.Ceiling()

    /// <summary>
    /// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="value">The value to be clamped.</param>
    /// <param name="min">The lower bound of the result.</param>
    /// <param name="max">The upper bound of the result.</param>
    /// <returns>
    /// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
    /// -or-
    /// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
    /// -or-
    /// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
    /// </returns>
    let inline clamp< ^t when ^t :> INumber< ^t>> (min:^t) (max:^t) (value:^t):^t = value.Clamp(min, max)

    /// <summary>
    /// Calculates the quotient and remainder of two numbers.
    /// </summary>
    /// <param name="dividend">The number to divide.</param>
    /// <param name="divisor">The number of divisions.</param>
    /// <returns>The quotient and remainder of the specified numbers.</returns>
    let inline ( /% )< ^t when ^t :> INumber< ^t>> (dividend:^t) (divisor:^t) = dividend.DivRem(divisor)

    /// <summary>
    /// Returns <see cref="Math.E"/> raised to the specified power.
    /// </summary>
    /// <param name="power">A number specifying a power to raise to.</param>
    /// <returns>The number <see cref="Math.E"/> raised to the <paramref name="power"/>.</returns>
    let inline exp< ^t when ^t :> IFloatingPoint< ^t>> (power:^t):^t = power.Exp()

    /// <summary>
    /// Returns the largest integral value less than or equal to the specified number.
    /// </summary>
    /// <param name="value">A floating-point number.</param>
    /// <returns>The largest integral value less than or equal to <paramref name="value"/>.</returns>
    let inline floor< ^t when ^t :> IFloatingPoint< ^t>> (value:^t):^t = value.Floor()

    /// <summary>
    /// Returns (<paramref name="x"/> * <paramref name="y"/>) + <paramref name="z"/>, rounded as one ternary operation.
    /// </summary>
    /// <param name="x">The number to be multiplied with <paramref name="y"/>.</param>
    /// <param name="y">The number to be multipled with <paramref name="x"/>.</param>
    /// <param name="z">The number to be added to the result of <paramref name="x"/> multiplied by <paramref name="y"/>.</param>
    /// <returns>(<paramref name="x"/> * <paramref name="y"/>) + <paramref name="z"/>, rounded as one ternary operation.</returns>
    let inline ( *+ )< ^t when ^t :> IFloatingPoint< ^t>> (x:^t) (y:^t, z:^t):^t = x.FusedMultiplyAdd(y, z)

    /// <summary>
    /// Returns a specified number raised to the specified power.
    /// </summary>
    /// <param name="value">A floating-point number to be raised to a power.</param>
    /// <param name="power">A floating-point number that specifies a power.</param>
    /// <returns>The number <paramref name="value"/> raised to the <paramref name="power"/>.</returns>
    let inline ( ** )< ^t when ^t :> IFloatingPoint< ^t>> (value:^t) (power:^t) = value.Pow(power)

    /// <summary>
    /// Returns the square root of a specified number.
    /// </summary>
    /// <param name="value">A number whos square root is to be found.</param>
    /// <returns>The square root of <paramref name="value"/>.</returns>
    let inline sqrt< ^t when ^t :> IFloatingPoint< ^t>> (value:^t):^t = value.Sqrt()
