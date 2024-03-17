/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 31/07/2008
 * Time: 7:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Description of Brush.
	/// </summary>
	public class Brush
	{
		int brushnumber;
		int numsides;
		int currentside;
		System.Collections.Generic.List<Coordinate> corners;
		Side[] sides;
		
		public Brush(int n)
		{
			numsides = n;
			sides = new Side[n];
			for (int i = 0; i < n; i++) {
				sides[i] = new Side();
			}
			currentside = 0;
			corners = new System.Collections.Generic.List<Coordinate>();
		}
		
		public bool isValid()
		{
			bool v = true;
			foreach (Side s in sides) if (!s.isValid()) v = false;
			return v;
		}
		
		public void addSide(Side s)
		{
			s.setID(currentside+1);
			sides[currentside] = s;
			currentside++;
		}
		
		public System.Collections.Generic.List<Coordinate> getCorners()
		{
			System.Collections.Generic.List<Coordinate> nl = new System.Collections.Generic.List<Coordinate>();
			foreach (Coordinate c in corners.ToArray()) nl.Add(c);
			return nl;
		}
		
		public bool isCorner (Coordinate c)
		{
			return (corners.Contains(c));
		}
		
		public void addCorner(Coordinate c)
		{
			if (isCorner(c)) return;
			corners.Add(c);
		}
		
		public void setID(int id)
		{
			brushnumber = id;
		}
		
		public int getID()
		{
			return brushnumber;
		}
		
		/*
		solid
		{
			"id" "2"
			side
			{
				"id" "3"
				"plane" "(0 0 0) (0 128 8) (64 128 2)"
				"material" "CONCRETE/CONCRETEFLOOR005A"
				"uaxis" "[1 0 0 0] 0.25"
				"vaxis" "[0 -1 0 0] 0.25"
				"rotation" "0"
				"lightmapscale" "16"
				"smoothing_groups" "0"
			}
			...
			editor
			{
				"color" "0 173 190"
				"visgroupshown" "1"
				"visgroupautoshown" "1"
			}
		}
		*/
		/*
		{
		( 256 0 0 ) ( 251 50 0 ) ( 314 62 0 ) AAATRIGGER [ 1 0 0 0 ] [ 0 -1 0 0 ] 0 1 1 
		( 251 50 0 ) ( 274 37 -10 ) ( 314 62 0 ) AAATRIGGER [ 0 1 0 0 ] [ 0 0 -1 0 ] 0 1 1 
		( 314 62 0 ) ( 274 37 -10 ) ( 256 0 0 ) AAATRIGGER [ 0 1 0 0 ] [ 0 0 -1 0 ] 0 1 1 
		( 251 50 0 ) ( 256 0 0 ) ( 274 37 -10 ) AAATRIGGER [ 1 0 0 0 ] [ 0 0 -1 0 ] 0 1 1 
		}
		*/
		
		public string toMap()
		{
			if (!isValid()) return "";
			string str = "";
			str += "{\r\n";
			foreach (Side s in sides) str += s.toMap();
			str += "}\r\n";
			return str;
		}
		
		private string sidesToString()
		{
			string str = "";
			foreach (Side s in sides) str += s.ToString();
			return str;
		}
		
		public override string ToString()
		{
			if (!isValid()) return "";
			string str = "";
			str +=
				"	solid\r\n" +
				"	{\r\n" +
				"		\"id\" \"" + brushnumber + "\"\r\n" +
				sidesToString() +
				"		editor\r\n" +
				"		{\r\n" +
				"			\"color\" \"0 173 190\"\r\n" +
				"			\"visgroupshown\" \"1\"\r\n" +
				"			\"visgroupautoshown\" \"1\"\r\n" +
				"		}\r\n" +
				"	}\r\n";
			return str;
		}
	}
}
