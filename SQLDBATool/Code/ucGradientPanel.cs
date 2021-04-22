using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class ucGradientPanel : UserControl
    {
        private Color FTopColor = Color.Gainsboro;
        private Color FBottomColor = Color.White;
        private float FColorAngle = 180f;
        public Color TopColor
        {
            get => FTopColor;
            set
            {
                FTopColor = value;
                this.Invalidate();
            }
        }
        public Color BottomColor
        {
            get => FBottomColor;
            set
            {
                FBottomColor = value;
                this.Invalidate();
            }
        }

        public float ColorAngle
        {
            get => FColorAngle;
            set
            {
                FColorAngle = value;
                this.Invalidate();
            }
        }

        public ucGradientPanel()
        {
            InitializeComponent();
            SetResizeStyle();
        }

        private void SetResizeStyle()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Width, this.ClientRectangle.Top);

            if (rect.Width > 0 && rect.Height > 0)
            {
                using (LinearGradientBrush background = new LinearGradientBrush(rect, TopColor, BottomColor, ColorAngle))
                {
                    g.FillRectangle(background, rect);
                }
            }
        }
    }
}
