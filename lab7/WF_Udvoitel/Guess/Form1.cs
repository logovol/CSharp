using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Лях Павел
// Используя Windows Forms, разработать игру «Угадай число».
// Компьютер загадывает число от 1 до 100,
// а человек пытается его угадать за минимальное число попыток.
// Компьютер говорит, больше или меньше загаданное число введенного.  
// a) Для ввода данных от человека используется элемент TextBox;
// б) ** Реализовать отдельную форму c TextBox для ввода числа.

namespace Guess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "Угадай число";
        }

        Form f2;        
        Random rnd = new Random();
        public string answer = string.Empty;
        public int target;
        int start = 0;
        int end = 51;

        private void btnPlay_Click(object sender, EventArgs e)
        {
            answer = string.Empty;
            target = rnd.Next(start, end);
            f2 = new Form2($"Загадано число от {start} до {end - 1}");
            f2.Owner = this;
            f2.Show();
            this.Hide();            
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (answer != string.Empty)
            {
                lblResult.Visible = true;
                lblResult.Text = answer;
            }
            else
            {
                lblResult.Visible = false;
            }
        }
    }
}
