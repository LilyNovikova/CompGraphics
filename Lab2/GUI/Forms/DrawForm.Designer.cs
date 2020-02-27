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
            this.BtflCbx = new System.Windows.Forms.CheckBox();
            this.XTurnTrb = new System.Windows.Forms.TrackBar();
            this.YTurnTrb = new System.Windows.Forms.TrackBar();
            this.ZTurnTrb = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XTurnTrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YTurnTrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZTurnTrb)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.Location = new System.Drawing.Point(12, 177);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(931, 601);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // PaintBtn
            // 
            this.PaintBtn.Location = new System.Drawing.Point(37, 12);
            this.PaintBtn.Name = "PaintBtn";
            this.PaintBtn.Size = new System.Drawing.Size(186, 43);
            this.PaintBtn.TabIndex = 1;
            this.PaintBtn.Text = "Paint";
            this.PaintBtn.UseVisualStyleBackColor = true;
            this.PaintBtn.Click += new System.EventHandler(this.PaintBtn_Click);
            // 
            // BtflCbx
            // 
            this.BtflCbx.AutoSize = true;
            this.BtflCbx.Location = new System.Drawing.Point(345, 23);
            this.BtflCbx.Name = "BtflCbx";
            this.BtflCbx.Size = new System.Drawing.Size(118, 21);
            this.BtflCbx.TabIndex = 2;
            this.BtflCbx.Text = "beautiful draw";
            this.BtflCbx.UseVisualStyleBackColor = true;
            // 
            // XTurnTrb
            // 
            this.XTurnTrb.Location = new System.Drawing.Point(563, 12);
            this.XTurnTrb.Maximum = 180;
            this.XTurnTrb.Minimum = -180;
            this.XTurnTrb.Name = "XTurnTrb";
            this.XTurnTrb.Size = new System.Drawing.Size(380, 56);
            this.XTurnTrb.TabIndex = 3;
            this.XTurnTrb.Scroll += new System.EventHandler(this.XTurnTrb_Scroll);
            // 
            // YTurnTrb
            // 
            this.YTurnTrb.Location = new System.Drawing.Point(83, 102);
            this.YTurnTrb.Maximum = 180;
            this.YTurnTrb.Minimum = -180;
            this.YTurnTrb.Name = "YTurnTrb";
            this.YTurnTrb.Size = new System.Drawing.Size(380, 56);
            this.YTurnTrb.TabIndex = 4;
            this.YTurnTrb.Scroll += new System.EventHandler(this.YTurnTrb_Scroll);
            // 
            // ZTurnTrb
            // 
            this.ZTurnTrb.Location = new System.Drawing.Point(563, 102);
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
            this.label1.Location = new System.Drawing.Point(505, 23);
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
            this.label3.Location = new System.Drawing.Point(505, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Z";
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 790);
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
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DrawForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XTurnTrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YTurnTrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZTurnTrb)).EndInit();
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
    }
}

