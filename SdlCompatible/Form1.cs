using SdlCompatible.TextToImg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SdlCompatible
{
    public partial class formMain : Form
    {
        private static int BASE_WIDTH = 48;
        private static int BASE_HEIGHT = 192;

        private HorizontalAlignment horAlign = HorizontalAlignment.Left;
        private Bitmap bmp = null;
        private Rectangle bmpRect;
        private Color FillColor = Color.White;
        private Color BorderColor = Color.White;
        private Color ForeColor = Color.White;
        private BorderLabel bl;
        private VerticalAlignment verAlign = VerticalAlignment.Top;
        private RenderPack rPack = null;
        private RTBData RtData = new RTBData();

        // 차후 미리보기 상의 광고 영역의 너비
        private int tmpAreaWidth = 120;

        private FontFamily[] fontFamilies;
        private BindingSource bs = new BindingSource();

        public formMain()
        {
            InitializeComponent();
            InitializeEvent();
            InitializeValue();


            pnlSizeChecker.BackgroundImageLayout = ImageLayout.None;
            // pnlMain
            // rtb
        }
        private void InitializeEvent()
        {
            btnDraw.Click += BtnDraw_Click;

            btnHorAlign.Click += BtnHorAlign_Click;
            btnVerAlign.Click += BtnVerAlign_Click;
            btnForeColor.Click += BtnForeColor_Click;
            btnBackColor.Click += BtnBackColor_Click;
            btnSfrColor.Click += BtnSelforeColor_Click;
            btnSfillColor.Click += BtnSfillColor_Click;
            btnSelBorderColor.Click += BtnSelBorderColor_Click;
            btnSbColor.Click += BtnSelbackColor_Click;
            btnLib.Click += BtnLib_Click;
            btnexprt.Click += Btnexprt_Click;
            btnLineRefresh.Click += (s, e) => Rtb_ContentChanged();
            /*rtb.TextChanged += Rtb_ContentChanged;
            rtb.BackColorChanged += Rtb_ContentChanged;
            rtb.SizeChanged += Rtb_ContentChanged;
            rtb.FontChanged += Rtb_ContentChanged;
            rtb.StyleChanged += Rtb_ContentChanged;
            rtb.ForeColorChanged += Rtb_ContentChanged;*/

            chk3d.CheckedChanged += Chk3d_CheckedChanged;
            cbxFont.SelectedIndexChanged += CbxFont_SelectedIndexChanged;
            nmrcFontEmsize.ValueChanged += NmrcFontEmsize_ValueChanged;
        }

        private void Rtb_ContentChanged()
        {
            tmpAreaWidth = (int)nmrcWidth.Value;
            Bitmap testbmp = new Bitmap(tmpAreaWidth, pnlSizeChecker.Size.Height);
            using (var gr = Graphics.FromImage(testbmp)) {
                gr.Clear(Color.Blue);
            }
            
            pnlSizeChecker.BackgroundImage = null;
            pnlSizeChecker.BackgroundImage = testbmp;



            //영역을 줄이면 미리보기 영역에 맞게 텍스트 라인도 변경됨

                float EmHeightPixels;
            //float AscentPixels;
            float DescentPixels;
            float CellHeightPixels;
            //float InternalLeadingPixels;
            float LineSpacingPixels;
            //float ExternalLeadingPixels;
            float BaseLinePixels;
            
            // 한 글자씩 돌면서 텍스트가 미리보기 너비를 벗어날때 라인을 넘김.

            /*var p = RtData.TotalPage;
            var l = RtData.LineData;
            var s = RtData.SelectedLine;*/
            RtData = new RTBData();

            for (int i = 0; i < rtb.Text.Length;) {

                LineCommonData lineData = new LineCommonData();

                int lineW = 0;
                do {
                    try
                    {
                        rtb.Select(i, 1);

                        if (rtb.SelectedText.Equals("\n")) {
                            break;
                        }

                        var the_font = rtb.SelectionFont;
                        lineW += TextRenderer.MeasureText(rtb.SelectedText, the_font).Width;

                        float em_height = the_font.FontFamily.GetEmHeight(the_font.Style);
                        EmHeightPixels = ConvertUnits(Graphics.FromHwnd(rtb.Handle), the_font.Size, the_font.Unit, GraphicsUnit.Pixel);
                        float design_to_pixels = EmHeightPixels / em_height;

                        //AscentPixels            = design_to_pixels * the_font.FontFamily.GetCellAscent(the_font.Style);
                        DescentPixels = design_to_pixels * the_font.FontFamily.GetCellDescent(the_font.Style);
                        //CellHeightPixels        = AscentPixels + DescentPixels;
                        CellHeightPixels = design_to_pixels * the_font.FontFamily.GetCellAscent(the_font.Style) + DescentPixels;
                        LineSpacingPixels = design_to_pixels * the_font.FontFamily.GetLineSpacing(the_font.Style);
                        //ExternalLeadingPixels   = LineSpacingPixels - CellHeightPixels;
                        BaseLinePixels = CellHeightPixels - DescentPixels;

                        if (lineData.LineSpacing < LineSpacingPixels)
                            lineData.LineSpacing = LineSpacingPixels;

                        if (lineData.BaseLine < BaseLinePixels)
                            lineData.BaseLine = BaseLinePixels;
                        if(lineW <= tmpAreaWidth)
                            i++;
                    }
                    catch (Exception)
                    {

                        break;
                    }
                    
                    
                }
                while (lineW <= (int)nmrcWidth.Value && i < rtb.Text.Length);

                i++;

                RtData.LineData.Add(lineData);
            }

            Console.WriteLine($"line : {RtData.LineData.Count}");

        }

        private float ConvertUnits(Graphics gr, float value,GraphicsUnit from_unit, GraphicsUnit to_unit)
        {
            if (from_unit == to_unit) return value;

            // Convert to pixels. 
            switch (from_unit)
            {
                case GraphicsUnit.Document:
                    value *= gr.DpiX / 300;
                    break;
                case GraphicsUnit.Inch:
                    value *= gr.DpiX;
                    break;
                case GraphicsUnit.Millimeter:
                    value *= gr.DpiX / 25.4F;
                    break;
                case GraphicsUnit.Pixel:
                    // Do nothing.
                    break;
                case GraphicsUnit.Point:
                    value *= gr.DpiX / 72;
                    break;
                default:
                    throw new Exception("Unknown input unit " +
                        from_unit.ToString() + " in FontInfo.ConvertUnits");
            }

            // Convert from pixels to the new units. 
            switch (to_unit)
            {
                case GraphicsUnit.Document:
                    value /= gr.DpiX / 300;
                    break;
                case GraphicsUnit.Inch:
                    value /= gr.DpiX;
                    break;
                case GraphicsUnit.Millimeter:
                    value /= gr.DpiX / 25.4F;
                    break;
                case GraphicsUnit.Pixel:
                    // Do nothing.
                    break;
                case GraphicsUnit.Point:
                    value /= gr.DpiX / 72;
                    break;
                default:
                    throw new Exception("Unknown output unit " +
                        to_unit.ToString() + " in FontInfo.ConvertUnits");
            }

            return value;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnDraw.PerformClick();
        }

        private void Btnexprt_Click(object sender, EventArgs e)
        {
            Graphics_DrawRtfText.RtbToBitmap(rtb).Save("export.png");
        }

        private void BtnLib_Click(object sender, EventArgs e)
        {
            var rtf = rtb.Rtf;
            Bitmap bmp = new Bitmap(rtb.ClientSize.Width, rtb.ClientSize.Height);
            using (var g = Graphics.FromImage(bmp)) {
                g.Clear(BackColor);
                Graphics_DrawRtfText.DrawRtfText(g, rtb.Rtf, new RectangleF(0, 0, rtb.ClientSize.Width, rtb.ClientSize.Height), 1);
            }


            bmp.Save("local.png");
                
        }

        private void Chk3d_CheckedChanged(object sender, EventArgs e)
        {
            /*if (chk3d.Checked)
            {
                rPack.rItems[0].rType = RenderType.TEXT_3D;
            }
            else 
            {
                rPack.rItems[0].rType = RenderType.MULTIPLE_LINE;
            }*/
        }

        private void BtnDraw_Click(object sender, EventArgs e)
        {
            if (rPack == null) 
                rPack = new RenderPack(pnlMain.ClientSize.Width, pnlMain.ClientSize.Height);

            rPack.rItems.Clear();

            RenderItemText rit = new RenderItemText();
            rit.is3d = chk3d.Checked;
            rit.FillColor = this.FillColor;
            rit.BorderColor = this.BorderColor;

            int idx = 0;
            for (int i = 0; i < rtb.Lines.Length; i++) {
                //rPack.rItemArray.Append(new RenderItemText() { });
                var lineT = new LineTexture();
                float tmpH = 0;
                for (int j = 0+i; j < rtb.Lines[i].Length+i; j++) {
                    var singleT = new SingleTexture();
                    rtb.Select(idx, 1);
                    singleT.BackColor = rtb.SelectionBackColor;
                    singleT.TextFont = rtb.SelectionFont;
                    singleT.ForeColor = rtb.SelectionColor;
                    singleT.Txt = rtb.SelectedText;
                    Graphics g = Graphics.FromImage(new Bitmap(1,1));
                    var sSize = g.MeasureString(rtb.SelectedText,rtb.SelectionFont);
                    singleT.WidthFromFont = sSize.Width;
                    if (tmpH < sSize.Height)
                        tmpH = sSize.Height;

                    lineT.SingleTextures.Add(singleT);

                    idx++;
                }
                lineT.LineHeight = tmpH;

                rit.groupTexture.LineTextures.Add(lineT);

                idx++;
            }
            rPack.rItems.Add(rit);

            pnlMain.BackgroundImage = rPack.oBitmap;
            rPack.oBitmap.Save("oBit.png");
            Console.WriteLine($"{rPack.oBitmap.Width},{rPack.oBitmap.Height}");

            pnlMain.Invalidate();
            pnlMain.Refresh();

        }

        private void NmrcFontEmsize_ValueChanged(object sender, EventArgs e)
        {
            // 글자 크기나 폰트나 한번에 변경하는 방법으로 변경하기
            int sIdx = rtb.SelectionStart;
            int sLen = rtb.SelectionLength;
            for (int i = sIdx; i < sIdx + sLen; i++) {
                rtb.Select(i,1);
                var selFont = rtb.Font;
                rtb.SelectionFont = new Font(selFont.FontFamily?.Name, (int)nmrcFontEmsize.Value, selFont.Style);
            }
            rtb.Select(sIdx,sLen);
        }

        private void CbxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtb.Font = new Font(fontFamilies[cbxFont.SelectedIndex], (int)nmrcFontEmsize.Value, FontStyle.Regular);
            rtb.ForeColor = Color.White;
        }

        
        private void BtnSfillColor_Click(object sender, EventArgs e)
        {
            colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK) {

                FillColor = colorDlg.Color;
                rtb.ForeColor = FillColor;
                pnlsFilSample.BackColor = FillColor;
            }
        }

        private void BtnSelBorderColor_Click(object sender, EventArgs e)
        {
            colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                BorderColor = colorDlg.Color;
                pnlsBorSample.BackColor = BorderColor;
            }
        }
        private void BtnSelbackColor_Click(object sender, EventArgs e)
        {
            colorDlg = new ColorDialog();
            colorDlg.Color = rtb.SelectionBackColor;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                rtb.SelectionBackColor = colorDlg.Color;
            }
        }


        private void BtnSelforeColor_Click(object sender, EventArgs e)
        {
            colorDlg = new ColorDialog();
            colorDlg.Color = rtb.SelectionColor;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                rtb.SelectionColor = colorDlg.Color;
                
            }
        }

        private void BtnBackColor_Click(object sender, EventArgs e)
        {
            colorDlg = new ColorDialog();
            colorDlg.Color = rtb.BackColor;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                rtb.BackColor = colorDlg.Color;
                rPack.BgColor = rtb.BackColor;
            }
        }

        private void BtnForeColor_Click(object sender, EventArgs e)
        {
            colorDlg = new ColorDialog();
            colorDlg.Color = rtb.ForeColor;
            if (colorDlg.ShowDialog() == DialogResult.OK) {
                rtb.ForeColor = colorDlg.Color;
                this.ForeColor = colorDlg.Color;
            }
        }

        private void BtnHorAlign_Click(object sender, EventArgs e)
        {
            rtb.SelectAll();
            switch (horAlign) {
                case HorizontalAlignment.Left:
                    horAlign = HorizontalAlignment.Center;
                    rtb.SelectionAlignment = HorizontalAlignment.Center;
                    break;
                case HorizontalAlignment.Center:
                    horAlign = HorizontalAlignment.Right;
                    rtb.SelectionAlignment = HorizontalAlignment.Right;
                    break;
                case HorizontalAlignment.Right:
                    horAlign = HorizontalAlignment.Left;
                    rtb.SelectionAlignment = HorizontalAlignment.Left;
                    break;
            }
            rtb.DeselectAll();
        }

        private void BtnVerAlign_Click(object sender, EventArgs e)
        {
            switch (verAlign)
            {
                case VerticalAlignment.Top:
                    verAlign = VerticalAlignment.Center;
                    break;
                case VerticalAlignment.Center: 
                    verAlign = VerticalAlignment.Bottom;
                    break;
                case VerticalAlignment.Bottom:
                    verAlign = VerticalAlignment.Top;
                    break;
            }
        }

        private void TemporaryRecord() { 

        }

        private void InitializeValue()
        {


            rPack = new RenderPack(pnlMain.ClientSize.Width, pnlMain.ClientSize.Height);

            nmrcFontEmsize.Value = 60;

            InstalledFontCollection ifc = new InstalledFontCollection();
            fontFamilies = ifc.Families;
            bs.DataSource = fontFamilies;
            cbxFont.DataSource = bs;
            cbxFont.DisplayMember = "Name";
            if (cbxFont.Items.Count > 0)
                cbxFont.SelectedIndex = 0;

            InitBl();
            InitRtb();
            //bmpRect = new Rectangle(0,0,bmp.Width, bmp.Height);
        }

        private void InitBl() {
            /*
            bl = new BorderLabel();
            bl.BackColor = Color.Transparent;
            bl.BorderColor = Color.Red;
            bl.ForeColor = Color.Transparent;
            bl.TextAlign = ContentAlignment.BottomCenter;
            bl.Size = new Size(pnlMain.ClientRectangle.Width, pnlMain.ClientRectangle.Height);
            bl.Font = new Font("Arial",24, FontStyle.Regular);
            bl.Text = "abc";
            bl.Image = Image.FromFile("duolingo-48.png");
            */
  
            //pnlMain.Controls.Add(bl);
        }

        private void InitRtb()
        {
            rtb.WordWrap = false;
            rtb.SelectionAlignment = horAlign;
            rtb.BackColor = Color.Black;
            rtb.Text = "ijqlm 맑장";
            if(cbxFont.Items.Count > 0)
                rtb.Font = new Font(fontFamilies[cbxFont.SelectedIndex], (int)nmrcFontEmsize.Value, FontStyle.Regular);
            rtb.SelectAll();
            rtb.SelectionColor = Color.White;
            //rtb.ScrollBars = RichTextBoxScrollBars.ForcedVertical;

            rtb.Select(0,0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //DrawBmp();
            base.OnPaint(e);
        }
    }

    public class RTBData {

        public RTBData() {
            LineData = new List<LineCommonData>();
            SelectedLine = TotalPage = 0;
        }

        public int TotalPage { get; set; } = 0;
        public int SelectedLine { get; set; } = 0;
        public List<LineCommonData> LineData {get; set;}
    }

    public class LineCommonData {
        public int Page { get; set; }
        public int LineInPage { get; set; }
        public float BaseLine { get; set; }
        public float LineSpacing { get; set; }
        public LineCommonData() {
            LineSpacing = BaseLine = LineInPage = Page = 0;
        }
    }

}
