using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Testing;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Testing {
	/// <summary>
	/// Represents the analyzer verifier used for Philosoft.
	/// </summary>
	/// <remarks>
	/// This is what allows abstracting the code over any unit test runner.
	/// </remarks>
	internal sealed class PhilosoftVerifier : IVerifier {
		/// <summary>
		/// Tracks context.
		/// </summary>
		private readonly ImmutableStack<String> Context;

		/// <summary>
		/// Initializes a new <see cref="PhilosoftVerifier"/>.
		/// </summary>
		public PhilosoftVerifier() : this(ImmutableStack<String>.Empty) { }

		/// <summary>
		/// Initializes a new <see cref="PhilosoftVerifier"/>.
		/// </summary>
		/// <param name="context">The context stack to include.</param>
		private PhilosoftVerifier(ImmutableStack<String> context) => Context = context;

		/// <inheritdoc/>
		public void Empty<T>(String collectionName, IEnumerable<T> collection) {
			using IEnumerator<T> enumerator = collection.GetEnumerator();
			if (enumerator.MoveNext()) {
				throw new AssertException($"'{collectionName}' is not empty.\n{FormatContext()}");
			}
		}

		/// <inheritdoc/>
		public void Equal<T>(T expected, T actual, String? message = null) {
			if (message is null && Context.IsEmpty) {
				new Assert<T>(actual).Equals(expected);
			} else {
				if (!EqualityComparer<T>.Default.Equals(expected, actual)) {
					new Assert<T>(actual).Equals(expected, additionalMessage: FormatContext());
				}
			}
		}

		/// <inheritdoc/>
		[DoesNotReturn]
		public void Fail(String? message = null) {
			if (message is null && Context.IsEmpty) {
				new AssertException($"Failure was manually triggered.");
			} else {
				new AssertException($"Failure was manually triggered.\n{FormatContext()}");
			}
		}

		/// <inheritdoc/>
		public void False([DoesNotReturnIf(true)] Boolean assert, String? message = null) {
			if (message is null && Context.IsEmpty) {
				new Assert<Boolean>(assert).False();
			} else {
				new Assert<Boolean>(assert).False(additionalMessage: FormatContext());
			}
		}

		/// <inheritdoc/>
		public void LanguageIsSupported(String language) {
			new Assert<Boolean>(language != LanguageNames.CSharp && language != LanguageNames.VisualBasic && language != LanguageNames.FSharp).False(additionalMessage: $"Unsupported language: {language}");
		}

		/// <inheritdoc/>
		public void NotEmpty<T>(String collectionName, IEnumerable<T> collection) {
			using IEnumerator<T> enumerator = collection.GetEnumerator();
			if (!enumerator.MoveNext()) {
				throw new AssertException($"'{collectionName}' is empty.\n{FormatContext()}");
			}
		}

		/// <inheritdoc/>
		public IVerifier PushContext(String context) => new PhilosoftVerifier(Context.Push(context));

		/// <inheritdoc/>
		public void SequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T>? equalityComparer = null, String? message = null) {
			if (message is null && Context.IsEmpty) {
				using IEnumerator<T> exp = expected.GetEnumerator();
				using IEnumerator<T> act = expected.GetEnumerator();
				if (equalityComparer is null) {
					while (exp.MoveNext() && act.MoveNext()) {
						if (!Equals(exp.Current, act.Current)) {
							goto NotEqual;
						}
					}
					if (exp.MoveNext() || act.MoveNext()) {
						goto NotEqual;
					}
				} else {
					while (exp.MoveNext() && act.MoveNext()) {
						if (!equalityComparer.Equals(exp.Current, act.Current)) {
							goto NotEqual;
						}
					}
					if (exp.MoveNext() || act.MoveNext()) {
						goto NotEqual;
					}
				}
				return;
			NotEqual:
				throw new AssertException($"");
			} else {
				SequenceEqualEnumerableEqualityComparer<T> comparer = new SequenceEqualEnumerableEqualityComparer<T>(equalityComparer);
				Boolean areEqual = comparer.Equals(expected, actual);
				if (!areEqual) {
					throw new AssertException($"");
				}
			}
		}

		/// <inheritdoc/>
		public void True([DoesNotReturnIf(true)] Boolean assert, String? message = null) {
			if (message is null && Context.IsEmpty) {
				new Assert<Boolean>(assert).True();
			} else {
				new Assert<Boolean>(assert).True(additionalMessage: FormatContext());
			}
		}

		private String FormatContext() {
			String message = "";
			foreach (String? frame in Context) {
				message = "Context: " + frame + Environment.NewLine + message;
			}
			return message;
		}
	}
}
