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
        public string labelString;
        public TextBox textBox;
        public Button button;
        public InputForm(string label)
        {
            InitializeComponent();
            labelString = label;
            textBox = textBox1;
            label1.Text = labelString;
            button = button1;
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }
    }
}
