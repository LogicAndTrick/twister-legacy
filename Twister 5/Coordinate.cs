/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 3/08/2008
 * Time: 3:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Description of Coordinate.
	/// </summary>
	public class Coordinate
	{
		float xval;
		float yval;
		float zval;
		
		public Coordinate(float x, float y, float z)
		{
			xval = x;
			yval = y;
			zval = z;
		}
		
		public bool Equals(Coordinate c)
		{
			bool equal = true;
			if (Math.Abs(c.getX()-xval) > 0.5) equal = false;
			if (Math.Abs(c.getY()-yval) > 0.5) equal = false;
			if (Math.Abs(c.getZ()-zval) > 0.5) equal = false;
			return equal;
		}
		
		public float getX()
		{
			return xval;
		}
		
		public void setX(float x)
		{
			xval = x;
		}
		
		public float getY()
		{
			return yval;
		}
		
		public void setY(float y)
		{
			yval = y;
		}
		
		public float getZ()
		{
			return zval;
		}
		
		public void setZ(float z)
		{
			zval = z;
		}
		
		public Coordinate round()
		{
			return new Coordinate((float)Math.Round(xval,4),(float)Math.Round(yval,4),(float)Math.Round(zval,4));
		}
		
		public Coordinate round(int num)
		{
			return new Coordinate((float)Math.Round(xval,num),(float)Math.Round(yval,num),(float)Math.Round(zval,num));
		}
		
		public float vectorMagnitude()
		{
			return (float)Math.Sqrt(Math.Pow(xval,2) + Math.Pow(yval,2) + Math.Pow(zval,2));
		}
		
		public static Coordinate operator +(Coordinate c1,Coordinate c2)
		{
			return new Coordinate(c1.getX()+c2.getX(),c1.getY()+c2.getY(),c1.getZ()+c2.getZ());
		}
		
		public static Coordinate operator -(Coordinate c1,Coordinate c2)
		{
			return new Coordinate(c1.getX()-c2.getX(),c1.getY()-c2.getY(),c1.getZ()-c2.getZ());
		}
		
		public static Coordinate operator /(Coordinate c,float f)
		{
			if (f == 0) return new Coordinate(0,0,0);
			return new Coordinate(c.getX()/f,c.getY()/f,c.getZ()/f);
		}
		
		public static Coordinate operator *(Coordinate c,float f)
		{
			return new Coordinate(c.getX()*f,c.getY()*f,c.getZ()*f);
		}
		
		public string ToString(bool a)
		{
			return xval + " " + yval + " " + zval;
		}
		
		public override string ToString()
		{
			return "(" + xval + " " + yval + " " + zval + ")";
		}
		
		public Coordinate Clone()
		{
			return new Coordinate(xval,yval,zval);
		}
	}
}
