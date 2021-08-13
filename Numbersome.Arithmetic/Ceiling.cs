using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the smallest integral value that is greater than or equal to the specified decimal number.
		/// </summary>
		/// <param name="d">A decimal number.</param>
		/// <returns>The smallest integral value that is greater than or equal to <paramref name="d"/>. Note that this method returns a <see cref="Decimal"/> instead of an integral type.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.ceiling"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Ceiling<T>(this T d) where T : IFloatingPoint<T> => T.Ceiling(d);

		/// <summary>
		/// Takes the smallest integral value that is greater than or equal to the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Ceiling<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Ceiling());
	}
}

