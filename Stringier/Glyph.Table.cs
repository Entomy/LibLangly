using System;
using System.Collections;
using System.Collections.Generic;

namespace Stringier {
	internal sealed class Table : IEnumerable<Record> {
		private Record[] records = new Record[32];

		private Int32 r = 0;

		internal Table() { }

		public ref Record this[UInt32 index] => ref records[index];

		public void Add(String sequence, UInt32 lower, UInt32 title, UInt32 upper, Int32 utf8Length, Int32 utf16Length) {
			if (r == records.Length) {
				Grow();
			}
			records[r++] = new Record(sequence, lower, title, upper, utf8Length, utf16Length);
		}

		internal void Grow() {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
			Record[] newRecords = new Record[records.Length * 2];
			Array.Copy(records, newRecords, r);
			records = null;
			GC.Collect();
			records = newRecords;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
		}

		/// <inheritdoc/>
		IEnumerator<Record> IEnumerable<Record>.GetEnumerator() => (IEnumerator<Record>)records.GetEnumerator();

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator() => records.GetEnumerator();
	}
}