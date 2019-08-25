using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal interface INode {
		Result Consume(String Source);

		Result Consume(ref Source Source);

		Boolean Equals(String Source);

		Result Neglect(String Source);

		Result Neglect(ref Source Source);

		String ToString();
	}
}
