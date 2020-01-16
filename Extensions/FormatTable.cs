using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Stringier {
	/// <summary>
	/// Helper class for tabular formatting.
	/// </summary>
	/// <remarks>
	/// This is essentially a semantic wrapper around what is conceptually a 2-dimensional array. The exact implementation will vary. Regardless, it provides the means to calculate things like maximal column width, and other useful properties when formatting.
	/// </remarks>
	public sealed class FormatTable {
		/// <summary>
		/// The <see cref="String"/> used to delimit columns.
		/// </summary>
		private readonly String ColumnDelimiter = "│";

		/// <summary>
		/// The backing records of the table.
		/// </summary>
		private readonly List<String[]> Records;

		/// <summary>
		/// The widths of each column of the table, and the width of the table overall.
		/// </summary>
		/// <remarks>
		/// This serves as part of a rolling computation. Because this datatype is obviously meant for formatting, and with intended use, always becomes a single <see cref="String"/> at the end of it's lifetime, it's faster to maintain the widths as a simple compare-assign during <see cref="Format(object[])"/>, etc, calls, than to defer until necessary and compute the maximal width by iterating over the table once for each column; this is the least efficient mode of iteration.
		/// </remarks>
		private readonly Int32[] Widths;

		/// <summary>
		/// The alignment to use for each column.
		/// </summary>
		/// <remarks>The defaults to <see cref="Alignment.Default"/>, which looks up the current cultures text direction and uses the (hopefully) appropriate alignment.</remarks>
		private readonly Alignment[] Alignments;

		/// <summary>
		/// Initialize a new <see cref="FormatTable"/> with the specified <paramref name="columns"/> count.
		/// </summary>
		/// <param name="columns">The amount of columns in the table.</param>
		public FormatTable(Int32 columns) {
			Records = new List<String[]>();
			Widths = new Int32[columns];
			Alignments = new Alignment[columns];
		}

		/// <summary>
		/// Initialize a new <see cref="FormatTable"/> with the specified <paramref name="columns"/> count and <paramref name="alignment"/>.
		/// </summary>
		/// <param name="columns">The amount of columns in the table.</param>
		/// <param name="alignment">The <see cref="Alignment"/> to use for each column.</param>
		public FormatTable(Int32 columns, Alignment alignment) : this(columns) {
			for (Int32 i = 0; i < Alignments.Length; i++) {
				Alignments[i] = alignment;
			}
		}

		/// <summary>
		/// Initialize a new <see cref="FormatTable"/> with the specified <paramref name="columns"/> count and <paramref name="alignments"/>.
		/// </summary>
		/// <param name="columns">The amount of columns in the table.</param>
		/// <param name="alignments">An <see cref="Array"/> of <see cref="Alignment"/> corresponding to each column.</param>
		public FormatTable(Int32 columns, params Alignment[] alignments) : this(columns) {
			if (alignments.Length != Alignments.Length) {
				throw new ArgumentException("Alignments count must be the same as the column count. Alignments are per-column.", nameof(alignments));
			}
			Alignments = alignments;
		}

		/// <summary>
		/// Places the format items in a new record of the <see cref="FormatTable"/> with the string representation of a specified object.
		/// </summary>
		/// <param name="arg0">The object to format.</param>
		/// <remarks>Unlike with <see cref="String.Format(String, Object)"/> or <see cref="StringierExtensions.Format(String, Object)"/> and variants, arguments here may be <see langword="null"/>. When <see langword="null"/>, they will be placed into the table as <see cref="String.Empty"/>.</remarks>
		public void Format(Object? arg0) {
			if (Widths.Length != 1) {
				throw new FormatException($"Table width is {Widths.Length}; all records must be that wide");
			}
			String s = arg0?.ToString() ?? String.Empty;
			if (s.Length > Widths[0]) {
				Widths[0] = s.Length;
			}
			Records.Add(new[] { s });
		}

		/// <summary>
		/// Places the format items in a new record of the <see cref="FormatTable"/> with the string representation of a specified object.
		/// </summary>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <remarks>Unlike with <see cref="String.Format(String, Object)"/> or <see cref="StringierExtensions.Format(String, Object)"/> and variants, arguments here may be <see langword="null"/>. When <see langword="null"/>, they will be placed into the table as <see cref="String.Empty"/>.</remarks>
		public void Format(Object? arg0, Object? arg1) {
			if (Widths.Length != 2) {
				throw new FormatException($"Table width is {Widths.Length}; all records must be that wide");
			}
			String s1 = arg0?.ToString() ?? String.Empty;
			if (s1.Length > Widths[0]) {
				Widths[0] = s1.Length;
			}
			String s2 = arg1?.ToString() ?? String.Empty;
			if (s2.Length > Widths[1]) {
				Widths[1] = s2.Length;
			}
			Records.Add(new[] { s1, s2 });
		}

		/// <summary>
		/// Places the format items in a new record of the <see cref="FormatTable"/> with the string representation of a specified object.
		/// </summary>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <param name="arg2">The third object to format.</param>
		/// <remarks>Unlike with <see cref="String.Format(String, Object)"/> or <see cref="StringierExtensions.Format(String, Object)"/> and variants, arguments here may be <see langword="null"/>. When <see langword="null"/>, they will be placed into the table as <see cref="String.Empty"/>.</remarks>
		public void Format(Object? arg0, Object? arg1, Object? arg2) {
			if (Widths.Length != 3) {
				throw new FormatException($"Table width is {Widths.Length}; all records must be that wide");
			}
			String s1 = arg0?.ToString() ?? String.Empty;
			if (s1.Length > Widths[0]) {
				Widths[0] = s1.Length;
			}
			String s2 = arg1?.ToString() ?? String.Empty;
			if (s2.Length > Widths[1]) {
				Widths[1] = s2.Length;
			}
			String s3 = arg2?.ToString() ?? String.Empty;
			if (s3.Length > Widths[2]) {
				Widths[2] = s3.Length;
			}
			Records.Add(new[] { s1, s2, s3 });
		}

		/// <summary>
		/// Places the format items in a new record of the <see cref="FormatTable"/> with the string representation of a corresponding object in a specified array.
		/// </summary>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <remarks>Unlike with <see cref="String.Format(String, Object)"/> or <see cref="StringierExtensions.Format(String, Object)"/> and variants, arguments here may be <see langword="null"/>. When <see langword="null"/>, they will be placed into the table as <see cref="String.Empty"/>.</remarks>
		public void Format(params Object?[] args) {
			if (Widths.Length != args.Length) {
				throw new FormatException($"Table width is {Widths.Length}; all records must be that wide");
			}
			String[] format = new String[args.Length];
			String s;
			for (Int32 i = 0; i < args.Length; i++) {
				s = args[i]?.ToString() ?? String.Empty;
				if (s.Length > Widths[i]) {
					Widths[i] = s.Length;
				}
				format[i] = s;
			}
			Records.Add(format);
		}

		/// <summary>
		/// Converts the table to its equivalent string representation.
		/// </summary>
		/// <returns>The string representation of this table.</returns>
		/// <remarks>This string can be directly written to the console or file without further processing.</remarks>
		/// <exception cref="InvalidOperationException">An alignment was present that hasn't been handled in this method.</exception>
		public override String ToString() {
			StringBuilder builder = new StringBuilder();
			foreach (String[] record in Records) {
				for (Int32 i = 0; i < Widths.Length; i++) {
					switch (Alignments[i]) {
					case Alignment.Default:
						if (CultureInfo.CurrentCulture.TextInfo.IsRightToLeft) {
							goto case Alignment.Right;
						} else {
							goto case Alignment.Left;
						}
					case Alignment.Left:
						_ = builder.Append(record[i].PadRight(Widths[i]));
						break;
					case Alignment.Right:
						_ = builder.Append(record[i].PadLeft(Widths[i]));
						break;
					case Alignment.Center:
						_ = builder.Append(record[i].Pad(Widths[i]));
						break;
					default:
						throw new InvalidOperationException($"Alignment of {Alignments[i]} wasn't handled.");
					}
					if (i < Widths.Length - 1) {
						_ = builder.Append(ColumnDelimiter);
					}
				}
				_ = builder.Append('\n');
			}
			return builder.ToString();
		}
	}
}
