using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace robot
{
	class Utils
	{
		public static List<Point> FindPath(int[,] m, Point start, Point final)
		{
			List<Point> path = new List<Point>();
			//m are doar 0 si -1
			int sx = (int)start.X, sy = (int)start.Y;
			int fx = (int)final.X, fy = (int)final.Y;
			Queue A = new Queue();
			A.Push(new Node(sx, sy, 1));
			
			m[(int)start.X, (int)start.Y] = 1;

			while (A.n != 0)
			{
				Node crt = A.Pop();
				if (crt.i - 1 >= 0 && m[crt.i - 1, crt.j] == 0)
				{
					A.Push(new Node(crt.i - 1, crt.j, crt.value + 1));
					m[crt.i - 1, crt.j] = crt.value + 1;
				}
				if (crt.i + 1 < Engine.n && m[crt.i + 1, crt.j] == 0)
				{
					A.Push(new Node(crt.i + 1, crt.j, crt.value + 1));
					m[crt.i + 1, crt.j] = crt.value + 1;
				}
				if (crt.j - 1 >= 0 && m[crt.i, crt.j - 1] == 0)
				{
					A.Push(new Node(crt.i, crt.j - 1, crt.value + 1));
					m[crt.i, crt.j - 1] = crt.value + 1;
				}
				if (crt.j + 1 < Engine.m && m[crt.i, crt.j + 1] == 0)
				{
					A.Push(new Node(crt.i, crt.j + 1, crt.value + 1));
					m[crt.i, crt.j + 1] = crt.value + 1;
				}
			}

			if (m[fx, fy] == 0)
				return null;
			Node current = new Node(fx, fy, m[fx, fy]);
			path.Add(final);

			while (current.value > 1)
			{
				if (current.i - 1 >= 0 && m[current.i - 1, current.j] == current.value - 1)
				{
					path.Add(new Point(current.i - 1, current.j));
					current.i--;
				}
				else if (current.i + 1 < Engine.n && m[current.i + 1, current.j] == current.value - 1)
				{
					path.Add(new Point(current.i + 1, current.j));
					current.i++;
				}
				else if (current.j - 1 >= 0 && m[current.i, current.j - 1] == current.value - 1)
				{
					path.Add(new Point(current.i, current.j - 1));
					current.j--;
				}
				else if (current.j + 1 < Engine.m && m[current.i, current.j + 1] == current.value - 1)
				{
					path.Add(new Point(current.i, current.j + 1));
					current.j++;
				}
				current.value--;
			}

			return path;
		}
	}
}
