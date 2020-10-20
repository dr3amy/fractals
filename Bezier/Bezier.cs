using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab05
{
    public partial class Bezier : Form
    {
        public Bezier()
        {
            InitializeComponent();
            imageToDrawBox.Image = new Bitmap(imageToDrawBox.Width, imageToDrawBox.Height);
            g = Graphics.FromImage(imageToDrawBox.Image);
            bmp = (Bitmap)imageToDrawBox.Image;
        }

        private static List<Point> points = new List<Point>();
        private static Graphics g;
        private static Bitmap bmp;
        private bool haveFictivePoint = false;
        private Point fictivePoint = new Point();
        private bool nowMoving = false;
        private bool dynamicUpdating = false;
        private int indOfMovingPoint = -1;

        private int accuracy = 7;

        /// <summary>
        /// очистка рисования сплайнов, не удаляя точки
        /// </summary>
        private void ClearWithoutPoints()
        {
            imageToDrawBox.Image = new Bitmap(imageToDrawBox.Width, imageToDrawBox.Height);
            g = Graphics.FromImage(imageToDrawBox.Image);
            bmp = (Bitmap)imageToDrawBox.Image;

            foreach (var p in points)
            {
                DrawPoint(p.X, p.Y, Color.Black);
            }
        }

        /// <summary>
        /// рисование точки 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="c"></param>
        private void DrawPoint(int x, int y, Color c)
        {
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(x, y, 5, 5));
            imageToDrawBox.Image = bmp;
        }

        /// <summary>
        /// рисование большей точки 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="c"></param>
        private void DrawBiggerPoint(int x, int y, Color c)
        {
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(x, y, 7, 7));
            imageToDrawBox.Image = bmp;
        }

        /// <summary>
        /// добавление точки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="c"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool AddPoint(int x, int y, Color c, int index = -1)
        {
            if (x > 0 && x < imageToDrawBox.Width && y > 0 && y < imageToDrawBox.Height)
            {
                Point p = new Point(x, y);
                if (index == -1)
                {
                    int f_ind = points.FindIndex(poin => (poin.X == p.X) && (poin.Y == p.Y));
                    if (f_ind == -1)
                        points.Add(p);

                }
                else
                    points.Insert(index, p);

                DrawPoint(x, y, c);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// удаление точки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool DeletePoint(int x, int y)
        {
            if (x > 0 && x < imageToDrawBox.Width && y > 0 && y < imageToDrawBox.Height)
            {
                int indToDel = 0;
                int diff = accuracy;
                if (points.Exists(point => ((point.X > x - diff) && (point.X < x + diff)) &&
                    ((point.Y > y - diff) && (point.Y < y + diff))))
                {
                    indToDel = points.FindIndex(point => ((point.X > x - diff) && (point.X < x + diff)) &&
                        ((point.Y > y - diff) && (point.Y < y + diff)));

                    DrawPoint(points[indToDel].X, points[indToDel].Y, imageToDrawBox.BackColor);

                    points.RemoveAt(indToDel);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        private void imageToDrawBox_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            if (CreateRadioButton.Checked)
            {
                AddPoint(x, y, Color.Black);
            }
            if (DeleteRadioButton.Checked)
            {
                DeletePoint(x, y);

                if (haveFictivePoint)
                {
                    DeletePoint(fictivePoint.X, fictivePoint.Y);
                    haveFictivePoint = false;
                }
            }
            ClearWithoutPoints();
            DrawSpline();
        }
        
        private void imageToDrawBox_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;

            if (MoveRadioButton.Checked)
            {
                nowMoving = true;
                int diff = accuracy;

                if (nowMoving && indOfMovingPoint == -1)
                {
                    indOfMovingPoint = points.FindIndex(point => ((point.X > x - diff) && (point.X < x + diff)) &&
                        ((point.Y > y - diff) && (point.Y < y + diff)));
                }
                ClearWithoutPoints();
                DrawSpline();
            }
        }
        
        private void imageToDrawBox_MouseUp(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;

            if (MoveRadioButton.Checked && indOfMovingPoint != -1)
            {
                int ind = System.Math.Min(indOfMovingPoint, points.Count());
                Point p = points[indOfMovingPoint];
                DeletePoint(p.X, p.Y);
                if (AddPoint(x, y, Color.Black, ind))
                {
                    ClearWithoutPoints();
                    DrawSpline();
                }
                nowMoving = false;
                indOfMovingPoint = -1;
            }
        }

        /// <summary>
        /// динамическое обновление кривой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageToDrawBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (dynamicUpdating && MoveRadioButton.Checked && indOfMovingPoint != -1)
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                if (x > 0 && x < imageToDrawBox.Width && y > 0 && y < imageToDrawBox.Height)
                {
                    int ind = System.Math.Min(indOfMovingPoint, points.Count());
                    Point p = points[indOfMovingPoint];
                    DeletePoint(p.X, p.Y);
                    if (AddPoint(x, y, Color.Black, ind))
                    {
                        ClearWithoutPoints();
                        DrawSpline();
                    }
                }
            }
        }

        /// <summary>
        /// координата точки q0=p0(1-t)+p1*t
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private PointF Q(PointF p0, PointF p1, float t)
        {
            return new PointF(p0.X * (1 - t) + p1.X * t, p0.Y * (1 - t) + p1.Y * t);
        }

        /// <summary>
        /// координата точки r0=q0(1-t)+q1*t
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private PointF R(PointF p0, PointF p1, PointF p2, float t)
        {
            return new PointF(Q(p0, p1, t).X * (1 - t) + Q(p1, p2, t).X * t,
                Q(p0, p1, t).Y * (1 - t) + Q(p1, p2, t).Y * t);
        }

        /// <summary>
        /// координата точки b=r0(1-t)+r1*t
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private PointF B(PointF p0, PointF p1, PointF p2, PointF p3, float t)
        {
            return new PointF(R(p0, p1, p2, t).X * (1 - t) + R(p1, p2, p3, t).X * t,
                R(p0, p1, p2, t).Y * (1 - t) + R(p1, p2, p3, t).Y * t);
        }

        private void DrawLine(PointF p1, PointF p2, Color c)
        {
            g.DrawLine(new Pen(c), new Point((int)p1.X, (int)p1.Y), new Point((int)p2.X, (int)p2.Y));
            imageToDrawBox.Image = imageToDrawBox.Image;
        }

        /// <summary>
        /// функция считает точку на середине отрезка, заданнаго координатами
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private Point PointBetweenPoints(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }

        private void AddPointsForDrawingCurve()
        {

            int s = points.Count();

            if (s % 2 != 0 && s > 4)
            {
                if (!haveFictivePoint)
                {
                    Point p1 = points[s - 2];
                    Point p2 = points[s - 1];
                    Point pb = PointBetweenPoints(p1, p2);

                    points[s - 1] = pb;
                    DrawPoint(pb.X, pb.Y, Color.Green);
                    points.Add(p2);

                    haveFictivePoint = true;
                    fictivePoint = pb;
                }
                else
                {
                    DeletePoint(fictivePoint.X, fictivePoint.Y);
                    haveFictivePoint = false;
                }
            }
        }

        /// <summary>
        /// построить сплайн по 4 точкам
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        private void DrawSplineBy4Points(Point p0, Point p1, Point p2, Point p3)
        {
            PointF prevP = B(p0, p1, p2, p3, (float)0);
            int factor = factorTrackBar.Value;
            for (int i = 1; i <= factor; ++i)
            {
                PointF p = B(p0, p1, p2, p3, (float)i / factor);

                DrawLine(prevP, p, Color.Red);
                prevP = p;
            }
        }

        /// <summary>
        /// рисование сплайна по заданным точкам
        /// </summary>
        private void DrawSpline()
        {
            AddPointsForDrawingCurve();
            if (points.Count() == 4)
            {
                Point p0 = points[0];
                Point p1 = points[1];
                Point p2 = points[2];
                Point p3 = points[3];

                DrawSplineBy4Points(p0, p1, p2, p3);
            }
            if (points.Count() > 4)
            {
                //addPointsForDrawingCurve();
                int sz = points.Count();

                if (sz % 2 == 0)
                {
                    Point p0 = points[0];
                    Point p1 = points[1];
                    Point p2 = points[2];
                    Point p3 = PointBetweenPoints(points[2], points[3]);

                    DrawSplineBy4Points(p0, p1, p2, p3);

                    for (int i = 3; i < sz - 4; i += 2)
                    {
                        p0 = PointBetweenPoints(points[i - 1], points[i]);
                        p1 = points[i];
                        p2 = points[i + 1];
                        p3 = PointBetweenPoints(points[i + 1], points[i + 2]);

                        DrawSplineBy4Points(p0, p1, p2, p3);
                    }

                    p3 = points[sz - 1];
                    p2 = points[sz - 2];
                    p1 = points[sz - 3];
                    p0 = PointBetweenPoints(points[sz - 3], points[sz - 4]);
                    DrawSplineBy4Points(p0, p1, p2, p3);
                }
            }
        }

        private void ClearListButton_Click(object sender, EventArgs e)
        {
            imageToDrawBox.Image = new Bitmap(imageToDrawBox.Width, imageToDrawBox.Height);
            g = Graphics.FromImage(imageToDrawBox.Image);
            bmp = (Bitmap)imageToDrawBox.Image;
            points.Clear();
        }

        private void DynamicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dynamicUpdating = !dynamicUpdating;
        }

        private void factorTrackBar_Scroll(object sender, EventArgs e)
        {
            ClearWithoutPoints();
            DrawSpline();
        }

        
    }
}
