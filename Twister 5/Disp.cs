/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 3/08/2008
 * Time: 3:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Holds a displacement with info about the position of each point as well as its properties.
	/// Also prints to VMF, VMF (brushwork), and MAP.
	/// </summary>
	public class Disp : Side
	{
		/*
		dispinfo
		{
		      "power" "2"
		      "startposition" "[-512 -512 0]"
		      "elevation" "0"
		      "subdiv" "0"
		      normals{}
		      distances{}
		      offsets{}
		      offset_normals{}
		      alphas{}
		      triangle_tags{}
		      allowed_verts{}
		}
		*/
		
		Coordinate[] dispcorners;
		
		int power;
		Coordinate startposition;
		int elevation;
		int subdiv;
		Coordinate[,] disppoints;
		float[,] alphas;
		int[,] tritags;
		
		//constructor
		public Disp(int p, Coordinate sp)
		{
			dispcorners = new Coordinate[4];
			power = p;
			startposition = sp;
			int r = getResolution()+1;
			disppoints = new Coordinate[r,r];
			alphas = new float[r,r];
			tritags = new int[(int)(Math.Pow(2,power+1)),r];
			for (int i = 0; i < r; i++) {
				for (int j = 0; j < r; j++) {
					disppoints[i,j] = new Coordinate(0,0,0);
				}
			}
		}
		
		// *******************************************************
		//
		// SETTERS AND GETTERS
		// FUNCTIONS TO MANIPULATE THE DISPLACMENT BEFORE IT IS PRINTED
		//
		// *******************************************************
		new public string sideType()
		{
			return "disp";
		}
		
		public void addLastCorner(Coordinate c)
		{
			//now we have the fourth, unspecified corner
			//get all our corners
			Coordinate[] v = {plane.getCoordinate(1),plane.getCoordinate(2),plane.getCoordinate(3),c};
			//v is in clockwise order
			//but we want some kind of standard
			//so we put the corners into standard positions
			//where dispcorners[0] = starting position
			//then work clockwise from there
			//imagine that the numbers are the   1 2
			//four corners of the displacement:  0 3
			//first, here is the insurance policy:
			bool matched = false;
			for (int i = 0; i < 4; i++) {
				if (v[i].Equals(startposition)) {
					//we have a match, we don't need to use insurance
					matched = true;
					dispcorners[0] = v[i];
					dispcorners[1] = v[(i+1)%4];
					dispcorners[2] = v[(i+2)%4];
					dispcorners[3] = v[(i+3)%4];
				}
			}
			//now we should have a "standardised" displacement.
			//but just in case, we'll throw an error message when no corners match.
			if (!matched) {
				System.Windows.Forms.MessageBox.Show("What did you do?! There's an error in one of your displacements.\nIf this is a valid VMF (i.e. saved by Hammer) send it to me ASAP!","OH NOES");
				//fuck, what's going on?
				System.Windows.Forms.MessageBox.Show(v[0].ToString() + "\n" +
				                                     v[1].ToString() + "\n" +
				                                     v[2].ToString() + "\n" +
				                                     v[3].ToString() + "\n" +
				                                     startposition.ToString());
			}
			//now i lose my no-claim bonus :(
			//aaaaaaanyway. let's just set the standard points :)
			if (matched) setStandardPoints();
		}
		
		public void setElevation(int e)
		{
			elevation = e;
		}
		
		public Coordinate getElevatedOffset()
		{
			return (plane.getNormal() * elevation);
		}
		
		public void setSubdiv(int s)
		{
			subdiv = s;
		}
		
		public int getResolution()
		{
			return (int)Math.Pow(2,power);
		}
		
		public void setPoint(int row, int column, Coordinate c)
		{
			try {
				disppoints[row,column] = c;
			}
			catch (Exception e) {
				System.Windows.Forms.MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void addToPoint(int row, int column, Coordinate c)
		{
			try {
				setPoint(row, column, disppoints[row,column] + c);
			}
			catch (Exception e) {
				System.Windows.Forms.MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public void vectorToSetPoint(int row, int column, float dist, float[] norm, float[] offs)
		{
			if (norm.Length != 3) return;
			if (norm[0] == 0 && norm[1] == 0 && norm[2] == 0) norm = offs;
			//normalise the vector
			float len = (float)Math.Sqrt(Math.Pow(norm[0],2) + Math.Pow(norm[1],2) + Math.Pow(norm[2],2));
			if (len == 0) len = 1;
			for (int i = 0; i < 3; i++) norm[i] = norm[i] / len;
			//now we have a normalised vector
			float xd = (norm[0] * dist) + getStandardPoint(row,column).getX();
			float yd = (norm[1] * dist) + getStandardPoint(row,column).getY();
			float zd = (norm[2] * dist) + getStandardPoint(row,column).getZ();
			Coordinate c = new Coordinate(xd,yd,zd);
			if (c.ToString(true) == "NaN NaN NaN") System.Windows.Forms.MessageBox.Show(len.ToString());
			setPoint(row,column,c);
		}
		
		public void setStandardPoints()
		{
			int r = getResolution()+1;
			for (int i = 0; i < r; i++) {
				for (int j = 0; j < r; j++) {
					disppoints[i,j] = getStandardPoint(i,j);
				}
			}
		}
		
		public Coordinate getStandardPoint(int row, int column)
		{
			//DISPLACEMENT MUST BE STANDARDISED BEFORE USING THIS FUNCTION
			//alrighty then, let's get this thing started.
			//find the column line using the corners
			//first find the first point of the column
			/*float ax = dispcorners[2].getX() - dispcorners[1].getX();
			float ay = dispcorners[2].getY() - dispcorners[1].getY();
			float az = dispcorners[2].getZ() - dispcorners[1].getZ();
			ax *= column / getResolution();
			ay *= column / getResolution();
			az *= column / getResolution();
			ax += dispcorners[1].getX();
			ay += dispcorners[1].getY();
			az += dispcorners[1].getZ();*/
			//bleurgh. let's see what we can do to improve on that.
			float ax = ((dispcorners[2].getX() - dispcorners[1].getX()) * column / getResolution()) + dispcorners[1].getX();
			float ay = ((dispcorners[2].getY() - dispcorners[1].getY()) * column / getResolution()) + dispcorners[1].getY();
			float az = ((dispcorners[2].getZ() - dispcorners[1].getZ()) * column / getResolution()) + dispcorners[1].getZ();
			//hooray! that's a bit better now isn't it?
			//let's so the same for the other point.
			float bx = ((dispcorners[3].getX() - dispcorners[0].getX()) * column / getResolution()) + dispcorners[0].getX();
			float by = ((dispcorners[3].getY() - dispcorners[0].getY()) * column / getResolution()) + dispcorners[0].getY();
			float bz = ((dispcorners[3].getZ() - dispcorners[0].getZ()) * column / getResolution()) + dispcorners[0].getZ();
			//now that we have a line defined by two points, let's do the same thing with it.
			float cx = ((ax - bx) * row / getResolution()) + bx;
			float cy = ((ay - by) * row / getResolution()) + by;
			float cz = ((az - bz) * row / getResolution()) + bz;
			//phew! that was a real pain in the ass. you think it works?
			return new Coordinate(cx,cy,cz);
		}
		
		// *******************************************************
		//
		// TOSTRING FUNCTIONS FOR DISPLACEMENT VMF
		// WILL OUTPUT THE DISPLACEMENT AS A VMF IN DISPLACEMENT MODE
		//
		// *******************************************************
		public override string ToString()
		{
			return topSideToString() + dispToString() + bottomSideToString();
		}
		
		public string dispToString()
		{
			string str = "";
			str +=
				"			dispinfo\r\n" +
				"			{\r\n" +
				"				\"power\" \"" + power + "\"\r\n" +
				"				\"startposition\" \"[" + startposition.ToString(true) + "]\"\r\n" +
				"				\"flags\" \"0\"\r\n" +
				"				\"elevation\" \"" + elevation + "\"\r\n" +
				"				\"subdiv\" \"" + subdiv + "\"\r\n" +
				normalsToString() +
				distancesToString() +
				offsetsToString() +
				offsetNormalsToString() +
				alphasToString() +
				triangleTagsToString() +
				allowedVertsToString() +
				"			}\r\n";
			return str;
		}
		
		private string normalsToString()
		{
			string str = "";
			str += "				normals\r\n				{\r\n";
			for (int i = 0; i <= getResolution(); i++)
			{
				str += "					\"row" + i + "\" \"";
				for (int j = 0; j <= getResolution(); j++)
				{
					str += normalsAt(i,j) + " ";
				}
				str = str.Substring(0,str.Length-1);
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private string normalsAt(int row, int column)
		{
			// az = relative zero
			Coordinate az = getStandardPoint(row,column);
			// ao = absolute offset
			Coordinate ao = disppoints[row,column];
			// ro = relative offset
			Coordinate ro = ao - az;
			// get distance
			float dist = ro.vectorMagnitude();
			//get normals
			Coordinate n = ((Coordinate)(ro / dist)).round();
			// format normals
			return n.ToString(true);
		}
		
		private string distancesToString()
		{
			string str = "";
			str += "				distances\r\n				{\r\n";
			for (int i = 0; i <= getResolution(); i++)
			{
				str += "					\"row" + i + "\" \"";
				for (int j = 0; j <= getResolution(); j++)
				{
					str += distanceAt(i,j) + " ";
				}
				str = str.Substring(0,str.Length-1);
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private float distanceAt(int row, int column)
		{
			// az = relative zero
			Coordinate az = getStandardPoint(row,column);
			// ao = absolute offset
			Coordinate ao = disppoints[row,column];
			// ro = relative offset
			Coordinate ro = ao - az;
			// get distance
			return ro.vectorMagnitude();
		}
		
		private string offsetsToString()
		{
			string str = "";
			str += "				offsets\r\n				{\r\n";
			for (int i = 0; i <= getResolution(); i++)
			{
				str += "					\"row" + i + "\" \"";
				for (int j = 0; j <= getResolution(); j++)
				{
					str += "0 0 0 ";
				}
				str = str.Substring(0,str.Length-1);
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private string offsetNormalsToString()
		{
			string str = "";
			str += "				offset_normals\r\n				{\r\n";
			for (int i = 0; i <= getResolution(); i++)
			{
				str += "					\"row" + i + "\" \"";
				for (int j = 0; j <= getResolution(); j++)
				{
					str += "0 0 1 ";
				}
				str = str.Substring(0,str.Length-1);
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private string alphasToString()
		{
			string str = "";
			str += "				alphas\r\n				{\r\n";
			for (int i = 0; i <= getResolution(); i++)
			{
				str += "					\"row" + i + "\" \"";
				for (int j = 0; j <= getResolution(); j++)
				{
					str += "0 ";
				}
				str = str.Substring(0,str.Length-1);
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private string triangleTagsToString()
		{
			string str = "";
			str += "				triangle_tags\r\n				{\r\n";
			for (int i = 0; i < getResolution(); i++)
			{
				str += "					\"row" + i + "\" \"";
				if (power == 2) str += "0 0 0 0 0 0 0 0"; 
				if (power == 3) str += "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0"; 
				if (power == 4) str += "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0"; 
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private string allowedVertsToString()
		{
			string str = "";
			str += 
				"				allowed_verts\r\n" +
				"				{\r\n" +
				"					\"10\" \"-1 -1 -1 -1 -1 -1 -1 -1 -1 -1\"\r\n" +
				"				}\r\n";
			return str;
		}
		
		// *******************************************************
		//
		// TOSTRING FUNCTIONS FOR BRUSHWORK VMF
		// WILL TURN THE DISPLACEMENT INTO BRUSHWORK AND INSERT INTO MAP
		//
		// *******************************************************
		public string toBrush(ref Map m)
		{
			valid = false;
			m.incDisp();
			return blocksToBrush(ref m);
		}
		
		private string blocksToBrush(ref Map m)
		{
			id = 1;
			string str = "";
			Coordinate elevated_offset = getElevatedOffset();
			for (int i = 0; i < getResolution(); i++) {
				for (int j = 0; j < getResolution(); j++) {
					m.addBrush(triangleToBrush(disppoints[i,j]+elevated_offset,
					                           disppoints[i+1,j]+elevated_offset,
					                           disppoints[i+1,j+1]+elevated_offset));
					m.addBrush(triangleToBrush(disppoints[i,j]+elevated_offset,
					                           disppoints[i+1,j+1]+elevated_offset,
					                           disppoints[i,j+1]+elevated_offset));
				}
			}
			return str;
		}
		
		private Brush triangleToBrush(Coordinate c1, Coordinate c2, Coordinate c3)
		{
			Coordinate c4 = normalPosition(c1,c2,c3);
			Plane p1 = new Plane(c1,c2,c3);
			Plane p2 = new Plane(c1,c3,c4);
			Plane p3 = new Plane(c1,c4,c2);
			Plane p4 = new Plane(c2,c4,c3);
			Side s1 = new Side();
			Side s2 = new Side();
			Side s3 = new Side();
			Side s4 = new Side();
			s1.setPlane(p1);
			s1.setMaterial(material);
			s1.setUAxis(uaxis);
			s1.setUScale(uscale);
			s1.setVAxis(vaxis);
			s1.setVScale(vscale);
			s1.setRotation(rotation);
			s1.setLightmapScale(lightmapscale);
			s1.setSmoothingGroups(smoothinggroups);
			//---
			s2.setPlane(p2);
			s2.setMaterial("TOOLS/TOOLSNODRAW");
			s2.setUAxis(uaxis);
			s2.setUScale(uscale);
			s2.setVAxis(vaxis);
			s2.setVScale(vscale);
			s2.setRotation(rotation);
			s2.setLightmapScale(lightmapscale);
			s2.setSmoothingGroups(smoothinggroups);
			//---
			s3.setPlane(p3);
			s3.setMaterial("TOOLS/TOOLSNODRAW");
			s3.setUAxis(uaxis);
			s3.setUScale(uscale);
			s3.setVAxis(vaxis);
			s3.setVScale(vscale);
			s3.setRotation(rotation);
			s3.setLightmapScale(lightmapscale);
			s3.setSmoothingGroups(smoothinggroups);
			//---
			s4.setPlane(p4);
			s4.setMaterial("TOOLS/TOOLSNODRAW");
			s4.setUAxis(uaxis);
			s4.setUScale(uscale);
			s4.setVAxis(vaxis);
			s4.setVScale(vscale);
			s4.setRotation(rotation);
			s4.setLightmapScale(lightmapscale);
			s4.setSmoothingGroups(smoothinggroups);
			//---
			Brush bsh = new Brush(4);
			bsh.addSide(s1);
			bsh.addSide(s2);
			bsh.addSide(s3);
			bsh.addSide(s4);
			//---
			return bsh;
		}
		
		private Coordinate normalPosition(Coordinate c1, Coordinate c2, Coordinate c3)
		{
			Coordinate center = (c1 + c2 + c3) / 3;
			Coordinate a = c2 - c1;
			Coordinate b = c3 - c1;
			
			float icom = (a.getY() * b.getZ()) - (a.getZ() * b.getY());
			float jcom = ((a.getX() * b.getZ()) - (a.getZ() * b.getX())) * -1;
			float kcom = (a.getX() * b.getY()) - (a.getY() * b.getX());
			
			Coordinate component = new Coordinate(icom,jcom,kcom);
			float len = component.vectorMagnitude();
			
			Coordinate norm = ((Coordinate)(center + (component / len) * 10)).round(2);
			
			return norm;
		}
	}
}
