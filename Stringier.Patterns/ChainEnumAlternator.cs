#if !NETSTANDARD1_3
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Traits;
using FastEnumUtility;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents the alternation of the values of an <see cref="Enum"/>.
	/// </summary>
	/// <typeparam name="TEnum">The type of the enumeration.</typeparam>
	/// <remarks>
	/// This is an optimization around cases where <see cref="Enum"/> is used to specify possible values. Whether truely chaining or not, this is the most efficient way to handle <see cref="Enum"/>.
	/// </remarks>
	internal sealed class ChainEnumAlternator<TEnum> : Combinator where TEnum : struct, Enum {
		/// <summary>
		/// The <see cref="Case"/> to use when parsing.
		/// </summary>
		private readonly Case Casing;

		/// <summary>
		/// Initializes a new <see cref="ChainEnumAlternator{TEnum}"/>.
		/// </summary>
		/// <param name="casing">The <see cref="Case"/> to use for all <typeparamref name="TEnum"/>.</param>
		internal ChainEnumAlternator(Case casing) => Casing = casing;

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			foreach (String name in FastEnum.GetNames<TEnum>()) {
				new MemoryLiteral(name).Consume(source, ref location, out exception, trace);
				if (exception is null) return;
			}
		}

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) {
			foreach (String name in FastEnum.GetNames<TEnum>()) {
				if (Text.Equals(name[0], source[location], Casing)) return true;
			}
			return false;
		}

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) {
			foreach (String name in FastEnum.GetNames<TEnum>()) {
				if (Text.Equals(name[0], source[location], Casing)) return false;
			}
			return true;
		}

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			Int32 start = location;
			Int32 shortest = Int32.MaxValue;
			foreach (String name in FastEnum.GetNames<TEnum>().Reverse()) {
				new MemoryLiteral(name).Neglect(source, ref location, out exception, trace);
				if (location - start < shortest) {
					shortest = location - start;
				}
				if (exception is null) {
					location = start;
				} else {
					break;
				}
			}
			location += shortest;
		}
	}
}
#endif
