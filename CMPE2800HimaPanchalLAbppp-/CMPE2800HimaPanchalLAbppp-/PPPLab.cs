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


namespace CMPE2800HimaPanchalLAbppp_
{
    public partial class PPPLab : Form
    {
        LinkedList<Region> llistRegion = new LinkedList<Region>();
        List<ShapeBAse> _llShapes = new List<ShapeBAse>();
        public PPPLab()
        {
            InitializeComponent();
        }

        private void timTick_UI_Tick(object sender, EventArgs e)
        {
            Triangle tr;
            foreach (ShapeBAse ss in _llShapes)
                ss.Tick(ClientSize);

            Graphics gr = CreateGraphics();
           
            for (int iOut = 0; iOut < _llShapes.Count; iOut++)
            {
                for (int iIn = 0; iIn < _llShapes.Count; iIn++)
                {
                    //Checking if it is not intersecting with itself
                    if (iOut != iIn && _llShapes[iOut].Distance(_llShapes[iIn].location)<=2*ShapeBAse._cfRadius)
                    {
                        Region A = new Region(_llShapes[iOut].GetPath());
                        Region B = new Region(_llShapes[iIn].GetPath());

                        A.Intersect(B);
                        if (!A.IsEmpty(CreateGraphics()))
                        {
                            llistRegion.AddLast(A);
                            _llShapes[iOut].IsMarkedForDeath = true;
                            _llShapes[iIn].IsMarkedForDeath = true;
                          
                        }

                    }
                }
            }
            _llShapes.RemoveAll(sr => sr.IsMarkedForDeath);

            //Double Buffering to create the graphics object
            using (BufferedGraphicsContext bgc = new BufferedGraphicsContext())
            {
                //Create Graphics of what size or what target Rectangle Ans is ClientRectangle
                using (BufferedGraphics bg = bgc.Allocate(CreateGraphics(), ClientRectangle))
                {
                    bg.Graphics.Clear(Color.Purple);
                    foreach (Region item in llistRegion)
                    {

                        //For Region not the pen it should be the brush
                        bg.Graphics.FillRegion(new SolidBrush(Color.Red), item);
                    }
                    //Go through each shapes in the class from the list
                    foreach (ShapeBAse ss in _llShapes)
                        // bg.Graphics.FillPath(new SolidBrush(Color.Blue), ss.GetPath());
                        ss.Render(bg.Graphics);
                    //Note You gotta render botth things 
                    //flipping the back buffer to the surface
                    bg.Render();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Mouse Down event for the mouse event to happen 
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //if the left mouse button is pressed 
            if (e.Button == MouseButtons.Left)
            {
                //IF shift + Left button is pressed then add the rock
                if (Control.ModifierKeys == Keys.Shift)
                _llShapes.Add(new Rock(new PointF(e.X, e.Y)));
                else
                {

                    _llShapes.Add(new Triangle(new PointF(e.X, e.Y)));
                }
            }
            if(e.Button== MouseButtons.Right)
            {
                for (int i = 0; i<1000; i++)
                {
                    PointF pt = new PointF();
                    pt.X = (float)(ShapeBAse._random.NextDouble()*ClientRectangle.Width);
                    pt.Y = (float)(ShapeBAse._random.NextDouble()*ClientRectangle.Height);
                   // _llShapes.Add(new Rock(new PointF(e.X, e.Y)));
                    if (Control.ModifierKeys == Keys.Shift)
                        _llShapes.Add(new Rock(pt));
                    else
                    {

                        _llShapes.Add(new Triangle(pt));
                    }
                }
            }

        }
           
               
        }
    }

