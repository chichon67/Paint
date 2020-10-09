using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace geometryLib
{
    public delegate void RedrawHandler(object sender, EventArgs e);
    public class Drawing
    {
        private List<Curve> Element = new List<Curve>();
        public event EventHandler redraw;

        public List<Line> Lines
        {

            get
            {
                List<Line> lines = new List<Line>();
                lines.AddRange(Element.Where(Element => Element.GetType() == typeof(Line)).Select(line => line as Line));
                return lines;

            }
        }

        public List<Circle> Circles
        {
            get
            {
                List<Circle> circles = new List<Circle>();
                circles.AddRange(Element.Where(Element => Element.GetType() == typeof(Circle)).Select(circle => circle as Circle));
                return circles;
            }
        }
        public List<Polyline> Polylines
        {
            get
            {
                List<Polyline> polylines = new List<Polyline>();
                polylines.AddRange(Element.Where(Element => Element.GetType() == typeof(Polyline)).Select(polyline => polyline as Polyline));
                return polylines;
            }
        }




        public void AddElement(Curve element)
        {
            Element.Add(element);
            if (redraw != null)
                redraw(this, EventArgs.Empty);
        }

        public void RemoveElement(Curve element)
        {
            Element.Remove(element);
            if (redraw != null)
                redraw(this, EventArgs.Empty);
        }

        public void RemoveElementAt(int index)
        {
            Element.RemoveAt(index);
            if (redraw != null)
                redraw(this, EventArgs.Empty);
        }

        public void Draw(Graphics g)
        {

            foreach (var curve in Element)
            {

                curve.Draw(g);


            }
        }



    }
}
