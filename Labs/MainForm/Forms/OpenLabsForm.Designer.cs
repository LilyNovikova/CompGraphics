namespace MainForm.Forms
{
    partial class OpenLabsForm
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
            this.Lab5Btn = new System.Windows.Forms.Button();
            this.Lab1Btn = new System.Windows.Forms.Button();
            this.Lab2Btn = new System.Windows.Forms.Button();
            this.Lab3Btn = new System.Windows.Forms.Button();
            this.Lab4Btn = new System.Windows.Forms.Button();
            this.Lab6Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lab5Btn
            // 
            this.Lab5Btn.Location = new System.Drawing.Point(297, 172);
            this.Lab5Btn.Name = "Lab5Btn";
            this.Lab5Btn.Size = new System.Drawing.Size(181, 83);
            this.Lab5Btn.TabIndex = 0;
            this.Lab5Btn.Text = "Lab 5 (colored surface)";
            this.Lab5Btn.UseVisualStyleBackColor = true;
            this.Lab5Btn.Click += new System.EventHandler(this.Lab5Btn_Click);
            // 
            // Lab1Btn
            // 
            this.Lab1Btn.Location = new System.Drawing.Point(54, 46);
            this.Lab1Btn.Name = "Lab1Btn";
            this.Lab1Btn.Size = new System.Drawing.Size(181, 83);
            this.Lab1Btn.TabIndex = 1;
            this.Lab1Btn.Text = "Lab 1 (tangents)";
            this.Lab1Btn.UseVisualStyleBackColor = true;
            this.Lab1Btn.Click += new System.EventHandler(this.Lab1Btn_Click);
            // 
            // Lab2Btn
            // 
            this.Lab2Btn.Location = new System.Drawing.Point(297, 46);
            this.Lab2Btn.Name = "Lab2Btn";
            this.Lab2Btn.Size = new System.Drawing.Size(181, 83);
            this.Lab2Btn.TabIndex = 2;
            this.Lab2Btn.Text = "Lab 2 (Bezier curve)";
            this.Lab2Btn.UseVisualStyleBackColor = true;
            this.Lab2Btn.Click += new System.EventHandler(this.Lab2Btn_Click);
            // 
            // Lab3Btn
            // 
            this.Lab3Btn.Location = new System.Drawing.Point(549, 46);
            this.Lab3Btn.Name = "Lab3Btn";
            this.Lab3Btn.Size = new System.Drawing.Size(181, 83);
            this.Lab3Btn.TabIndex = 3;
            this.Lab3Btn.Text = "Lab 3 (Bezier surface)";
            this.Lab3Btn.UseVisualStyleBackColor = true;
            this.Lab3Btn.Click += new System.EventHandler(this.Lab3Btn_Click);
            // 
            // Lab4Btn
            // 
            this.Lab4Btn.Location = new System.Drawing.Point(54, 172);
            this.Lab4Btn.Name = "Lab4Btn";
            this.Lab4Btn.Size = new System.Drawing.Size(181, 83);
            this.Lab4Btn.TabIndex = 4;
            this.Lab4Btn.Text = "Lab 4 (visible sections\' parts)";
            this.Lab4Btn.UseVisualStyleBackColor = true;
            this.Lab4Btn.Click += new System.EventHandler(this.Lab4Btn_Click);
            // 
            // Lab6Btn
            // 
            this.Lab6Btn.Location = new System.Drawing.Point(549, 172);
            this.Lab6Btn.Name = "Lab6Btn";
            this.Lab6Btn.Size = new System.Drawing.Size(181, 83);
            this.Lab6Btn.TabIndex = 5;
            this.Lab6Btn.Text = "Lab 6 (light)";
            this.Lab6Btn.UseVisualStyleBackColor = true;
            this.Lab6Btn.Click += new System.EventHandler(this.Lab6Btn_Click);
            // 
            // OpenLabsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Lab6Btn);
            this.Controls.Add(this.Lab4Btn);
            this.Controls.Add(this.Lab3Btn);
            this.Controls.Add(this.Lab2Btn);
            this.Controls.Add(this.Lab1Btn);
            this.Controls.Add(this.Lab5Btn);
            this.Name = "OpenLabsForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Lab5Btn;
        private System.Windows.Forms.Button Lab1Btn;
        private System.Windows.Forms.Button Lab2Btn;
        private System.Windows.Forms.Button Lab3Btn;
        private System.Windows.Forms.Button Lab4Btn;
        private System.Windows.Forms.Button Lab6Btn;
    }
}

