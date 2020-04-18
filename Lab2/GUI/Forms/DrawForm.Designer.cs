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
            this.windowInputFileCmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.HighlightVisibleBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sectionsInputFileCmb = new System.Windows.Forms.ComboBox();
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
            // windowInputFileCmb
            // 
            this.windowInputFileCmb.FormattingEnabled = true;
            this.windowInputFileCmb.Items.AddRange(new object[] {
            "5window.txt",
            "3window.txt",
            "8window.txt"});
            this.windowInputFileCmb.Location = new System.Drawing.Point(509, 21);
            this.windowInputFileCmb.Name = "windowInputFileCmb";
            this.windowInputFileCmb.Size = new System.Drawing.Size(135, 24);
            this.windowInputFileCmb.TabIndex = 13;
            this.windowInputFileCmb.SelectedIndexChanged += new System.EventHandler(this.windowInputFileCmb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Window input file:";
            // 
            // HighlightVisibleBtn
            // 
            this.HighlightVisibleBtn.Location = new System.Drawing.Point(187, 13);
            this.HighlightVisibleBtn.Name = "HighlightVisibleBtn";
            this.HighlightVisibleBtn.Size = new System.Drawing.Size(126, 42);
            this.HighlightVisibleBtn.TabIndex = 9;
            this.HighlightVisibleBtn.Text = "Highlight visible";
            this.HighlightVisibleBtn.UseVisualStyleBackColor = true;
            this.HighlightVisibleBtn.Click += new System.EventHandler(this.highlightVisibleBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(666, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sections input file:";
            // 
            // sectionsInputFileCmb
            // 
            this.sectionsInputFileCmb.FormattingEnabled = true;
            this.sectionsInputFileCmb.Items.AddRange(new object[] {
            "2sections.txt",
            "4sections.txt",
            "7sections.txt"});
            this.sectionsInputFileCmb.Location = new System.Drawing.Point(795, 22);
            this.sectionsInputFileCmb.Name = "sectionsInputFileCmb";
            this.sectionsInputFileCmb.Size = new System.Drawing.Size(162, 24);
            this.sectionsInputFileCmb.TabIndex = 15;
            this.sectionsInputFileCmb.SelectedIndexChanged += new System.EventHandler(this.sectionsInputFileCmb_SelectedIndexChanged);
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 790);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sectionsInputFileCmb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.windowInputFileCmb);
            this.Controls.Add(this.HighlightVisibleBtn);
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
        private System.Windows.Forms.ComboBox windowInputFileCmb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button HighlightVisibleBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sectionsInputFileCmb;
    }
}

