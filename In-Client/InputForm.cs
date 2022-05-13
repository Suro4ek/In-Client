using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace In_Client
{
    public partial class InputForm : Form
    {
        int top = 1;
        public Button button;
        public InputForm()
        {
            InitializeComponent();
            this.button = button1;
        }

        public TextBox addTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.Left = 30;
            textBox.Top = top * 30;
            textBox.Width = 200;
            top += 1;
            return textBox;
        }

        public Label addLabel(String text)
        {
            Label label = new Label();
            label.Left = 30;
            label.Text = text;
            label.Width = 200;
            label.Left = 30;
            label.Top = top * 30;
            top += 1;
            return label;
        }
    }
}
