using System;
using System.Drawing;
using System.Windows.Forms;

namespace ePOSOne.btnProduct
{
    public class RoundButton : Button
    {
        private Color ColorEdge = Color.Purple;
        private Color ColorButton = Color.Gray;
        private Color ColorTxt = Color.White;

        //При наведении курсора мыши
        private Color ColorEdge2 = Color.White;
        private Color ColorButton2 = Color.Orange;
        private Color ColorTxt2 = Color.Gray;
        private bool Cursor; //Наведен ли курсор мыши
       
        private int Thickness = 6;
        private int Thickness2 = 3;


        public RoundButton()
        {
            DoubleBuffered = true;
            MouseEnter += (sender, e) =>
            {
                Cursor = true;
                Invalidate();
            };

            MouseLeave += (sender, e) =>
            {
                Cursor = false;
                Invalidate();
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Brush brush = new SolidBrush(Cursor ? ColorEdge2 : ColorEdge);

            //Границы
            g.FillEllipse(brush, 0, 0, Height, Height);
            g.FillEllipse(brush, Width - Height, 0, Height, Height);
            g.FillRectangle(brush, Height / 2, 0, Width - Height, Height);

            brush.Dispose();
            brush = new SolidBrush(Cursor ? ColorButton2 : ColorButton);

            g.FillEllipse(brush, Thickness2, Thickness2, Height - Thickness,
                Height - Thickness);
            g.FillEllipse(brush, (Width - Height) + Thickness2, Thickness2,
                Height - Thickness, Height - Thickness);
            g.FillRectangle(brush, Height / 2 + Thickness2, Thickness2,
                Width - Height - Thickness, Height - Thickness);

            brush.Dispose();
            brush = new SolidBrush(Cursor ? ColorTxt2 : ColorTxt);

            //тхт
            SizeF stringSize = g.MeasureString(Text, Font);
            g.DrawString(Text, Font, brush, (Width - stringSize.Width) / 2, (Height - stringSize.Height) / 2);
        }


        public Color BorderColor
        {
            get => ColorEdge;
            set
            {
                ColorEdge = value;
                Invalidate();
            }
        }

        public Color OnHoverBorderColor
        {
            get => ColorEdge2;
            set
            {
                ColorEdge2 = value;
                Invalidate();
            }
        }

        public Color ButtonColor
        {
            get => ColorButton;
            set
            {
                ColorButton = value;
                Invalidate();
            }
        }

        public Color OnHoverButtonColor
        {
            get => ColorButton2;
            set
            {
                ColorButton2 = value;
                Invalidate();
            }
        }

        public Color TextColor
        {
            get => ColorTxt;
            set
            {
                ColorTxt = value;
                Invalidate();
            }
        }

        public Color OnHoverTextColor
        {
            get => ColorTxt2;
            set
            {
                ColorTxt2 = value;
                Invalidate();
            }
        }
    }
}