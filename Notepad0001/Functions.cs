using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad0001
{
    class Functions
    {    
        private static string _textToFind;
         public static string TextToFind
         {
             get {return _textToFind;}
             set {_textToFind = value;}
         }
        public static int GoToLineNumber { get; set; }
        public static string ReplacementText { get; internal set; }
        public static int MaxNumberOfLines { get; set; }

    }
}
