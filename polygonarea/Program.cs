/*
    Problem:  https://open.kattis.com/submissions/7450513
    CPU time: 0.03 s
*/

using System;
using System.IO;
using System.Linq;

namespace polygonarea
{
    class Program
    {
        public struct Point
        {
            public readonly double X;
            public readonly double Y;
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        public enum Orientation
        {
            CLOCKVICE,
            COUNTER_CLOCKVICE,
            UNKNOWN
        }

        public struct Polygon
        {
            private const int MinimumPointCount = 3;
            public readonly Point[] Points;
            public readonly double Area;
            public readonly Orientation Orientation;
            private const string ccw = "CCW";
            private const string cw  = "CW";

            public Polygon(Span<Point> points)
            {
                if (points.Length < MinimumPointCount) {
                    throw new ArgumentException($"Cannot create polygon b/c not enough points (points: {points.Length}, minimum: {MinimumPointCount})");
                }

                Points = new Point[points.Length];
                points.CopyTo(Points.AsSpan());

                double temp = 0;
                for (var pointIdx = 0; pointIdx < Points.Length; pointIdx++) {
                    temp += (Points[pointIdx].X * Points[(pointIdx + 1 < Points.Length) ? (pointIdx + 1) : 0].Y);
                    temp -= (Points[pointIdx].Y * Points[(pointIdx + 1 < Points.Length) ? (pointIdx + 1) : 0].X);
                }

                Area = temp / 2;
                Orientation = (Area > 0) ? Orientation.COUNTER_CLOCKVICE : Orientation.CLOCKVICE;
            }

            public string AreaToString() => Math.Abs(Area).ToString("F1");
            public string OrientationToString() => (Orientation == Orientation.CLOCKVICE) ? cw : ccw;
        }

        static void Main(string[] args)
        {
            const char endCase = '0';

            using (var inputStream  = Console.OpenStandardInput())
            using (var streamReader = new StreamReader(inputStream)) {

                while (true) {
                    uint inputPointCount = UInt32.Parse(streamReader.ReadLine() ?? "0");
                    if (inputPointCount == 0) {
                        Environment.Exit(0);
                    }

                    var inputValues = new Point[inputPointCount];
                    var line        = String.Empty;
                    double[] lineValues;
                    for (var itemIdx = 0; itemIdx < inputPointCount; itemIdx++) {

                        line = streamReader.ReadLine();
                        if (String.IsNullOrEmpty(line) || (line.Length == 1 && line[0] == endCase)) {
                            Environment.Exit(0);
                        }

                        lineValues = line.Split(' ', 2).Select(x => double.Parse(x)).ToArray();

                        inputValues[itemIdx] = new Point(
                            x: lineValues[0],
                            y: lineValues[1]
                        );
                    }

                    var polygon = new Polygon(inputValues);
                    Console.WriteLine($"{polygon.OrientationToString()} {polygon.AreaToString()}");
                }
            }
        }
    }
}
