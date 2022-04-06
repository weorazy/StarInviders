using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace StarInviders
{
    public class NLO
    {
        public Point point;                // положение НЛО в 2D-пространстве
        public Size size;                     // размеры НЛО
        int veloX;                                  // скорость смещения по X
        int veloY;                                  // скорость_падения по Y
        public HatchBrush br;        // кисть для покраски НЛО
        public Region reg = new Region();   // занимаемая им область в пространстве
        public Boolean life = true;                  // НЛО жив (true) или мертв (false)

        public void New_bug(Form1 F, int rch)    // задать свойства (параметры) НЛО
        {
            Random rv = new Random(rch);
            point.X = rv.Next(10, Form1.ActiveForm.Width - 40);
            point.Y = rv.Next(10, Form1.ActiveForm.Height / 5);
            size.Width = rv.Next(35, 70);
            size.Height = size.Width * 2 / 3;
            veloX = rv.Next(7) - 3;
            veloY = rv.Next(3, 10);
            br = F.bc.New_br(rch);
            reg = Form_bug();
        }
        public Region Form_bug()
        {
            Point pt = new Point();
            Size st = new Size();
            pt.X = point.X;
            pt.Y = point.Y + size.Height / 4;
            st.Width = size.Width;
            st.Height = size.Height / 2;
            Rectangle rec = new Rectangle(pt, st);
            GraphicsPath path1 = new GraphicsPath();
            path1.AddEllipse(rec);
            Region reg = new Region(path1);
            rec.X = point.X + size.Width / 4;
            rec.Y = point.Y;
            rec.Width = size.Width / 2;
            rec.Height = size.Height;
            path1.AddEllipse(rec);
            reg.Union(path1);
            return reg;
        }

        public void Move_bug()
        {
            point.X += veloX;
            point.Y += veloY;
            reg = Form_bug();
        }
    }
}
