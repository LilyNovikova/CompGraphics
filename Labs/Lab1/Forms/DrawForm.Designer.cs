namespace Lab1.Forms
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
            this.DrawTangentBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pointAXUpdn = new System.Windows.Forms.NumericUpDown();
            this.pointAYUpdn = new System.Windows.Forms.NumericUpDown();
            this.radiusAUpdn = new System.Windows.Forms.NumericUpDown();
            this.radiusBUpdn = new System.Windows.Forms.NumericUpDown();
            this.pointBYUpdn = new System.Windows.Forms.NumericUpDown();
            this.pointBXUpdn = new System.Windows.Forms.NumericUpDown();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FlipSideBtn = new System.Windows.Forms.Button();
            this.SideLbl = new System.Windows.Forms.Label();
            this.WarningLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pointAXUpdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointAYUpdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusAUpdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusBUpdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBYUpdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBXUpdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawTangentBtn
            // 
            this.DrawTangentBtn.Location = new System.Drawing.Point(367, 47);
            this.DrawTangentBtn.Name = "DrawTangentBtn";
            this.DrawTangentBtn.Size = new System.Drawing.Size(126, 38);
            this.DrawTangentBtn.TabIndex = 0;
            this.DrawTangentBtn.Text = "Draw tangent";
            this.DrawTangentBtn.UseVisualStyleBackColor = true;
            this.DrawTangentBtn.Click += new System.EventHandler(this.DrawTangentBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "radius";
            // 
            // pointAXUpdn
            // 
            this.pointAXUpdn.Location = new System.Drawing.Point(108, 45);
            this.pointAXUpdn.Maximum = new decimal(new int[] {
            730,
            0,
            0,
            0});
            this.pointAXUpdn.Name = "pointAXUpdn";
            this.pointAXUpdn.Size = new System.Drawing.Size(70, 22);
            this.pointAXUpdn.TabIndex = 7;
            this.pointAXUpdn.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // pointAYUpdn
            // 
            this.pointAYUpdn.Location = new System.Drawing.Point(176, 45);
            this.pointAYUpdn.Maximum = new decimal(new int[] {
            565,
            0,
            0,
            0});
            this.pointAYUpdn.Name = "pointAYUpdn";
            this.pointAYUpdn.Size = new System.Drawing.Size(70, 22);
            this.pointAYUpdn.TabIndex = 8;
            this.pointAYUpdn.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // radiusAUpdn
            // 
            this.radiusAUpdn.Location = new System.Drawing.Point(272, 45);
            this.radiusAUpdn.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.radiusAUpdn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radiusAUpdn.Name = "radiusAUpdn";
            this.radiusAUpdn.Size = new System.Drawing.Size(70, 22);
            this.radiusAUpdn.TabIndex = 9;
            this.radiusAUpdn.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // radiusBUpdn
            // 
            this.radiusBUpdn.Location = new System.Drawing.Point(272, 82);
            this.radiusBUpdn.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.radiusBUpdn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radiusBUpdn.Name = "radiusBUpdn";
            this.radiusBUpdn.Size = new System.Drawing.Size(70, 22);
            this.radiusBUpdn.TabIndex = 12;
            this.radiusBUpdn.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // pointBYUpdn
            // 
            this.pointBYUpdn.Location = new System.Drawing.Point(176, 82);
            this.pointBYUpdn.Maximum = new decimal(new int[] {
            565,
            0,
            0,
            0});
            this.pointBYUpdn.Name = "pointBYUpdn";
            this.pointBYUpdn.Size = new System.Drawing.Size(70, 22);
            this.pointBYUpdn.TabIndex = 11;
            this.pointBYUpdn.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // pointBXUpdn
            // 
            this.pointBXUpdn.Location = new System.Drawing.Point(108, 82);
            this.pointBXUpdn.Maximum = new decimal(new int[] {
            730,
            0,
            0,
            0});
            this.pointBXUpdn.Name = "pointBXUpdn";
            this.pointBXUpdn.Size = new System.Drawing.Size(70, 22);
            this.pointBXUpdn.TabIndex = 10;
            this.pointBXUpdn.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // Canvas
            // 
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.Location = new System.Drawing.Point(41, 161);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(731, 565);
            this.Canvas.TabIndex = 13;
            this.Canvas.TabStop = false;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "point A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "point B";
            // 
            // FlipSideBtn
            // 
            this.FlipSideBtn.Location = new System.Drawing.Point(367, 113);
            this.FlipSideBtn.Name = "FlipSideBtn";
            this.FlipSideBtn.Size = new System.Drawing.Size(126, 32);
            this.FlipSideBtn.TabIndex = 16;
            this.FlipSideBtn.Text = "Flip side";
            this.FlipSideBtn.UseVisualStyleBackColor = true;
            this.FlipSideBtn.Click += new System.EventHandler(this.FlipSideBtn_Click);
            // 
            // SideLbl
            // 
            this.SideLbl.AutoSize = true;
            this.SideLbl.Location = new System.Drawing.Point(499, 121);
            this.SideLbl.Name = "SideLbl";
            this.SideLbl.Size = new System.Drawing.Size(57, 17);
            this.SideLbl.TabIndex = 17;
            this.SideLbl.Text = "left side";
            // 
            // WarningLbl
            // 
            this.WarningLbl.Location = new System.Drawing.Point(499, 45);
            this.WarningLbl.Name = "WarningLbl";
            this.WarningLbl.Size = new System.Drawing.Size(237, 59);
            this.WarningLbl.TabIndex = 18;
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 738);
            this.Controls.Add(this.WarningLbl);
            this.Controls.Add(this.SideLbl);
            this.Controls.Add(this.FlipSideBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.radiusBUpdn);
            this.Controls.Add(this.pointBYUpdn);
            this.Controls.Add(this.pointBXUpdn);
            this.Controls.Add(this.radiusAUpdn);
            this.Controls.Add(this.pointAYUpdn);
            this.Controls.Add(this.pointAXUpdn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DrawTangentBtn);
            this.Name = "DrawForm";
            this.Text = "Lab1";
            ((System.ComponentModel.ISupportInitialize)(this.pointAXUpdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointAYUpdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusAUpdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusBUpdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBYUpdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBXUpdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DrawTangentBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown pointAXUpdn;
        private System.Windows.Forms.NumericUpDown pointAYUpdn;
        private System.Windows.Forms.NumericUpDown radiusAUpdn;
        private System.Windows.Forms.NumericUpDown radiusBUpdn;
        private System.Windows.Forms.NumericUpDown pointBYUpdn;
        private System.Windows.Forms.NumericUpDown pointBXUpdn;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button FlipSideBtn;
        private System.Windows.Forms.Label SideLbl;
        private System.Windows.Forms.Label WarningLbl;
    }
}


