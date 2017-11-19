using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;


namespace CMPE2800HimaPanchalLAbppp_
{
    abstract class ShapeBAse
    {
        public abstract GraphicsPath GetPath();

        // public GraphicsPath _gpModel;
        public const float _cfRadius = 100;
        public float _fRotation = 0f;
        float _fRotationIncrement = 0f;
        public static Random _random = new Random();
        //X speed in float
        public float _fXSpeed;
        //Y speed in float
        public float _fYSpeed;

        //get the location and set the location further in the constructor
        public PointF location { get; set; }
        //bool  value to remove the ones which are dead in the form of lambda
        public bool IsMarkedForDeath { get; set; }
        public ShapeBAse(PointF _position)
        {
            //   _gpModel = new GraphicsPath();
            
            location = _position;

            _fRotation = 0;
            //rotation in the range of 
            _fRotationIncrement = (float)_random.NextDouble() * 6 - 3;
            //X and Yspeed in the range of 
            _fXSpeed = (float)(_random.NextDouble() * 5 - 2.5);
            _fYSpeed = (float)(_random.NextDouble() * 5 - 2.5);
            //initialization of IsMarkedForD`eath to false
            IsMarkedForDeath = false;

        }

        public void Render(Graphics gr)
        {

            //fill the Getpath return value with a provided color
            //is it fillpath? new SolidBrush() just like demo
            //it should be teh instance of buffered graphics
            gr.FillPath(new SolidBrush(Color.Green), GetPath());
           // gr.DrawEllipse(new Pen(Color.Green), (location.X -_cfRadius), location.Y-_cfRadius);




        }
        public void Tick(Size sz)
        {
            //will accept a size and will move the shape according to the current speed values
            _fRotation += _fRotationIncrement;
            //for any violation in the speed values it would flip the sign

            if (location.X < 0)
            {
                //setting the location to the new point
                location = new PointF(0, location.Y);
            }
            //if Width is greater than 
            else if (location.X > sz.Width)
            {
                
                location = new PointF(sz.Width, location.Y);
            }

            if (location.X + _fXSpeed > sz.Width || location.X + _fXSpeed < 0)
            {
                _fXSpeed *= -1;
            }
            if (location.Y < 0)
            {
                location = new PointF(location.X, 0);

            }
            else if (location.Y > sz.Height)
            {
                location = new PointF(location.X, sz.Height);

            }
            if (location.Y + _fYSpeed > sz.Height || location.Y + _fYSpeed < 0)
            {
                _fYSpeed *= -1;
            }


            location = new PointF(location.X + _fXSpeed, location.Y + _fYSpeed);
        }


        public double Distance(PointF point)
        {
            //initializing distance to 0.0
            double distance= 0.0;
           //According to the distance between two points 
            distance = Math.Sqrt(Math.Pow(location.X - point.X,2) + Math.Pow(location.Y - point.Y,2));
            
            return distance;
        }

    }

    }


    
