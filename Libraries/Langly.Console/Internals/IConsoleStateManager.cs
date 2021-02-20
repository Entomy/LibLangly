using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Internals {
	/// <summary>
	/// Indicates the type manages the state of the <see cref="Console"/>.
	/// </summary>
	public interface IConsoleStateManager {
		/// <summary>
		/// Sets the background color to the <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The <see cref="Color"/> to set.</param>
		void SetBackground([AllowNull] Color value);

		/// <summary>
		/// Sets the foreground color to the <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The <see cref="Color"/> to set.</param>
		void SetForeground([AllowNull] Color value);

		/// <summary>
		/// Sets the console title.
		/// </summary>
		/// <param name="title">The title to set.</param>
		void SetTitle([AllowNull] String title);

		/// <summary>
		/// Switch to the alternate screen buffer.
		/// </summary>
		void UseAlternateScreenBuffer();

		/// <summary>
		/// Switch to the main screen buffer.
		/// </summary>
		void UseMainScreenBuffer();
	}
}
