using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace robot
{
	public abstract class Robot
	{
		public Point location, destination;
		public List<Point> points=new List<Point>();

		public abstract void Move();
		public abstract void GetTarget();

		public virtual void Draw(DrawingContext dc)
		{
			dc.DrawEllipse(Brushes.DarkMagenta, new Pen(Brushes.Black, 1), new Point(location.X * Engine.length - Engine.length / 2, location.X * Engine.length - Engine.length / 2), Engine.length / 2, Engine.length / 2);
		}
	}
	public class Tester : Robot
	{
		public override void GetTarget()
		{
			throw new NotImplementedException();
		}

		public override void Move()
		{
			throw new NotImplementedException();
		}
	}
}
