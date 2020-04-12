namespace GUI.Forms
{
    partial class DrawForm
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
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.PaintBtn = new System.Windows.Forms.Button();
            this.inputFileCmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ResetAngleBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.Location = new System.Drawing.Point(12, 177);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1115, 601);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // PaintBtn
            // 
            this.PaintBtn.Location = new System.Drawing.Point(37, 12);
            this.PaintBtn.Name = "PaintBtn";
            this.PaintBtn.Size = new System.Drawing.Size(127, 43);
            this.PaintBtn.TabIndex = 1;
            this.PaintBtn.Text = "Paint";
            this.PaintBtn.UseVisualStyleBackColor = true;
            this.PaintBtn.Click += new System.EventHandler(this.PaintBtn_Click);
            // 
            // inputFileCmb
            // 
            this.inputFileCmb.FormattingEnabled = true;
            this.inputFileCmb.Items.AddRange(new object[] {
            "4points.txt",
            "6points.txt",
            "0points.txt"});
            this.inputFileCmb.Location = new System.Drawing.Point(419, 22);
            this.inputFileCmb.Name = "inputFileCmb";
            this.inputFileCmb.Size = new System.Drawing.Size(92, 24);
            this.inputFileCmb.TabIndex = 13;
            this.inputFileCmb.SelectedIndexChanged += new System.EventHandler(this.inputFileCmb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Input file:";
            // 
            // ResetAngleBtn
            // 
            this.ResetAngleBtn.Location = new System.Drawing.Point(187, 13);
            this.ResetAngleBtn.Name = "ResetAngleBtn";
            this.ResetAngleBtn.Size = new System.Drawing.Size(126, 42);
            this.ResetAngleBtn.TabIndex = 9;
            this.ResetAngleBtn.Text = "Reset angle";
            this.ResetAngleBtn.UseVisualStyleBackColor = true;
            this.ResetAngleBtn.Click += new System.EventHandler(this.ResetAngleBtn_Click);
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 790);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputFileCmb);
            this.Controls.Add(this.ResetAngleBtn);
            this.Controls.Add(this.PaintBtn);
            this.Controls.Add(this.Canvas);
            this.Name = "DrawForm";
            this.Text = "DrawForm";
            this.Load += new System.EventHandler(this.DrawForm_Load);
            this.ResizeEnd += new System.EventHandler(this.DrawForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Button PaintBtn;
        private System.Windows.Forms.ComboBox inputFileCmb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ResetAngleBtn;
    }
}

