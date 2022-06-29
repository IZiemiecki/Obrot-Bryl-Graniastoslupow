using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace OBG_Ziemiecki42601
{
    public partial class Form1 : Form
    {
        public static Graphics iz_Graphics;
        public static Form1 iz_Form;
        public static Random iz_Random;
        public static int iz_RandomDistractor;
        List<iz_BrylaGeometryczna> iz_List = new List<iz_BrylaGeometryczna>();


        public Form1()
        {

            InitializeComponent();
            iz_PictureBox.Image = new Bitmap(iz_PictureBox.Width, iz_PictureBox.Height);
            iz_Graphics = Graphics.FromImage(iz_PictureBox.Image);
            iz_Form = this;
            iz_Random = new Random();
            iz_RandomDistractor = iz_Random.Next();
            iz_cmbSolidsList.SelectedIndex = 0;

        }





        /*=========================================================================================================
         * ======================================= klasy ==========================================================
         * ======================================================================================================*/

        abstract class iz_BrylaGeometryczna
        {
            protected Color iz_Color;
            protected DashStyle iz_Dash;
            protected int iz_Thickness;
            protected bool iz_Direction;
            protected Point iz_Point;

            public iz_BrylaGeometryczna(Color iz_color, DashStyle iz_dash, int iz_thickness, bool iz_direction, Point iz_point)
            {
                iz_Color = iz_color;
                iz_Dash = iz_dash;
                iz_Thickness = iz_thickness;
                iz_Direction = iz_direction;
                iz_Point = iz_point;
            }
            public void iz_EditGraphicSettings(Color iz_color, int iz_thickness, DashStyle iz_dash)
            {
                iz_Color = iz_color;
                iz_Thickness = iz_thickness;
                iz_Dash = iz_dash;
            }
            public void iz_SetDirection(bool iz_direction) { iz_Direction = iz_direction; }
            public void iz_SetPosition(Point iz_point) { iz_Remove(); iz_Point = iz_point; iz_Draw(); }
            public abstract void iz_Draw();
            public abstract void iz_Remove();
            public abstract void iz_Rotate(int iz_angle);
            public abstract void iz_RotateAndDraw(int iz_angle);

        }
        abstract class iz_BrylaObrotowa : iz_BrylaGeometryczna
        {
            protected int iz_Radius;
            public iz_BrylaObrotowa(Color iz_color, DashStyle iz_dash, int iz_thickness, bool iz_direction, Point iz_point, int iz_radius) :
                base(iz_color, iz_dash, iz_thickness, iz_direction, iz_point)
            {
                iz_Radius = iz_radius;
            }

            public abstract override void iz_Draw();
            public abstract override void iz_Remove();
            public abstract override void iz_Rotate(int iz_angle);
            public abstract override void iz_RotateAndDraw(int iz_angle);

        }
        abstract class iz_Wieloscian : iz_BrylaGeometryczna
        {
            protected float iz_Height;
            protected int iz_NrOfSides;
            public iz_Wieloscian(Color iz_color, DashStyle iz_dash, int iz_thickness, bool iz_direction,
                Point iz_point, int iz_nrofsides, int iz_height) :
                base(iz_color, iz_dash, iz_thickness, iz_direction, iz_point)
            {
                iz_Height = iz_height;
                iz_NrOfSides = iz_nrofsides;
            }

            public abstract override void iz_Draw();
            public abstract override void iz_Remove();
            public abstract override void iz_Rotate(int iz_angle);
            public abstract override void iz_RotateAndDraw(int iz_angle);


        }
        /* ====================== end of abstract classes ========================*/

        class iz_OstroslupProsty : iz_Wieloscian
        {
            float iz_FirstPointPositionAngle;
            float iz_NewAngle;
            Point[] iz_PointTable;
            int iz_BigAxis, iz_SmallAxis;

            public iz_OstroslupProsty(Color iz_color, DashStyle iz_dash, int iz_thickness, bool iz_direction, Point iz_point,
                int iz_nrofsides, int iz_height) :
                base(iz_color, iz_dash, iz_thickness, iz_direction, iz_point, iz_nrofsides, iz_height)
            {
                iz_FirstPointPositionAngle = 0.0f;
                iz_Random = new Random((int)DateTime.Now.Ticks + iz_RandomDistractor);
                iz_RandomDistractor = iz_Random.Next();

                do
                {
                    iz_SmallAxis = (int)(0.05 * iz_Random.Next(1, iz_Form.iz_PictureBox.Height));
                    iz_BigAxis = (int)(0.25 * iz_Random.Next(1, iz_Form.iz_PictureBox.Width));
                }
                while (iz_BigAxis < (3 * iz_SmallAxis));
                iz_PointTable = new Point[iz_NrOfSides + 1];
                for (int i = 0; i < iz_NrOfSides; i++)
                    iz_PointTable[i] = new Point();



            }
            public override void iz_Draw()
            {
                int i;
                Pen iz_Pen = new Pen(iz_Color, iz_Thickness);
                iz_Pen.DashStyle = iz_Dash;
                iz_Rotate(0); // inicjalizacja punktow, obrot zerowy

                for (i = 0; i < iz_NrOfSides; i++)
                {
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i], iz_PointTable[i + 1]);
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i], new Point(iz_Point.X, (int)(iz_Point.Y - iz_Height)));
                }

            }
            public override void iz_Remove()
            {
                int i;
                Pen iz_Pen = new Pen(iz_Form.iz_PictureBox.BackColor, iz_Thickness);
                iz_Pen.DashStyle = iz_Dash;

                for (i = 0; i < iz_NrOfSides; i++)
                {
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i], iz_PointTable[i + 1]);
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i], new Point(iz_Point.X, (int)(iz_Point.Y - iz_Height)));
                }
            }
            public override void iz_Rotate(int iz_angle)
            {
                int i;
                float iz_AngleBetweenVertices = 360f / iz_NrOfSides;
                iz_NewAngle = iz_Direction ? (iz_FirstPointPositionAngle + iz_angle) : (iz_FirstPointPositionAngle - iz_angle);
                iz_FirstPointPositionAngle = iz_NewAngle;
                for (i = 0; i <= iz_NrOfSides; i++)
                {
                    iz_PointTable[i].X = ((int)(iz_Point.X + iz_BigAxis * Math.Cos(Math.PI * (iz_NewAngle + i * iz_AngleBetweenVertices) / 180)));
                    iz_PointTable[i].Y = ((int)(iz_Point.Y + iz_SmallAxis * Math.Sin(Math.PI * (iz_NewAngle + i * iz_AngleBetweenVertices) / 180)));
                }

            }
            public override void iz_RotateAndDraw(int iz_angle)
            {
                iz_Remove();
                iz_Rotate(iz_angle);
                iz_Draw();
            }
        }

        class iz_GraniastoslupProsty : iz_Wieloscian
        {
            float iz_FirstPointPositionAngle;
            float iz_NewAngle;
            Point[] iz_PointTable;
            int iz_BigAxis, iz_SmallAxis;

            public iz_GraniastoslupProsty(Color iz_color, DashStyle iz_dash, int iz_thickness, bool iz_direction,
                Point iz_point, int iz_nrofsides, int iz_height) :
                base(iz_color, iz_dash, iz_thickness, iz_direction, iz_point, iz_nrofsides, iz_height)
            {
                iz_FirstPointPositionAngle = 0.0f;
                iz_Random = new Random((int)DateTime.Now.Ticks + iz_RandomDistractor);
                iz_RandomDistractor = iz_Random.Next();

                do
                {
                    iz_SmallAxis = (int)(0.05 * iz_Random.Next(1, iz_Form.iz_PictureBox.Height));
                    iz_BigAxis = (int)(0.25 * iz_Random.Next(1, iz_Form.iz_PictureBox.Width));
                }
                while (iz_BigAxis < (3 * iz_SmallAxis));
                iz_PointTable = new Point[iz_NrOfSides + 1];
                for (int i = 0; i < iz_NrOfSides; i++)
                    iz_PointTable[i] = new Point();



            }
            public override void iz_Draw()
            {
                int i;
                Pen iz_Pen = new Pen(iz_Color, iz_Thickness);
                iz_Pen.DashStyle = iz_Dash;
                iz_Rotate(0); // inicjalizacja punktow, obrot zerowy

                for (i = 0; i < iz_NrOfSides; i++)
                {
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i], iz_PointTable[i + 1]);
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i].X, iz_PointTable[i].Y - iz_Height, iz_PointTable[i + 1].X, iz_PointTable[i + 1].Y - iz_Height);
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i], new Point(iz_PointTable[i].X, iz_PointTable[i].Y - (int)iz_Height));
                }

            }
            public override void iz_Remove()
            {
                int i;
                Pen iz_Pen = new Pen(iz_Form.iz_PictureBox.BackColor, iz_Thickness);
                iz_Pen.DashStyle = iz_Dash;

                for (i = 0; i < iz_NrOfSides; i++)
                {
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i], iz_PointTable[i + 1]);
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i].X, iz_PointTable[i].Y - iz_Height, iz_PointTable[i + 1].X, iz_PointTable[i + 1].Y - iz_Height);
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i], new Point(iz_PointTable[i].X, iz_PointTable[i].Y - (int)iz_Height));
                }
            }
            public override void iz_Rotate(int iz_angle)
            {
                int i;
                float iz_AngleBetweenVertices = 360f / iz_NrOfSides;
                iz_NewAngle = iz_Direction ? (iz_FirstPointPositionAngle + iz_angle) : (iz_FirstPointPositionAngle - iz_angle);
                iz_FirstPointPositionAngle = iz_NewAngle;
                for (i = 0; i <= iz_NrOfSides; i++)
                {
                    iz_PointTable[i].X = ((int)(iz_Point.X + iz_BigAxis * Math.Cos(Math.PI * (iz_NewAngle + i * iz_AngleBetweenVertices) / 180)));
                    iz_PointTable[i].Y = ((int)(iz_Point.Y + iz_SmallAxis * Math.Sin(Math.PI * (iz_NewAngle + i * iz_AngleBetweenVertices) / 180)));
                }

            }
            public override void iz_RotateAndDraw(int iz_angle)
            {
                iz_Remove();
                iz_Rotate(iz_angle);
                iz_Draw();
            }
        }



        class iz_Kula : iz_BrylaObrotowa
        {
            int iz_MovingEllipse, iz_MovingEllipse2;
            uint iz_Variable;
            public iz_Kula(Color iz_color, DashStyle iz_dash, int iz_thickness, bool iz_direction, Point iz_point, int iz_radius) :
                base(iz_color, iz_dash, iz_thickness, iz_direction, iz_point, iz_radius)
            {

                iz_Point = iz_point;
                iz_MovingEllipse = iz_Radius;
                iz_Variable = 0;

            }

            public override void iz_Draw()
            {
                Pen iz_Pen = new Pen(iz_Color, iz_Thickness);
                iz_Pen.DashStyle = iz_Dash;
                iz_Rotate(0); // inicjalizacja punktow, obrot zerowy

                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_Radius / 2), (int)(iz_Point.Y - iz_Radius / 2), iz_Radius, iz_Radius);
                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_Radius / 2), (int)(iz_Point.Y - iz_Radius / 8), iz_Radius, iz_Radius / 4);

                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_MovingEllipse / 2), (int)(iz_Point.Y - iz_Radius / 2), iz_MovingEllipse, iz_Radius);
                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_MovingEllipse2 / 2), (int)(iz_Point.Y - iz_Radius / 2), iz_MovingEllipse2, iz_Radius);

            }
            public override void iz_Remove()
            {
                Pen iz_Pen = new Pen(Color.White, iz_Thickness);
                iz_Pen.DashStyle = iz_Dash;

                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_Radius / 2), (int)(iz_Point.Y - iz_Radius / 2), iz_Radius, iz_Radius);
                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_Radius / 2), (int)(iz_Point.Y - iz_Radius / 8), iz_Radius, iz_Radius / 4);

                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_MovingEllipse / 2), (int)(iz_Point.Y - iz_Radius / 2), iz_MovingEllipse, iz_Radius);
                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_MovingEllipse2 / 2), (int)(iz_Point.Y - iz_Radius / 2), iz_MovingEllipse2, iz_Radius);
            }
            public override void iz_Rotate(int iz_angle)
            {
                if (iz_Variable < 360)
                    iz_Variable += (uint)iz_angle;
                else
                    iz_Variable = 0;

                iz_MovingEllipse = (int)(iz_Radius * Math.Cos(iz_Variable * Math.PI / 180));
                iz_MovingEllipse2 = (int)(iz_Radius * Math.Sin(iz_Variable * Math.PI / 180));
            }
            public override void iz_RotateAndDraw(int iz_angle)
            {
                iz_Remove();
                iz_Rotate(iz_angle);
                iz_Draw();
            }


        }

        class iz_Walec : iz_BrylaObrotowa
        {
            float iz_AngleBetweenVertices, iz_FirstPointPositionAngle;
            int iz_Height;
            Point[] iz_PointTable;
            float iz_SmallAxis;

            public iz_Walec(Color iz_color, DashStyle iz_dash, int iz_thickness, bool iz_direction,
                Point iz_point, int iz_radius, int iz_height) :
                base(iz_color, iz_dash, iz_thickness, iz_direction, iz_point, iz_radius)
            {
                iz_Radius = iz_radius;
                iz_Height = iz_height;
                iz_AngleBetweenVertices = 360.0f / 6;
                iz_FirstPointPositionAngle = 0;

                do
                {
                    iz_SmallAxis = (float)(0.05f * iz_Random.NextDouble() * iz_Form.iz_PictureBox.Height);

                }
                while (iz_Radius >= (float)(2 * iz_SmallAxis) && iz_Radius <= (float)(5 * iz_SmallAxis));

                iz_PointTable = new Point[6 + 1];
                for (int i = 0; i < 6 + 1; i++)
                {
                    iz_PointTable[i] = new Point();
                    iz_PointTable[i].X = (int)(iz_Point.X + iz_Radius * Math.Cos(Math.PI * (iz_AngleBetweenVertices * i + iz_FirstPointPositionAngle) / 180f));
                    iz_PointTable[i].Y = (int)(iz_Point.Y + iz_SmallAxis * Math.Sin(Math.PI * (iz_AngleBetweenVertices * i + iz_FirstPointPositionAngle) / 180f));
                }
            }

            public override void iz_Draw()
            {
                Pen iz_Pen = new Pen(iz_Color, iz_Thickness);
                iz_Pen.DashStyle = iz_Dash;

                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_Radius), (int)(iz_Point.Y - iz_SmallAxis), (int)(2 * iz_Radius), (int)(2 * iz_SmallAxis));
                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_Radius), (int)(iz_Point.Y - iz_SmallAxis + iz_Height), (int)(2 * iz_Radius), (int)(2 * iz_SmallAxis));
                iz_Graphics.DrawLine(iz_Pen, iz_Point.X - iz_Radius, iz_Point.Y, iz_Point.X - iz_Radius, iz_Point.Y + iz_Height);
                iz_Graphics.DrawLine(iz_Pen, iz_Point.X + iz_Radius, iz_Point.Y, iz_Point.X + iz_Radius, iz_Point.Y + iz_Height);

                for (int i = 0; i < 6; i++)
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i], new Point(iz_PointTable[i].X, iz_PointTable[i].Y + iz_Height));
            }
            public override void iz_Remove()
            {
                Pen iz_Pen = new Pen(Color.White, iz_Thickness);
                iz_Pen.DashStyle = iz_Dash;

                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_Radius), (int)(iz_Point.Y - iz_SmallAxis), (int)(2 * iz_Radius), (int)(2 * iz_SmallAxis));
                iz_Graphics.DrawEllipse(iz_Pen, (int)(iz_Point.X - iz_Radius), (int)(iz_Point.Y - iz_SmallAxis + iz_Height), (int)(2 * iz_Radius), (int)(2 * iz_SmallAxis));
                iz_Graphics.DrawLine(iz_Pen, iz_Point.X - iz_Radius, iz_Point.Y, iz_Point.X - iz_Radius, iz_Point.Y + iz_Height);
                iz_Graphics.DrawLine(iz_Pen, iz_Point.X + iz_Radius, iz_Point.Y, iz_Point.X + iz_Radius, iz_Point.Y + iz_Height);

                for (int i = 0; i < 6; i++)
                    iz_Graphics.DrawLine(iz_Pen, iz_PointTable[i], new Point(iz_PointTable[i].X, iz_PointTable[i].Y + iz_Height));
            }
            public override void iz_Rotate(int iz_angle)
            {
                int i;
                float iz_NewAngle = iz_Direction ? (iz_FirstPointPositionAngle + iz_angle) : (iz_FirstPointPositionAngle - iz_angle);
                iz_FirstPointPositionAngle = iz_NewAngle;
                for (i = 0; i <= 6; i++)
                {
                    iz_PointTable[i].X = ((int)(iz_Point.X + iz_Radius * Math.Cos(Math.PI * (iz_NewAngle + i * iz_AngleBetweenVertices) / 180)));
                    iz_PointTable[i].Y = ((int)(iz_Point.Y + iz_SmallAxis * Math.Sin(Math.PI * (iz_NewAngle + i * iz_AngleBetweenVertices) / 180)));
                }
            }
            public override void iz_RotateAndDraw(int iz_angle)
            {
                iz_Remove();
                iz_Rotate(iz_angle);
                iz_Draw();
            }
        }
        /* =================================================================================================
         * =================================== end of classes ==============================================
         * ===============================================================================================*/

        private void iz_AddNew_Click(object sender, EventArgs e)
        {

            iz_Random = new Random((int)DateTime.Now.Ticks + iz_RandomDistractor);
            iz_RandomDistractor = iz_Random.Next();
            Color iz_Color = Color.FromArgb(iz_Random.Next(0, 255), iz_Random.Next(0, 255), iz_Random.Next(0, 255));
            DashStyle iz_Dash;
            {
                int i = iz_Random.Next(1, 5);
                switch (i)
                {
                    case 0:
                        iz_Dash = DashStyle.Dash; break;
                    case 1:
                        iz_Dash = DashStyle.DashDot; break;
                    case 2:
                        iz_Dash = DashStyle.DashDotDot; break;
                    case 3:
                        iz_Dash = DashStyle.Dot; break;
                    case 4:
                        iz_Dash = DashStyle.Solid; break;
                    default:
                        iz_Dash = DashStyle.Solid; break;
                }
            }

            switch (iz_cmbSolidsList.SelectedIndex + 1)
            {
                case 1:
                    iz_List.Add(new iz_OstroslupProsty(iz_Color, iz_Dash, iz_trb3.Value,
                        iz_Random.Next(0, 1) == 1 ? true : false, new Point(iz_Random.Next(5, iz_Form.iz_PictureBox.Height),
                        iz_Random.Next(10, iz_Form.iz_PictureBox.Width)), iz_trb2.Value,
                        iz_trb1.Value));
                    iz_List[iz_List.Count - 1].iz_Draw();
                    break;
                case 2:
                    iz_List.Add(new iz_GraniastoslupProsty(iz_Color, iz_Dash, iz_trb3.Value,
                        iz_Random.Next(0, 1) == 1 ? true : false, new Point(iz_Random.Next(5, iz_Form.iz_PictureBox.Height),
                        iz_Random.Next(10, iz_Form.iz_PictureBox.Width)), iz_trb2.Value,
                        iz_trb1.Value));
                    iz_List[iz_List.Count - 1].iz_Draw();
                    break;
                case 3:
                    iz_List.Add(new iz_Kula(iz_Color,
                        iz_Dash,
                        iz_trb2.Value,
                        iz_Random.Next(0, 1) == 1 ? true : false, new Point(iz_Random.Next(10, iz_Form.iz_PictureBox.Width), iz_Random.Next(10, iz_Form.iz_PictureBox.Height)),
                        iz_trb1.Value));
                    iz_List[iz_List.Count - 1].iz_Draw();
                    break;
                case 4:
                    iz_List.Add(new iz_Walec(iz_Color, iz_Dash, iz_trb2.Value,
                        iz_Random.Next(0, 1) == 1 ? true : false,
                        new Point(iz_Random.Next(10, iz_Form.iz_PictureBox.Width), iz_Random.Next(10, iz_Form.iz_PictureBox.Height)),
                        iz_Random.Next(10, iz_Form.iz_PictureBox.Width / 2),
                        iz_trb1.Value));
                    iz_List[iz_List.Count - 1].iz_Draw();
                    break;




            }
            iz_PictureBox.Refresh();

        }

        private void iz_Timer_Tick(object sender, EventArgs e)
        {
            iz_Timer.Enabled = false;
            //  iz_Graphics.Clear(Color.White);
            for (int i = 0; i < iz_List.Count; i++)
                iz_List[i].iz_RotateAndDraw(1);
            iz_PictureBox.Refresh();
            iz_Timer.Enabled = true;

        }

        private void iz_PokazSlajdow_Tick(object sender, EventArgs e)
        {
            if (iz_List.Count <= 0)
                return;
            iz_Graphics.Clear(Color.White);

            iz_List[(int)iz_PokazSlajdow.Tag].iz_Draw();
            iz_PokazSlajdow.Tag = (int.Parse(iz_PokazSlajdow.Tag.ToString()) + 1) % iz_List.Count;
            iz_PictureBox.Refresh();

        }

        private void iz_btnTurnOn_Click(object sender, EventArgs e)
        {
            iz_Timer.Enabled = false;
            iz_Graphics.Clear(Color.White);


            if (iz_rdbAuto.Checked)
            {
                iz_PokazSlajdow.Enabled = true;
                iz_PokazSlajdow.Tag = 0;
            }
            iz_PictureBox.Refresh();

        }

        private void iz_txtSlajd_TextChanged(object sender, EventArgs e)
        {
            int iz_nrSlajdu;
            if (!int.TryParse(iz_txtSlajd.Text, out iz_nrSlajdu))
            {
                iz_EP.SetError(iz_txtSlajd, "ERROR: błędny zapis numeru slajdu\ndo pokazu!");
                return;
            }
            if (iz_nrSlajdu < 0 || iz_nrSlajdu >= iz_List.Count)
            {
                iz_EP.SetError(iz_txtSlajd, "ERROR: nie ma takiego slajdu");
                return;

            }
            iz_EP.Dispose();
            iz_Graphics.Clear(Color.White);
            if (iz_nrSlajdu >= 0 && iz_nrSlajdu <= iz_List.Count)
                iz_List[iz_nrSlajdu].iz_Draw();
        }

        private void iz_btnNext_Click(object sender, EventArgs e)
        {
            int iz_nrSlajdu;
            if (!int.TryParse(iz_txtSlajd.Text, out iz_nrSlajdu))
            {
                iz_EP.SetError(iz_txtSlajd, "ERROR: błędny zapis numeru slajdu\ndo pokazu!");
                return;
            }
            if (iz_nrSlajdu < 0 || iz_nrSlajdu >= iz_List.Count)
            {
                iz_EP.SetError(iz_txtSlajd, "ERROR: nie ma takiego slajdu");
                return;

            }
            iz_EP.Dispose();
            iz_List[iz_nrSlajdu].iz_Remove();
            if (iz_nrSlajdu < iz_List.Count - 1)
            {
                iz_nrSlajdu++;
                iz_List[iz_nrSlajdu].iz_Draw();
                iz_txtSlajd.Text = iz_nrSlajdu.ToString();
            }
            iz_PictureBox.Refresh();
        }

        private void iz_btnPrev_Click(object sender, EventArgs e)
        {
            int iz_nrSlajdu;
            if (!int.TryParse(iz_txtSlajd.Text, out iz_nrSlajdu))
            {
                iz_EP.SetError(iz_txtSlajd, "ERROR: błędny zapis numeru slajdu\ndo pokazu!");
                return;
            }
            if (iz_nrSlajdu < 0 || iz_nrSlajdu > iz_List.Count)
            {
                iz_EP.SetError(iz_txtSlajd, "ERROR: nie ma takiego slajdu");
                return;

            }
            iz_EP.Dispose();
            iz_List[iz_nrSlajdu].iz_Remove();
            if (iz_nrSlajdu > 0 && iz_nrSlajdu < iz_List.Count)
            {
                iz_nrSlajdu--;
                iz_List[iz_nrSlajdu].iz_Draw();
                iz_txtSlajd.Text = iz_nrSlajdu.ToString();
            }
            iz_PictureBox.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iz_Graphics.Clear(Color.White);

            if (iz_rdbAuto.Checked)
            {
                iz_PokazSlajdow.Enabled = false;
                iz_PokazSlajdow.Tag = 0;
            }
            iz_Timer.Enabled = true;

        }

        private void iz_BtnLeft_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < iz_List.Count; i++)
                iz_List[i].iz_SetDirection(false);
        }

        private void iz_BtnRight_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < iz_List.Count; i++)
                iz_List[i].iz_SetDirection(true);
        }

        private void iz_btnRoll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < iz_List.Count; i++)
            {
                int iz_Thickness = iz_Random.Next(1, 5);
                Color iz_Color = Color.FromArgb(iz_Random.Next(0, 255), iz_Random.Next(0, 255), iz_Random.Next(0, 255));
                DashStyle iz_Dash;
                {
                    int j = iz_Random.Next(1, 5);
                    switch (j)
                    {
                        case 0:
                            iz_Dash = DashStyle.Dash; break;
                        case 1:
                            iz_Dash = DashStyle.DashDot; break;
                        case 2:
                            iz_Dash = DashStyle.DashDotDot; break;
                        case 3:
                            iz_Dash = DashStyle.Dot; break;
                        case 4:
                            iz_Dash = DashStyle.Solid; break;
                        default:
                            iz_Dash = DashStyle.Solid; break;
                    }
                }
                iz_List[i].iz_Remove();
                iz_List[i].iz_EditGraphicSettings(iz_Color, iz_Thickness, iz_Dash);
                iz_List[i].iz_Draw();
            }
        }

        private void iz_btnRemoveFirst_Click(object sender, EventArgs e)
        {
            if (iz_List.Count <= 0)
                return;
            iz_List[0].iz_Remove();
            iz_List.Remove(iz_List[0]);
        }

        private void iz_btnRemoveLast_Click(object sender, EventArgs e)
        {
            if (iz_List.Count <= 0)
                return;
            iz_List[iz_List.Count - 1].iz_Remove();
            iz_List.Remove(iz_List[iz_List.Count - 1]);
        }

        private void iz_BtnRemoveExac_Click(object sender, EventArgs e)
        {
            // numeric up-down i nie trzeba checkow robic, bo nie akceptuje niczego innego niz liczby, i to liczby ograniczone przez nas :)
            if (iz_List.Count <= 0)
                return;
            if (iz_nudNumber.Value > iz_List.Count)
                return;


            iz_List[(int)iz_nudNumber.Value - 1].iz_Remove();
            iz_List.Remove(iz_List[(int)iz_nudNumber.Value - 1]);
        }

        private void iz_BtnRollPosition_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < iz_List.Count; i++)
                iz_List[i].iz_SetPosition(new Point(iz_Random.Next(5, iz_Form.iz_PictureBox.Width), iz_Random.Next(5, iz_Form.iz_PictureBox.Height)));

        }

        private void iz_cmbSolidsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (iz_cmbSolidsList.SelectedIndex)
            {
                case 0:
                case 1:
                    iz_lbl1.Text = "Wysokość:";
                    iz_lbl2.Text = "Ilość boków podstawy:";
                    iz_lbl3.Text = "Grubość linii:";
                    iz_trb1.Minimum = 10;
                    iz_trb1.Maximum = iz_Form.iz_PictureBox.Height - 10;
                    iz_trb2.Minimum = 3;
                    iz_trb2.Maximum = 10;
                    iz_trb3.Minimum = 1;
                    iz_trb3.Maximum = 5;
                    iz_lbl1.Visible = iz_lbl1.Enabled = true;
                    iz_lbl2.Visible = iz_lbl2.Enabled = true;
                    iz_lbl3.Visible = iz_lbl3.Enabled = true;
                    iz_trb1.Visible = iz_trb1.Enabled = true;
                    iz_trb2.Visible = iz_trb2.Enabled = true;
                    iz_trb3.Visible = iz_trb3.Enabled = true;
                    break;
                case 2:
                    iz_lbl1.Text = "Promień:";
                    iz_lbl2.Text = "Grubość linii:";
                    iz_lbl3.Text = "";
                    iz_trb1.Minimum = 10;
                    iz_trb1.Maximum = iz_Form.iz_PictureBox.Height - 10;
                    iz_trb2.Minimum = 1;
                    iz_trb2.Maximum = 5;
                    iz_trb3.Minimum = 1;
                    iz_trb3.Maximum = 5;
                    iz_lbl1.Visible = iz_lbl1.Enabled = true;
                    iz_lbl2.Visible = iz_lbl2.Enabled = true;
                    iz_lbl3.Visible = iz_lbl3.Enabled = false;
                    iz_trb1.Visible = iz_trb1.Enabled = true;
                    iz_trb2.Visible = iz_trb2.Enabled = true;
                    iz_trb3.Visible = iz_trb3.Enabled = false;
                    break;
                case 3:
                    iz_lbl1.Text = "Promień:";
                    iz_lbl2.Text = "Grubość linii:";
                    iz_lbl3.Text = "Wysokość:";
                    iz_trb1.Minimum = 10;
                    iz_trb1.Maximum = iz_Form.iz_PictureBox.Height - 10;
                    iz_trb2.Minimum = 1;
                    iz_trb2.Maximum = 5;
                    iz_trb3.Minimum = 1;
                    iz_trb3.Maximum = 5;
                    iz_lbl1.Visible = iz_lbl1.Enabled = true;
                    iz_lbl2.Visible = iz_lbl2.Enabled = true;
                    iz_lbl3.Visible = iz_lbl3.Enabled = true;
                    iz_trb1.Visible = iz_trb1.Enabled = true;
                    iz_trb2.Visible = iz_trb2.Enabled = true;
                    iz_trb3.Visible = iz_trb3.Enabled = true;
                    break;


            }
        }


    }
}

