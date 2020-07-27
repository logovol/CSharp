using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Reflection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxNumeric.Text = "0";
        }

        private void btnGetProperties_Click(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime();
            textBoxProperties.Text = GetPropertiesInfo(dateTime);
        }

        string GetPropertiesInfo(DateTime obj)
        {
            PropertyInfo[] info = obj.GetType().GetProperties();            
            StringBuilder str = new StringBuilder();
            int count = 1;
            foreach (var item in info)
            {                
                str.Append($"{count++}. {item.Name}\r\n");
            }                
            
            return str.ToString();
        }

        private void numericUpDownForTextBox_ValueChanged(object sender, EventArgs e)
        {
            textBoxNumeric.Text = numericUpDownForTextBox.Value.ToString();            
        }

        private void btnPlayBelieveOrNotBelieve_Click(object sender, EventArgs e)
        {
            FormGame f2 = new FormGame();
            f2.Show();
        }
    }
}
