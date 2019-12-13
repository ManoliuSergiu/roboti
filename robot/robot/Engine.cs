using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace robot
{
	static class Engine
	{
		public static Canvas canvas;
		public static int n, m, length;
		public static int[,] map;
		public static Tile[,] tiles;
		public static Random rnd = new Random();
		public static List<Robot> robots = new List<Robot>();
		public static void Init(Canvas canvas)
		{
			Engine.canvas = canvas;
			length = 20;
			n =(int) canvas.Width / length;
			m =(int) canvas.Height / length;
			map = new int[n, m];
			tiles = new Tile[n, m];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					tiles[i, j] = new Tile(i, j);
			for (int i = 0; i < 150; i++)
			{
				int x = rnd.Next(n), y = rnd.Next(m);
				map[x, y] = -1;
			}
			DrawingGroup dg = new DrawingGroup();
			using (DrawingContext dc = dg.Open())
			{
				dc.DrawRectangle(Brushes.ForestGreen, new Pen(Brushes.Black, 1), new Rect(0, 0, canvas.Width, canvas.Height));
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < m; j++)
					{
						tiles[i, j].DrawTile(dc);
					}
				}
			}
			DrawingImage di = new DrawingImage(dg);
			Image a = new Image();
			a.Source = di;
			canvas.Children.Add(a);
			canvas.Children.Add(a);

		}
		public static int DrawMap()
		{
			DrawingGroup dg = new DrawingGroup();
			using (DrawingContext dc = dg.Open())
			{
				foreach (var robot in robots)
				{
					robot.Draw(dc);
				}
			}
			DrawingImage di = new DrawingImage(dg);
			Image a = new Image();
			a.Source = di;
			canvas.Children[1] = a;
		}
		public static int Dist(Point a, Point b)
		{
			return (int)(Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y));
		}
	}
}
