namespace WindowsFormsApp1
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "f1:Зеленая миля  ",
            "f2:Побег из Шоушенка  ",
            "f3:Форрест Гамп  ",
            "f4:1+1  ",
            "f5:Список Шиндлера  ",
            "f6:Властелин колец - Братство Кольца  ",
            "f7:Интерстеллар  ",
            "f8:Бойцовский клуб  ",
            "f9:Унесённые призраками  ",
            "f10:Тайна Коко  ",
            "f11:Криминальное чтиво  ",
            "f12:Оппенгеймер  ",
            "f13:Начало  ",
            "f14:Назад в будущее  ",
            "f15:Изгой  ",
            "f16:Терминал  ",
            "f17:Красавцы  ",
            "f18:Поймай меня, если сможешь  ",
            "f19:Особенные  ",
            "f20:Симпсоны  ",
            "f21:Хоббит - Нежданное путешествие  ",
            "f22:Бешеные псы  ",
            "f23:Бесславные ублюдки  ",
            "f24:Корпорация монстров  ",
            "f25:Я краснею  ",
            "f26:Ходячие мертвецы  ",
            "f27:Мгла  ",
            "f28:Я — легенда"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(613, 293);
            this.checkedListBox1.TabIndex = 1;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "f1:Зеленая миля  ",
            "f2:Побег из Шоушенка  ",
            "f3:Форрест Гамп  ",
            "f4:1+1  ",
            "f5:Список Шиндлера  ",
            "f6:Властелин колец - Братство Кольца  ",
            "f7:Интерстеллар  ",
            "f8:Бойцовский клуб  ",
            "f9:Унесённые призраками  ",
            "f10:Тайна Коко  ",
            "f11:Криминальное чтиво  ",
            "f12:Оппенгеймер  ",
            "f13:Начало  ",
            "f14:Назад в будущее  ",
            "f15:Изгой  ",
            "f16:Терминал  ",
            "f17:Красавцы  ",
            "f18:Поймай меня, если сможешь  ",
            "f19:Особенные  ",
            "f20:Симпсоны  ",
            "f21:Хоббит - Нежданное путешествие  ",
            "f22:Бешеные псы  ",
            "f23:Бесславные ублюдки  ",
            "f24:Корпорация монстров  ",
            "f25:Я краснею  ",
            "f26:Ходячие мертвецы  ",
            "f27:Мгла  ",
            "f28:Я — легенда"});
            this.checkedListBox2.Location = new System.Drawing.Point(12, 317);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(613, 310);
            this.checkedListBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(901, 630);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "Прямой вывод";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(641, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(657, 465);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(641, 495);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(657, 129);
            this.textBox2.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1106, 630);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 27);
            this.button2.TabIndex = 6;
            this.button2.Text = "Обратный вывод";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(690, 630);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(189, 27);
            this.button3.TabIndex = 7;
            this.button3.Text = "Очистить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 669);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

