namespace Numbersome

open Troschuetz.Random

/// <summary>
/// Represents a pseudo-random number generator, which is an algorithm that produces a sequence of numbers that meet certain statistical requirements for randomness.
/// </summary>
type random = Random

[<AutoOpen>]
module Functions =
    /// <summary>
    /// Initializes a new instance of the <see cref="Random"/> class using a default seed value.
    /// </summary>
    let random = Random()

    /// <summary>
    /// Initializes a new instance of the <see cref="Random"/> class, using the specified <paramref name="seed"/> value.
    /// </summary>
    let randomSd (seed:int) = Random(seed)

    /// <summary>
    /// Initializes a new instance of the <see cref="Random"/> class, using the specified <paramref name="generator"/>.
    /// </summary>
    let randomGn (generator:#IGenerator) = Random(generator)

    /// <summary>
    /// Internal random number generator for the loose functions.
    /// </summary>
    let private rnd = Random()

    /// <summary>
    /// Generates a <see cref="boolean"/> value.
    /// </summary>
    let rndBool = rnd.NextBoolean()

    /// <summary>
    /// Generates a <see cref="char"/> value.
    /// </summary>
    let rndChar = rnd.NextChar()

    /// <summary>
    /// Generates a <see cref="decimal"/> value.
    /// </summary>
    let rndDecimal = rnd.NextDecimal()

    /// <summary>
    /// Generates a <see cref="double"/> value.
    /// </summary>
    let rndDouble = rnd.NextDouble()

    /// <summary>
    /// Generates a <see cref="int8"/> value.
    /// </summary>
    let rndInt8 = rnd.NextByte()

    /// <summary>
    /// Generates a <see cref="int16"/> value.
    /// </summary>
    let rndInt16 = rnd.NextInt16()

    /// <summary>
    /// Generates a <see cref="int32"/> value.
    /// </summary>
    let rndInt32 = rnd.NextInt32()

    /// <summary>
    /// Generates a <see cref="int64"/> value.
    /// </summary>
    let rndInt64 = rnd.NextInt64()

    /// <summary>
    /// Generates a <see cref="nativeint"/> value.
    /// </summary>
    let rndNativeInt = rnd.NextIntPtr()

    /// <summary>
    /// Generates a <see cref="uint8"/> value.
    /// </summary>
    let rndUInt8 = rnd.NextSByte()

    /// <summary>
    /// Generates a <see cref="uint16"/> value.
    /// </summary>
    let rndUInt16 = rnd.NextUInt16()

    /// <summary>
    /// Generates a <see cref="uint32"/> value.
    /// </summary>
    let rndUInt32 = rnd.NextUInt32()

    /// <summary>
    /// Generates a <see cref="uint64"/> value.
    /// </summary>
    let rndUInt64 = rnd.NextUInt64()

    /// <summary>
    /// Generates a <see cref="unativeint"/> value.
    /// </summary>
    let rndUNativeInt = rnd.NextUIntPtr()

    /// <summary>
    /// Generates a <see cref="single"/> value.
    /// </summary>
    let rndSingle = rnd.NextSingle()
