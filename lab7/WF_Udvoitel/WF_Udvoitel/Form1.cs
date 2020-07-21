using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WF_Udvoitel.Doubler;

// Лях Павел
//а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
//б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.
// Игрок должен получить это число за минимальное количество ходов.
//в) * Добавить кнопку «Отменить», которая отменяет последние ходы.Используйте обобщенный класс Stack.

namespace WF_Udvoitel
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Сброс";
            lblNumber.Text = "0";
            this.Text = "Удвоитель";

            // Create menu
            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            ToolStripMenuItem play = new ToolStripMenuItem("Играть");
            play.Click += Play_Click;
            play.ShortcutKeys = Keys.Control | Keys.G;
            fileItem.DropDownItems.Add(play);
            menuStrip1.Items.Add(fileItem);
        }                
       
        private void Play_Click(object sender, EventArgs e)
        {
            btnReset_Click("new game", new EventArgs());
            game = true;
            Start();
            MessageBox.Show($"Необходимо получить: {target}\nМинимальное количество ходов: {min}");
            lblTarget.Text = $"Необходимо получить: {target}";
            lblSteps.Text = $"Минимальное количество ходов: {min}";
            AdditionalElementsVisible(true);
        }       

        private void btnCommand1_Click(object sender, EventArgs e)
        {            
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            counter++;
            lblPressCount.Text = $"Количество нажатий: {counter.ToString()}";
            PushStack(1);
            CheckStatusOfGame();
        }
        private void btnCommand2_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            counter++;
            lblPressCount.Text = $"Количество нажатий: {counter.ToString()}";
            PushStack(2);
            CheckStatusOfGame();
        }

        private void CheckStatusOfGame()
        {
            if (game)
            {
                if (counter >= 1)
                {
                    btnUndo.Visible = true;
                }
                else
                {
                    btnUndo.Visible = false;
                }

                if (counter == min && target == int.Parse(lblNumber.Text))
                {
                    MessageBox.Show($"Выигрыш");
                    btnReset_Click("Конец игры", new EventArgs());
                }
                else if ((counter == min || counter > min) && target < int.Parse(lblNumber.Text))
                {
                    MessageBox.Show("Проигрыш");                    
                    btnReset_Click("Конец игры", new EventArgs());
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "0";
            counter = 0;
            lblPressCount.Text = "Количество нажатий: " + counter.ToString();
            game = false;
            stack.Clear();
            AdditionalElementsVisible(false);            
        }

        private void AdditionalElementsVisible(bool v)
        {
            if (counter == 0)
            {
                btnUndo.Visible = false;
            }
            lblTarget.Visible = v;
            lblSteps.Visible = v;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {         
            AdditionalElementsVisible(false);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        { 
            if (stack.Count > 0)
            {
                counter--;
                if (stack.Peek() == 1)
                {
                    lblNumber.Text = (int.Parse(lblNumber.Text) - stack.Pop()).ToString();                    
                    lblPressCount.Text = $"Количество нажатий: {counter.ToString()}";
                }
                else if (stack.Peek() == 2)
                {
                    lblNumber.Text = (int.Parse(lblNumber.Text) / stack.Pop()).ToString();
                    lblPressCount.Text = $"Количество нажатий: {counter.ToString()}";
                }                
            }           
            AdditionalElementsVisible(true);
        }
    }
}