using System.Windows.Forms;

namespace System
{
    internal class KeyEventHandler
    {
        private Action<object, KeyPressEventArgs> lineTextBox1_TextChanged;

        public KeyEventHandler(Action<object, KeyPressEventArgs> lineTextBox1_TextChanged)
        {
            this.lineTextBox1_TextChanged = lineTextBox1_TextChanged;
        }
    }
}