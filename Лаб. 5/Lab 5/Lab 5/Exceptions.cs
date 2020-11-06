using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab_5
{
    public class WrongInputException : ApplicationException
    {
        public WrongInputException() { }
        public WrongInputException(string message) : base(message) { }
      
    }

    public class FilmClassException : ApplicationException
    {
        public FilmClassException () { }
        public FilmClassException(string message) : base (message){ }

    }

    public class FilmCastException : FilmClassException
    {
        public FilmCastException() { }
        public FilmCastException(string message) : base(message) { }
    }
}
