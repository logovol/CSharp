using System;
using System.Windows.Forms;

namespace Guess
{
    public partial class Form2 : Form
    {
        string title;
                
        public Form2(string title)
        {            
            InitializeComponent();
            Text = "Игра";            
            this.title = title;
        }

        Form1 main;

        private void textBoxNum_KeyDown(object sender, KeyEventArgs e)
        {
            lblResult.Text = "";
            if (e.KeyData == Keys.Enter)
            {                
                int n;
                try
                {
                    e.SuppressKeyPress = true;
                    main = this.Owner as Form1;
                    int target = main.target;
                    
                    n = int.Parse(textBoxNum.Text);
                    if (n > target)
                    {
                        lblResult.Text = "Перелет";                       
                    }
                    else if (n < target)
                    {
                        lblResult.Text = "Недолет";
                    }
                    else
                    {
                        this.Hide();
                        main.answer = "Победа";
                        main.Show();                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblInfo.Text = title;
        }  
        
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            main = this.Owner as Form1;
            if (main != null)
            {
                main.Show();
            }
        }
    }
}
