using System;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents part of a <see cref="Pattern"/>
	/// </summary>
	internal interface INode : IParser, IEquatable<String> {
		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see cref="Pattern"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		Result Neglect(ref Source Source);
	}
}
