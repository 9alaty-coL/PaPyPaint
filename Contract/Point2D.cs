using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Contract
{
    public class Point2D : IShape
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Color color { get; set; }
        public double thickness { get; set; }

        public string Name => "Point";

        public void HandleStart(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void HandleEnd(double x, double y)
        {
            X = x;
            Y = y;
        }

        public UIElement Draw()
        {
            Line l = new Line()
            {
                X1 = X,
                Y1 = Y,
                X2 = X,
                Y2 = Y,
                StrokeThickness = thickness,
                Stroke = new SolidColorBrush(color),
            };

            return l;
        }

        public IShape Clone(Color cl, double t)
        {
            return new Point2D() { color = cl , thickness=t};
        }
        public double GetX()
        {
            return X;
        }
        public double GetY()
        {
            return Y;
        }
        public Point2D GetStart()
        {
            return this;
        }
        public Point2D GetEnd()
        {
            return this;
        }
    }
}
