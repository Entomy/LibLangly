using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations
	/// </summary>
    public readonly struct Result {

		private readonly Boolean Success;

		private readonly String Remaining;

		public static implicit operator Boolean(Result Result) => Result.Success;

		public static implicit operator String(Result Result) => Result.Remaining;

		public Result(Boolean Success, String Remaining) {
			this.Success = Success;
			this.Remaining = Remaining;
		}

	}
}
