

namespace Notepad0001
{
    class Functions
    {
        /*Make that class static since I need only one instance of it!
         Add a static auto property to the class I added:*/
        private static string _textToFind;
         public static string TextToFind
         {
             get {return _textToFind;}
             set {_textToFind = value;}
         }
        
        public string Content { get; set; }
        public static int GoToLineNumber { get; set; }
        public static string ReplacementText { get; internal set; }
        public static int MaxNumberOfLines { get; set; }
        public object SelectionEnd { get; private set; }
        public object SelectionStart { get; private set; }
        public int SelectionLength { get; private set; }


    }
}
