using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace StarInviders
{

    public class Player
    {
        public Point point;              // положение игрока в 2D-пространстве
        public Size size;                // размеры игрока
        public Region reg;               // занимаемая им область в пространстве
        public Pen laser_pen;            // свойство оружия
        public void New_player(Form1 F)         // задать свойства (параметры) игрока
        {
            size = F.imageP.Size;
            point.X = 0;
            point.Y = 0;
            Rectangle rec = new Rectangle(point, size);
            reg = new Region(rec);
            laser_pen = new Pen(new HatchBrush(HatchStyle.DashedUpwardDiagonal, F.bc.LaserColor, F.bc.LaserColor), 3);
        }
        public void Show_player(Form1 F, int x, int y)        // показать его на поле  битвы                       
        {
            F.g.ResetClip();
            F.g.FillRegion(new SolidBrush(F.BackColor), reg);
            point.X = x - size.Width / 2;
            point.Y = y;
            Rectangle rec = new Rectangle(point, size);
            reg = new Region(rec);
            F.g.DrawImage(F.imageP, point);
            F.g.ExcludeClip(reg);
        }
    }
}
