using System;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents part of a <see cref="Pattern"/>
	/// </summary>
	internal interface INode : IEquatable<String> {
		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		Result Consume(String Source);

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		Result Consume(ref Source Source);

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see name="Pattern"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		Result Neglect(String Source);

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see cref="Pattern"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		Result Neglect(ref Source Source);
	}
}
