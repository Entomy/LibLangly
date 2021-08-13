using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns <see cref="IFloatingPoint{TSelf}.E"/> raised to the specified power.
		/// </summary>
		/// <param name="d">A number specifying a power.</param>
		/// <returns>The number <see cref="Math.E"/> raised to the power <paramref name="d"/>. If <paramref name="d"/> equals <see cref="Double.NaN"/> or <see cref="Double.PositiveInfinity"/>, that value is returned. If <paramref name="d"/> equals <see cref="Double.NegativeInfinity"/>, 0 is returned.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.exp"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Exp<T>(this T d) where T : IFloatingPoint<T> => T.Exp(d);

		/// <summary>
		/// Takes <see cref="IFloatingPoint{TSelf}.E"/>, raises it to the power of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Exp<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Exp());
	}
}
