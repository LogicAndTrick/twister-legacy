/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 10/08/2008
 * Time: 11:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Description of Plane.
	/// </summary>
	public class Plane
	{
		Coordinate point1;
		Coordinate point2;
		Coordinate point3;
		Coordinate normal;
		// ax + by + cz + d = 0;
		float a;
		float b;
		float c;
		float d;
		public Plane(Coordinate p1, Coordinate p2, Coordinate p3)
		{
			point1 = p1;
			point2 = p2;
			point3 = p3;
			Coordinate xvals = new Coordinate(p1.getX(),p2.getX(),p3.getX());
			Coordinate yvals = new Coordinate(p1.getY(),p2.getY(),p3.getY());
			Coordinate zvals = new Coordinate(p1.getZ(),p2.getZ(),p3.getZ());
			Matrix3 eq = new Matrix3();
			eq.setColumn(0,new Coordinate(1,1,1));
			eq.setColumn(1,yvals);
			eq.setColumn(2,zvals);
			a = eq.determinant();
			eq.setColumn(0,xvals);
			eq.setColumn(1,new Coordinate(1,1,1));
			eq.setColumn(2,zvals);
			b = eq.determinant();
			eq.setColumn(1,yvals);
			eq.setColumn(2,new Coordinate(1,1,1));
			c = eq.determinant();
			eq.setColumn(2,zvals);
			d = -1 * eq.determinant();
			normal = new Coordinate(a,b,c);
			float len = (float)Math.Sqrt(Math.Pow(normal.getX(),2) + Math.Pow(normal.getY(),2) + Math.Pow(normal.getZ(),2));
			if (len == 0) len = 1;
			normal = normal / -len;
		}
		
		public Coordinate getNormal()
		{
			return normal;
		}
		
		public bool containsCorner(Coordinate co)
		{
			bool con = false;
			if (co.Equals(point1)) con = true;
			if (co.Equals(point2)) con = true;
			if (co.Equals(point3)) con = true;
			return con;
		}
		
		public Coordinate getCoordinate(int i)
		{
			if (i == 1) return point1.Clone();
			if (i == 2) return point2.Clone();
			if (i == 3) return point3.Clone();
			return new Coordinate(0,0,0);
		}
		
		public int onPlane(Coordinate co)
		{
			//eval (s = Ax + By + Cz + D) at point (x,y,z)
			//if s > 0 then point is "above" the plane (same side as normal)
			//if s < 0 then it lies on the opposite side
			//if s = 0 then the point (x,y,z) lies on the plane
			//NOTE: should i be worrying about deltas and rounding? i hope not.
			return (int)Math.Round(a * co.getX() + b * co.getY() + c * co.getZ() + d);
		}
		
		public override string ToString()
		{
			return point1.ToString() + " " + point2.ToString() + " " + point3.ToString();
		}
		
		public string ToString(bool b)
		{
			return "( " + point1.ToString(b) + " ) ( " + point2.ToString(b) + ") (" + point3.ToString(b) + " )";
		}
	}
}
