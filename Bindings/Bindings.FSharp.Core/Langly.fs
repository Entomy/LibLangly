namespace Langly

/// <summary>
/// Text case comparison mode.
/// </summary>
type case = Case

/// <summary>
/// The order of bytes of a multi-byte sequence.
/// </summary>
type endian = Endian

/// <summary>
/// Represents the base of all <see cref="Langly"/> objects.
/// </summary>
type object = Object

/// <summary>
/// Represents the base of all <see cref="Langly"/> records.
/// </summary>
type record< ^self when ^self :> Record< ^self>> = Record< ^self>
