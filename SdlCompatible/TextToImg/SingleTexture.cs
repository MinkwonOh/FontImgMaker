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

    public class GroupTexture
    {
        public List<LineTexture> LineTextures { get; set; } = new List<LineTexture>();
        public HorizontalAlignment AlignH { get; set; }
        public VerticalAlignment AlignV { get; set; }
        private Color bgColor { get; set; } = Color.Transparent;
        public int effect3d { get; set; }
        public int effectBack { get; set; }
        public int effectFrame { get; set; }
        public int effectBorder { get; set; }
        public int effectFore { get; set; }

        public GroupTexture()
        {
        }
    }
    public class LineTexture
    {
        public int Length { get => SingleTextures.Count; }
        public int Height { get => SingleTextures.Max(i => i.TextFont.Height); }
        public float LineHeight { get; set; }
        public List<SingleTexture> SingleTextures { get; set; } = new List<SingleTexture>();

        public LineTexture()
        {

        }
    }

    public class SingleTexture : ICloneable
    {
        public Color ForeColor { get; set; } = Color.White;
        public Color BackColor { get; set; } = Color.Black;
        public Font TextFont { get; set; }
        public string Txt { get; set; } = string.Empty;
        public float WidthFromFont { get; set; }
        public float offsetX { get; set; }
        public float offsetY { get; set; }


        public SingleTexture() { }

        public object Clone()
        {
            return new SingleTexture();
        }
    }
}
