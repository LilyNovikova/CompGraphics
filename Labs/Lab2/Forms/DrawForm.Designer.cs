namespace Lab2.Forms
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
            this.BtflCbx = new System.Windows.Forms.CheckBox();
            this.XTurnTrb = new System.Windows.Forms.TrackBar();
            this.YTurnTrb = new System.Windows.Forms.TrackBar();
            this.ZTurnTrb = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResetAngleBtn = new System.Windows.Forms.Button();
            this.XUdn = new System.Windows.Forms.NumericUpDown();
            this.ZUdn = new System.Windows.Forms.NumericUpDown();
            this.YUdn = new System.Windows.Forms.NumericUpDown();
            this.inputFileCmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XTurnTrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YTurnTrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZTurnTrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZUdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUdn)).BeginInit();
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
            // BtflCbx
            // 
            this.BtflCbx.AutoSize = true;
            this.BtflCbx.Location = new System.Drawing.Point(37, 66);
            this.BtflCbx.Name = "BtflCbx";
            this.BtflCbx.Size = new System.Drawing.Size(118, 21);
            this.BtflCbx.TabIndex = 2;
            this.BtflCbx.Text = "beautiful draw";
            this.BtflCbx.UseVisualStyleBackColor = true;
            // 
            // XTurnTrb
            // 
            this.XTurnTrb.Location = new System.Drawing.Point(738, 13);
            this.XTurnTrb.Maximum = 180;
            this.XTurnTrb.Minimum = -180;
            this.XTurnTrb.Name = "XTurnTrb";
            this.XTurnTrb.Size = new System.Drawing.Size(380, 56);
            this.XTurnTrb.TabIndex = 3;
            this.XTurnTrb.Scroll += new System.EventHandler(this.XTurnTrb_Scroll);
            // 
            // YTurnTrb
            // 
            this.YTurnTrb.Location = new System.Drawing.Point(166, 102);
            this.YTurnTrb.Maximum = 180;
            this.YTurnTrb.Minimum = -180;
            this.YTurnTrb.Name = "YTurnTrb";
            this.YTurnTrb.Size = new System.Drawing.Size(380, 56);
            this.YTurnTrb.TabIndex = 4;
            this.YTurnTrb.Scroll += new System.EventHandler(this.YTurnTrb_Scroll);
            // 
            // ZTurnTrb
            // 
            this.ZTurnTrb.Location = new System.Drawing.Point(738, 102);
            this.ZTurnTrb.Maximum = 180;
            this.ZTurnTrb.Minimum = -180;
            this.ZTurnTrb.Name = "ZTurnTrb";
            this.ZTurnTrb.Size = new System.Drawing.Size(380, 56);
            this.ZTurnTrb.TabIndex = 5;
            this.ZTurnTrb.Scroll += new System.EventHandler(this.ZTurnTrb_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(570, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(570, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Z";
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
            // XUdn
            // 
            this.XUdn.Location = new System.Drawing.Point(612, 21);
            this.XUdn.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.XUdn.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.XUdn.Name = "XUdn";
            this.XUdn.Size = new System.Drawing.Size(120, 22);
            this.XUdn.TabIndex = 10;
            this.XUdn.ValueChanged += new System.EventHandler(this.XUdn_ValueChanged);
            // 
            // ZUdn
            // 
            this.ZUdn.Location = new System.Drawing.Point(612, 112);
            this.ZUdn.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.ZUdn.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.ZUdn.Name = "ZUdn";
            this.ZUdn.Size = new System.Drawing.Size(120, 22);
            this.ZUdn.TabIndex = 11;
            this.ZUdn.ValueChanged += new System.EventHandler(this.ZUdn_ValueChanged);
            // 
            // YUdn
            // 
            this.YUdn.Location = new System.Drawing.Point(57, 112);
            this.YUdn.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.YUdn.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.YUdn.Name = "YUdn";
            this.YUdn.Size = new System.Drawing.Size(120, 22);
            this.YUdn.TabIndex = 12;
            this.YUdn.ValueChanged += new System.EventHandler(this.YUdn_ValueChanged);
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
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 790);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputFileCmb);
            this.Controls.Add(this.YUdn);
            this.Controls.Add(this.ZUdn);
            this.Controls.Add(this.XUdn);
            this.Controls.Add(this.ResetAngleBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ZTurnTrb);
            this.Controls.Add(this.YTurnTrb);
            this.Controls.Add(this.XTurnTrb);
            this.Controls.Add(this.BtflCbx);
            this.Controls.Add(this.PaintBtn);
            this.Controls.Add(this.Canvas);
            this.Name = "DrawForm";
            this.Text = "Lab2";
            this.Load += new System.EventHandler(this.DrawForm_Load);
            this.ResizeEnd += new System.EventHandler(this.DrawForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XTurnTrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YTurnTrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZTurnTrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZUdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUdn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Button PaintBtn;
        private System.Windows.Forms.CheckBox BtflCbx;
        private System.Windows.Forms.TrackBar XTurnTrb;
        private System.Windows.Forms.TrackBar YTurnTrb;
        private System.Windows.Forms.TrackBar ZTurnTrb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ResetAngleBtn;
        private System.Windows.Forms.NumericUpDown XUdn;
        private System.Windows.Forms.NumericUpDown ZUdn;
        private System.Windows.Forms.NumericUpDown YUdn;
        private System.Windows.Forms.ComboBox inputFileCmb;
        private System.Windows.Forms.Label label4;
    }
}

