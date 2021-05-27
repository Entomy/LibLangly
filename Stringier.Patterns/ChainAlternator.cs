using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents the alternation of more than two <see cref="Pattern"/>. That is, one of many <see cref="Pattern"/>.
	/// </summary>
	/// <remarks>
	/// This is an optimization around cases of alternating alternators; there's much less indirection and other issues when flattening that portion of the graph. It also causes better syntax when written to a string.
	/// </remarks>
	internal sealed class ChainAlternator : Combinator {
		/// <summary>
		/// The possible <see cref="Pattern"/> matches.
		/// </summary>
		[DisallowNull, NotNull]
		internal readonly Pattern[] Patterns;

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="patterns"/>.
		/// </summary>
		/// <param name="patterns">The possible <see cref="Pattern"/> matches.</param>
		internal ChainAlternator([DisallowNull] params Pattern[] patterns) => Patterns = patterns;

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="firstPattern"/> and <paramref name="otherPatterns"/>.
		/// </summary>
		/// <param name="firstPattern">The very first <see cref="Pattern"/> to check.</param>
		/// <param name="otherPatterns">The other possible <see cref="Pattern"/> matches.</param>
		internal ChainAlternator([DisallowNull] Pattern firstPattern, [DisallowNull] Pattern[] otherPatterns) {
			Patterns = new Pattern[otherPatterns.Length + 1];
			Patterns[0] = firstPattern;
			otherPatterns.CopyTo(Patterns, 1);
		}

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="otherPatterns"/> and <paramref name="lastPattern"/>.
		/// </summary>
		/// <param name="otherPatterns">All but the very last possible <see cref="Pattern"/> to check.</param>
		/// <param name="lastPattern">The very last <see cref="Pattern"/> to check.</param>
		internal ChainAlternator([DisallowNull] Pattern[] otherPatterns, [DisallowNull] Pattern lastPattern) {
			Patterns = new Pattern[otherPatterns.Length + 1];
			otherPatterns.CopyTo(Patterns, 0);
			Patterns[Patterns.Length - 1] = lastPattern;
		}

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="firstPatterns"/> and <paramref name="lastPatterns"/>.
		/// </summary>
		/// <param name="firstPatterns">The first set of <see cref="Pattern"/> to check.</param>
		/// <param name="lastPatterns">The last set of <see cref="Pattern"/> to check.</param>
		internal ChainAlternator([DisallowNull] Pattern[] firstPatterns, [DisallowNull] Pattern[] lastPatterns) {
			Patterns = new Pattern[firstPatterns.Length + lastPatterns.Length];
			firstPatterns.CopyTo(Patterns, 0);
			lastPatterns.CopyTo(Patterns, firstPatterns.Length);
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Many() {
			foreach (Pattern Pattern in Patterns) {
				if (Pattern is Optor) {
					throw new InvalidOperationException("One or more of the components of this alternator are optional, and the alternator is marked as spanning. Options can not span, as it creates an infinite loop.");
				}
			}
			return base.Many();
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Or([AllowNull] Pattern other) {
			switch (other) {
			case ChainAlternator chain:
				return new ChainAlternator(Patterns, chain.Patterns);
			default:
				return base.Or(other);
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Or(Char other) => new ChainAlternator(Patterns, new CharLiteral(other));

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Or(Rune other) => new ChainAlternator(Patterns, new RuneLiteral(other));

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Or([AllowNull] String other) => other is not null ? new ChainAlternator(Patterns, new StringLiteral(other)) : this;
		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			foreach (Pattern pattern in Patterns) {
				pattern.Consume(source, ref location, out exception, trace);
				if (exception is null) {
					return;
				}
			}
		}

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			foreach (Pattern pattern in Patterns) {
				pattern.Consume(source, length, ref location, out exception, trace);
				if (exception is null) {
					return;
				}
			}
		}

		/// <inheritdoc/>
		protected internal override Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location) {
			foreach (Pattern pattern in Patterns) {
				if (pattern.IsConsumeHeader(source, location)) return true;
			}
			return false;
		}

		/// <inheritdoc/>
		protected internal override Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location) {
			foreach (Pattern pattern in Patterns) {
				if (pattern.IsNeglectHeader(source, location)) return true;
			}
			return false;
		}

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			Int32 start = location;
			Int32 shortest = Int32.MaxValue;
			for (Int32 i = Patterns.Length - 1; i >= 0; i--) {
				Patterns[i].Neglect(source, ref location, out exception, trace);
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

		/// <inheritdoc/>
		protected internal override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			exception = null;
			Int32 start = location;
			Int32 shortest = Int32.MaxValue;
			for (Int32 i = Patterns.Length - 1; i >= 0; i--) {
				Patterns[i].Neglect(source, length, ref location, out exception, trace);
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
