using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace sn
{
    /// <summary>
    /// Логика взаимодействия для snake.xaml
    /// </summary>
    public partial class snake : Window

    {

        private int _width = 500;
        private int _height = 500; 
        Point[] p; //координаты 
        Point Apple; 
        int direction; // 1 лево 2 право 3 вверх 4 вниз 
        int len; //длина червя 
        private List<Ellipse> snakeBody = new List<Ellipse>();

        public snake()
        {
            this.Width = _width;
            this.Height = _height; 
            InitializeComponent();
            p = new Point[150];
            len = 10;
            for (int i = 0; i < 5; i++)
            {
                p[i].X = 100;
                p[i].Y = 100 + i * 10;
            }


        }

        private void panel1_Paint(object sender PaintEventArgs e)
        {
            for (int i = 149; i >= 0; i--)
            {
                p[i + 1].X = p[i].X;
                p[i + 1].Y = p[i].Y;
            }
            if (direction == 1)
            {
                p[0].X = p[1].X - 10;
                p[0].Y = p[1].Y;
            }
            if (direction == 2)
            {
                p[0].X = p[1].X + 10;
                p[0].Y = p[1].Y;
            }
            if (direction == 3)
            {
                p[0].X = p[1].X;
                p[0].Y = p[1].Y - 10;
            }
            if (direction == 4)
            {
                p[0].X = p[1].X;
                p[0].Y = p[1].Y + 10;
            }

            SolidColorBrush b = new SolidColorBrush(Color.Blue); //шутка мем 
            for (int i = 0; i<len; i++)
            {
                e.Graphics.FillEllipse(b, p[i].X, p[i].Y, 10, 10); 
            }


            SolidColorBrush b1 = new SolidColorBrush(Color.Red);// одной прграмме работает, в этой нет 
            e.Graphics.FillEllipse(b1, Apple.X, Apple.Y, 10, 10); 

            if (p[0].X == Apple.X&& p[0].Y ==Apple.Y)
            {
                len++;
                Random R;
                R = new Random();
                Apple.X = R.Next(0, 50) * 10;
                Apple.Y = R.Next(0, 50) * 10;
            }
            
            public void gr_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Left)
                    direction = 1;
                if (e.KeyCode == Keys.Right)
                    direction = 2;
                if (e.KeyCode == Keys.Up)
                    direction = 3;
                if (e.KeyCode == Keys.Down)
                    direction = 4;
            }

            Apple.X = 10;
            Apple.Y = 10; 
    }

    } 
}
