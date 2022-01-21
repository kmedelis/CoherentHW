using System;
using System.Collections.Generic;

namespace Task1_Piano
{
	public struct Key : IComparable
	{
		public Note keyNote;
		public Accidental keyAccidental;
		public Octave keyOctave;

		public Key(Octave octave, Note note, Accidental accidental)
		{
			keyOctave = octave;
			keyNote = note;
			keyAccidental = accidental;
		}

        public int Compare(Key keyToCompare)
        {
			return keyToCompare.keyOctave == this.keyOctave ? 1 : 0;
		}

		public override string ToString()
		{
			string temp = "";
			if (this.keyAccidental == Accidental.Flat)
            {
				temp = "b";
            }
			if (this.keyAccidental == Accidental.Sharp)
			{
				temp = "#";
			}
			return $"{this.keyNote}{temp} ({(int)this.keyOctave})";
		}
	}
}

