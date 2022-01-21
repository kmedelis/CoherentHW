using Task1_Piano;

Key key = new Key(Octave.First, Note.A, Accidental.Sharp);
Key key2 = new Key(Octave.Second, Note.A, Accidental.Sharp);

Console.WriteLine(key2.Equals(key)); // False because they are different
Console.WriteLine(key2.Compare(key)); // 0 because different octaves

Console.WriteLine(key.ToString()); // prints A# (1)

Key key3 = new Key(Octave.First, Note.A, Accidental.Sharp);
Key key4 = new Key(Octave.First, Note.B, Accidental.Sharp);

Console.WriteLine(key3.Equals(key4)); // Returns False because they are different, as they have different notes
Console.WriteLine(key3.Compare(key4)); // returns 1 because they have same octaves