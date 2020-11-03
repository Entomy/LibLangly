using System.Diagnostics.CodeAnalysis;

namespace Consolator.Internals {
	public interface IConsoleStateManager {
		/// <summary>
		/// Sets the background color to the <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The <see cref="Color"/> to set.</param>
		void SetBackground([MaybeNull] Color value);

		/// <summary>
		/// Sets the foreground color to the <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The <see cref="Color"/> to set.</param>
		void SetForeground([MaybeNull] Color value);
	}
}
