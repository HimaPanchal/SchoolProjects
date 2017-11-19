using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace CMPE2800HimaPanchalLAbppp_
{
    class Rock : ShapeBAse
    //non static class 
    {
        public GraphicsPath _graphicsPath;

        public override GraphicsPath GetPath()
        {
            GraphicsPath gpclone = (GraphicsPath)_graphicsPath.Clone();
            Matrix mat = new Matrix();
            
            mat.Translate(location.X, location.Y);
            mat.Rotate(_fRotation);
            gpclone.Transform(mat);
            return (gpclone);
        }

        public Rock(PointF _position) : base(_position)
        {
            _graphicsPath = new GraphicsPath();
            //_modelStaticPath.AddPolygon(new Point[]{
            //                 new Point(-10,20),new Point(-15,30) ,new Point(20,40)  });
            _graphicsPath.AddPolygon(pointArray(_random.Next(4,12)));
        }

        static PointF[] pointArray(int sides)
        {
            PointF[] point = new PointF[sides];
            double angle = 0;
           
            for (int i = 0; i < point.Length; i++)
            {
                double r = _random.NextDouble() * (_cfRadius/2)+ (_cfRadius / 2);
                angle += Math.PI * 2 / sides;//360/number of sides
                PointF pointX = new PointF();
                pointX.X = (float)(r* Math.Sin(angle));
                pointX.Y = (float)(r* Math.Cos(angle));
                point[i] = pointX;
            }
           

            return point;

        }
    }
}
