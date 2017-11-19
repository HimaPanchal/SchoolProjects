using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace CMPE2800HimaPanchalLAbppp_
{
    class Triangle : ShapeBAse
    {
        //raedonly marked as it is gonna be served as model and will be cloned for use
        static readonly GraphicsPath _modelStaticPath;
        // float _fRotation = 0f;
       
        //static class

        static Triangle()
        {
            _modelStaticPath = new GraphicsPath();
            //_modelStaticPath.AddPolygon(new Point[]{
            //                 new Point(-10,20),new Point(-15,30) ,new Point(20,40)  });
            _modelStaticPath.AddPolygon(pointArray(3));
            //gpmodel models an equilateral triangle
        }

        public Triangle(PointF _position) : base(_position)
        {

        }

        public override GraphicsPath GetPath()
        {
            GraphicsPath gpclone = (GraphicsPath)_modelStaticPath.Clone();
            Matrix mat = new Matrix();
           
            mat.Translate(location.X, location.Y);
            mat.Rotate(_fRotation);
            gpclone.Transform(mat);
            return (gpclone);
        }

        //return _gpModel;
        //fully transformed model -clone 
        //apply transformations and rotation ,returning it when done.

        static PointF[] pointArray(int sides)
        {
            PointF[] point = new PointF[sides];
            double angle = 0;
            for (int i = 0; i < point.Length; i++)
            {
                angle += Math.PI * 2 / sides;//360/number of sides
                PointF pointX = new PointF();//assignment
                //Setting X= r*Sin(Theta)
                pointX.X = (float)(_cfRadius * Math.Sin(angle));
                //Setting Y = r*Cos(Theta)
                pointX.Y = (float)(_cfRadius * Math.Cos(angle));
                point[i] = pointX;
            }
           //returning point array which has pointX.X and pointX.Y in it
             return point;

        }

    }

}
