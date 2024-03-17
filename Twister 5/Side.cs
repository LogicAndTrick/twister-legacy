/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 3/08/2008
 * Time: 2:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Description of Side.
	/// </summary>
	public class Side
	{
		protected int id;
		protected Coordinate[] points;
		protected Plane plane;
		protected string material;
		protected Vector4 uaxis;
		protected float uscale;
		protected Vector4 vaxis;
		protected float vscale;
		protected float rotation;
		protected int lightmapscale;
		protected int smoothinggroups;
		protected bool valid;
		
		public Side()
		{
			id = 1;
			material = "CONCRETE/CONCRETEFLOOR005A";
			uaxis = new Vector4();
			plane = new Plane(new Coordinate(0,0,0),new Coordinate(0,0,0),new Coordinate(0,0,0));
			uscale = 0.25f;
			vaxis = new Vector4();
			vscale = 0.25f;
			rotation = 0;
			lightmapscale = 16;
			smoothinggroups = 0;
			valid = true;
		}
		
		public bool isValid()
		{
			return valid;
		}
		
		public string sideType()
		{
			return "side";
		}
		
		public void setID(int i)
		{
			id = i;
		}
		
		public void setCorners(Coordinate[] corners)
		{
			points = corners;
		}
		
		public void setPlane(Plane p)
		{
			plane = p;
		}
		
		public void setMaterial(string mat)
		{
			material = mat;
		}
		
		public void setUAxis(Vector4 v)
		{
			uaxis = v;
		}
		
		public void setUScale(float s)
		{
			uscale = s;
		}
		
		public void setVAxis(Vector4 v)
		{
			vaxis = v;
		}
		
		public void setVScale(float s)
		{
			vscale = s;
		}
		
		public void setRotation(float r)
		{
			rotation = r;
		}
		
		public void setLightmapScale(int l)
		{
			lightmapscale = l;
		}
		
		public void setSmoothingGroups(int g)
		{
			smoothinggroups = g;
		}
		
		public string toMap()
		{
			//( 251 50 0 ) ( 256 0 0 ) ( 274 37 -10 ) AAATRIGGER [ 1 0 0 0 ] [ 0 0 -1 0 ] 0 1 1 
			string str = "";
			string mat = "AAATRIGGER";
			if (material.Contains("NODRAW")) mat = "NULL";
			str += plane.ToString(true) + " " + mat + " " + uaxis.ToString(true) + " " + vaxis.ToString(true) + " 0 1 1 \r\n";
			return str;
		}
		
		protected string topSideToString()
		{
			string str = "";
			str +=
				"		side\r\n" +
				"		{\r\n" +
				"			\"id\" \"" + id + "\"\r\n" +
				"			\"plane\" \"" + plane.ToString() + "\"\r\n" +
				"			\"material\" \"" + material + "\"\r\n" +
				"			\"uaxis\" \"" + uaxis.ToString() + " " + uscale + "\"\r\n" +
				"			\"vaxis\" \"" + vaxis.ToString() + " " + vscale + "\"\r\n" +
				"			\"rotation\" \"" + rotation + "\"\r\n" +
				"			\"lightmapscale\" \"" + lightmapscale + "\"\r\n" +
				"			\"smoothing_groups\" \"" + smoothinggroups + "\"\r\n";
			return str;
		}
		
		protected string bottomSideToString()
		{
			return "		}\r\n";
		}
		
		public override string ToString()
		{
			return topSideToString() + bottomSideToString();
		}
	}
}
