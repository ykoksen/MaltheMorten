using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WindowsApp
{
    // A small, extendable helper for creating and drawing shapes on a Canvas.
    public class ShapeDrawer
    {
        // Create a Polyline from a set of points. Can be overridden to change behavior.
        public virtual Polyline CreatePolyline(IEnumerable<Point> points, Brush stroke = null, double thickness = 1)
        {
            var polyline = new Polyline
            {
                Stroke = stroke ?? Brushes.Black,
                StrokeThickness = thickness
            };

            if (points is null)
                return polyline;

            foreach (var p in points)
                polyline.Points.Add(p);

            return polyline;
        }

        // Draw a line (polyline) onto the provided Canvas using CreatePolyline.
        public virtual void DrawLine(Canvas canvas, IEnumerable<Point> points, Brush stroke = null, double thickness = 1)
        {
            if (canvas is null)
                return;

            var poly = CreatePolyline(points, stroke, thickness);
            canvas.Children.Add(poly);
        }

        // Example method that uses DrawLine. Can be used by educational code paths.
        public virtual void DrawSample(Canvas canvas)
        {
            var points = new List<Point>
            {
                new Point(10, 10),
                new Point(100, 50),
                new Point(200, 120),
                new Point(300, 80),
                new Point(400, 200)
            };

            DrawLine(canvas, points, Brushes.Blue, 2);
        }
    }
}
