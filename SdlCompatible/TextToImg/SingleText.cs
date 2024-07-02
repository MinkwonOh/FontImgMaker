using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

namespace SdlCompatible.TextToImg
{

    public class GroupText
    {
        public List<LineText> LineTexts { get; set; } = new List<LineText>();
        public HorizontalAlignment AlignH { get; set; }
        public VerticalAlignment AlignV { get; set; }
        private Color bgColor { get; set; } = Color.Transparent;
        public int effect3d { get; set; }
        public int effectBack { get; set; }
        public int effectFrame { get; set; }
        public int effectBorder { get; set; }
        public int effectFore { get; set; }

        public GroupText()
        {
        }
    }
    public class LineText
    {
        public int Length { get => SingleTexts.Count; }
        public int Height { get => SingleTexts.Max(i => i.TextFont.Height); }
        public float LineHeight { get; set; }
        public List<SingleText> SingleTexts { get; set; } = new List<SingleText>();

        public LineText()
        {

        }
    }

    public class SingleText : ICloneable
    {
        public Color ForeColor { get; set; } = Color.White;
        public Color BackColor { get; set; } = Color.Black;
        public Font TextFont { get; set; }
        public string Txt { get; set; } = string.Empty;
        public float WidthFromFont { get; set; }
        public float offsetX { get; set; }
        public float offsetY { get; set; }


        public SingleText() { }

        public object Clone()
        {
            return new SingleText();
        }
    }
}
