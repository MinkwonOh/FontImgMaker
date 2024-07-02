using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SdlCompatible.TextToImg
{
    /// <summary>
    /// RenderSet / RenderPack / RenderItem
    /// </summary>
    public class RenderPack
    {
        public Bitmap oBitmap { get => Draw(); }
        public Color BgColor { get; set; } = Color.Black;

        private Bitmap bmp;
        private Size size = new Size(1,1);
        private Point point = new Point(0,0);
        public List<RenderBaseItem> rItems = new List<RenderBaseItem>();


        public RenderPack(int w, int h) {
            size = new Size(w, h);
            InitCommon();
        }

        public RenderPack(int x, int y, int w, int h) {
            point = new Point(x, y);
            size = new Size(w, h);
            InitCommon();
        }

        private void InitCommon()
        {
            bmp?.Dispose();
            bmp = new Bitmap(size.Width, size.Height);
        }

        private Bitmap Draw() {
            if (bmp != null && BgColor != null) {
                using (var g = Graphics.FromImage(bmp)) {
                    g.Clear(BgColor);
                }
                for (int i = 0; i < rItems.Count; i++)
                    rItems[i].RefBmp(ref bmp);
            }
            
            return bmp;
        }
    }

    public enum RenderType { 
        SINGLE_LINE,
        MULTIPLE_LINE,
        IMAGE,
        MOVIE,
        ANIME_CHAR,
        TEXT_3D,
        CLOCK,
        CALENDAR,
        TIMER,
        WEATHER,
        NEON,

    }

    public class RenderItemText : RenderBaseItem {
        private bool isSingle = false;
        public GroupTexture groupTexture;
        public bool is3d { get; set; }
        public Color FillColor { get; set; } = Color.White;
        public Color BorderColor { get; set; } = Color.White;
        public SolidBrush BackBrush { get; set; } = new SolidBrush(Color.Transparent);

        private Pen p = new Pen(Color.Transparent, 1);

        public RenderItemText(bool isSingle = false) {
            this.isSingle = isSingle;
            base.rType = this.isSingle ? RenderType.SINGLE_LINE : RenderType.MULTIPLE_LINE;
            groupTexture = new GroupTexture();

        }

        public float EmHeightPixels;
        public float AscentPixels;
        public float DescentPixels;
        public float CellHeightPixels;
        public float InternalLeadingPixels;
        public float LineSpacingPixels;
        public float ExternalLeadingPixels;

        public override Bitmap RefBmp(ref Bitmap bmp) {
            GraphicsPath gPath = new GraphicsPath() { 
                FillMode = FillMode.Winding
            };
            var ratio = 96f / 72f;

            using (var g = Graphics.FromImage(bmp)) {
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                string tempTxt = string.Empty;
                float yPos = 0;
                for (int i = 0; i < groupTexture.LineTextures.Count; i++) {
                    var charLen = groupTexture.LineTextures[i].SingleTextures.Count;
                    float xPos = 0;
                    int yTmp = 0;
                    float baseLine = 0f;
                    
                    for (int j = 0; j< charLen; j++) {
                        var sText = groupTexture.LineTextures[i].SingleTextures[j];
                        var the_font = sText.TextFont;

                        EmHeightPixels = ConvertUnits(g, the_font.Size, the_font.Unit, GraphicsUnit.Pixel);
                        float em_height = the_font.FontFamily.GetEmHeight(the_font.Style);
                        float design_to_pixels = EmHeightPixels / em_height;
                        AscentPixels = design_to_pixels * the_font.FontFamily.GetCellAscent(the_font.Style);
                        CellHeightPixels = AscentPixels + DescentPixels;
                        InternalLeadingPixels = CellHeightPixels - EmHeightPixels;

                        if (baseLine < AscentPixels) {
                            tempTxt = sText.Txt;
                            baseLine = AscentPixels;
                        }
                    }

                    for (int j = 0; j < charLen; j++) {
                        var sText= groupTexture.LineTextures[i].SingleTextures[j];
                        gPath.Reset();

                        var the_font = sText.TextFont;

                        float em_height =
                            the_font.FontFamily.GetEmHeight(the_font.Style);
                        EmHeightPixels = ConvertUnits(g, the_font.Size, the_font.Unit, GraphicsUnit.Pixel);
                        float design_to_pixels = EmHeightPixels / em_height;

                        AscentPixels = design_to_pixels * the_font.FontFamily.GetCellAscent(the_font.Style);
                        DescentPixels = design_to_pixels * the_font.FontFamily.GetCellDescent(the_font.Style);
                        CellHeightPixels = AscentPixels + DescentPixels;
                        InternalLeadingPixels = CellHeightPixels - EmHeightPixels;
                        LineSpacingPixels = design_to_pixels * the_font.FontFamily.GetLineSpacing(the_font.Style);
                        ExternalLeadingPixels = LineSpacingPixels - CellHeightPixels;

                        Debug.WriteLine($"=======================================================");
                        Debug.WriteLine($"\t\t{sText.Txt}");
                        Debug.WriteLine($"LineSpac : {LineSpacingPixels}");
                        Debug.WriteLine($"Internal : {InternalLeadingPixels}");
                        Debug.WriteLine($"EmHeight : {EmHeightPixels}");
                        Debug.WriteLine($"External : {ExternalLeadingPixels}");
                        Debug.WriteLine($"AscentPx : {AscentPixels}");
                        Debug.WriteLine($"DscentPx : {DescentPixels}");
                        Debug.WriteLine($"CellHeig : {CellHeightPixels}");
                        Debug.WriteLine($"=======================================================");

                        
                        gPath.AddString(sText.Txt, sText.TextFont.FontFamily, (int)sText.TextFont.Style,
                            sText.TextFont.Size * ratio,
                            new RectangleF(xPos, yPos + baseLine - AscentPixels, sText.TextFont.Size * ratio, groupTexture.LineTextures[i].LineHeight),
                            StringFormat.GenericTypographic
                            );

                        var gpw = gPath.GetBounds(null, p);

                        BackBrush.Color = sText.BackColor == Color.Black ? Color.Orange : sText.BackColor;
                        g.FillRectangle(BackBrush, new RectangleF(xPos,yPos,sText.TextFont.Size * ratio,groupTexture.LineTextures[i].LineHeight));
                        g.FillPath(new SolidBrush(is3d ? FillColor : sText.ForeColor), gPath);
                        g.DrawPath(new Pen(new SolidBrush(is3d ? BorderColor : sText.ForeColor)), gPath);
                        
                        //tmp
                        g.DrawLine(new Pen(new SolidBrush(Color.Blue),1), new PointF(xPos,yPos),new PointF(xPos,groupTexture.LineTextures[i].LineHeight));

                        if (ContainsUnicodeCharacter(sText.Txt))
                        {
                            xPos += sText.WidthFromFont / ratio;
                        }
                        else {
                            xPos += gpw.Width;
                        }

                        if (sText.Txt == "2") {
                            Console.WriteLine();
                        }

                        //tmp
                        g.DrawLine(new Pen(new SolidBrush(Color.Blue), 1), new PointF(xPos, yPos), new PointF(xPos, groupTexture.LineTextures[i].LineHeight));

                    }
                    g.DrawLine(new Pen(new SolidBrush(Color.Red)),new PointF(0,yPos+baseLine),new PointF(xPos, yPos + baseLine));
                    yPos += groupTexture.LineTextures[i].LineHeight;
                }
                
            }
            return bmp;
        }

        private float ConvertUnits(Graphics gr, float value, GraphicsUnit from_unit, GraphicsUnit to_unit)
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

        private bool ContainsUnicodeCharacter(string input) {
            const int MaxAnsiCode = 255;
            return input.Any(c => c > MaxAnsiCode);
        }
    }

    public class RenderItemImage : RenderBaseItem { 
    }
    public class RenderItemMovie : RenderBaseItem { 
    }
    public class RenderItemAnime : RenderBaseItem { 
    }
    public class RenderItem3D : RenderBaseItem { 
    }
    public class RenderItemClock : RenderBaseItem { 
    }
    public class RenderItemCalendar : RenderBaseItem { }
    public class RenderItemTimer : RenderBaseItem { }
    public class RenderItemWeater : RenderBaseItem { }
    public class RenderItemNeon : RenderBaseItem { }


    public class RenderBaseItem : IDisposable
    {
        public Color SelBackColor { get; set; } = Color.Black;
        public Color SelForeColor { get; set; } = Color.White;
        public RenderType rType;

        public void Dispose()
        {
            
        }

        public virtual Bitmap RefBmp(ref Bitmap bmp) { return bmp; }
    }
}
