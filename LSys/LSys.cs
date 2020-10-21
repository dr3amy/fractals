using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab05
{
    public partial class LSys : Form
    {
        Grammar currentGrammar = null;
        Pen drawingPen = new Pen(Color.Black);

        public LSys()
        {
            InitializeComponent();
        }

        class Grammar
        {
            public string atom;
            public double angle;
            public Dictionary<char, string> rules = new Dictionary<char, string>();
        }

        private void loadGrammar(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                string[] firstLineItems = lines[0].Split(' ');
                Grammar grammar = new Grammar();
                grammar.atom = firstLineItems[0];
                grammar.angle = double.Parse(firstLineItems[1].Replace('.', ','));

                foreach (var line in lines.Skip(1))
                {
                    string[] lineItems = line.Split(' ');
                    grammar.rules.Add(lineItems[0][0], lineItems[2]);
                }

                currentGrammar = grammar;
            }
            catch (Exception)
            {
                currentGrammar = null;
                MessageBox.Show("invalid file", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.CurrentDirectory.Replace("bin\\Debug", "") + "LSys\\examples";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = dialog.FileName;
                fileNameLabel.Text = Path.GetFileName(selectedFile);
                iterationsCountBox.Value = 1;
                loadGrammar(selectedFile);
                drawFractals();
            }
        }

        private PointF getNewPoint(PointF prevPoint, double angle, double lineSize)
        {
            angle *= Math.PI / 180.0;
            float deltaX = (float)(lineSize * Math.Cos(angle));
            float deltaY = (float)(lineSize * Math.Sin(angle));
            return new PointF(prevPoint.X + deltaX, prevPoint.Y - deltaY);
        }

        private void drawFractals()
        {
            if (currentGrammar == null)
                return;
            int depth = (int)iterationsCountBox.Value;
            string currentValue = currentGrammar.atom;
            for (int curDepth = 0; curDepth < depth; curDepth++)
            {
                //применяем правила
                string oldCurrentValue = currentValue;
                currentValue = "";
                for (int i = 0; i < oldCurrentValue.Length; i++)
                {
                    if (currentGrammar.rules.ContainsKey(oldCurrentValue[i]))
                        currentValue += currentGrammar.rules[oldCurrentValue[i]];
                    else
                        currentValue += oldCurrentValue[i];
                }
            }

            // рисуем по полученной строке
            List<PointF> points = new List<PointF>();
            List<PointF> pointsNoLines = new List<PointF>();
            PointF lastPoint = new PointF(0, 0);
            points.Add(new PointF(0, 0));
            double currentAngle = 0;
            // чтобы оставлять размер ломаных постоянным и компенсировать их рост на каждом шаге
            double lineSize = 200.0 / Math.Pow(Math.Log(200, 9), depth - 1);

            //стек точек и углов
            Stack<Tuple<PointF, double>> _stack = new Stack<Tuple<PointF, double>>();

            for (int i = 0; i < currentValue.Length; i++)
            {
                char c = currentValue[i];
                switch (c)
                {
                    case '-':
                        currentAngle += currentGrammar.angle;
                        break;
                    case '+':
                        currentAngle -= currentGrammar.angle;
                        break;
                    case '[':
                        _stack.Push(new Tuple<PointF, double>(lastPoint, currentAngle));
                        break;
                    case ']':
                        var settings = _stack.Pop();
                        lastPoint = settings.Item1;
                        points.Add(lastPoint);
                        pointsNoLines.Add(lastPoint);
                        currentAngle = settings.Item2;
                        break;
                    case 'F':
                        {
                            PointF newPoint = getNewPoint(lastPoint, currentAngle, lineSize);
                            if (Math.Round(lastPoint.X) == Math.Round(newPoint.X) && Math.Round(lastPoint.Y) == Math.Round(newPoint.Y))
                            {
                                lastPoint = newPoint;
                                continue;
                            }
                            points.Add(newPoint);
                            lastPoint = newPoint;
                            break;
                        }
                }
            }

            double xMin = points.Select(point => point.X).Min();
            double yMin = points.Select(point => point.Y).Min();
            double xMax = points.Select(point => point.X).Max();
            double yMax = points.Select(point => point.Y).Max();

            double kZoomX = (fractalsArea.Width - 10) * 1.0 / (xMax - xMin);
            double kZoomY = (fractalsArea.Height - 10) * 1.0 / (yMax - yMin);
            double kZoom = Math.Min(kZoomX, kZoomY);

            //сдвигаем и масштабируем
            for (int i = 0; i < points.Count; i++)
                points[i] = new PointF((float)((points[i].X - xMin) * kZoom + 5), (float)((points[i].Y - yMin) * kZoom + 5));

            Image fractalImage;
            fractalImage = new Bitmap((int)((xMax - xMin) * kZoom + 10), (int)((yMax - yMin) * kZoom + 10));

            Graphics g = Graphics.FromImage(fractalImage);

            for (int i = 1; i < points.Count; i++)
                if (!pointsNoLines.Contains(points[i - 1])) g.DrawLine(drawingPen, points[i - 1], points[i]); //рисуем линии
            fractalsArea.Image = fractalImage;
            g.Dispose();
        }

        private void iterationsCountBox_ValueChanged(object sender, EventArgs e)
        {
            drawFractals();
        }
    }
}
