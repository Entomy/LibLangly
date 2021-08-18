using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

namespace Defender {
	/// <summary>
	/// Represents a <see cref="Tests"/> asserter.
	/// </summary>
	/// <typeparam name="TAnalyzer">The type of the analyzer to make assertions against.</typeparam>
	[CLSCompliant(false)]
	public sealed class AnalyzerAsserter<TAnalyzer> : Asserter<TAnalyzer> where TAnalyzer : DiagnosticAnalyzer, new() {
		private readonly String file;

		/// <summary>
		/// The case represented in the source being tested.
		/// </summary>
		public String Case => Path.GetFileNameWithoutExtension(file);

		/// <summary>
		/// The extension of the file being analyzed.
		/// </summary>
		public String Extension => Path.GetExtension(file);

		/// <summary>
		/// The language being analyzed.
		/// </summary>
		/// <remarks>
		/// This uses the constants in <see cref="LanguageNames"/> for consistencies sake.
		/// </remarks>
		public String Language {
			get {
				switch (Extension) {
				case ".cs":
					return LanguageNames.CSharp;
				case ".vb":
					return LanguageNames.VisualBasic;
				case ".fs":
				case ".fsi":
					return LanguageNames.FSharp;
				default:
					throw new NotSupportedException($"The extension '{Extension}' is not supported.");
				}
			}
		}

		/// <summary>
		/// Initializes a new <see cref="AnalyzerAsserter{TAnalyzer}"/>.
		/// </summary>
		/// <param name="file">The filename of the source to analyze.</param>
		public AnalyzerAsserter(String file) : base(new TAnalyzer()) => this.file = file;

		/// <summary>
		/// Asserts that when this source is analyzed, it reports no diagnostics.
		/// </summary>
		/// <returns>This <see cref="AnalyzerAsserter{TAnalyzer}"/>.</returns>
		public AnalyzerAsserter<TAnalyzer> Reports() {
			switch (Language) {
			case LanguageNames.CSharp:
				CSharpAnalyzerVerifier<TAnalyzer, Verifier>.VerifyAnalyzerAsync(File.ReadAllText(State.Path + file));
				break;
			default:
				throw new NotSupportedException($"The language '{Language}' is not supported.");
			}
			return this;
		}

		/// <summary>
		/// Asserts that when this source is analyzed, it reports a diagnostic with the <paramref name="id"/>.
		/// </summary>
		/// <param name="id">The identifier of the expected diagnostic.</param>
		/// <returns>This <see cref="AnalyzerAsserter{TAnalyzer}"/>.</returns>
		public AnalyzerAsserter<TAnalyzer> Reports(String id) {
			switch (Language) {
			case LanguageNames.CSharp:
				CSharpAnalyzerVerifier<TAnalyzer, Verifier>.VerifyAnalyzerAsync(File.ReadAllText(State.Path + file), CSharpAnalyzerVerifier<TAnalyzer, Verifier>.Diagnostic(id));
				break;
			default:
				throw new NotSupportedException($"The language '{Language}' is not supported.");
			}
			return this;
		}

		/// <summary>
		/// Asserts that when this source is analyzed, it reports each diagnostic in the specified <paramref name="ids"/>.
		/// </summary>
		/// <param name="ids">The identifiers of the expected diagnostics.</param>
		/// <returns>This <see cref="AnalyzerAsserter{TAnalyzer}"/>.</returns>
		public AnalyzerAsserter<TAnalyzer> Reports(params String[] ids) {
			switch (Language) {
			case LanguageNames.CSharp:
				DiagnosticResult[] diagnostics = new DiagnosticResult[ids.Length];
				for (Int32 i = 0; i < ids.Length; i++) {
					diagnostics[i] = CSharpAnalyzerVerifier<TAnalyzer, Verifier>.Diagnostic(ids[i]);
				}
				CSharpAnalyzerVerifier<TAnalyzer, Verifier>.VerifyAnalyzerAsync(File.ReadAllText(State.Path + file), diagnostics);
				break;
			default:
				throw new NotSupportedException($"The language '{Language}' is not supported.");
			}
			return this;
		}
	}
}
