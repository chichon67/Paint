using geometryLib;
using System;
using System.Drawing;
using System.Windows.Forms;
using Point = vectorLib.Point;

namespace frmMain
{
    public partial class Form1 : Form
    {



        Curve curve = null;
        Drawing draw = new Drawing();
        ClickHandler clickHandler;
        MouseButtons mb = new MouseButtons();




        public Form1()
        {
            InitializeComponent();
            draw.redraw += Draw_redraw;     // we append the event redraw to Draw_redraw?

        }

        private void Draw_redraw(object sender, EventArgs e)
        {

            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }



        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void line_click(object sender, EventArgs e)
        {
            clickHandler = Line.ClickHandler;
            curve = null;
        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // adjust coordinate 
            SetGraphicsTransformToWorld(e.Graphics);

            draw.Draw(e.Graphics);

            if (toolStripButton2.Checked)
            {
                draw.AddElement(new Line());
            }
            else if (toolStripButton1.Checked)
            {
                draw.AddElement(new Circle());
            }
            else if (btn_Polyline.Checked)
            {
                draw.AddElement(new Polyline());
            }


        }


        private void circle_click(object sender, EventArgs e)
        {
            clickHandler = Circle.ClickHandler;
            curve = null;

        }

        private void polyline_click(object sender, EventArgs e)
        {
            clickHandler = Polyline.ClickHandler;
            curve = new Polyline();

        }

        private void SetGraphicsTransformToWorld(Graphics g)
        {
            g.ResetTransform();
            g.ScaleTransform(1f, -1f);
            g.TranslateTransform(0f, -pictureBox1.Height);

        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (clickHandler != null)
            {
                ClickResult resultClickHandler = clickHandler(new System.Drawing.Point((int)TransformScreen2World(e.Location).X, (int)TransformScreen2World(e.Location).Y), e.Button, ref curve);

                if (resultClickHandler == ClickResult.canceled)
                {
                    curve = null;
                }

                if (resultClickHandler == ClickResult.finished)
                {
                    draw.AddElement(curve);
                    curve = null;
                }

            }


        }

        public Point TransformScreen2World(System.Drawing.Point screenPoint)
        { return new Point(screenPoint.X, -(screenPoint.Y - pictureBox1.Height)); }



        private void kreiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void Info_btn_click(object sender, EventArgs e)
        {
            int numOflines = draw.Lines.Count;
            int numOfPolylines = draw.Polylines.Count;
            int numOfCircle = draw.Circles.Count;

            MessageBox.Show("Lines: " + numOflines.ToString() + "Circles: " + " " + numOfCircle + "Polylines: " + " " + numOfPolylines);

        }
    }
}
