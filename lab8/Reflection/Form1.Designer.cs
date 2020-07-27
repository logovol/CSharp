namespace Reflection
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.task1 = new System.Windows.Forms.TabPage();
            this.textBoxProperties = new System.Windows.Forms.TextBox();
            this.btnGetProperties = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.task2 = new System.Windows.Forms.TabPage();
            this.numericUpDownForTextBox = new System.Windows.Forms.NumericUpDown();
            this.textBoxNumeric = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.task3 = new System.Windows.Forms.TabPage();
            this.btnPlayBelieveOrNotBelieve = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.task1.SuspendLayout();
            this.task2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForTextBox)).BeginInit();
            this.task3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.task1);
            this.tabControl1.Controls.Add(this.task2);
            this.tabControl1.Controls.Add(this.task3);
            this.tabControl1.Location = new System.Drawing.Point(-4, 1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1404, 816);
            this.tabControl1.TabIndex = 0;
            // 
            // task1
            // 
            this.task1.Controls.Add(this.textBoxProperties);
            this.task1.Controls.Add(this.btnGetProperties);
            this.task1.Controls.Add(this.label1);
            this.task1.Controls.Add(this.textBox1);
            this.task1.Location = new System.Drawing.Point(4, 38);
            this.task1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.task1.Name = "task1";
            this.task1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.task1.Size = new System.Drawing.Size(1396, 774);
            this.task1.TabIndex = 0;
            this.task1.Text = "1";
            this.task1.UseVisualStyleBackColor = true;
            // 
            // textBoxProperties
            // 
            this.textBoxProperties.Location = new System.Drawing.Point(142, 235);
            this.textBoxProperties.Multiline = true;
            this.textBoxProperties.Name = "textBoxProperties";
            this.textBoxProperties.ReadOnly = true;
            this.textBoxProperties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxProperties.Size = new System.Drawing.Size(438, 177);
            this.textBoxProperties.TabIndex = 3;
            // 
            // btnGetProperties
            // 
            this.btnGetProperties.Location = new System.Drawing.Point(142, 116);
            this.btnGetProperties.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnGetProperties.Name = "btnGetProperties";
            this.btnGetProperties.Size = new System.Drawing.Size(443, 93);
            this.btnGetProperties.TabIndex = 2;
            this.btnGetProperties.Text = "Вывести свойста";
            this.btnGetProperties.UseMnemonic = false;
            this.btnGetProperties.UseVisualStyleBackColor = true;
            this.btnGetProperties.Click += new System.EventHandler(this.btnGetProperties_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Задание:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 21);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(443, 73);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "С помощью рефлексии выведите все свойства структуры DateTime";
            // 
            // task2
            // 
            this.task2.Controls.Add(this.numericUpDownForTextBox);
            this.task2.Controls.Add(this.textBoxNumeric);
            this.task2.Controls.Add(this.label2);
            this.task2.Controls.Add(this.textBox2);
            this.task2.Location = new System.Drawing.Point(4, 38);
            this.task2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.task2.Name = "task2";
            this.task2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.task2.Size = new System.Drawing.Size(1396, 774);
            this.task2.TabIndex = 1;
            this.task2.Text = "2";
            this.task2.UseVisualStyleBackColor = true;
            // 
            // numericUpDownForTextBox
            // 
            this.numericUpDownForTextBox.Location = new System.Drawing.Point(157, 232);
            this.numericUpDownForTextBox.Name = "numericUpDownForTextBox";
            this.numericUpDownForTextBox.Size = new System.Drawing.Size(120, 34);
            this.numericUpDownForTextBox.TabIndex = 5;
            this.numericUpDownForTextBox.ValueChanged += new System.EventHandler(this.numericUpDownForTextBox_ValueChanged);
            // 
            // textBoxNumeric
            // 
            this.textBoxNumeric.Location = new System.Drawing.Point(157, 166);
            this.textBoxNumeric.Name = "textBoxNumeric";
            this.textBoxNumeric.ReadOnly = true;
            this.textBoxNumeric.Size = new System.Drawing.Size(100, 34);
            this.textBoxNumeric.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Задание:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(157, 27);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(524, 96);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Создайте простую форму на которой свяжите свойство Text элемента TextBox со свойс" +
    "твом Value элемента NumericUpDown";
            // 
            // task3
            // 
            this.task3.Controls.Add(this.btnPlayBelieveOrNotBelieve);
            this.task3.Controls.Add(this.textBox3);
            this.task3.Location = new System.Drawing.Point(4, 38);
            this.task3.Name = "task3";
            this.task3.Size = new System.Drawing.Size(1396, 774);
            this.task3.TabIndex = 2;
            this.task3.Text = "3";
            this.task3.UseVisualStyleBackColor = true;
            // 
            // btnPlayBelieveOrNotBelieve
            // 
            this.btnPlayBelieveOrNotBelieve.Location = new System.Drawing.Point(228, 276);
            this.btnPlayBelieveOrNotBelieve.Name = "btnPlayBelieveOrNotBelieve";
            this.btnPlayBelieveOrNotBelieve.Size = new System.Drawing.Size(269, 113);
            this.btnPlayBelieveOrNotBelieve.TabIndex = 5;
            this.btnPlayBelieveOrNotBelieve.Text = "Редактор вопросов \"Верю не верю\"";
            this.btnPlayBelieveOrNotBelieve.UseVisualStyleBackColor = true;
            this.btnPlayBelieveOrNotBelieve.Click += new System.EventHandler(this.btnPlayBelieveOrNotBelieve_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(14, 14);
            this.textBox3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(706, 216);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 491);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Лях Павел. Лабораторная работа №8";
            this.tabControl1.ResumeLayout(false);
            this.task1.ResumeLayout(false);
            this.task1.PerformLayout();
            this.task2.ResumeLayout(false);
            this.task2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForTextBox)).EndInit();
            this.task3.ResumeLayout(false);
            this.task3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage task1;
        private System.Windows.Forms.TabPage task2;
        private System.Windows.Forms.Button btnGetProperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxProperties;
        private System.Windows.Forms.NumericUpDown numericUpDownForTextBox;
        private System.Windows.Forms.TextBox textBoxNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TabPage task3;
        private System.Windows.Forms.Button btnPlayBelieveOrNotBelieve;
        private System.Windows.Forms.TextBox textBox3;
    }
}

