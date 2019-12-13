using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace robot
{
	class Tile
	{
		int i, j;
		public Tile(int a, int b)
		{
			i = a;
			j = b;
		}
		public void DrawTile(DrawingContext dc)
		{
			Pen penny = new Pen(Brushes.Black, 1);
			if (Engine.map[i,j]==0)
			{
				dc.DrawRectangle(null, penny, new Rect(i * Engine.length, j * Engine.length, Engine.length, Engine.length));
			}
			else
			{
				dc.DrawRectangle(Brushes.Brown, penny, new Rect(i * Engine.length, j * Engine.length, Engine.length, Engine.length));
			}
		}
	}
}
