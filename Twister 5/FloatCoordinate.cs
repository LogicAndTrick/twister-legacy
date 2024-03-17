/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 5/09/2008
 * Time: 9:45 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Description of FloatCoordinate.
	/// </summary>
	public class FloatCoordinate
	{
		float xval;
		float yval;
		float zval;
		
		public FloatCoordinate(float x, float y, float z)
		{
			xval = x;
			yval = y;
			zval = z;
		}
		
		public bool Equals(FloatCoordinate c)
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
		
		public float dot(FloatCoordinate c)
		{
			return ((this.xval * c.xval) + (this.yval * c.yval) + (this.zval * c.zval));
		}
		
		public FloatCoordinate cross(FloatCoordinate that)
		{
			float xv = (this.yval * that.zval) - (this.zval * that.yval);
			float yv = -1 * ((this.xval * that.zval) - (this.zval * that.xval));
			float zv = (this.xval * that.yval) - (this.yval * that.xval);
			FloatCoordinate res =  new FloatCoordinate(xv,yv,zv);
			return res;
		}
		
		public FloatCoordinate round()
		{
			return new FloatCoordinate((float)Math.Round(xval,4),(float)Math.Round(yval,4),(float)Math.Round(zval,4));
		}
		
		public FloatCoordinate round(int num)
		{
			return new FloatCoordinate((float)Math.Round(xval,num),(float)Math.Round(yval,num),(float)Math.Round(zval,num));
		}
		
		public float vectorMagnitude()
		{
			return (float)Math.Sqrt(Math.Pow(xval,2) + Math.Pow(yval,2) + Math.Pow(zval,2));
		}
		
		public FloatCoordinate normalise()
		{
			float len = this.vectorMagnitude();
			return new FloatCoordinate(xval/len,yval/len,zval/len);
		}
		
		public static bool operator ==(FloatCoordinate c1,FloatCoordinate c2)
		{
			return (c1.xval == c2.xval) && (c1.yval == c2.yval) && (c1.zval == c2.zval);
		}
		
		public static bool operator !=(FloatCoordinate c1,FloatCoordinate c2)
		{
			return (c1.xval != c2.xval) || (c1.yval != c2.yval) || (c1.zval != c2.zval);
		}
		
		public override bool Equals(object obj)
		{
			if (obj is FloatCoordinate) return (this == (FloatCoordinate)obj);
			return base.Equals(obj);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public static FloatCoordinate operator +(FloatCoordinate c1,FloatCoordinate c2)
		{
			return new FloatCoordinate(c1.getX()+c2.getX(),c1.getY()+c2.getY(),c1.getZ()+c2.getZ());
		}
		
		public static FloatCoordinate operator -(FloatCoordinate c1,FloatCoordinate c2)
		{
			return new FloatCoordinate(c1.getX()-c2.getX(),c1.getY()-c2.getY(),c1.getZ()-c2.getZ());
		}
		
		public static FloatCoordinate operator -(FloatCoordinate c1)
		{
			return new FloatCoordinate(-c1.getX(),-c1.getY(),-c1.getZ());
		}
		
		public static FloatCoordinate operator /(FloatCoordinate c,float f)
		{
			if (f == 0) return new FloatCoordinate(0,0,0);
			return new FloatCoordinate(c.getX()/f,c.getY()/f,c.getZ()/f);
		}
		
		public static FloatCoordinate operator *(FloatCoordinate c,float f)
		{
			return new FloatCoordinate(c.getX()*f,c.getY()*f,c.getZ()*f);
		}
		
		public static FloatCoordinate operator *(float f,FloatCoordinate c)
		{
			return c * f;
		}
		
		public string ToString(bool a)
		{
			return xval + " " + yval + " " + zval;
		}
		
		public override string ToString()
		{
			return "(" + xval + " " + yval + " " + zval + ")";
		}
		
		public FloatCoordinate Clone()
		{
			return new FloatCoordinate(xval,yval,zval);
		}
	}
}
