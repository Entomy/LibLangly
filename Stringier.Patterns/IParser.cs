using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	/// <summary>
	/// Specifies the type is capable of parsing
	/// </summary>
	internal interface IParser : IEquatable<String> {
		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		Result Consume(ref Source Source);
	}
}
