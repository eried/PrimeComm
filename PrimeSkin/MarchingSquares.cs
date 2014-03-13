using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PrimeSkin
{
    /// <summary>
    /// Finds the border using the MarchingSquare algorithm
    /// Based on: http://devblog.phillipspiess.com/2010/02/23/better-know-an-algorithm-1-marching-squares/
    /// </summary>
    public class MarchingSquares
    {
        private enum StepDirection
        {
            None,Up,Left,Down,Right
        }

        private Bitmap _img;
        private StepDirection _previousStep, _nextStep;
        private Color _cornerColor;
        private const float Tolerance = 0.0001F; // To do the line optimization

        public Point[] DoMarch(Bitmap target, bool optimized=true)
        {
            _img = target;
            _cornerColor = _img.GetPixel(0, 0);

            // Find the start points
            var perimeterStart = FindStartPoint();

            // Return the list of points
            var p = WalkPerimeter(perimeterStart.X, perimeterStart.Y);

            return (optimized ? OptimizePointsInLine(p):p).ToArray();

        }

        /// <summary>
        /// This optimizes the points that are in line
        /// </summary>
        /// <param name="points">Input points</param>
        private static List<Point> OptimizePointsInLine(List<Point> points)
        {
            if(points.Count == 0)
                return null;

            var r = new List<Point> {points[0]};
            points.Add(points[0]);
            var last = 0;

            for (var i = 0; i < points.Count() - 2; i++)
            {
                if (PointIsInLine(points[last], points[i + 2], points[i + 1])) continue;

                r.Add(points[i + 1]);
                last = i;
            }

            return r;
        }

        public static float GetY(Point start, Point end, Point check)
        {
            if (end.X == start.X)
                return check.Y;

            var m = (end.Y - start.Y) / (float)(end.X - start.X);
            var b = start.Y - (m * start.X);
            return m * check.X + b;
        }

        private static bool PointIsInLine(Point start, Point end, Point check)
        {
            if (check == start || check == end)
                return true;

            return Math.Abs(GetY(start, end, check) - check.Y) < Tolerance;
        }

        /// <summary>
        /// Finds the first pixel in the perimeter of the image
        /// </summary>
        /// <returns>The first different pixel</returns>
        private Point FindStartPoint()
        {
            for(var x=1;x<_img.Width;x++)
                for (var y = 0; y < _img.Height; y++)
                    if (_img.GetPixel(x, y) != _cornerColor)
                        return new Point(x, y);

            return Point.Empty;
        }

        /// <summary>
        /// Performs the main while loop of the algorithm
        /// </summary>
        /// <param name="startX">X</param>
        /// <param name="startY">Y</param>
        /// <returns>Perimeter</returns>
        private List<Point> WalkPerimeter(int startX, int startY)
        {
            // Do some sanity checking, so we aren't
            // walking outside the image
            if (startX < 0)
                startX = 0;
            if (startX > _img.Width)
                startX = _img.Width;
            if (startY < 0)
                startY = 0;
            if (startY > _img.Height)
                startY = _img.Height;

            // Set up our return list
            var pointList = new List<Point>();

            // Our current x and y positions, initialized
            // to the init values passed in
            int x = startX;
            int y = startY;

            // The main while loop, continues stepping until
            // we return to our initial points
            do
            {
                // Evaluate our state, and set up our next direction
                Step(x, y);

                // If our current point is within our image
                // add it to the list of points
                if (x >= 0 &&
                    x < _img.Width &&
                    y >= 0 &&
                    y < _img.Height)
                    pointList.Add(new Point(x, y));

                switch (_nextStep)
                {
                    case StepDirection.Up: y--; break;
                    case StepDirection.Left: x--; break;
                    case StepDirection.Down: y++; break;
                    case StepDirection.Right: x++; break;
                }
            } while (x != startX || y != startY);

            return pointList;
        }

        /// <summary>
        /// Determines and sets the state of the 4 pixels that represent our current state, and sets our current and previous directions
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        private void Step(int x, int y)
        {
            // Scan our 4 pixel area
            bool upLeft = IsBorder(x - 1, y - 1),upRight = IsBorder(x, y - 1);
            bool downLeft = IsBorder(x - 1, y), downRight = IsBorder(x, y);

            // Store our previous step
            _previousStep = _nextStep;

            // Determine which state we are in
            var state = 0;

            if (upLeft)
                state |= 1;
            if (upRight)
                state |= 2;
            if (downLeft)
                state |= 4;
            if (downRight)
                state |= 8;

            // State now contains a number between 0 and 15
            // representing our state.
            // In binary, it looks like 0000-1111 (in binary)

            // An example. Let's say the top two pixels are filled,
            // and the bottom two are empty.
            // Stepping through the if statements above with a state
            // of 0b0000 initially produces:
            // Upper Left == true ==>  0b0001
            // Upper Right == true ==> 0b0011
            // The others are false, so 0b0011 is our state
            // (That's 3 in decimal.)

            // Looking at the chart above, we see that state
            // corresponds to a move right, so in our switch statement
            // below, we add a case for 3, and assign Right as the
            // direction of the next step. We repeat this process
            // for all 16 states.

            // So we can use a switch statement to determine our
            // next direction based on
            switch (state)
            {
                case 1: _nextStep = StepDirection.Up; break;
                case 2: _nextStep = StepDirection.Right; break;
                case 3: _nextStep = StepDirection.Right; break;
                case 4: _nextStep = StepDirection.Left; break;
                case 5: _nextStep = StepDirection.Up; break;
                case 6:
                    _nextStep = _previousStep == StepDirection.Up ? StepDirection.Left : StepDirection.Right;
                    break;
                case 7: _nextStep = StepDirection.Right; break;
                case 8: _nextStep = StepDirection.Down; break;
                case 9:
                    _nextStep = _previousStep == StepDirection.Right ? StepDirection.Up : StepDirection.Down;
                    break;
                case 10: _nextStep = StepDirection.Down; break;
                case 11: _nextStep = StepDirection.Down; break;
                case 12: _nextStep = StepDirection.Left; break;
                case 13: _nextStep = StepDirection.Up; break;
                case 14: _nextStep = StepDirection.Left; break;
                default:
                    _nextStep = StepDirection.None;
                    break;
            }
        }

        private bool IsBorder(int x, int y)
        {
            // Make sure we don't pick a point outside our
            // image boundary!
            if (x < 0 || y < 0 || x >= _img.Width || y >= _img.Height)
                return false;

            // Check the color value of the pixel
            // If it isn't 100% transparent, it is solid
            return _img.GetPixel(x,y)!=_cornerColor;
        }
    }
}
