namespace Lab6.Forms
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
            this.LightZUdn = new System.Windows.Forms.NumericUpDown();
            this.LightYUdn = new System.Windows.Forms.NumericUpDown();
            this.LightXUdn = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XTurnTrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YTurnTrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZTurnTrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZUdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightZUdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightYUdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightXUdn)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.Location = new System.Drawing.Point(9, 227);
            this.Canvas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(836, 502);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // PaintBtn
            // 
            this.PaintBtn.Location = new System.Drawing.Point(28, 10);
            this.PaintBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PaintBtn.Name = "PaintBtn";
            this.PaintBtn.Size = new System.Drawing.Size(95, 35);
            this.PaintBtn.TabIndex = 1;
            this.PaintBtn.Text = "Paint";
            this.PaintBtn.UseVisualStyleBackColor = true;
            this.PaintBtn.Click += new System.EventHandler(this.PaintBtn_Click);
            // 
            // XTurnTrb
            // 
            this.XTurnTrb.Location = new System.Drawing.Point(554, 11);
            this.XTurnTrb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.XTurnTrb.Maximum = 180;
            this.XTurnTrb.Minimum = -180;
            this.XTurnTrb.Name = "XTurnTrb";
            this.XTurnTrb.Size = new System.Drawing.Size(285, 45);
            this.XTurnTrb.TabIndex = 3;
            this.XTurnTrb.Scroll += new System.EventHandler(this.XTurnTrb_Scroll);
            // 
            // YTurnTrb
            // 
            this.YTurnTrb.Location = new System.Drawing.Point(124, 83);
            this.YTurnTrb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.YTurnTrb.Maximum = 180;
            this.YTurnTrb.Minimum = -180;
            this.YTurnTrb.Name = "YTurnTrb";
            this.YTurnTrb.Size = new System.Drawing.Size(285, 45);
            this.YTurnTrb.TabIndex = 4;
            this.YTurnTrb.Scroll += new System.EventHandler(this.YTurnTrb_Scroll);
            // 
            // ZTurnTrb
            // 
            this.ZTurnTrb.Location = new System.Drawing.Point(554, 83);
            this.ZTurnTrb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ZTurnTrb.Maximum = 180;
            this.ZTurnTrb.Minimum = -180;
            this.ZTurnTrb.Name = "ZTurnTrb";
            this.ZTurnTrb.Size = new System.Drawing.Size(285, 45);
            this.ZTurnTrb.TabIndex = 5;
            this.ZTurnTrb.Scroll += new System.EventHandler(this.ZTurnTrb_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Z";
            // 
            // ResetAngleBtn
            // 
            this.ResetAngleBtn.Location = new System.Drawing.Point(140, 11);
            this.ResetAngleBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ResetAngleBtn.Name = "ResetAngleBtn";
            this.ResetAngleBtn.Size = new System.Drawing.Size(94, 34);
            this.ResetAngleBtn.TabIndex = 9;
            this.ResetAngleBtn.Text = "Reset angle";
            this.ResetAngleBtn.UseVisualStyleBackColor = true;
            this.ResetAngleBtn.Click += new System.EventHandler(this.ResetAngleBtn_Click);
            // 
            // XUdn
            // 
            this.XUdn.Location = new System.Drawing.Point(459, 17);
            this.XUdn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.XUdn.Size = new System.Drawing.Size(90, 20);
            this.XUdn.TabIndex = 10;
            this.XUdn.ValueChanged += new System.EventHandler(this.XUdn_ValueChanged);
            // 
            // ZUdn
            // 
            this.ZUdn.Location = new System.Drawing.Point(459, 91);
            this.ZUdn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.ZUdn.Size = new System.Drawing.Size(90, 20);
            this.ZUdn.TabIndex = 11;
            this.ZUdn.ValueChanged += new System.EventHandler(this.ZUdn_ValueChanged);
            // 
            // YUdn
            // 
            this.YUdn.Location = new System.Drawing.Point(43, 91);
            this.YUdn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.YUdn.Size = new System.Drawing.Size(90, 20);
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
            this.inputFileCmb.Location = new System.Drawing.Point(314, 18);
            this.inputFileCmb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputFileCmb.Name = "inputFileCmb";
            this.inputFileCmb.Size = new System.Drawing.Size(70, 21);
            this.inputFileCmb.TabIndex = 13;
            this.inputFileCmb.SelectedIndexChanged += new System.EventHandler(this.inputFileCmb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Input file:";
            // 
            // LightZUdn
            // 
            this.LightZUdn.Location = new System.Drawing.Point(431, 177);
            this.LightZUdn.Margin = new System.Windows.Forms.Padding(2);
            this.LightZUdn.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LightZUdn.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.LightZUdn.Name = "LightZUdn";
            this.LightZUdn.Size = new System.Drawing.Size(90, 20);
            this.LightZUdn.TabIndex = 15;
            this.LightZUdn.ValueChanged += new System.EventHandler(this.LightZUdn_ValueChanged);
            // 
            // LightYUdn
            // 
            this.LightYUdn.Location = new System.Drawing.Point(242, 177);
            this.LightYUdn.Margin = new System.Windows.Forms.Padding(2);
            this.LightYUdn.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LightYUdn.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.LightYUdn.Name = "LightYUdn";
            this.LightYUdn.Size = new System.Drawing.Size(90, 20);
            this.LightYUdn.TabIndex = 16;
            this.LightYUdn.ValueChanged += new System.EventHandler(this.LightYUdn_ValueChanged);
            // 
            // LightXUdn
            // 
            this.LightXUdn.Location = new System.Drawing.Point(43, 177);
            this.LightXUdn.Margin = new System.Windows.Forms.Padding(2);
            this.LightXUdn.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LightXUdn.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.LightXUdn.Name = "LightXUdn";
            this.LightXUdn.Size = new System.Drawing.Size(90, 20);
            this.LightXUdn.TabIndex = 17;
            this.LightXUdn.ValueChanged += new System.EventHandler(this.LightXUdn_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 146);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Light point:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 179);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(224, 179);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(413, 179);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Z";
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 739);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LightXUdn);
            this.Controls.Add(this.LightYUdn);
            this.Controls.Add(this.LightZUdn);
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
            this.Controls.Add(this.PaintBtn);
            this.Controls.Add(this.Canvas);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DrawForm";
            this.Text = "Lab6";
            this.Load += new System.EventHandler(this.DrawForm_Load);
            this.ResizeEnd += new System.EventHandler(this.DrawForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XTurnTrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YTurnTrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZTurnTrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZUdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightZUdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightYUdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightXUdn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Button PaintBtn;
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
        private System.Windows.Forms.NumericUpDown LightZUdn;
        private System.Windows.Forms.NumericUpDown LightYUdn;
        private System.Windows.Forms.NumericUpDown LightXUdn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
