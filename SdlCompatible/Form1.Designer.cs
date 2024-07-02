namespace SdlCompatible
{
    partial class formMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.btnHorAlign = new System.Windows.Forms.Button();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.btnSfrColor = new System.Windows.Forms.Button();
            this.btnSbColor = new System.Windows.Forms.Button();
            this.nmrcHeight = new System.Windows.Forms.NumericUpDown();
            this.nmrcWidth = new System.Windows.Forms.NumericUpDown();
            this.colorDlg = new System.Windows.Forms.ColorDialog();
            this.btnVerAlign = new System.Windows.Forms.Button();
            this.cbxFont = new System.Windows.Forms.ComboBox();
            this.nmrcFontEmsize = new System.Windows.Forms.NumericUpDown();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnSfillColor = new System.Windows.Forms.Button();
            this.btnSelBorderColor = new System.Windows.Forms.Button();
            this.chk3d = new System.Windows.Forms.CheckBox();
            this.pnlsBorSample = new System.Windows.Forms.Panel();
            this.pnlsFilSample = new System.Windows.Forms.Panel();
            this.btnLib = new System.Windows.Forms.Button();
            this.btnexprt = new System.Windows.Forms.Button();
            this.btnLineRefresh = new System.Windows.Forms.Button();
            this.pnlSizeChecker = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcFontEmsize)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Location = new System.Drawing.Point(12, 482);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1012, 288);
            this.pnlMain.TabIndex = 0;
            // 
            // rtb
            // 
            this.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb.Location = new System.Drawing.Point(12, 127);
            this.rtb.Name = "rtb";
            this.rtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtb.Size = new System.Drawing.Size(1012, 289);
            this.rtb.TabIndex = 1;
            this.rtb.Text = "";
            this.rtb.WordWrap = false;
            // 
            // btnHorAlign
            // 
            this.btnHorAlign.Location = new System.Drawing.Point(12, 74);
            this.btnHorAlign.Name = "btnHorAlign";
            this.btnHorAlign.Size = new System.Drawing.Size(67, 23);
            this.btnHorAlign.TabIndex = 2;
            this.btnHorAlign.Text = "HorAlign";
            this.btnHorAlign.UseVisualStyleBackColor = true;
            // 
            // btnForeColor
            // 
            this.btnForeColor.Location = new System.Drawing.Point(85, 74);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(67, 23);
            this.btnForeColor.TabIndex = 3;
            this.btnForeColor.Text = "foreColor";
            this.btnForeColor.UseVisualStyleBackColor = true;
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(85, 98);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(67, 23);
            this.btnBackColor.TabIndex = 4;
            this.btnBackColor.Text = "bckColor";
            this.btnBackColor.UseVisualStyleBackColor = true;
            // 
            // btnSfrColor
            // 
            this.btnSfrColor.Location = new System.Drawing.Point(158, 75);
            this.btnSfrColor.Name = "btnSfrColor";
            this.btnSfrColor.Size = new System.Drawing.Size(67, 23);
            this.btnSfrColor.TabIndex = 5;
            this.btnSfrColor.Text = "sForeClr";
            this.btnSfrColor.UseVisualStyleBackColor = true;
            // 
            // btnSbColor
            // 
            this.btnSbColor.Location = new System.Drawing.Point(158, 99);
            this.btnSbColor.Name = "btnSbColor";
            this.btnSbColor.Size = new System.Drawing.Size(67, 23);
            this.btnSbColor.TabIndex = 6;
            this.btnSbColor.Text = "sbackClr";
            this.btnSbColor.UseVisualStyleBackColor = true;
            // 
            // nmrcHeight
            // 
            this.nmrcHeight.Location = new System.Drawing.Point(12, 47);
            this.nmrcHeight.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nmrcHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrcHeight.Name = "nmrcHeight";
            this.nmrcHeight.Size = new System.Drawing.Size(56, 21);
            this.nmrcHeight.TabIndex = 7;
            this.nmrcHeight.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            // 
            // nmrcWidth
            // 
            this.nmrcWidth.Location = new System.Drawing.Point(74, 47);
            this.nmrcWidth.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nmrcWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrcWidth.Name = "nmrcWidth";
            this.nmrcWidth.Size = new System.Drawing.Size(56, 21);
            this.nmrcWidth.TabIndex = 8;
            this.nmrcWidth.Value = new decimal(new int[] {
            192,
            0,
            0,
            0});
            // 
            // btnVerAlign
            // 
            this.btnVerAlign.Location = new System.Drawing.Point(12, 98);
            this.btnVerAlign.Name = "btnVerAlign";
            this.btnVerAlign.Size = new System.Drawing.Size(67, 23);
            this.btnVerAlign.TabIndex = 9;
            this.btnVerAlign.Text = "VerAlign";
            this.btnVerAlign.UseVisualStyleBackColor = true;
            // 
            // cbxFont
            // 
            this.cbxFont.FormattingEnabled = true;
            this.cbxFont.Location = new System.Drawing.Point(820, 99);
            this.cbxFont.Name = "cbxFont";
            this.cbxFont.Size = new System.Drawing.Size(204, 20);
            this.cbxFont.TabIndex = 10;
            // 
            // nmrcFontEmsize
            // 
            this.nmrcFontEmsize.Location = new System.Drawing.Point(957, 72);
            this.nmrcFontEmsize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmrcFontEmsize.Name = "nmrcFontEmsize";
            this.nmrcFontEmsize.Size = new System.Drawing.Size(67, 21);
            this.nmrcFontEmsize.TabIndex = 11;
            this.nmrcFontEmsize.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(949, 452);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 12;
            this.btnDraw.Text = "draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            // 
            // btnSfillColor
            // 
            this.btnSfillColor.Location = new System.Drawing.Point(231, 75);
            this.btnSfillColor.Name = "btnSfillColor";
            this.btnSfillColor.Size = new System.Drawing.Size(67, 23);
            this.btnSfillColor.TabIndex = 13;
            this.btnSfillColor.Text = "sfillClr";
            this.btnSfillColor.UseVisualStyleBackColor = true;
            // 
            // btnSelBorderColor
            // 
            this.btnSelBorderColor.Location = new System.Drawing.Point(231, 101);
            this.btnSelBorderColor.Name = "btnSelBorderColor";
            this.btnSelBorderColor.Size = new System.Drawing.Size(67, 23);
            this.btnSelBorderColor.TabIndex = 14;
            this.btnSelBorderColor.Text = "sBorClr";
            this.btnSelBorderColor.UseVisualStyleBackColor = true;
            // 
            // chk3d
            // 
            this.chk3d.AutoSize = true;
            this.chk3d.Location = new System.Drawing.Point(892, 456);
            this.chk3d.Name = "chk3d";
            this.chk3d.Size = new System.Drawing.Size(37, 16);
            this.chk3d.TabIndex = 15;
            this.chk3d.Text = "3d";
            this.chk3d.UseVisualStyleBackColor = true;
            // 
            // pnlsBorSample
            // 
            this.pnlsBorSample.Location = new System.Drawing.Point(304, 101);
            this.pnlsBorSample.Name = "pnlsBorSample";
            this.pnlsBorSample.Size = new System.Drawing.Size(23, 21);
            this.pnlsBorSample.TabIndex = 16;
            // 
            // pnlsFilSample
            // 
            this.pnlsFilSample.Location = new System.Drawing.Point(304, 76);
            this.pnlsFilSample.Name = "pnlsFilSample";
            this.pnlsFilSample.Size = new System.Drawing.Size(23, 21);
            this.pnlsFilSample.TabIndex = 17;
            // 
            // btnLib
            // 
            this.btnLib.Location = new System.Drawing.Point(949, 422);
            this.btnLib.Name = "btnLib";
            this.btnLib.Size = new System.Drawing.Size(75, 24);
            this.btnLib.TabIndex = 18;
            this.btnLib.Text = "btnLib";
            this.btnLib.UseVisualStyleBackColor = true;
            // 
            // btnexprt
            // 
            this.btnexprt.Location = new System.Drawing.Point(949, 12);
            this.btnexprt.Name = "btnexprt";
            this.btnexprt.Size = new System.Drawing.Size(75, 24);
            this.btnexprt.TabIndex = 19;
            this.btnexprt.Text = "export";
            this.btnexprt.UseVisualStyleBackColor = true;
            // 
            // btnLineRefresh
            // 
            this.btnLineRefresh.Location = new System.Drawing.Point(854, 12);
            this.btnLineRefresh.Name = "btnLineRefresh";
            this.btnLineRefresh.Size = new System.Drawing.Size(75, 24);
            this.btnLineRefresh.TabIndex = 20;
            this.btnLineRefresh.Text = "refresh";
            this.btnLineRefresh.UseVisualStyleBackColor = true;
            // 
            // pnlSizeChecker
            // 
            this.pnlSizeChecker.Location = new System.Drawing.Point(12, 422);
            this.pnlSizeChecker.Name = "pnlSizeChecker";
            this.pnlSizeChecker.Size = new System.Drawing.Size(452, 17);
            this.pnlSizeChecker.TabIndex = 21;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 837);
            this.Controls.Add(this.pnlSizeChecker);
            this.Controls.Add(this.btnLineRefresh);
            this.Controls.Add(this.btnexprt);
            this.Controls.Add(this.btnLib);
            this.Controls.Add(this.pnlsFilSample);
            this.Controls.Add(this.pnlsBorSample);
            this.Controls.Add(this.chk3d);
            this.Controls.Add(this.btnSelBorderColor);
            this.Controls.Add(this.btnSfillColor);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.nmrcFontEmsize);
            this.Controls.Add(this.cbxFont);
            this.Controls.Add(this.btnVerAlign);
            this.Controls.Add(this.nmrcWidth);
            this.Controls.Add(this.nmrcHeight);
            this.Controls.Add(this.btnSbColor);
            this.Controls.Add(this.btnSfrColor);
            this.Controls.Add(this.btnBackColor);
            this.Controls.Add(this.btnForeColor);
            this.Controls.Add(this.btnHorAlign);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.pnlMain);
            this.Name = "formMain";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.nmrcHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcFontEmsize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Button btnHorAlign;
        private System.Windows.Forms.Button btnForeColor;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnSfrColor;
        private System.Windows.Forms.Button btnSbColor;
        private System.Windows.Forms.NumericUpDown nmrcHeight;
        private System.Windows.Forms.NumericUpDown nmrcWidth;
        private System.Windows.Forms.ColorDialog colorDlg;
        private System.Windows.Forms.Button btnVerAlign;
        private System.Windows.Forms.ComboBox cbxFont;
        private System.Windows.Forms.NumericUpDown nmrcFontEmsize;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnSfillColor;
        private System.Windows.Forms.Button btnSelBorderColor;
        private System.Windows.Forms.CheckBox chk3d;
        private System.Windows.Forms.Panel pnlsBorSample;
        private System.Windows.Forms.Panel pnlsFilSample;
        private System.Windows.Forms.Button btnLib;
        private System.Windows.Forms.Button btnexprt;
        private System.Windows.Forms.Button btnLineRefresh;
        private System.Windows.Forms.Panel pnlSizeChecker;
    }
}

